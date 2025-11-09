using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace HMI_Report
{
    public partial class Report : UserControl
    {
        private string connectionString = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=LVTN;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Report()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Privilege = 1;

            string[] items = { "Alarm_FLOOR1", "LoginDiary", "User" };
            comboBox1.Items.AddRange(items);

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "User")
            {
                pick_StartDate.Enabled = false;
                pick_EndDate.Enabled = false;
            }
            else
            {
                pick_StartDate.Enabled = true;
                pick_EndDate.Enabled = true;
            }
        }

        [Category("Security")]
        private int _privilege;
        public int Privilege
        {
            get { return _privilege; }
            set
            {
                _privilege = value;
                CheckPrivilege();
            }
        }


        [Category("Security")]
        private int _userPrivilege;
        public int UserPrivilege
        {
            get { return _userPrivilege; }
            set
            {
                _userPrivilege = value;
                CheckPrivilege();
            }
        }

        private void CheckPrivilege()
        {
            if (_userPrivilege >= _privilege)
            {
                this.Enabled = true;
            }
            else
            {
                this.Enabled = false;
            }
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a report from the list.", "No Report Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportName = comboBox1.SelectedItem.ToString();
            DateTime startDate = pick_StartDate.Value;
            DateTime endDate = pick_EndDate.Value;

            //if (startDate > endDate)
            //{
            //    MessageBox.Show("Start date cannot be later than end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            DataTable reportData = GetReportData(reportName, startDate, endDate);
            DisplayReport(reportData);
        }

        private DataTable GetReportData(string reportName, DateTime startDate, DateTime endDate)
        {
            DataTable reportData = new DataTable();

            string query;

            if (reportName == "User")
            {
                query = $"SELECT * FROM [User]";
            }
            else
            {
                query = $"SELECT * FROM {reportName} WHERE CONVERT(DATE, DateTime) >= @startDate AND CONVERT(DATE, DateTime) <= @endDate";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (reportName != "User")
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                        cmd.Parameters.AddWithValue("@endDate", endDate.Date);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(reportData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return reportData;
        }

        private void DisplayReport(DataTable data)
        {
            dataGridView1.DataSource = data;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a report from the list.", "No Report Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportName = comboBox1.SelectedItem.ToString();
            DateTime startDate = pick_StartDate.Value;
            DateTime endDate = pick_EndDate.Value;

            //if (startDate > endDate)
            //{
            //    MessageBox.Show("Start date cannot be later than end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            ExportDataToExcel(reportName, startDate, endDate);
        }

        private void ExportDataToExcel(string reportName, DateTime startDate, DateTime endDate)
        {
            DataTable reportData = GetReportData(reportName, startDate, endDate);

            if (reportData.Rows.Count > 0)
            {
                // Set up
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Report";

                // Write column headers to Excel
                for (int i = 1; i < reportData.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = reportData.Columns[i - 1].ColumnName;
                }

                // Write data rows to Excel
                for (int i = 0; i < reportData.Rows.Count; i++)
                {
                    for (int j = 0; j < reportData.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = reportData.Rows[i][j].ToString();
                    }
                }

                worksheet.Columns.AutoFit();

                excelApp.Visible = true;

                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(excelApp);
            }
            else
            {
                MessageBox.Show("No data available for the selected report and date range.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
    }
}
