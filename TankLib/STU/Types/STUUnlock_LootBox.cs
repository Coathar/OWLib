// Generated by TankLibHelper
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types
{
    [STU(0xC294A43B, 320)]
    public class STUUnlock_LootBox : STU_895A2A7A
    {
        [STUField(0x3CC2088A, 288)] // size: 16
        public teStructuredDataAssetRef<STUHero> m_3CC2088A;

        [STUField(0x7AB4E3F8, 304)] // size: 4
        public Enum_BABC4175 m_lootboxType;

        [STUField(0xD8A49A4D, 308)] // size: 4
        public int m_D8A49A4D;

        [STUField(0x2F922165, 312)] // size: 4
        public STUUnlockRarity m_2F922165 = STUUnlockRarity.Rare;

        [STUField(0x48A41554, 316)] // size: 1
        public byte m_48A41554;
    }
}
