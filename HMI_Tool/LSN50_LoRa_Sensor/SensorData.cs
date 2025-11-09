using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI_Tool.LSN50_LoRa_Sensor
{
    public class SensorData
    {
        public string Sensorname;
        public string Datetime { get; set; }
        public string Battery { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
    }
}
