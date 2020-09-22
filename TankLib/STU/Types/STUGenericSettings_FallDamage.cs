// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0xA10FCCD3, 48)]
    public class STUGenericSettings_FallDamage : STUGenericSettings_Base
    {
        [STUField(0x7B5AE194, 8)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier>[] m_7B5AE194;
        
        [STUField(0x13024362, 24, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUAnimCurve m_13024362;
        
        [STUField(0x7690E074, 32)] // size: 4
        public float m_7690E074;
        
        [STUField(0x6CFD21C9, 36)] // size: 4
        public float m_6CFD21C9;
        
        [STUField(0xF871EA4D, 40)] // size: 4
        public float m_F871EA4D = 10f;
    }
}
