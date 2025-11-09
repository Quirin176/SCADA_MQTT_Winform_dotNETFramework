using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HMI_Tool.Faceplate
{
    public class AllSensorSettings
    {
        public List<SensorSettings> Sensors { get; set; } = new List<SensorSettings>();
    }
}
