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

namespace DEMO
{
    public partial class frm_Login : Form
    {
        private Form1 mainForm;

        private readonly string connectionString = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=LVTN;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private int privilege;
        private string role;

        public frm_Login(Form1 form1)
        {
            InitializeComponent();
            mainForm = form1;
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txt_Username.Text;
            string password = txt_Password.Text;

            if (Login(username, password))
            {
                LogLoginActivity(username, privilege, role);

                if (mainForm == null || mainForm.IsDisposed)
                {
                    mainForm = new Form1();
                }

                //mainForm.UpdateUserDetails(username, privilege);
                mainForm.UserName = username;
                mainForm.UserPrivilege = privilege;
                mainForm.Role = role;

                //MessageBox.Show("Privilege = " + privilege);

                mainForm.SetUserNameForControls(mainForm.Controls, username);
                mainForm.SetUserPrivilegeForControls(mainForm.Controls, privilege);

                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private bool Login(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Query to get the password hash, privilege and role
                string query = "SELECT PasswordHash, Privilege, Role FROM [User] WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string storedPasswordHash = reader["PasswordHash"].ToString();
                    privilege = Convert.ToInt32(reader["Privilege"]);
                    role = Convert.ToString(reader["Role"]);

                    // Verify the password
                    string inputPasswordHash = HashPassword(password);
                    return storedPasswordHash == inputPasswordHash;
                }
                return false;  // Username not found
            }
        }

        private void LogLoginActivity(string username, int privilege, string role)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO LoginDiary (Username, Privilege, Role, DateTime) VALUES (@Username, @Privilege, @Role, @DateTime)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Privilege", privilege);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while logging the login activity: " + ex.Message);
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

        private void checkbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPassword.Checked)
            {
                txt_Password.PasswordChar = '\0';
            }
            else
            {
                txt_Password.PasswordChar = '*';
            }
        }
    }
}
