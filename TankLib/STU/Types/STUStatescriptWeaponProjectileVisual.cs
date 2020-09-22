// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0xF18160D1, 40)]
    public class STUStatescriptWeaponProjectileVisual : STUInstance
    {
        [STUField(0xC9D22FAA, 8, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUStatescriptWeaponProjectileDataFlow[] m_fixedDataFlow;
        
        [STUField(0xF3E60FB5, 24, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUConfigVar m_animRecoilImpulseFactor;
        
        [STUField(0xADDACE26, 32, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUConfigVar m_showHUDWarningIndicator;
    }
}
