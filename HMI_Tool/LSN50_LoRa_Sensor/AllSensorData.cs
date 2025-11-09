using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI_Tool.LSN50_LoRa_Sensor
{
    public class AllSensorsData
    {
        public List<SensorData> Sensors { get; set; } = new List<SensorData>();
    }
}
