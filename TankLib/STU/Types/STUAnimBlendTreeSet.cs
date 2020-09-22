// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0xFC47A2ED, 440)]
    public class STUAnimBlendTreeSet : STUInstance
    {
        [STUField(0x93DA6E7C, 8, ReaderType = typeof(InlineInstanceFieldReader))] // size: 208
        public STUAnimBlendTreeSet_HardcodedAnimCategoryRefs m_hardcodedAnimCategoryRefs;
        
        [STUField(0x253EE7C8, 216)] // size: 16
        public ulong[] m_253EE7C8;
        
        [STUField(0x6AFCD1A5, 232, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUAnimBlendTreeSet_BlendTreeItem[] m_blendTreeItems;
        
        [STUField(0xF9CA7995, 248)] // size: 16
        public uint[] m_paramIds;
        
        [STUField(0xBCAD245E, 264)] // size: 16
        public ulong[] m_BCAD245E;
        
        [STUField(0x999F01F8, 280, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_C898217C[] m_999F01F8;
        
        [STUField(0x85453F7B, 296)] // size: 16
        public teStructuredDataAssetRef<STUAnimCategory>[] m_85453F7B;
        
        [STUField(0xE1FA44F9, 312)] // size: 16
        public ulong[] m_externalRefs;
        
        [STUField(0x226CC159, 328, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 16
        public STU_A323F0F5[] m_226CC159;
        
        [STUField(0x6DDF40DD, 344, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUAnimBlendTreeSet_BonePoseOverrideItem[] m_bonePoseOverrideItems;
        
        [STUField(0x85CC326B, 360, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_DF9B7DE2 m_85CC326B;
        
        [STUField(0x8610C654, 376)] // size: 16
        public teStructuredDataAssetRef<ulong> m_8610C654;
        
        [STUField(0xBA53D5ED, 392)] // size: 8
        public ulong m_guid;
        
        [STUField(0x84935843, 400)] // size: 8
        public ulong m_rootAnimAliasGUID;
        
        [STUField(0xD1467FCA, 408, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUAnimGameData_Base m_D1467FCA;
        
        [STUField(0x2B2C5C7F, 416, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_72C48DD7 m_animParamUpdater;
        
        [STUField(0x384DE14F, 424, ReaderType = typeof(InlineInstanceFieldReader))] // size: 8
        public STUAnimBlendTreeSet_RetargetParams m_retargetParams;
        
        [STUField(0x2F9541A4, 432)] // size: 4
        public int m_crc;
    }
}
