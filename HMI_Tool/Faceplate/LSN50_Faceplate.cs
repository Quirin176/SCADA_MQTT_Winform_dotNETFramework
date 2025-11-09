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

namespace HMI_Tool.Faceplate
{
    public partial class LSN50_Faceplate : Form
    {
        private double TempHighHigh { get; set; }
        private double TempHigh { get; set; }
        private double TempLow { get; set; }
        private double TempLowLow { get; set; }
        private double HumHighHigh { get; set; }
        private double HumHigh { get; set; }
        private double HumLow { get; set; }
        private double HumLowLow { get; set; }
        private LSN50_LoRa_Sensor.LSN50_LoRa_Sensor Sensor { get; set; }

        public LSN50_Faceplate(LSN50_LoRa_Sensor.LSN50_LoRa_Sensor sensor)
        {
            InitializeComponent();

            this.Text = "Alarm Settings: " + sensor.SensorName;
            TempHighHigh = sensor.TempHighHigh;
            TempHigh = sensor.TempHigh;
            TempLow = sensor.TempLow;
            TempLowLow = sensor.TempLowLow;

            HumHighHigh = sensor.HumHighHigh;
            HumHigh = sensor.HumHigh;
            HumLow = sensor.HumLow;
            HumLowLow = sensor.HumLowLow;

            Sensor = sensor;
        }

        private void LSN50_Faceplate_Load(object sender, EventArgs e)
        {
            txt_TempHighHigh.Text = TempHighHigh.ToString();
            txt_TempHigh.Text = TempHigh.ToString();
            txt_TempLow.Text = TempLow.ToString();
            txt_TempLowLow.Text = TempLowLow.ToString();

            txt_HumHighHigh.Text = HumHighHigh.ToString();
            txt_HumHigh.Text = HumHigh.ToString();
            txt_HumLow.Text = HumLow.ToString();
            txt_HumLowLow.Text = HumLowLow.ToString();
        }

        private void LSN50_Faceplate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sensor.TempHighHigh = Convert.ToDouble(txt_TempHighHigh.Text);
            Sensor.TempHigh = Convert.ToDouble(txt_TempHigh.Text);
            Sensor.TempLow = Convert.ToDouble(txt_TempLow.Text);
            Sensor.TempLowLow = Convert.ToDouble(txt_TempLowLow.Text);

            Sensor.HumHighHigh = Convert.ToDouble(txt_HumHighHigh.Text);
            Sensor.HumHigh = Convert.ToDouble(txt_HumHigh.Text);
            Sensor.HumLow = Convert.ToDouble(txt_HumLow.Text);
            Sensor.HumLowLow = Convert.ToDouble(txt_HumLowLow.Text);

            SaveSettingsToXml();
        }

        public SensorSettings GetSettings()
        {
            return new SensorSettings
            {
                SensorName = Sensor.SensorName,
                TempHighHigh = Convert.ToDouble(txt_TempHighHigh.Text),
                TempHigh = Convert.ToDouble(txt_TempHigh.Text),
                TempLow = Convert.ToDouble(txt_TempLow.Text),
                TempLowLow = Convert.ToDouble(txt_TempLowLow.Text),

                HumHighHigh = Convert.ToDouble(txt_HumHighHigh.Text),
                HumHigh = Convert.ToDouble(txt_HumHigh.Text),
                HumLow = Convert.ToDouble(txt_HumLow.Text),
                HumLowLow = Convert.ToDouble(txt_HumLowLow.Text),
            };
        }

        public static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AllSensorsSettings.xml");
        private static readonly object FileLock = new object();
        public void SaveSettingsToXml()
        {
            try
            {
                SensorSettings currentData = GetSettings();

                lock (FileLock) // Thread-safe access to the file
                {
                    AllSensorSettings allSettings;

                    if (File.Exists(FilePath))
                    {
                        // Load existing settings from the XML file
                        XmlSerializer serializer = new XmlSerializer(typeof(AllSensorSettings));
                        using (StreamReader reader = new StreamReader(FilePath))
                        {
                            allSettings = (AllSensorSettings)serializer.Deserialize(reader);
                        }

                        // Find and update the existing sensor settings
                        SensorSettings existingSensor = allSettings.Sensors
                            .FirstOrDefault(s => s.SensorName == currentData.SensorName);

                        if (existingSensor != null)
                        {
                            // Update the settings for the existing sensor
                            existingSensor.TempHighHigh = currentData.TempHighHigh;
                            existingSensor.TempHigh = currentData.TempHigh;
                            existingSensor.TempLow = currentData.TempLow;
                            existingSensor.TempLowLow = currentData.TempLowLow;

                            existingSensor.HumHighHigh = currentData.HumHighHigh;
                            existingSensor.HumHigh = currentData.HumHigh;
                            existingSensor.HumLow = currentData.HumLow;
                            existingSensor.HumLowLow = currentData.HumLowLow;
                        }
                        else
                        {
                            // If the sensor doesn't exist, add new
                            allSettings.Sensors.Add(currentData);
                        }
                    }
                    else
                    {
                        // Create a new AllSensorSettings instance if the file doesn't exist
                        allSettings = new AllSensorSettings
                        {
                            Sensors = new List<SensorSettings> { currentData }
                        };
                    }

                    // Save the updated data back to the XML file
                    XmlSerializer serializerSave = new XmlSerializer(typeof(AllSensorSettings));
                    using (StreamWriter writer = new StreamWriter(FilePath, false)) // Overwrite the file
                    {
                        serializerSave.Serialize(writer, allSettings);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Access denied: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File is in use or other IO issue: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_SetAsDefault_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TempHighHigh.Text) || string.IsNullOrWhiteSpace(txt_TempHigh.Text) ||
                string.IsNullOrWhiteSpace(txt_TempLow.Text) || string.IsNullOrWhiteSpace(txt_TempLowLow.Text) ||
                string.IsNullOrWhiteSpace(txt_HumHighHigh.Text) || string.IsNullOrWhiteSpace(txt_HumHigh.Text) ||
                string.IsNullOrWhiteSpace(txt_HumLow.Text) || string.IsNullOrWhiteSpace(txt_HumLowLow.Text))
                return;
            SaveDefaultSettingsToXml();
        }

        private void btn_UseDefaultSettings_Click(object sender, EventArgs e)
        {
            LoadDefaultSettingsFromXml();
        }

        public static readonly string DefaultSettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SensorDefaultSettings.xml");
        private static readonly object DefaultSettingsFileLock = new object();
        public void SaveDefaultSettingsToXml()
        {
            try
            {
                lock (DefaultSettingsFileLock)
                {
                    // Load existing data or initialize a new list
                    AllSensorSettings allData;
                    if (File.Exists(DefaultSettingsFilePath))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(AllSensorSettings));
                        using (StreamReader reader = new StreamReader(DefaultSettingsFilePath))
                        {
                            allData = (AllSensorSettings)serializer.Deserialize(reader);
                        }
                    }
                    else
                    {
                        allData = new AllSensorSettings();
                    }

                    // Get current sensor data
                    SensorSettings currentData = GetSettings();

                    // Find the existing sensor data by SensorName
                    var existingData = allData.Sensors.FirstOrDefault(s => s.SensorName == currentData.SensorName);

                    if (existingData != null)
                    {
                        existingData.TempHighHigh = currentData.TempHighHigh;
                        existingData.TempHigh = currentData.TempHigh;
                        existingData.TempLow = currentData.TempLow;
                        existingData.TempLowLow = currentData.TempLowLow;

                        existingData.HumHighHigh = currentData.HumHighHigh;
                        existingData.HumHigh = currentData.HumHigh;
                        existingData.HumLow = currentData.HumLow;
                        existingData.HumLowLow = currentData.HumLowLow;
                    }
                    else
                    {
                        // Add new sensor data if it has at least one non-empty field
                        allData.Sensors.Add(currentData);
                    }

                    // Save updated data back to the XML file
                    XmlSerializer serializerSave = new XmlSerializer(typeof(AllSensorSettings));
                    using (StreamWriter writer = new StreamWriter(DefaultSettingsFilePath, false)) // Overwrite the file
                    {
                        serializerSave.Serialize(writer, allData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDefaultSettingsFromXml()
        {
            try
            {
                if (!File.Exists(DefaultSettingsFilePath))
                    return;

                lock (DefaultSettingsFileLock) // Thread safety
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AllSensorSettings));
                    using (StreamReader reader = new StreamReader(DefaultSettingsFilePath))
                    {
                        AllSensorSettings allData = (AllSensorSettings)serializer.Deserialize(reader);

                        // Find the data for this sensor
                        SensorSettings sensorData = allData.Sensors
                            .FirstOrDefault(sensor => sensor.SensorName == Sensor.SensorName);

                        if (sensorData != null)
                        {
                            txt_TempHighHigh.Text = sensorData.TempHighHigh.ToString();
                            txt_TempHigh.Text = sensorData.TempHigh.ToString();
                            txt_TempLow.Text = sensorData.TempLow.ToString();
                            txt_TempLowLow.Text = sensorData.TempLowLow.ToString();

                            txt_HumHighHigh.Text = sensorData.HumHighHigh.ToString();
                            txt_HumHigh.Text = sensorData.HumHigh.ToString();
                            txt_HumLow.Text = sensorData.HumLow.ToString();
                            txt_HumLowLow.Text = sensorData.HumLowLow.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sensor data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
