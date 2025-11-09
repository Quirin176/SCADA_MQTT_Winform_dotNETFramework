using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI_Tool.Faceplate
{
    public class SensorSettings
    {
        public string SensorName { get; set; }
        public double TempHighHigh { get; set; }
        public double TempHigh { get; set; }
        public double TempLow { get; set; }
        public double TempLowLow { get; set; }
        public double HumHighHigh { get; set; }
        public double HumHigh { get; set; }
        public double HumLow { get; set; }
        public double HumLowLow { get; set; }
    }
}
