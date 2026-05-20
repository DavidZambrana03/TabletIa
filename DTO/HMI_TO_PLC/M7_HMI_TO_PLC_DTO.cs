namespace WhiteFlexo
{
    public class M7_HMI_TO_PLC_DTO
    {
        public float rRewTensionSP { get; set; }
        public float rLayonPressureSP { get; set; }
        public float rTaperTensionSP { get; set; }
        public float rTaperPressureSP { get; set; }
        public float rDiameterOffsetTaperSP { get; set; }
        public short iTaperType { get; set; }
        public bool bRewinderTurnDirection { get; set; }
        public float rRewCoreSize { get; set; }
        public bool bRewMeterAcusticSignal { get; set; }
        public bool bRewMeterStop { get; set; }
        public float rRewMeterStopSP { get; set; }
        public bool bRewDiameterAcusticSignal { get; set; }
        public bool bRewDiameterStop { get; set; }
        public float rRewDiameterStopSP { get; set; }
        public bool bRewDancerCalibrationStart { get; set; }
        public bool bRewSetMinDiameter { get; set; }
        public bool bRewSetMaxDiameter { get; set; }
        public float rRewCalibrationDiameter { get; set; }

        public void SetMinMaxValues(string name, out float MinValuePopup, out float MaxValuePopup)
        {
            switch (name)
            {
                case nameof(M7_HMI_TO_PLC_DTO.rRewTensionSP):
                    MinValuePopup = 2.5f;
                    MaxValuePopup = 40;
                    break;
                case nameof(M7_HMI_TO_PLC_DTO.rLayonPressureSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 6;
                    break;
                case nameof(M7_HMI_TO_PLC_DTO.rTaperTensionSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 55;
                    break;
                case nameof(M7_HMI_TO_PLC_DTO.rTaperPressureSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 60;
                    break;
                case nameof(M7_HMI_TO_PLC_DTO.rDiameterOffsetTaperSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 1000;
                    break;
                default:
                    MinValuePopup = 0;
                    MaxValuePopup = 0;
                    break;
            }
        }
    }

}
