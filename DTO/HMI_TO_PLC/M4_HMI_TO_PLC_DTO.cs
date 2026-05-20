namespace WhiteFlexo
{
    public class M4_HMI_TO_PLC_DTO
    {
        public bool[] bManualMoveCb { get; set; }
        public bool[] bMoveCtrlSideCb { get; set; }
        public bool[] bMoveOpSideCb { get; set; }
        public bool[] bStopMoveCb { get; set; }
        public bool[] bAutoSetPositionsCb { get; set; }
        public bool[] bSetHomePositionCb { get; set; }
        public bool[] bSetPhReplacePositionCb { get; set; }
        public bool[] bGoHomePositionCb { get; set; }
        public bool[] bGoPhReplacePositionCb { get; set; }
        public bool[] bCbSet0Position { get; set; }
        public bool bOpenAirConditioningDoor { get; set; }
        public bool[] bMaintenanceCrossbeamDown { get; set; }
        public bool[] bManualMovePb { get; set; }
        public bool[] bMoveCtrlSidePb { get; set; }
        public bool[] bMoveOpSidePb { get; set; }
        public bool[] bStopMovePb { get; set; }
        public bool[] bAutoSetPositionsPb { get; set; }
        public bool[] bSetHomePositionPb { get; set; }
        public bool[] bSetPrintPositionPb { get; set; }
        public bool[] bPbSet0Position { get; set; }
        public bool[] bGoHomePositionPb { get; set; }
        public bool[] bGoPrintPositionPb { get; set; }
        public bool[] bGoCappingPositionPb { get; set; }
        public bool[] bPurgePb { get; set; }
        public bool[] bWipePb { get; set; }
        public bool[] bPurgeWipePb { get; set; }
        public bool bNixkaShutDown { get; set; }
        public float rModuleTensionSP { get; set; }

        public short iPreImpulsionFanSP_1 { get; set; }
        public short iPreExhaustFanSP_1 { get; set; }
        public short iProdImpulsionFanSP_1 { get; set; }
        public short iProdExhaustFanSP_1 { get; set; }

        public short iPreImpulsionFanSP_2 { get; set; }
        public short iPreExhaustFanSP_2 { get; set; }
        public short iProdImpulsionFanSP_2 { get; set; }
        public short iProdExhaustFanSP_2 { get; set; }

        public float rPreTempOvenSP { get; set; }
        public float rProdTempOvenSP { get; set; }

        public bool bOpenOvenDoors { get; set; }
        public bool bEnableDrumTempControl { get; set; }
        public float rDrumTempControlSP { get; set; }

        public bool bStartPosOptical { get; set; }
        public float rOpticalSensorPosSP { get; set; }

        public short iPinningPreImpulsionFanSP { get; set; }
        public short iPinningProdImpulsionFanSP { get; set; }
        public short iPinningPreExhaustFanSP { get; set; }
        public short iPinningProdExhaustFanSP { get; set; }
        public float rPinningPreTempSP { get; set; }
        public float rPinningProdTempSP { get; set; }


        public void SetMinMaxValues(string name, ref float MinValuePopup, ref float MaxValuePopup)
        {
            switch (name)
            {
                case nameof(rModuleTensionSP):
                    MinValuePopup = 2.5f;
                    MaxValuePopup = 40;
                    break;
                case nameof(iPreImpulsionFanSP_1):
                    MinValuePopup = 10;
                    MaxValuePopup = 80;
                    break;
                case nameof(iPreExhaustFanSP_1):
                    MinValuePopup = 10;
                    MaxValuePopup = 80;
                    break;
                case nameof(iProdImpulsionFanSP_1):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(iProdExhaustFanSP_1):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(iPreImpulsionFanSP_2):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(iPreExhaustFanSP_2):
                    MinValuePopup = 10;
                    MaxValuePopup = 100;
                    break;
                case nameof(iProdImpulsionFanSP_2):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(iProdExhaustFanSP_2):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(rPreTempOvenSP):
                    MinValuePopup = 20;
                    MaxValuePopup = 100;
                    break;
                case nameof(rProdTempOvenSP):
                    MinValuePopup = 20;
                    MaxValuePopup = 100;
                    break;
                case nameof(rDrumTempControlSP):
                    MinValuePopup = 20;
                    MaxValuePopup = 100;
                    break;
                case nameof(rOpticalSensorPosSP):
                    MinValuePopup = -500;
                    MaxValuePopup = 490;
                    break; 
                case nameof(iPinningPreImpulsionFanSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(iPinningProdImpulsionFanSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(iPinningPreExhaustFanSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(iPinningProdExhaustFanSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(rPinningPreTempSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(rPinningProdTempSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                default:
                    MinValuePopup = 0;
                    MaxValuePopup = 0;
                    break;
            }
        }



    }
}
