using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteFlexo
{
    public class M5_HMI_TO_PLC_DTO
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
        public bool[] bCbStopMove { get; set; }
        public bool[] bCbSet0Position { get; set; }

        public bool[] bManualMovePb { get; set; }
        public bool[] bMoveCtrlSidePb { get; set; }
        public bool[] bMoveOpSidePb { get; set; }
        public bool[] bStopMovePb { get; set; }
        public bool[] bAutoSetPositionsPb { get; set; }
        public bool[] bSetHomePositionPb { get; set; }
        public bool[] bSetPrintPositionPb { get; set; }
        public bool[] bGoHomePositionPb { get; set; }
        public bool[] bGoPrintPositionPb { get; set; }
        public bool[] bGoCappingPositionPb { get; set; }
        public bool[] bPurgePb { get; set; }
        public bool[] bWipePb { get; set; }
        public bool[] bPurgeWipePb { get; set; }
        public bool[] bPbStopMove { get; set; }
        public bool[] bPbSet0Position { get; set; }

        public float rModuleTensionSP { get; set; }
        public bool bEnableDrumTempControl { get; set; }
        public float rDrumTempControlSP { get; set; }

        public bool bStartPosOptical { get; set; }
        public float rOpticalSensorPosSP { get; set; }
        public bool bEnableAutomaticRegister { get; set; }
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

        public float rPlateCylinderFormat { get; set; }
        public float rAniloxCylinderFormat { get; set; }
        public float rManualAdjustStep { get; set; }
        public float rPlateCylinderPrintingOffset { get; set; }
        public float rPlateCylinderPrintingLateralOffset { get; set; }
        public bool bGoToPrint { get; set; }
        public bool bGoToPrePrint { get; set; }
        public bool bSleeveChangeMovement { get; set; }
        public bool bGoToHome { get; set; }
        public bool bStopMove { get; set; }
        public bool bSetDeckCenterPosition { get; set; }
        public bool bSetPrintPosition { get; set; }
        public bool bSetHomePosition { get; set; }
        public bool bManualAdjust { get; set; }
        public bool bStartMarkSensor { get; set; }
        public bool bEnableSmartPrint { get; set; }
        public bool bAxPcSelector { get; set; }
        public bool bMoveFwdLeft { get; set; }
        public bool bMoveFwdRight { get; set; }
        public bool bMoveRevLeft { get; set; }
        public bool bMoveRevRight { get; set; }
        public bool bMoveFwd { get; set; }
        public bool bMoveRev { get; set; }
        public bool bDeckMoveToRight { get; set; }
        public bool bDeckMoveToLeft { get; set; }
        public bool bDeckToCenter { get; set; }
        public bool bStartRecirculation { get; set; }
        public bool bStopRecirculation { get; set; }
        public bool bFlexoMarkSensorTeach { get; set; }
        public bool bFlexoMarkSensorWindowPb { get; set; }
        public bool bSetPlateCylinderPrintingOffset { get; set; }
        public bool bSetPlateCylinderLateralPrintingOffset { get; set; }
        // REAL to float/double (float is often sufficient for single-precision)
        public float rDrBladePressureMs { get; set; }
        public float rDrBladePressureCs { get; set; }
        public short iPumpSpeedSP { get; set; }
        public float rAniloxFormat { get; set; }
        public float rPcFormat { get; set; }
        public float rMarkSensorPositionSetpoint { get; set; }
        public float rFlexoTensionSp { get; set; }

        // BOOL to bool
        public bool bStartProductRecirculation { get; set; }
        public bool bDrainDoctorBlade { get; set; }
        public bool bStartCleaningSequence { get; set; }
        public bool bStartSleeveExtraction { get; set; }

        // INT to int
        public short iCleaningCyclesSP { get; set; }

        // UDINT to uint (unsigned integer)
        public ushort udiCleanRecirculationTimeSP { get; set; }
        public ushort udiCleanFillingWaterTimeSP { get; set; }
        public ushort udiCleanEmptyTimeSP { get; set; }
        public ushort udiAirExtractionTimeSP { get; set; }

        public bool bGoToWetting { get; set; }
        public bool bMoveFwd_MS { get; set; }
        public bool bMoveFwd_CS { get; set; }
        public bool bMoveRev_MS { get; set; }
        public bool bMoveRev_CS { get; set; }
        public bool bDeckMoveTo_CS { get; set; }
        public bool bDeckMoveTo_MS { get; set; }
        public short iM5WhiteConfiguration { get; set; } // 0 = digital, 1 = flexo, 2 = hybrid (not possible nowadays)
        public bool bOffsetDone { get; set; }

        public void SetMinMaxValues(string name, out float MinValuePopup, out float MaxValuePopup)
        {
            switch (name)
            {
                case nameof(rModuleTensionSP):
                    MinValuePopup = 2.5f;
                    MaxValuePopup = 40;
                    break;
                case nameof(iPreImpulsionFanSP_1):
                case nameof(iPreExhaustFanSP_1):
                    MinValuePopup = 10;
                    MaxValuePopup = 80;
                    break;
                case nameof(iPumpSpeedSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(iProdImpulsionFanSP_1):
                case nameof(iProdExhaustFanSP_1):
                case nameof(iPreImpulsionFanSP_2):
                case nameof(iProdImpulsionFanSP_2):
                case nameof(iProdExhaustFanSP_2):
                    MinValuePopup = 0;
                    MaxValuePopup = 100;
                    break;
                case nameof(iPreExhaustFanSP_2):
                    MinValuePopup = 10;
                    MaxValuePopup = 100;
                    break;
                case nameof(rPreTempOvenSP):
                case nameof(rProdTempOvenSP):
                case nameof(rDrumTempControlSP):
                    MinValuePopup = 20;
                    MaxValuePopup = 100;
                    break;
                case nameof(rOpticalSensorPosSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 1000; // placeholder
                    break;
                case nameof(rPlateCylinderFormat):
                case nameof(rAniloxCylinderFormat):
                case nameof(rAniloxFormat):
                case nameof(rPcFormat):
                    MinValuePopup = 0;
                    MaxValuePopup = 1000; // placeholder
                    break;
                case nameof(rManualAdjustStep):
                    MinValuePopup = 0;
                    MaxValuePopup = 0.05f;
                    break;
                //case nameof(rPlateCylinderPrintingOffset):
                //    MinValuePopup = -500;
                //    MaxValuePopup = 500 ;
                //    break;
                //case nameof(rPlateCylinderPrintingLateralOffset):
                //    MinValuePopup = -500;
                //    MaxValuePopup = 500 ;
                //    break;
                case nameof(rDrBladePressureMs):
                case nameof(rDrBladePressureCs):
                    MinValuePopup = 0;
                    MaxValuePopup = 6;
                    break;
                case nameof(rFlexoTensionSp):
                    MinValuePopup = 1;
                    MaxValuePopup = 50;
                    break;
                case nameof(iCleaningCyclesSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 10;
                    break;
                case nameof(udiCleanRecirculationTimeSP):
                case nameof(udiCleanFillingWaterTimeSP):
                case nameof(udiCleanEmptyTimeSP):
                case nameof(udiAirExtractionTimeSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 300; // 10 minutes max as a placeholder
                    break;
                default:
                    MinValuePopup = 0;
                    MaxValuePopup = 0;
                    break;
            }
        }

    }
}
