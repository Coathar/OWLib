// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x7C37840C, 216)]
    public class STUStatescriptState : STUStatescriptBase
    {
        [STUField(0xE390CDB8, 112)] // size: 16
        public teStructuredDataAssetRef<STUStatescriptStateGroup> m_stateGroup;
        
        [STUField(0xC4E39595, 128, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 16
        public STU_EE275B33[] m_transitionPlug;
        
        [STUField(0x4F8F2F3F, 144)] // size: 16
        public int[] m_4F8F2F3F;
        
        [STUField(0x0B1AA8CA, 160, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUStatescriptSubGraph m_0B1AA8CA;
        
        [STUField(0xE965193B, 168, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUStatescriptInputPlug m_beginPlug;
        
        [STUField(0xF198FD3A, 176, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_1CCEA5F7 m_F198FD3A;
        
        [STUField(0x984573B1, 184, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_DA98CA6D m_onBeginPlug;
        
        [STUField(0x8BC64AEB, 192, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUStatescriptOutputPlug m_onEndPlug;
        
        [STUField(0x64338F79, 200, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_904BFCEC m_subgraphPlug;
        
        [STUField(0x26B6454C, 208)] // size: 4
        public int m_26B6454C;
    }
}
