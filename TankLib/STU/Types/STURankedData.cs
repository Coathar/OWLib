// Generated by TankLibHelper

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x8159A26D, 264)]
    public class STURankedData : STUInstance
    {
        [STUField(0x58066D8F, 8, ReaderType = typeof(InlineInstanceFieldReader))] // size: 24
        public STUUnlocks m_58066D8F;

        [STUField(0x3C1894B2, 32, ReaderType = typeof(InlineInstanceFieldReader))] // size: 24
        public STUUnlocks m_heroicUnlocks;

        [STUField(0x5BB8DFF3, 56, ReaderType = typeof(InlineInstanceFieldReader))] // size: 16
        public STU_A92F620A[] m_5BB8DFF3;

        [STUField(0xEC70AD04, 72)] // size: 16
        public teStructuredDataAssetRef<STUHero>[] m_EC70AD04;

        [STUField(0x590CF462, 88)] // size: 16
        public teStructuredDataAssetRef<STUMap>[] m_590CF462;

        [STUField(0x1E4E5957, 104)] // size: 16
        public teStructuredDataAssetRef<ulong> m_1E4E5957;

        [STUField(0xB804C4DB, 120)] // size: 16
        public teStructuredDataAssetRef<ulong> m_B804C4DB;

        [STUField(0xE0B3D69F, 136)] // size: 16
        public teStructuredDataAssetRef<ulong> m_E0B3D69F;

        [STUField(0x21EB3E73, 152)] // size: 16
        public teStructuredDataAssetRef<ulong> m_21EB3E73;

        [STUField(0x56E7DD46, 168)] // size: 16
        public teStructuredDataAssetRef<STUMap>[] m_56E7DD46;

        [STUField(0xD3DE9579, 184)] // size: 16
        public teStructuredDataAssetRef<STUIdentifier> m_D3DE9579;

        [STUField(0xF82A8727, 200)] // size: 8
        public teStructuredDataDateAndTime m_F82A8727;

        [STUField(0x275B6D5C, 208)] // size: 8
        public teStructuredDataDateAndTime m_275B6D5C;

        [STUField(0x961B4853, 216)] // size: 8
        public teStructuredDataDateAndTime m_961B4853;

        [STUField(0x9A31D01C, 224)] // size: 8
        public teStructuredDataDateAndTime m_9A31D01C;

        [STUField(0x2E7A5FDB, 232)] // size: 4
        public float m_2E7A5FDB;

        [STUField(0x503BAA0A, 236)] // size: 4
        public float m_503BAA0A = 168f;

        [STUField(0x85059B03, 240)] // size: 4
        public uint m_85059B03 = 0x32;

        [STUField(0x82AA08B4, 244)] // size: 4
        public int m_82AA08B4 = 0xA;

        [STUField(0x46B0B905, 248)] // size: 4
        public int m_46B0B905 = 0x7;

        [STUField(0x842AF60F, 252)] // size: 4
        public int m_842AF60F = 0x19;

        [STUField(0xB5DD91B7, 256)] // size: 1
        public byte m_B5DD91B7 = 0x1;
    }
}
