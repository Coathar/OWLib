// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x875F19AE, 336)]
    public class STULineupPose : STUInstance
    {
        [STUField(0xBEF008DE, 8, ReaderType = typeof(InlineInstanceFieldReader))] // size: 96
        public STULineupPoseVariant m_BEF008DE;

        [STUField(0x0189332F, 104, ReaderType = typeof(InlineInstanceFieldReader))] // size: 96
        public STULineupPoseVariant m_0189332F;

        [STUField(0xDE70F501, 200, ReaderType = typeof(InlineInstanceFieldReader))] // size: 96
        public STULineupPoseVariant m_DE70F501;

        [STUField(0xDA65C3DC, 296)] // size: 16
        public teStructuredDataAssetRef<ulong> m_DA65C3DC;

        [STUField(0xE599EB7C, 312)] // size: 16
        public teStructuredDataAssetRef<ulong> m_E599EB7C;

        [STUField(0x40AF7E2D, 328)] // size: 4
        public float m_40AF7E2D = 1f;
    }
}
