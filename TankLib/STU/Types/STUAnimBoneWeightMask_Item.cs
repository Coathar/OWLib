// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x70BFB706, 24)]
    public class STUAnimBoneWeightMask_Item : STUInstance
    {
        [STUField(0xF97609C8, 0)] // size: 16
        public teStructuredDataAssetRef<STUBoneLabel> m_bone;
        
        [STUField(0x9CDDC24D, 16)] // size: 4
        public float m_weight = 1f;
        
        [STUField(0xC7E4EB10, 20)] // size: 1
        public byte m_C7E4EB10;
        
        [STUField(0xA08C6C1C, 21)] // size: 1
        public byte m_A08C6C1C = 0x1;
    }
}
