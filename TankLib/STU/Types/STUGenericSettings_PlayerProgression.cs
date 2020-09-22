// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0xC881FD3B, 168)]
    public class STUGenericSettings_PlayerProgression : STUGenericSettings_Base
    {
        [STUField(0xBF482AA3, 8, ReaderType = typeof(InlineInstanceFieldReader))] // size: 24
        public STUUnlocks m_otherUnlocks;
        
        [STUField(0xC84D463F, 32)] // size: 16
        public teStructuredDataAssetRef<STUUnlock>[] m_C84D463F;
        
        [STUField(0x50C6BC40, 48, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STULootBoxCelebrationOverride[] m_lootBoxCelebrationOverrides;
        
        [STUField(0x22D62B2D, 64, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STURulesetWinReward[] m_rulesetWinRewards;
        
        [STUField(0x9A4245F2, 80, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUAdditionalUnlocks[] m_additionalUnlocks;
        
        [STUField(0x473494FF, 96, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STULootBoxUnlocks[] m_lootBoxesUnlocks;
        
        [STUField(0x03F27C01, 112, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STULootBoxCurrencyUnlocks[] m_lootBoxesCurrencyUnlocks;
        
        [STUField(0x0C6A363E, 128, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_F021DC6B[] m_0C6A363E;
        
        [STUField(0x88922C14, 144)] // size: 16
        public ulong[] m_88922C14;
        
        [STUField(0xE7377888, 160)] // size: 4
        public uint m_E7377888;
    }
}
