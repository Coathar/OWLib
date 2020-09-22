// Generated by TankLibHelper
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0x857C15FC, 96)]
    public class STUCriteria_Stat : STUCriteria
    {
        [STUField(0xBC4326FF, 32)] // size: 16
        public teStructuredDataAssetRef<STUStat> m_stat;
        
        [STUField(0xAF872E86, 48)] // size: 8
        public double m_amount;
        
        [STUField(0x7FE9F87A, 56)] // size: 8
        public ulong m_heroGUID;
        
        [STUField(0xEA58FA50, 64)] // size: 8
        public ulong m_mapGUID;
        
        [STUField(0x411ABFEA, 72)] // size: 8
        public ulong m_context;
        
        [STUField(0x5D32D524, 80)] // size: 4
        public Enum_2D0A59BA m_5D32D524 = Enum_2D0A59BA.x712178EF;
        
        [STUField(0x5ED79353, 84)] // size: 4
        public Enum_10064D07 m_5ED79353;
        
        [STUField(0xAB103723, 88)] // size: 1
        public byte m_AB103723;
    }
}
