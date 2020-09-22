// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x67866D38, 128)]
    public class STUAnimBlendTree : STUInstance
    {
        [STUField(0x85CC326B, 8, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_DF9B7DE2 m_85CC326B;
        
        [STUField(0x0B15B894, 24, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 16
        public STUAnimNode_Base[] m_animNodes;
        
        [STUField(0xF9CA7995, 40)] // size: 16
        public uint[] m_paramIds;
        
        [STUField(0xBCAD245E, 56)] // size: 16
        public ulong[] m_BCAD245E;
        
        [STUField(0xEED04EED, 72)] // size: 16
        public ulong[] m_EED04EED;
        
        [STUField(0x123205BA, 88, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUAnimBlendDriverParam[] m_123205BA;
        
        [STUField(0xA4712A0A, 104)] // size: 8
        public ulong m_treeCRC;
        
        [STUField(0x191CEC72, 112)] // size: 8
        public ulong m_191CEC72;
        
        [STUField(0xD6497916, 120, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_CB30C7C3 m_rootNode;
    }
}
