using MQTT_Protocol.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HMI_Security
{
    public delegate void EventUserChanged(User ch);

    public partial class frm_User : Form
    {
        public EventUserChanged eventUserChanged = null;
        private bool IsDataChanged = false;
        private string connectionString = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=LVTN;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public frm_User()
        {
            InitializeComponent();
        }

        private void frm_User_Load(object sender, EventArgs e)
        {
            try
            {
                txt_Privilege.SelectedIndex = 0;

                string xmlFile = User_Manager.ReadKey(User_Manager.XML_NAME_DEFAULT);
                if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return;
                InitializeUserData(User_Manager.ReadKey(User_Manager.XML_NAME_DEFAULT));
                User_Manager.GetChannels();
                foreach (User tg in User_Manager.Users)
                {
                    string[] row = {string.Format("{0}", tg.UserID), tg.UserName, "****************", string.Format("{0}", tg.Privilege), tg.Role};

                    ListViewItem item = new ListViewItem(row);
                    item.ImageIndex = 0;
                    listView1.Items.Add(item);
                }

                RegenerateRowNumbers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeUserData(string xmlPath)
        {
            User_Manager.Users.Clear();
            User_Manager.XmlPath = xmlPath;
        }

        private void btn_AddUpdate_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txt_UserName.Text) || string.IsNullOrWhiteSpace(txt_UserName.Text))
            {
                errorProvider1.SetError(txt_UserName, "Please fill out the Username.");
                MessageBox.Show("Please fill out the Username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txt_Password.Text) || string.IsNullOrWhiteSpace(txt_Password.Text))
            {
                errorProvider1.SetError(txt_Password, "Please fill out the Password.");
                MessageBox.Show("Please fill out the Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txt_Role.Text) || string.IsNullOrWhiteSpace(txt_Role.Text))
            {
                errorProvider1.SetError(txt_Role, "Please fill out the Role.");
                MessageBox.Show("Please fill out the Role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            errorProvider1.Clear();

            // Check if the UserName already exists in the ListView
            foreach (ListViewItem li in listView1.Items)
            {
                if (li.SubItems[1].Text == txt_UserName.Text)
                {
                    MessageBox.Show("UserName already exists. \nDelete existing UserName or change current UserName.");
                    return;
                }
            }

            // Add new UserName to ListView
            string[] s = new string[5];
            s[1] = txt_UserName.Text;
            s[2] = txt_Password.Text;
            s[3] = txt_Privilege.Text;
            s[4] = txt_Role.Text;

            listView1.Items.Add(new ListViewItem(s));

            RegenerateRowNumbers();

            try
            {
                // Add new UserName to UserManager
                User newTg = new User();
                newTg.UserID = User_Manager.Users.Count + 1;
                newTg.UserName = txt_UserName.Text;
                newTg.PasswordHash = HashPassword(txt_Password.Text);
                newTg.Privilege = int.Parse(txt_Privilege.Text.ToString());
                newTg.Role = txt_Role.Text;

                User_Manager.Add(newTg);

                if (eventUserChanged != null) eventUserChanged(newTg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            IsDataChanged = true;
        }

        private void btn_Delete_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem li in listView1.SelectedItems)
                    {
                        string username = li.SubItems[1].Text;
                        User userCurrent = User_Manager.GetByChannelName(username);
                        User_Manager.Delete(userCurrent);

                        listView1.Items.Remove(li);
                    }

                    RegenerateRowNumbers();
                    IsDataChanged = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void RegenerateRowNumbers()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].SubItems[0].Text = (i + 1).ToString(); // Update row number
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Delete all users from the database
                    string deleteAllQuery = "DELETE FROM [User]";
                    SqlCommand deleteCmd = new SqlCommand(deleteAllQuery, connection);
                    deleteCmd.ExecuteNonQuery();

                    foreach (User user in User_Manager.Users)
                    {
                        InsertToDatabase(user.UserName, user.PasswordHash, user.Privilege, user.Role);
                    }

                    if (string.IsNullOrEmpty(User_Manager.XmlPath) || string.IsNullOrWhiteSpace(User_Manager.XmlPath))
                    {
                        User_Manager.Save(string.Format("{0}\\{1}.xml", Application.StartupPath, User_Manager.XML_NAME_DEFAULT));
                    }
                    else
                    {
                        User_Manager.Save(User_Manager.XmlPath);
                        MessageBox.Show(this, "Data saved successfully!", Msg.MSG_INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsDataChanged = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InsertToDatabase(string username, string passwordHash, int privilege, string role)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DateTime createdAt = DateTime.Now;

                // Insert new user into the database
                string insertQuery = "INSERT INTO [User] (Username, PasswordHash, Privilege, Role, CreatedAt) VALUES (@Username, @PasswordHash, @Privilege, @Role, @CreatedAt)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@Username", username);
                insertCmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                insertCmd.Parameters.AddWithValue("@Privilege", privilege);
                insertCmd.Parameters.AddWithValue("@Role", role);
                insertCmd.Parameters.AddWithValue("@CreatedAt", createdAt);

                insertCmd.ExecuteNonQuery();
            }
        }

        private void frm_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (IsDataChanged == false) return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
