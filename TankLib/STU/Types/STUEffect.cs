// Generated by TankLibHelper
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0xCE1A4D26, 224)]
    public class STUEffect : STUInstance
    {
        [STUField(0x131257CD, 8, ReaderType = typeof(InlineInstanceFieldReader))] // size: 144
        public STU_49A12335 m_root;
        
        [STUField(0xB64D5A14, 152)] // size: 16
        public teStructuredDataAssetRef<STUModel> m_previewModel;
        
        [STUField(0x6AD1B882, 168)] // size: 16
        public teStructuredDataAssetRef<STUModelLook> m_6AD1B882;
        
        [STUField(0x05AA9DFE, 184)] // size: 16
        public teStructuredDataAssetRef<STUHardPoint> m_05AA9DFE;
        
        [STUField(0xF2C4BBBC, 200)] // size: 16
        public teStructuredDataAssetRef<STUGenericSettings_Base> m_F2C4BBBC;
        
        [STUField(0xE2B2B673, 216)] // size: 1
        public byte m_E2B2B673;
        
        [STUField(0xBCC3D95D, 217)] // size: 1
        public Enum_F588EA94 m_BCC3D95D;
    }
}
