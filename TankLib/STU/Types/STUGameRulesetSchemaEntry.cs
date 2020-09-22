// Generated by TankLibHelper
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x074EDCB9, 104)]
    public class STUGameRulesetSchemaEntry : STUInstance
    {
        [STUField(0xAA76FAD1, 0)] // size: 16
        public teStructuredDataAssetRef<ulong> m_displayText;
        
        [STUField(0x7DF418A5, 16)] // size: 16
        public teStructuredDataAssetRef<ulong> m_7DF418A5;
        
        [STUField(0x3E783677, 32)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier> m_3E783677;
        
        [STUField(0x7E3ED979, 48)] // size: 16
        public teStructuredDataAssetRef<STUTargetTag>[] m_7E3ED979;
        
        [STUField(0x34993B2E, 64)] // size: 16
        public teStructuredDataAssetRef<STUTargetTag>[] m_34993B2E;
        
        [STUField(0x07DD813E, 80, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_848957AF m_value;
        
        [STUField(0x65184E78, 88, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_96788737 m_65184E78;
        
        [STUField(0x2C54AEAF, 96)] // size: 4
        public Enum_F2F62E3D m_category;
        
        [STUField(0x37D4F9CD, 100)] // size: 4
        public int m_37D4F9CD;
    }
}
