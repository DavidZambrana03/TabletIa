using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteFlexo
{
    public class M4_PLC_TO_HMI_NIXKA_DTO
    {
        public short[] iSts_InkLevel { get; set; }
        public short[] iSts_Error { get; set; }
        public short[] iSts_Erros_Spare { get; set; }
        public bool[] bSts_Capping { get; set; }
        public bool[] bSts_Purging { get; set; }
        public bool[] bSts_Wiping { get; set; }
        public bool[] bSts_ShutDown { get; set; }
        public bool[] bSts_Busy { get; set; }
        public bool[] bSts_Capping_Sensor_0 { get; set; }
        public bool[] bSts_Capping_Sensor_1 { get; set; }

        public short[][] iSts_InkTemp { get; set; }
        public short[][] iSts_PressureIn { get; set; }
        public short[][] iSts_PressureOut { get; set; }
        public short[][] iSts_Meniscus { get; set; }
        public short[][] iSts_PurgePressure { get; set; }
        public short[][] iSts_PurgeTime { get; set; }
        public short[][] iSts_FlowRate { get; set; }
        public bool[][] bSts_EnabledInking { get; set; }
        public bool[][] bSts_Recirculation { get; set; }
    }

}
