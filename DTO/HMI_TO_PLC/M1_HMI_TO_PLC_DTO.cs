namespace WhiteFlexo
{
    public class M1_HMI_TO_PLC_DTO
    {
        public float rUnwTensionSP { get; set; }
        public float rMaterialWidthSP { get; set; }
        public float rMaterialThicknessSP { get; set; }
        public bool bSpliceSensorTeach { get; set; }
        public bool bUnwTurnDirection { get; set; }
        public short iMaterialType { get; set; }
        public float rUnwCoreSize { get; set; }
        public bool bUnwEnableAntiStaticBars { get; set; }
        public float rTreaterPowerSP { get; set; }
        public float rTreaterDoseSP { get; set; }
        public short iTreaterWorkMode { get; set; }
        public bool bEnableTreater { get; set; }
        public float rTreaterPropMinPower { get; set; }
        public float rTreaterPropMaxPower { get; set; }
        public float rTreaterPropMinSpeed { get; set; }
        public float rTreaterPropMaxSpeed { get; set; }
        public bool bUnwDiameterStop { get; set; }
        public bool bUnwDiameterAcusticsignal { get; set; }
        public float rUnwDiameterStopSP { get; set; }
        public bool bUnwDancerCalibrationStart { get; set; }
        public bool bUnwSetMinDiameter { get; set; }
        public bool bUnwSetMaxDiameter { get; set; }
        public float rUnwDiameterToCalibrated { get; set; }

        public void SetMinMaxValues(string name, out float MinValuePopup, out float MaxValuePopup)
        {
            switch (name)
            {
                case nameof(M1_HMI_TO_PLC_DTO.rUnwTensionSP):
                    MinValuePopup = 2.5f;
                    MaxValuePopup = 40;
                    break;
                case nameof(M1_HMI_TO_PLC_DTO.rMaterialThicknessSP):
                    MinValuePopup = 2;
                    MaxValuePopup = 100;
                    break;
                case nameof(M1_HMI_TO_PLC_DTO.rMaterialWidthSP):
                    MinValuePopup = 300;
                    MaxValuePopup = 980;
                    break;
                case nameof(M1_HMI_TO_PLC_DTO.rTreaterDoseSP):
                    MinValuePopup = 100;
                    MaxValuePopup = 4000;
                    break;
                case nameof(M1_HMI_TO_PLC_DTO.rTreaterPowerSP):
                    MinValuePopup = 100;
                    MaxValuePopup = 4000;
                    break;
                case nameof(M1_HMI_TO_PLC_DTO.rTreaterPropMaxPower):
                    MinValuePopup = 100;
                    MaxValuePopup = 4000;
                    break;
                case nameof(M1_HMI_TO_PLC_DTO.rTreaterPropMinPower):
                    MinValuePopup = 100;
                    MaxValuePopup = 4000;
                    break;
                case nameof(M1_HMI_TO_PLC_DTO.rTreaterPropMinSpeed):
                    MinValuePopup = 35;
                    MaxValuePopup = 75;
                    break;
                case nameof(M1_HMI_TO_PLC_DTO.rTreaterPropMaxSpeed):
                    MinValuePopup = 35;
                    MaxValuePopup = 75;
                    break;
                default:
                    MinValuePopup = 0;
                    MaxValuePopup = 0;
                    break;
            }

        }
    }

}
