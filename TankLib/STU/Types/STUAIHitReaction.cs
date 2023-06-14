// Generated by TankLibHelper
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x543CF5E7, 136)]
    public class STUAIHitReaction : STUInstance
    {
        [STUField(0x24D0A25D, 0)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier> m_24D0A25D;

        [STUField(0x2DDFCB42, 16)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier> m_2DDFCB42;

        [STUField(0x22A48A23, 32)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier>[] m_22A48A23;

        [STUField(0x140825EF, 48)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier>[] m_140825EF;

        [STUField(0xB6A970ED, 64, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_FC2C8334[] m_B6A970ED;

        [STUField(0x1E958CD3, 80, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_EAB333BD m_1E958CD3;

        [STUField(0xE8BD3F70, 88, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUConfigVar m_E8BD3F70;

        [STUField(0xCF371912, 96, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUConfigVar m_CF371912;

        [STUField(0xA58E69E4, 104, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUConfigVar m_A58E69E4;

        [STUField(0x0B7962CB, 112, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STUConfigVar m_0B7962CB;

        [STUField(0x6A79BD98, 120, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_AC5B11ED m_6A79BD98;

        [STUField(0xBB16810A, 128)] // size: 4
        public Enum_5014E5C9 m_priority;
    }
}
