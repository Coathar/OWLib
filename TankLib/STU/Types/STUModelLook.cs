// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x5207484B, 192)]
    public class STUModelLook : STUInstance
    {
        [STUField(0xBAFDAFBA, 8, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUModelMaterial[] m_materials;

        [STUField(0x33DA887B, 24)] // size: 16
        public teStructuredDataAssetRef<STU_CBD8CDF3>[] m_33DA887B;

        [STUField(0xC250886C, 40, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_3AB3BE9E[] m_C250886C;

        [STUField(0x05692DC5, 56, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STUAnimationPermutation[] m_05692DC5;

        [STUField(0x844B23C0, 72, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_D5C245D3[] m_844B23C0;

        [STUField(0x44821537, 88, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_F1CC9AED[] m_44821537;

        [STUField(0x29C9F2F3, 104, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_669D00A9[] m_29C9F2F3;

        [STUField(0x7B5D8241, 120)] // size: 16
        public teStructuredDataAssetRef<STUMaterialEffect> m_7B5D8241 = 0x0;

        [STUField(0xC45F5F6F, 136, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 16
        public STUModelHardPoint[] m_hardPoints;

        [STUField(0x312C5F1A, 152, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_D75EA2E1[] m_materialEffects;

        [STUField(0x5ED21CE1, 168)] // size: 16
        public ulong[] m_5ED21CE1;

        [STUField(0x7465A325, 184)] // size: 1
        public byte m_7465A325 = 0x0;

        [STUField(0x46884170, 185)] // size: 1
        public byte m_46884170 = 0x0;
    }
}
