using Microsoft.Win32.SafeHandles;

namespace WhiteFlexo
{
    public class M4_PLC_TO_HMI_DTO
    {
        public float rModuleTensionFeedback { get; set; }
        public bool bOvenGateClosed { get; set; }
        public bool bDrumTempControlInOp { get; set; }
        public float rDrumTempControlPV { get; set; }
        public short[] iPbState { get; set; }
        public short[] iCbState { get; set; }
        public bool bNixkaComunicationOk { get; set; }
        //public bool bModuleEnabled { get; set; }

        //Ink
        //public float[] rInkTemperatureFeedback { get; set; }
        //public float[] rInkLevelFeedback { get; set; }

        //Drying
        public short iPreImpulsionFanPV_1 { get; set; }
        public short iPreExhaustFanPV_1 { get; set; }
        public short iProdImpulsionFanPV_1 { get; set; }
        public short iProdExhaustFanPV_1 { get; set; }

        public short iPreImpulsionFanPV_2 { get; set; }
        public short iPreExhaustFanPV_2 { get; set; }
        public short iProdImpulsionFanPV_2 { get; set; }
        public short iProdExhaustFanPV_2 { get; set; }

        //public float rPreTempOvenPV { get; set; }
        public float rProdTempOvenPv { get; set; }

        public float rDancerTensionFeedback { get; set; }
        ////Register
        ///
        public float rOpticalSensorPosPV { get; set; }
        public float rCalculatedFormat { get; set; }
        public float rXError_C_K { get; set; }
        public float rXError_M_C { get; set; }
        public float rXError_C_Y { get; set; }

        public float rYError_C_K { get; set; }
        public float rYError_M_C { get; set; }
        public float rYError_C_Y { get; set; }

        public short iPinningPreImpulsionFanPV { get; set; }
        public short iPinningProdImpulsionFanPV { get; set; }
        public short iPinningPreExhaustFanPV { get; set; }
        public short iPinningProdExhaustFanPV { get; set; }
        public float rPinningTempPV { get; set; }

        //public float[] rRegisterErrorX { get; set; }
        //public float[] rRegisterErrorY { get; set; }
        //public bool bCanReadRegister { get; set; }
    }
}
