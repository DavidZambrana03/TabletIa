namespace WhiteFlexo
{
    public class M2_HMI_TO_PLC_DTO
    {
        public float rDoctorBladeOpSidePressureSP { get; set; }
        public float rDoctorBladeTransSidePressureSP { get; set; }
        public float rCoatingSleeveOpSidePressureSP { get; set; }
        public float rCoatingSleeveTransSidePressureSP { get; set; }
        public float rChillRollNipPressureSP { get; set; }
        public float rModuleTensionSP { get; set; }
        public short iPreImpulsionBlowerSP { get; set; }
        public short iProdImpulsionBlowerSP { get; set; }
        public short iPreExhaustBlowerSP { get; set; }
        public short iProdExhaustBlowerSP { get; set; }
        public short iPeristalticPumpSP { get; set; }
        public float rPreTunnelTempSP { get; set; }
        public float rProdTunnelTempSP { get; set; }
        public bool bCoatingSleeveNipAutoManPB { get; set; }
        public bool bOpenCloseCoatingSleevePB { get; set; }
        public bool bOpenCloseDoctorBladePB { get; set; }
        public bool bSleeveChangeActivationPB { get; set; }
        public bool bStartCleaningPB { get; set; }
        public bool bStopOperationPrimerPB { get; set; }
        public bool bDrainDoctorBladePB { get; set; }
        public bool bStartPrimerRecirculationPB { get; set; }
        public bool bEnablePrimerSystem { get; set; }
        public uint udiCleaningEmptyTimeSP { get; set; }
        public uint udiCleaningRecircTimeSP { get; set; }
        public uint udiCleaningFillWaterTimeSP { get; set; }
        public uint udiSleeveChangeTimeSP { get; set; }
        public short iCleaningCyclesSP { get; set; }
        public bool bSlowRotationEnable { get; set; }

        public void SetMinMaxValues(string name, out float MinValuePopup, out float MaxValuePopup)
        {
            switch (name)
            {
                case nameof(M2_HMI_TO_PLC_DTO.rPreTunnelTempSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 90;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.rProdTunnelTempSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 90;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.rChillRollNipPressureSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 6;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.rCoatingSleeveOpSidePressureSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 6;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.rCoatingSleeveTransSidePressureSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 6;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.rDoctorBladeOpSidePressureSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 6;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.rDoctorBladeTransSidePressureSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 6;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.rModuleTensionSP):
                    MinValuePopup = 2.5f;
                    MaxValuePopup = 40;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.iCleaningCyclesSP):
                    MinValuePopup = 1;
                    MaxValuePopup = 10;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.iPreExhaustBlowerSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 130;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.iPreImpulsionBlowerSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 130;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.iProdExhaustBlowerSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 130;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.iProdImpulsionBlowerSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 130;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.udiCleaningEmptyTimeSP):
                    MinValuePopup = 30;
                    MaxValuePopup = 180;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.udiCleaningFillWaterTimeSP):
                    MinValuePopup = 30;
                    MaxValuePopup = 180;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.udiCleaningRecircTimeSP):
                    MinValuePopup = 30;
                    MaxValuePopup = 180;
                    break;
                case nameof(M2_HMI_TO_PLC_DTO.udiSleeveChangeTimeSP):
                    MinValuePopup = 5;
                    MaxValuePopup = 30;
                    break;
                default:
                    MinValuePopup = 0;
                    MaxValuePopup = 0;
                    break;
            }
        }
    }

}
