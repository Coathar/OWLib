// Generated by TankLibHelper
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x56B6D12E, 192)]
    public class STULootBox : STUInstance
    {
        [STUField(0xCBE2DADD, 8)] // size: 16
        public teStructuredDataAssetRef<STUEntityDefinition> m_chestEntity;
        
        [STUField(0xB2F9D222, 24)] // size: 16
        public teStructuredDataAssetRef<STUEntityDefinition> m_baseEntity;
        
        [STUField(0x3970E137, 40)] // size: 16
        public teStructuredDataAssetRef<STUEffect> m_idleEffect;
        
        [STUField(0xFFE7768F, 56)] // size: 16
        public teStructuredDataAssetRef<STUEffect> m_FFE7768F;
        
        [STUField(0xFEC3ED62, 72)] // size: 16
        public teStructuredDataAssetRef<STUEffect> m_FEC3ED62;
        
        [STUField(0x041CE51F, 88)] // size: 16
        public teStructuredDataAssetRef<STUModelLook> m_modelLook;
        
        [STUField(0x9B180535, 104)] // size: 16
        public teStructuredDataAssetRef<STUModelLook> m_baseModelLook;
        
        [STUField(0xB48F1D22, 120)] // size: 16
        public teStructuredDataAssetRef<STUUXDisplayText> m_name;
        
        [STUField(0xE02BEE24, 136)] // size: 16
        public teStructuredDataAssetRef<STUCelebration> m_celebration;
        
        [STUField(0xD75586C0, 152, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STULootBoxShopCard[] m_shopCards;
        
        [STUField(0x3DFAC8CA, 168)] // size: 16
        public teStructuredDataAssetRef<STUUXDisplayText>[] m_3DFAC8CA;
        
        [STUField(0x7AB4E3F8, 184)] // size: 4
        public Enum_BABC4175 m_lootboxType;
        
        [STUField(0x45C33D76, 188)] // size: 1
        public byte m_45C33D76;
        
        [STUField(0xFA2D81E7, 189)] // size: 1
        public byte m_hidePucks;
    }
}
