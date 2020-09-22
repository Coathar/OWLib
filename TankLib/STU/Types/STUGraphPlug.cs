// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0xCEAA4897, 32)]
    public class STUGraphPlug : STUInstance
    {
        [STUField(0x979E8BDE, 8, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 16
        public STUGraphLink[] m_links;
        
        [STUField(0x3868F518, 24, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUGraphNode m_parentNode;
    }
}
