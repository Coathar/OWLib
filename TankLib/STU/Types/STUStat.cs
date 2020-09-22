// Generated by TankLibHelper
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0xC7BAA017, 208)]
    public class STUStat : STUInstance
    {
        [STUField(0xB48F1D22, 8)] // size: 16
        public teStructuredDataAssetRef<ulong> m_name;
        
        [STUField(0x9F574E87, 24)] // size: 16
        public teStructuredDataAssetRef<ulong> m_9F574E87;
        
        [STUField(0x2F5D06B7, 40)] // size: 16
        public teStructuredDataAssetRef<STU_4B259FE1>[] m_2F5D06B7;
        
        [STUField(0x056D3E39, 56)] // size: 16
        public teStructuredDataAssetRef<STUHero>[] m_heroes;
        
        [STUField(0x6E01378E, 72)] // size: 16
        public teStructuredDataAssetRef<STUMap>[] m_6E01378E;
        
        [STUField(0xD440A0F7, 88)] // size: 4
        public TeamIndex[] m_teams;
        
        [STUField(0x4C9917C1, 104)] // size: 16
        public teStructuredDataAssetRef<STUStat> m_4C9917C1;
        
        [STUField(0x155E2A47, 120)] // size: 16
        public teStructuredDataAssetRef<STUStat> m_155E2A47;
        
        [STUField(0x57817968, 136, ReaderType = typeof(EmbeddedInstanceFieldReader))] // size: 8
        public STU_783B8A59 m_57817968;
        
        [STUField(0xBEA87015, 144)] // size: 4
        public Enum_CC0F4675 m_BEA87015;
        
        [STUField(0xF91D6DAD, 148)] // size: 4
        public Enum_6CBB673B m_F91D6DAD;
        
        [STUField(0x2FC4460C, 152)] // size: 4
        public Enum_CD0A8047 m_2FC4460C;
        
        [STUField(0xF3507330, 156)] // size: 4
        public Enum_3AA82AF1 m_F3507330;
        
        [STUField(0x0619C597, 160)] // size: 4
        public STUStatType m_type;
        
        [STUField(0x08CACF3A, 164)] // size: 4
        public Enum_149525F6 m_08CACF3A;
        
        [STUField(0x16CCEFC8, 168)] // size: 4
        public Enum_C9A3B99F m_16CCEFC8;
        
        [STUField(0x09276DD8, 172)] // size: 4
        public Enum_F5D8585C m_09276DD8;
        
        [STUField(0xC6C4C538, 176)] // size: 4
        public Enum_B220D6E4 m_C6C4C538;
        
        [STUField(0x0BB7C364, 180)] // size: 4
        public Enum_E7FEC166 m_0BB7C364;
        
        [STUField(0x33DDBA15, 184)] // size: 4
        public Enum_E7FEC166 m_33DDBA15;
        
        [STUField(0xD0FEEC0E, 188)] // size: 4
        public Enum_5B361C17 m_D0FEEC0E;
        
        [STUField(0x4811336B, 192)] // size: 4
        public Enum_8C9887E8 m_4811336B;
        
        [STUField(0xDFD4F586, 196)] // size: 4
        public Enum_E279EC92 m_DFD4F586;
        
        [STUField(0xC0211FD4, 200)] // size: 1
        public byte m_C0211FD4;
        
        [STUField(0x9B42F159, 201)] // size: 1
        public byte m_9B42F159;
        
        [STUField(0x439EAAA8, 202)] // size: 1
        public byte m_439EAAA8;
        
        [STUField(0xEED826CD, 203)] // size: 1
        public byte m_EED826CD;
    }
}
