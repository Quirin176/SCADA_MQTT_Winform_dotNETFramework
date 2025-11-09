using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace HMI_Tool.LSN50_LoRa_Sensor
{
    public partial class ExportData : UserControl
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AllSensorsData.xml");

        // Privilege
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
        public ExportData()
        {
            InitializeComponent();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            DateTime startDate = pick_StartDate.Value;
            DateTime endDate = pick_EndDate.Value;

            //if (startDate > endDate)
            //{
            //    MessageBox.Show("Start date cannot be later than end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            ExportToExcel(startDate, endDate);
        }

        private void ExportToExcel(DateTime startDate, DateTime endDate)
        {
            try
            {
                // Define the directory containing the data files
                string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogData");

                if (!Directory.Exists(logDirectory))
                {
                    MessageBox.Show("The LogData directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get all files matching the selected date range
                var selectedFiles = Directory.GetFiles(logDirectory, "*.xml")
                    .Where(file =>
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        return DateTime.TryParseExact(fileName, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime fileDate)
                               && fileDate >= startDate.Date && fileDate <= endDate.Date;
                    })
                    .ToList();

                if (selectedFiles.Count == 0)
                {
                    MessageBox.Show("No data files found within the selected date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var allFilteredData = new List<SensorData>();

                // Process each file and extract relevant data
                foreach (var file in selectedFiles)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AllSensorsData));
                    using (StreamReader reader = new StreamReader(file))
                    {
                        AllSensorsData allData = (AllSensorsData)serializer.Deserialize(reader);
                        allFilteredData.AddRange(allData.Sensors);
                    }
                }

                if (allFilteredData.Count == 0)
                {
                    MessageBox.Show("No data found within the selected files.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Start Excel application
                Excel.Application excelApp = new Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not properly installed on your system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a new workbook
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.ActiveSheet;

                // Add headers
                worksheet.Cells[1, 1] = "Sensor Name";
                worksheet.Cells[1, 2] = "DateTime";
                worksheet.Cells[1, 3] = "Battery";
                worksheet.Cells[1, 4] = "Temperature";
                worksheet.Cells[1, 5] = "Humidity";

                // Populate data
                int row = 2; // Start from the second row
                foreach (var data in allFilteredData)
                {
                    worksheet.Cells[row, 1] = data.Sensorname;
                    worksheet.Cells[row, 2] = data.Datetime;
                    worksheet.Cells[row, 3] = data.Battery;
                    worksheet.Cells[row, 4] = data.Temperature;
                    worksheet.Cells[row, 5] = data.Humidity;
                    row++;
                }

                worksheet.Columns.AutoFit();

                // Show Excel to the user
                excelApp.Visible = true;

                // Cleanup
                ReleaseExcelObject(worksheet);
                ReleaseExcelObject(workbook);
                ReleaseExcelObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during export: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReleaseExcelObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
