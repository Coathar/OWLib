﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TACTLib;
using TankLib;
using TankLib.STU;
using TankLib.STU.Types;
using TankLib.STU.Types.Enums;
using static DataTool.Helper.STUHelper;
using static DataTool.Helper.IO;

namespace DataTool.DataModels {
    /// <summary>
    /// Unlock data model
    /// </summary>
    [DataContract]
    public class Unlock {
        [DataMember]
        public teResourceGUID GUID;

        /// <summary>
        /// Name of this unlock
        /// </summary>
        [DataMember]
        public string Name;

        /// <summary>
        /// DataTool enum for the type of Unlock
        /// </summary>
        [DataMember]
        public UnlockType Type;

        /// <summary>
        /// Unlock rarity
        /// </summary>
        /// <see cref="STUUnlockRarity"/>
        [DataMember]
        public STUUnlockRarity Rarity;

        /// <summary>
        /// Description of this unlock
        /// </summary>
        [DataMember]
        public string Description;

        /// <summary>
        /// Where this unlock can be obtained from
        /// </summary>
        /// <example>"Available in Halloween Loot Boxes"</example>
        [DataMember]
        public string AvailableIn;

        /// <summary>
        /// If the Unlock is a Skin, the GUID of the SkinTheme
        /// </summary>
        [DataMember]
        public teResourceGUID SkinThemeGUID;

        /// <summary>
        /// DataTool specific Unlock Data Tag
        /// </summary>
        [DataMember]
        public string Tag;

        /// <summary>
        /// Array of categories the Unlock belongs to that the Hero Gallery & Career Profile filtering options use
        /// </summary>
        [DataMember]
        public string[] Categories;

        /// <summary>
        /// If the Unlock is a form of Currency, the amount of currency it is
        /// </summary>
        [DataMember]
        public int Currency;

        [DataMember]
        public Enum_BABC4175 LootBoxType;

        [DataMember]
        public bool IsEsportsUnlock;

        [DataMember]
        public string EsportsTeam;

        /// <summary>
        /// Internal Unlock STU
        /// </summary>
        [IgnoreDataMember]
        public STU_3021DDED STU;

        /// <summary>
        /// Whether this is a "normal" Unlock like a skin, emote, voiceline, pose, icon, etc and not something like a Lootbox or Currency.
        /// </summary>
        [IgnoreDataMember]
        public bool IsTraditionalUnlock;

        // These types are specific to certain unlocks so don't show them unless we're on that unlock
        public bool ShouldSerializeLootBoxType() => Type == UnlockType.Lootbox;
        public bool ShouldSerializeSkinThemeGUID() => Type == UnlockType.Skin;
        public bool ShouldSerializeCurrency() => Type == UnlockType.CompetitiveCurrency || Type == UnlockType.Currency || Type == UnlockType.OWLToken;

        // These only really apply to "normal" unlocks and can be removed from others
        public bool ShouldSerializeAvailableIn() => IsTraditionalUnlock;
        public bool ShouldSerializeTag() => IsTraditionalUnlock;
        public bool ShouldSerializeCategories() => IsTraditionalUnlock;

        public Unlock(STU_3021DDED unlock, ulong guid) {
            Init(unlock, guid);
        }

        public Unlock(ulong guid) {
            var unlock = GetInstance<STU_3021DDED>(guid);
            if (unlock == null) return;
            Init(unlock, guid);
        }

        private void Init(STU_3021DDED unlock, ulong guid) {
            GUID = (teResourceGUID) guid;
            STU = unlock;

            Name = GetString(unlock.m_name)?.TrimEnd(' '); // ffs blizz, why do the names end in a space sometimes
            AvailableIn = GetString(unlock.m_53145FAF);
            Rarity = unlock.m_rarity;
            Description = GetDescriptionString(unlock.m_3446F580);
            Type = GetTypeForUnlock(unlock);
            Tag = UnlockData.GetTagFor(guid);

            IsTraditionalUnlock =
                Type == UnlockType.Icon || Type == UnlockType.Spray ||
                Type == UnlockType.Skin || Type == UnlockType.HighlightIntro ||
                Type == UnlockType.VictoryPose || Type == UnlockType.VoiceLine;

            if (unlock.m_BEE9BCDA != null)
                Categories = unlock.m_BEE9BCDA.Select(x => GetGUIDName(x.GUID)).ToArray();

            // Lootbox and currency unlocks have some additional relevant data
            switch (unlock) {
                case STUUnlock_CompetitiveCurrency stu:
                    Currency = stu.m_760BF18E;
                    break;
                case STUUnlock_Currency stu:
                    Currency = stu.m_currency;
                    break;
                case STUUnlock_OWLToken stu:
                    Currency = stu.m_63A026AF;
                    break;
                case STUUnlock_LootBox stu:
                    Rarity = stu.m_2F922165;
                    LootBoxType = stu.m_lootboxType;
                    break;
                case STUUnlock_SkinTheme stu:
                    SkinThemeGUID = stu.m_skinTheme;
                    break;
            }

            if (unlock.m_0B1BA7C1 != null) {
                var teamDefinition = new TeamDefinition(unlock.m_0B1BA7C1);
                if (teamDefinition.Id != 0) {
                    IsEsportsUnlock = true;
                    EsportsTeam = teamDefinition.FullName;
                }
            }
        }

        public string GetName() {
            return Name ?? GetFileName(GUID);
        }

        /// <summary>
        /// Returns the UnlockType for an Unlock
        /// </summary>
        /// <param name="unlock">Source unlock</param>
        /// <returns>Friendly type name</returns>
        private static UnlockType GetTypeForUnlock(STUUnlock unlock) {
            return GetUnlockType(unlock.GetType());
        }

        /// <summary>
        /// Returns the UnlockType for a STUUnlock Type
        /// </summary>
        /// <param name="type">unlock stu type</param>
        /// <returns></returns>
        public static UnlockType GetUnlockType(Type type) {
            if (type == typeof(STUUnlock_SkinTheme)) {
                return UnlockType.Skin;
            }

            if (type == typeof(STUUnlock_AvatarPortrait)) {
                return UnlockType.Icon;
            }

            if (type == typeof(STUUnlock_Emote)) {
                return UnlockType.Emote;
            }

            if (type == typeof(STUUnlock_Pose)) {
                return UnlockType.VictoryPose;
            }

            if (type == typeof(STUUnlock_VoiceLine)) {
                return UnlockType.VoiceLine;
            }

            if (type == typeof(STUUnlock_SprayPaint)) {
                return UnlockType.Spray;
            }

            if (type == typeof(STUUnlock_Currency)) {
                return UnlockType.Currency;
            }

            if (type == typeof(STUUnlock_PortraitFrame)) {
                return UnlockType.PortraitFrame;
            }

            if (type == typeof(STUUnlock_Weapon)) {
                return UnlockType.WeaponSkin;
            }

            if (type == typeof(STUUnlock_POTGAnimation)) {
                return UnlockType.HighlightIntro;
            }

            if (type == typeof(STUUnlock_HeroMod)) {
                return UnlockType.HeroMod;
            }

            if (type == typeof(STUUnlock_CompetitiveCurrency)) {
                return UnlockType.CompetitiveCurrency;
            }

            if (type == typeof(STUUnlock_OWLToken)) {
                return UnlockType.OWLToken;
            }

            if (type == typeof(STUUnlock_LootBox)) {
                return UnlockType.Lootbox;
            }

            Logger.Debug("Unlock", $"Unknown unlock type ${type}");
            return UnlockType.Unknown;
        }

        /// <summary>
        /// Get an array of <see cref="Unlock"/> from an array of GUIDs
        /// </summary>
        /// <param name="guids">GUID collection</param>
        /// <returns>Array of <see cref="Unlock"/></returns>
        public static Unlock[] GetArray(IEnumerable<ulong> guids) {
            if (guids == null) return new Unlock[0];
            List<Unlock> unlocks = new List<Unlock>();
            foreach (ulong guid in guids) {
                STU_3021DDED stu = GetInstance<STU_3021DDED>(guid);
                if (stu == null) continue;
                Unlock unlock = new Unlock(stu, guid);
                unlocks.Add(unlock);
            }

            return unlocks.ToArray();
        }

        /// <summary>Get an array of <see cref="Unlock"/> from STUUnlocks</summary>
        /// <inheritdoc cref="GetArray(System.Collections.Generic.IEnumerable{ulong})"/>
        public static Unlock[] GetArray(STUUnlocks unlocks) {
            return GetArray(unlocks?.m_unlocks);
        }

        public static Unlock[] GetArray(teStructuredDataAssetRef<STUUnlock>[] unlocks) {
            return GetArray(unlocks?.Select(x => (ulong) x));
        }
    }

    public enum UnlockType {
        Unknown, // :david:
        Skin,
        Icon,
        Spray,
        Emote,
        VictoryPose,
        HighlightIntro,
        VoiceLine,
        WeaponSkin,
        Lootbox,
        PortraitFrame, // borders
        Currency, // gold
        CompetitiveCurrency, // competitive points
        OWLToken,
        HeroMod, // wot? unused?
    }

    // todo: fix this lmao :zingy:
    // todo: noidontthinkso :js:
    public static class UnlockData {
        public static readonly Dictionary<string, ulong[]> CuratedGUID = new Dictionary<string, ulong[]> {
            {
                "sg2018",
                new ulong[] {
                    0x0250000000001716,
                    0x0250000000001A8B,
                    0x025000000000170B,
                    0x0250000000001A88,
                    0x02500000000015F2,
                    0x0250000000001A89,
                    0x0250000000001A8A,
                    0x02500000000011AE,
                    0x02500000000016D2,
                    0x0250000000001A86,
                    0x0250000000001A87,
                    0x0250000000001A5A,
                    0x0250000000001ABE,
                    0x0250000000001952,
                    0x0250000000001A84,
                    0x0250000000001A51,
                    0x02500000000011D7,
                    0x02500000000011B6,
                    0x0250000000001ABF,
                    0x0250000000001062,
                    0x0250000000001A85,
                    0x0250000000001ABB,
                    0x0250000000001A3C,
                    0x0250000000001A67,
                    0x0250000000001A66,
                    0x0250000000001ABD,
                    0x0250000000001A58,
                    0x0250000000001A64,
                    0x0250000000001A6A,
                    0x0250000000001A6D,
                    0x0250000000001A3A,
                    0x0250000000001AB3,
                    0x0250000000001AB4,
                    0x0250000000001A3B,
                    0x0250000000001A6B,
                    0x0250000000001A68,
                    0x0250000000001AB1,
                    0x0250000000001AB2,
                    0x0250000000001A6C,
                    0x0250000000001A69,
                    0x0250000000001AAF,
                    0x0250000000001AB0,
                    0x02500000000012A5,
                    0x0250000000001A7E,
                    0x0250000000001A81,
                    0x0250000000001A77,
                    0x02500000000013A5,
                    0x0250000000001A7B,
                    0x0250000000001A7A,
                    0x02500000000013A6,
                    0x0250000000001A7C,
                    0x0250000000001A79,
                    0x0250000000001A78,
                    0x0250000000001A7F,
                    0x0250000000001A82,
                    0x0250000000001A80,
                    0x0250000000001A7D,
                    0x0250000000001A83,
                    0x0250000000001A8C
                }
            }, {
                "sg2017",
                new ulong[] {
                    0x025000000000106A,
                    0x025000000000106B,
                    0x0250000000001095,
                    0x0250000000001096,
                    0x0250000000001097,
                    0x0250000000001098,
                    0x02500000000010BF,
                    0x025000000000113F,
                    0x0250000000001141,
                    0x025000000000117A,
                    0x02500000000011AC,
                    0x02500000000011AD,
                    0x02500000000011AF,
                    0x02500000000011B2,
                    0x02500000000011B3,
                    0x02500000000011B8,
                    0x02500000000011B9,
                    0x0250000000001216,
                    0x0250000000001217,
                    0x0250000000001218,
                    0x0250000000001219,
                    0x025000000000121A,
                    0x025000000000121B,
                    0x025000000000121C,
                    0x025000000000121D,
                    0x025000000000121E,
                    0x025000000000121F,
                    0x0250000000001220,
                    0x0250000000001221,
                    0x0250000000001222,
                    0x0250000000001223,
                    0x0250000000001224,
                    0x0250000000001225,
                    0x0250000000001226,
                    0x0250000000001227,
                    0x0250000000001228,
                    0x0250000000001229,
                    0x025000000000122A,
                    0x025000000000122B,
                    0x025000000000122C,
                    0x025000000000122D,
                    0x025000000000122E,
                    0x025000000000122F,
                    0x0250000000001230,
                    0x0250000000001231,
                    0x0250000000001232,
                    0x0250000000001233,
                    0x0250000000001234,
                    0x0250000000001235,
                    0x0250000000001236,
                    0x0250000000001237,
                    0x025000000000125A,
                }
            }, {
                "sg2016",
                new ulong[] {
                    0x0250000000000B08,
                    0x0250000000000B17,
                    0x0250000000000B18,
                    0x0250000000000B19,
                    0x0250000000000B1C,
                    0x0250000000000B1D,
                    0x0250000000000B24,
                    0x0250000000000B25,
                    0x0250000000000B26,
                    0x0250000000000B27,
                    0x0250000000000B28,
                    0x0250000000000B2C,
                    0x0250000000000B30,
                    0x0250000000000B38,
                    0x0250000000000B39,
                    0x0250000000000B3A,
                    0x0250000000000B3B,
                    0x0250000000000B3C,
                    0x0250000000000B3D,
                    0x0250000000000B3E,
                    0x0250000000000B3F,
                    0x0250000000000B41,
                    0x0250000000000B42,
                    0x0250000000000B43,
                    0x0250000000000B44,
                    0x0250000000000B45,
                    0x0250000000000B46,
                    0x0250000000000B47,
                    0x0250000000000B48,
                    0x0250000000000B49,
                    0x0250000000000B4A,
                    0x0250000000000B4B,
                    0x0250000000000B4C,
                    0x0250000000000B4D,
                    0x0250000000000B51,
                    0x0250000000000B53,
                    0x0250000000000B54,
                    0x0250000000000B55,
                    0x0250000000000B56,
                    0x0250000000000B57,
                    0x0250000000000B58,
                    0x0250000000000B59,
                    0x0250000000000B5A,
                    0x0250000000000B5B,
                    0x0250000000000B5C,
                    0x0250000000000B5E,
                    0x0250000000000B74,
                    0x0250000000000B75,
                    0x0250000000000B76,
                    0x0250000000000B77,
                    0x0250000000000B7A,
                    0x0250000000000B7F,
                    0x0250000000000B81,
                    0x0250000000000B83,
                    0x0250000000000B9D,
                    0x0250000000000B9E,
                    0x0250000000000BA0,
                    0x0250000000000BA1,
                    0x0250000000000BA2,
                    0x0250000000000BA3,
                    0x0250000000000BAB,
                    0x0250000000000BAC,
                    0x0250000000000BAD,
                    0x0250000000000BAE,
                    0x0250000000000BAF,
                    0x0250000000000BB0,
                    0x0250000000000BB1,
                    0x0250000000000BB2,
                    0x0250000000000BB3,
                    0x0250000000000BB5,
                    0x0250000000000BB6,
                    0x0250000000000BB7,
                    0x0250000000000BB8,
                    0x0250000000000BB9,
                    0x0250000000000BBA,
                    0x0250000000000BBB,
                    0x0250000000000BBC,
                    0x0250000000000BBD,
                    0x0250000000000BBE,
                    0x0250000000000BBF,
                    0x0250000000000BC0,
                    0x0250000000000BC1,
                    0x0250000000000BC2,
                    0x0250000000000BC6,
                    0x0250000000000BC7,
                    0x0250000000000BC8,
                    0x0250000000000BC9,
                    0x0250000000000BCA,
                    0x0250000000000BCB,
                    0x0250000000000BCC,
                    0x0250000000000BCD,
                    0x0250000000000BCE,
                    0x0250000000000BCF,
                    0x0250000000000BD0,
                    0x0250000000000BD1,
                    0x0250000000000BD2,
                    0x0250000000000BD3,
                    0x0250000000000BD4,
                    0x0250000000000BD5,
                    0x0250000000000BD6,
                    0x0250000000000BD7,
                    0x0250000000000BD8,
                    0x0250000000000BD9,
                    0x0250000000000BDA,
                    0x0250000000000BDB,
                    0x0250000000000BDC,
                    0x0250000000000BDD,
                    0x0250000000000BDE,
                    0x0250000000000BDF,
                    0x0250000000000BE4,
                }
            }, {
                "anniversary2018",
                new ulong[] {
                    0x025000000000137F,
                    0x0250000000001380,
                    0x0250000000001382,
                    0x0250000000001384,
                    0x025000000000156A,
                    0x0250000000001575,
                    0x02500000000016C6,
                    0x0250000000001728,
                    0x025000000000194F,
                    0x0250000000001954,
                    0x0250000000001955,
                    0x0250000000001969,
                    0x025000000000196A,
                    0x025000000000196B,
                    0x025000000000196C,
                    0x025000000000196D,
                    0x025000000000196E,
                    0x025000000000196F,
                    0x0250000000001970,
                    0x0250000000001971,
                    0x0250000000001972,
                    0x0250000000001984,
                    0x0250000000001985,
                    0x0250000000001986,
                    0x0250000000001987,
                    0x0250000000001988,
                    0x0250000000001989,
                    0x025000000000198A,
                    0x025000000000198B,
                    0x0250000000001992,
                    0x0250000000001993,
                    0x02500000000019A0,
                    0x02500000000019A1,
                    0x02500000000019A2,
                    0x02500000000019A3,
                    0x02500000000019A4,
                    0x02500000000019A5,
                    0x02500000000019A6,
                    0x02500000000019A7,
                    0x02500000000019A8,
                    0x02500000000019A9,
                    0x02500000000019AA,
                    0x02500000000019AB,
                    0x02500000000019AC,
                    0x02500000000019AD,
                    0x02500000000019AE,
                    0x02500000000019AF,
                    0x02500000000019B0,
                    0x02500000000019B1,
                    0x02500000000019B2,
                    0x02500000000019B3,
                    0x02500000000019B4,
                    0x02500000000019B5,
                    0x02500000000019B6,
                    0x02500000000019B7,
                    0x02500000000019B8,
                    0x02500000000019B9,
                    0x02500000000019BA,
                    0x02500000000019BB,
                    0x02500000000019BC,
                    0x02500000000019BD,
                    0x02500000000019BE,
                    0x02500000000019C5,
                    0x02500000000019CA,
                }
            }, {
                "anniversary2017",
                new ulong[] {
                    0x0250000000000A7E,
                    0x0250000000000CA9,
                    0x0250000000000CAA,
                    0x0250000000000CE7,
                    0x0250000000000CF1,
                    0x0250000000000CF5,
                    0x0250000000000CF6,
                    0x0250000000000D04,
                    0x0250000000000D26,
                    0x0250000000000E7B,
                    0x0250000000000E7F,
                    0x0250000000000E80,
                    0x0250000000000E81,
                    0x0250000000000E82,
                    0x0250000000000F4A,
                    0x0250000000000F5F,
                    0x0250000000000F60,
                    0x0250000000000F79,
                    0x0250000000000F7D,
                    0x0250000000000FE2,
                    0x0250000000000FE3,
                    0x0250000000000FE4,
                    0x0250000000000FE5,
                    0x0250000000000FE6,
                    0x0250000000000FE7,
                    0x0250000000000FE9,
                    0x0250000000000FF8,
                    0x0250000000000FF9,
                    0x0250000000000FFA,
                    0x025000000000106F,
                    0x0250000000001092,
                    0x0250000000001093,
                    0x0250000000001094,
                    0x02500000000010AA,
                    0x02500000000010AB,
                    0x02500000000010AC,
                    0x02500000000010FA,
                    0x02500000000010FB,
                    0x02500000000010FC,
                    0x02500000000010FD,
                    0x02500000000010FE,
                    0x02500000000010FF,
                    0x0250000000001100,
                    0x0250000000001101,
                    0x0250000000001102,
                    0x0250000000001103,
                    0x0250000000001104,
                    0x0250000000001105,
                    0x0250000000001106,
                    0x0250000000001107,
                    0x0250000000001108,
                    0x0250000000001109,
                    0x025000000000110A,
                    0x025000000000110B,
                    0x025000000000110C,
                    0x025000000000110D,
                    0x025000000000110E,
                    0x025000000000110F,
                    0x0250000000001110,
                    0x0250000000001111,
                    0x0250000000001112,
                    0x0250000000001113,
                    0x0250000000001114,
                    0x0250000000001115,
                    0x0250000000001116,
                    0x0250000000001117,
                    0x0250000000001118,
                    0x0250000000001119,
                    0x025000000000111A,
                    0x025000000000111B,
                    0x025000000000111C,
                    0x025000000000111D,
                    0x025000000000111E,
                    0x025000000000111F,
                    0x0250000000001120,
                    0x0250000000001121,
                    0x0250000000001122,
                    0x0250000000001123,
                    0x0250000000001124,
                    0x0250000000001125,
                    0x0250000000001126,
                    0x0250000000001127,
                    0x0250000000001128,
                    0x0250000000001129,
                    0x025000000000112A,
                    0x0250000000001149,
                    0x025000000000114A,
                    0x025000000000114B,
                    0x025000000000114C,
                    0x025000000000114D,
                    0x025000000000114E,
                    0x025000000000114F,
                    0x0250000000001150,
                    0x0250000000001151,
                    0x0250000000001152,
                    0x0250000000001153,
                    0x0250000000001154,
                    0x0250000000001155,
                    0x0250000000001156,
                    0x0250000000001157,
                    0x0250000000001158,
                    0x0250000000001159,
                    0x025000000000115A,
                    0x025000000000115B,
                    0x025000000000115C,
                    0x025000000000115D,
                    0x025000000000115E,
                    0x025000000000115F,
                    0x0250000000001161,
                    0x0250000000001162,
                    0x0250000000001163,
                    0x0250000000001164,
                    0x0250000000001165,
                    0x0250000000001166,
                    0x0250000000001167,
                    0x0250000000001168,
                    0x0250000000001169,
                    0x025000000000116A,
                    0x025000000000116B,
                    0x025000000000116C,
                    0x025000000000116D,
                    0x025000000000116E,
                    0x025000000000116F,
                    0x0250000000001170,
                    0x0250000000001171,
                    0x0250000000001172,
                    0x0250000000001173,
                    0x0250000000001174,
                    0x0250000000001175,
                    0x0250000000001176,
                    0x0250000000001177,
                    0x0250000000001178,
                    0x0250000000001195,
                }
            }, {
                "archives2018",
                new ulong[] {
                    0x0250000000001253,
                    0x0250000000001258,
                    0x025000000000126C,
                    0x0250000000001288,
                    0x025000000000128E,
                    0x02500000000012A7,
                    0x0250000000001383,
                    0x0250000000001385,
                    0x0250000000001386,
                    0x025000000000142A,
                    0x02500000000015F4,
                    0x0250000000001744,
                    0x02500000000017A8,
                    0x02500000000017A9,
                    0x02500000000017AA,
                    0x02500000000017AB,
                    0x02500000000017AC,
                    0x02500000000017AD,
                    0x02500000000017AE,
                    0x02500000000017AF,
                    0x02500000000017B0,
                    0x02500000000017B1,
                    0x02500000000017B2,
                    0x02500000000017B3,
                    0x02500000000017B4,
                    0x02500000000017B5,
                    0x02500000000017B6,
                    0x02500000000017FA,
                    0x02500000000017FC,
                    0x0250000000001822,
                    0x0250000000001823,
                    0x02500000000018DA,
                    0x02500000000018DC,
                    0x02500000000018DD,
                    0x02500000000018EB,
                    0x0250000000001908,
                    0x0250000000001909,
                    0x025000000000190A,
                    0x025000000000190B,
                    0x025000000000190C,
                    0x025000000000190D,
                    0x025000000000190E,
                    0x025000000000190F,
                    0x0250000000001910,
                    0x0250000000001911,
                    0x0250000000001912,
                    0x0250000000001913,
                    0x0250000000001914,
                    0x0250000000001915,
                    0x0250000000001916,
                    0x0250000000001917,
                    0x0250000000001918,
                    0x0250000000001919,
                    0x025000000000191A,
                    0x025000000000191B,
                    0x025000000000191C,
                    0x025000000000191D,
                    0x025000000000191E,
                    0x025000000000191F,
                    0x0250000000001937,
                    0x0250000000001938,
                    0x0250000000001939,
                    0x025000000000193A,
                    0x025000000000193B,
                    0x025000000000193C,
                    0x025000000000193D,
                    0x025000000000193E,
                    0x025000000000193F,
                }
            }, {
                "archives2017",
                new ulong[] {
                    0x0250000000000D05,
                    0x0250000000000F62,
                    0x0250000000000F71,
                    0x0250000000000F77,
                    0x0250000000000F8E,
                    0x0250000000000F91,
                    0x0250000000000FD9,
                    0x0250000000000FE8,
                    0x025000000000103D,
                    0x025000000000103E,
                    0x025000000000104A,
                    0x025000000000104B,
                    0x025000000000104C,
                    0x025000000000104D,
                    0x0250000000001056,
                    0x0250000000001057,
                    0x0250000000001058,
                    0x0250000000001059,
                    0x025000000000105A,
                    0x025000000000105B,
                    0x0250000000001060,
                    0x0250000000001061,
                    0x025000000000106C,
                    0x025000000000106D,
                    0x0250000000001072,
                    0x0250000000001073,
                    0x0250000000001074,
                    0x0250000000001075,
                    0x0250000000001076,
                    0x0250000000001077,
                    0x0250000000001078,
                    0x0250000000001079,
                    0x025000000000107A,
                    0x025000000000107B,
                    0x025000000000107C,
                    0x025000000000107D,
                    0x025000000000107F,
                    0x0250000000001080,
                    0x0250000000001081,
                    0x0250000000001082,
                    0x0250000000001083,
                    0x0250000000001084,
                    0x0250000000001085,
                    0x025000000000108E,
                    0x025000000000108F,
                    0x0250000000001090,
                    0x0250000000001091,
                    0x02500000000010B4,
                    0x02500000000010B5,
                    0x02500000000010B6,
                    0x02500000000010B7,
                    0x02500000000010B8,
                    0x02500000000010B9,
                    0x02500000000010BA,
                    0x02500000000010BB,
                    0x02500000000010BC,
                    0x02500000000010BD,
                    0x02500000000010BE,
                    0x02500000000010C1,
                    0x02500000000010C2,
                    0x02500000000010C3,
                    0x02500000000010C4,
                    0x02500000000010C5,
                    0x02500000000010C6,
                    0x02500000000010C7,
                    0x02500000000010C8,
                    0x02500000000010C9,
                    0x02500000000010CA,
                    0x02500000000010CB,
                    0x02500000000010CC,
                    0x02500000000010CD,
                    0x02500000000010CE,
                    0x02500000000010CF,
                    0x02500000000010D0,
                    0x02500000000010D1,
                    0x02500000000010D2,
                    0x02500000000010D3,
                    0x02500000000010D4,
                    0x02500000000010D5,
                    0x02500000000010D6,
                    0x02500000000010D7,
                    0x02500000000010D8,
                    0x02500000000010D9,
                    0x02500000000010DA,
                    0x02500000000010DB,
                    0x02500000000010DC,
                    0x02500000000010DD,
                    0x02500000000010DE,
                    0x02500000000010DF,
                    0x02500000000010E0,
                    0x02500000000010E1,
                    0x02500000000010E2,
                    0x02500000000010E3,
                    0x02500000000010E4,
                    0x02500000000010E5,
                    0x02500000000010E6,
                    0x02500000000010E7,
                    0x02500000000010E8,
                    0x02500000000010E9,
                    0x02500000000010EA,
                    0x02500000000010EB,
                    0x02500000000010EC,
                    0x02500000000010ED,
                    0x02500000000010EE,
                    0x02500000000010F1,
                    0x02500000000010F4,
                    0x02500000000010F5,
                }
            }, {
                "halloween2018",
                new ulong[] {
                    0x02500000000022B6,
                    0x02500000000022B5,
                    0x0250000000001B3D,
                    0x025000000000194D,
                    0x02500000000022B4,
                    0x02500000000022CD,
                    0x0250000000002405,
                    0x02500000000023FD,
                    0x02500000000022B7,
                    0x0250000000002384,
                    0x02500000000022C5,
                    0x02500000000022B1,
                    0x02500000000022B3,
                    0x0250000000001B4C,
                    0x025000000000240D,
                    0x02500000000022B2,
                    0x0250000000001B2F,
                    0x025000000000172A,
                    0x02500000000022CE,
                    0x0250000000002406,
                    0x0250000000001942,
                    0x02500000000022CB,
                    0x0250000000002407,
                    0x0250000000002403,
                    0x02500000000022CA,
                    0x0250000000001982,
                    0x02500000000023FB,
                    0x0250000000001A39,
                    0x02500000000022AF,
                    0x02500000000022B0,
                    0x02500000000022CC,
                    0x02500000000022C7,
                    0x0250000000002404,
                    0x02500000000023FA,
                    0x02500000000022AD,
                    0x02500000000022AE,
                    0x02500000000022BC,
                    0x02500000000022C8,
                    0x02500000000023F8,
                    0x02500000000022AB,
                    0x02500000000022AC,
                    0x0250000000001AC9,
                    0x02500000000022CF,
                    0x02500000000022C9,
                    0x0250000000002408,
                    0x02500000000023F9,
                    0x02500000000022D0,
                    0x02500000000022D1,
                    0x02500000000022D2
                }
            }, {
                "halloween2017",
                new ulong[] {
                    0x0250000000000E5C,
                    0x025000000000109C,
                    0x025000000000109F,
                    0x025000000000113C,
                    0x0250000000001185,
                    0x0250000000001187,
                    0x0250000000001193,
                    0x0250000000001194,
                    0x0250000000001209,
                    0x025000000000120A,
                    0x025000000000120C,
                    0x025000000000127E,
                    0x025000000000127F,
                    0x0250000000001280,
                    0x02500000000012A6,
                    0x02500000000012B1,
                    0x02500000000012B2,
                    0x02500000000012B3,
                    0x02500000000012B4,
                    0x02500000000012B5,
                    0x02500000000012B6,
                    0x02500000000012B7,
                    0x02500000000012B8,
                    0x02500000000012B9,
                    0x02500000000012BA,
                    0x02500000000012BB,
                    0x02500000000012BC,
                    0x02500000000012BD,
                    0x02500000000012BE,
                    0x02500000000012BF,
                    0x02500000000012C0,
                    0x02500000000012C1,
                    0x02500000000012C2,
                    0x02500000000012C3,
                    0x02500000000012C4,
                    0x02500000000012C5,
                    0x02500000000012C6,
                    0x02500000000012C7,
                    0x02500000000012C8,
                    0x02500000000012C9,
                    0x02500000000012CA,
                    0x02500000000012CB,
                    0x02500000000012CC,
                    0x02500000000012D0,
                    0x02500000000012D1,
                    0x02500000000012D2,
                    0x02500000000012D3,
                    0x02500000000012D4,
                    0x02500000000012D5,
                    0x02500000000012D7,
                    0x02500000000012D8,
                    0x02500000000012D9,
                    0x02500000000012DA,
                    0x02500000000012DC,
                    0x02500000000012DE,
                    0x02500000000012DF,
                }
            }, {
                "halloween2016",
                new ulong[] {
                    0x0250000000000A7C,
                    0x0250000000000A86,
                    0x0250000000000B4F,
                    0x0250000000000BE9,
                    0x0250000000000BEE,
                    0x0250000000000C1D,
                    0x0250000000000C24,
                    0x0250000000000C25,
                    0x0250000000000C26,
                    0x0250000000000C27,
                    0x0250000000000C28,
                    0x0250000000000C29,
                    0x0250000000000C2A,
                    0x0250000000000C2B,
                    0x0250000000000C2C,
                    0x0250000000000C2D,
                    0x0250000000000C2E,
                    0x0250000000000C2F,
                    0x0250000000000C30,
                    0x0250000000000C33,
                    0x0250000000000C34,
                    0x0250000000000C35,
                    0x0250000000000C36,
                    0x0250000000000C37,
                    0x0250000000000C38,
                    0x0250000000000C3A,
                    0x0250000000000C3F,
                    0x0250000000000C40,
                    0x0250000000000C41,
                    0x0250000000000C42,
                    0x0250000000000C43,
                    0x0250000000000C44,
                    0x0250000000000C45,
                    0x0250000000000C4A,
                    0x0250000000000C4B,
                    0x0250000000000C4C,
                    0x0250000000000C4D,
                    0x0250000000000C4E,
                    0x0250000000000C4F,
                    0x0250000000000C50,
                    0x0250000000000C51,
                    0x0250000000000C52,
                    0x0250000000000C53,
                    0x0250000000000C54,
                    0x0250000000000C55,
                    0x0250000000000C56,
                    0x0250000000000C57,
                    0x0250000000000C58,
                    0x0250000000000C59,
                    0x0250000000000C5A,
                    0x0250000000000C5B,
                    0x0250000000000C5C,
                    0x0250000000000C5D,
                    0x0250000000000C5E,
                    0x0250000000000C5F,
                    0x0250000000000C60,
                    0x0250000000000C61,
                    0x0250000000000C62,
                    0x0250000000000C63,
                    0x0250000000000C64,
                    0x0250000000000C65,
                    0x0250000000000C68,
                    0x0250000000000C69,
                    0x0250000000000C6A,
                    0x0250000000000C6C,
                    0x0250000000000C6D,
                    0x0250000000000C6E,
                    0x0250000000000C6F,
                    0x0250000000000C70,
                    0x0250000000000C71,
                    0x0250000000000C72,
                    0x0250000000000C73,
                    0x0250000000000C74,
                    0x0250000000000C75,
                    0x0250000000000C76,
                    0x0250000000000C77,
                    0x0250000000000C78,
                    0x0250000000000C79,
                    0x0250000000000C7A,
                    0x0250000000000C7B,
                    0x0250000000000C7C,
                    0x0250000000000C7F,
                    0x0250000000000C80,
                    0x0250000000000C81,
                    0x0250000000000C82,
                    0x0250000000000C86,
                    0x0250000000000C87,
                    0x0250000000000C89,
                    0x0250000000000C8A,
                    0x0250000000000C91,
                    0x0250000000000C92,
                    0x0250000000000C93,
                    0x0250000000000C94,
                    0x0250000000000C95,
                    0x0250000000000C96,
                    0x0250000000000C97,
                    0x0250000000000C98,
                    0x0250000000000C99,
                    0x0250000000000C9A,
                    0x0250000000000C9C,
                    0x0250000000000C9E,
                    0x0250000000000C9F,
                    0x0250000000000CA0,
                    0x0250000000000CA1,
                    0x0250000000000CA2,
                    0x0250000000000CA3,
                    0x0250000000000CA4,
                    0x0250000000000CA5,
                    0x0250000000000CA6,
                    0x0250000000000CA7,
                    0x0250000000000CA8,
                    0x0250000000000CAC,
                    0x0250000000000CAE,
                }
            }, {
                "winter2018",
                new ulong[] {
                    0x0250000000002496,
                    0x02500000000024C7,
                    0x025000000000250A,
                    0x02500000000019C3,
                    0x02500000000024F7,
                    0x02500000000024F4,
                    0x0250000000002460,
                    0x02500000000017D2,
                    0x0250000000002509,
                    0x0250000000002494,
                    0x02500000000024F0,
                    0x02500000000024F8,
                    0x02500000000024D9,
                    0x0250000000001A4A,
                    0x0250000000002506,
                    0x02500000000024FC,
                    0x0250000000002493,
                    0x02500000000024C6,
                    0x02500000000024F1,
                    0x0250000000002505,
                    0x025000000000194E,
                    0x0250000000002507,
                    0x0250000000001F4E,
                    0x02500000000024F2,
                    0x02500000000024FB,
                    0x0250000000002508,
                    0x0250000000001A4B,
                    0x02500000000024F6,
                    0x0250000000002490,
                    0x0250000000002483,
                    0x02500000000024F3,
                    0x0250000000002459,
                    0x0250000000002485,
                    0x0250000000002504,
                    0x02500000000024EE,
                    0x02500000000024EF,
                    0x0250000000002484,
                    0x0250000000002503,
                    0x02500000000024E1,
                    0x02500000000024F9,
                    0x02500000000024FA,
                    0x025000000000229A,
                    0x02500000000022C6,
                    0x0250000000002467,
                    0x02500000000024EC,
                    0x02500000000024ED,
                    0x025000000000250B,
                    0x025000000000250C,
                    0x025000000000250D,
                }
            }, {
                "winter2017",
                new ulong[] {
                    0x0250000000001039,
                    0x02500000000011BA,
                    0x025000000000123B,
                    0x025000000000123E,
                    0x0250000000001245,
                    0x0250000000001247,
                    0x0250000000001249,
                    0x025000000000124B,
                    0x025000000000124D,
                    0x0250000000001251,
                    0x0250000000001257,
                    0x025000000000125E,
                    0x0250000000001260,
                    0x0250000000001278,
                    0x025000000000127C,
                    0x02500000000012CE,
                    0x0250000000001331,
                    0x0250000000001332,
                    0x0250000000001333,
                    0x0250000000001334,
                    0x0250000000001335,
                    0x0250000000001336,
                    0x0250000000001337,
                    0x0250000000001338,
                    0x0250000000001339,
                    0x025000000000133A,
                    0x025000000000133B,
                    0x025000000000133C,
                    0x025000000000133D,
                    0x025000000000133E,
                    0x025000000000133F,
                    0x0250000000001340,
                    0x0250000000001341,
                    0x0250000000001342,
                    0x0250000000001343,
                    0x0250000000001344,
                    0x0250000000001345,
                    0x0250000000001346,
                    0x0250000000001347,
                    0x0250000000001348,
                    0x0250000000001349,
                    0x025000000000134A,
                    0x025000000000134B,
                    0x025000000000134E,
                    0x025000000000134F,
                    0x0250000000001391,
                    0x0250000000001392,
                    0x0250000000001393,
                    0x0250000000001394,
                    0x0250000000001395,
                    0x0250000000001396,
                    0x0250000000001398,
                    0x0250000000001399,
                    0x025000000000139A,
                    0x025000000000139B,
                    0x025000000000139C,
                    0x025000000000139D,
                    0x025000000000139E,
                    0x025000000000139F,
                    0x025000000000141D,
                }
            }, {
                "winter2016",
                new ulong[] {
                    0x0250000000000A8D,
                    0x0250000000000BF1,
                    0x0250000000000C31,
                    0x0250000000000C32,
                    0x0250000000000CF4,
                    0x0250000000000CF7,
                    0x0250000000000CF8,
                    0x0250000000000CF9,
                    0x0250000000000CFA,
                    0x0250000000000CFB,
                    0x0250000000000CFC,
                    0x0250000000000CFD,
                    0x0250000000000CFE,
                    0x0250000000000D01,
                    0x0250000000000D02,
                    0x0250000000000D06,
                    0x0250000000000D07,
                    0x0250000000000D08,
                    0x0250000000000D09,
                    0x0250000000000D0A,
                    0x0250000000000D0D,
                    0x0250000000000D0E,
                    0x0250000000000D0F,
                    0x0250000000000D10,
                    0x0250000000000D11,
                    0x0250000000000D12,
                    0x0250000000000D13,
                    0x0250000000000D14,
                    0x0250000000000D15,
                    0x0250000000000D16,
                    0x0250000000000D17,
                    0x0250000000000D18,
                    0x0250000000000D19,
                    0x0250000000000D1A,
                    0x0250000000000D1B,
                    0x0250000000000D1C,
                    0x0250000000000D1D,
                    0x0250000000000D1E,
                    0x0250000000000D1F,
                    0x0250000000000D20,
                    0x0250000000000D22,
                    0x0250000000000D23,
                    0x0250000000000D24,
                    0x0250000000000D27,
                    0x0250000000000D28,
                    0x0250000000000D29,
                    0x0250000000000D2A,
                    0x0250000000000D2B,
                    0x0250000000000D2C,
                    0x0250000000000D2D,
                    0x0250000000000D2E,
                    0x0250000000000D2F,
                    0x0250000000000D30,
                    0x0250000000000D31,
                    0x0250000000000D32,
                    0x0250000000000D33,
                    0x0250000000000D35,
                    0x0250000000000D36,
                    0x0250000000000D37,
                    0x0250000000000D38,
                    0x0250000000000D39,
                    0x0250000000000D3A,
                    0x0250000000000D3C,
                    0x0250000000000D3F,
                    0x0250000000000D40,
                    0x0250000000000D41,
                    0x0250000000000D43,
                    0x0250000000000D4C,
                    0x0250000000000D4D,
                    0x0250000000000D50,
                    0x0250000000000D51,
                    0x0250000000000D5F,
                    0x0250000000000D60,
                    0x0250000000000D61,
                    0x0250000000000D62,
                    0x0250000000000D63,
                    0x0250000000000D64,
                    0x0250000000000D65,
                    0x0250000000000D66,
                    0x0250000000000D67,
                    0x0250000000000D68,
                    0x0250000000000D69,
                    0x0250000000000D6A,
                    0x0250000000000D6B,
                    0x0250000000000D6C,
                    0x0250000000000D6D,
                    0x0250000000000D6E,
                    0x0250000000000D6F,
                    0x0250000000000D70,
                    0x0250000000000D71,
                    0x0250000000000D72,
                    0x0250000000000D73,
                    0x0250000000000D74,
                    0x0250000000000D75,
                    0x0250000000000D76,
                    0x0250000000000D7E,
                    0x0250000000000D7F,
                    0x0250000000000D80,
                    0x0250000000000D81,
                    0x0250000000000D82,
                    0x0250000000000D83,
                    0x0250000000000D84,
                    0x0250000000000D85,
                    0x0250000000000D86,
                    0x0250000000000D87,
                    0x0250000000000D88,
                    0x0250000000000D89,
                    0x0250000000000D8A,
                    0x0250000000000D8B,
                    0x0250000000000D8C,
                    0x0250000000000D8D,
                    0x0250000000000D8E,
                    0x0250000000000D8F,
                    0x0250000000000D90,
                    0x0250000000000D91,
                    0x0250000000000D92,
                    0x0250000000000D93,
                    0x0250000000000D94,
                    0x0250000000000E52,
                }
            }, {
                "lunar2018",
                new ulong[] {
                    0x025000000000120B,
                    0x025000000000124F,
                    0x0250000000001250,
                    0x025000000000125B,
                    0x025000000000125F,
                    0x0250000000001262,
                    0x025000000000127D,
                    0x0250000000001282,
                    0x0250000000001284,
                    0x025000000000142B,
                    0x0250000000001570,
                    0x0250000000001572,
                    0x0250000000001577,
                    0x02500000000015E7,
                    0x02500000000015E8,
                    0x02500000000015E9,
                    0x02500000000015EA,
                    0x02500000000015EB,
                    0x02500000000015EC,
                    0x02500000000015F9,
                    0x0250000000001628,
                    0x0250000000001629,
                    0x025000000000162A,
                    0x025000000000162B,
                    0x025000000000162C,
                    0x025000000000162D,
                    0x025000000000162E,
                    0x025000000000162F,
                    0x0250000000001630,
                    0x0250000000001631,
                    0x0250000000001632,
                    0x0250000000001633,
                    0x0250000000001634,
                    0x0250000000001635,
                    0x0250000000001636,
                    0x0250000000001637,
                    0x0250000000001638,
                    0x0250000000001639,
                    0x025000000000163A,
                    0x025000000000163B,
                    0x025000000000163C,
                    0x025000000000163D,
                    0x025000000000163E,
                    0x025000000000163F,
                    0x0250000000001640,
                    0x0250000000001641,
                    0x0250000000001642,
                    0x0250000000001643,
                    0x0250000000001644,
                    0x0250000000001645,
                    0x0250000000001646,
                    0x0250000000001647,
                    0x0250000000001648,
                    0x0250000000001649,
                    0x025000000000164A,
                    0x025000000000164B,
                    0x025000000000164C,
                    0x025000000000164D,
                    0x025000000000164E,
                    0x0250000000001650,
                    0x025000000000169C,
                    0x02500000000016A1,
                    0x02500000000016A2,
                }
            }, {
                "lunar2017",
                new ulong[] {
                    0x0250000000000A87,
                    0x0250000000000BEB,
                    0x0250000000000BF3,
                    0x0250000000000C1B,
                    0x0250000000000CFF,
                    0x0250000000000D53,
                    0x0250000000000D54,
                    0x0250000000000D55,
                    0x0250000000000D56,
                    0x0250000000000D58,
                    0x0250000000000D59,
                    0x0250000000000D5D,
                    0x0250000000000E4F,
                    0x0250000000000E54,
                    0x0250000000000E5D,
                    0x0250000000000E5F,
                    0x0250000000000E63,
                    0x0250000000000E93,
                    0x0250000000000E94,
                    0x0250000000000E95,
                    0x0250000000000E96,
                    0x0250000000000EA5,
                    0x0250000000000EAD,
                    0x0250000000000EAE,
                    0x0250000000000EB0,
                    0x0250000000000EB1,
                    0x0250000000000EB4,
                    0x0250000000000EBE,
                    0x0250000000000EC0,
                    0x0250000000000EC1,
                    0x0250000000000EC4,
                    0x0250000000000EC5,
                    0x0250000000000EC6,
                    0x0250000000000EC7,
                    0x0250000000000EC8,
                    0x0250000000000EC9,
                    0x0250000000000ECA,
                    0x0250000000000ECB,
                    0x0250000000000ECC,
                    0x0250000000000ECD,
                    0x0250000000000ECE,
                    0x0250000000000ECF,
                    0x0250000000000ED0,
                    0x0250000000000ED1,
                    0x0250000000000ED2,
                    0x0250000000000ED3,
                    0x0250000000000ED4,
                    0x0250000000000ED5,
                    0x0250000000000ED6,
                    0x0250000000000ED7,
                    0x0250000000000ED8,
                    0x0250000000000ED9,
                    0x0250000000000EDA,
                    0x0250000000000EDB,
                    0x0250000000000EDC,
                    0x0250000000000EDD,
                    0x0250000000000EDE,
                    0x0250000000000EDF,
                    0x0250000000000EE0,
                    0x0250000000000EE1,
                    0x0250000000000EE2,
                    0x0250000000000EE3,
                    0x0250000000000EE4,
                    0x0250000000000EE5,
                    0x0250000000000EE6,
                    0x0250000000000EE7,
                    0x0250000000000EE8,
                    0x0250000000000EE9,
                    0x0250000000000EEA,
                    0x0250000000000EEB,
                    0x0250000000000EEC,
                    0x0250000000000EED,
                    0x0250000000000EEE,
                    0x0250000000000EEF,
                    0x0250000000000EF0,
                    0x0250000000000EF1,
                    0x0250000000000EF2,
                    0x0250000000000EF3,
                    0x0250000000000EF4,
                    0x0250000000000EF5,
                    0x0250000000000EF6,
                    0x0250000000000EF7,
                    0x0250000000000EF8,
                    0x0250000000000EF9,
                    0x0250000000000EFA,
                    0x0250000000000EFB,
                    0x0250000000000EFC,
                    0x0250000000000EFD,
                    0x0250000000000EFF,
                    0x0250000000000F00,
                    0x0250000000000F01,
                    0x0250000000000F02,
                    0x0250000000000F03,
                    0x0250000000000F04,
                    0x0250000000000F05,
                    0x0250000000000F06,
                    0x0250000000000F07,
                    0x0250000000000F17,
                    0x0250000000000F4B,
                    0x0250000000000F4C,
                    0x0250000000000F4D,
                    0x0250000000000F4E,
                    0x0250000000000F4F,
                    0x0250000000000F50,
                    0x0250000000000F51,
                    0x0250000000000F52,
                    0x0250000000000F53,
                    0x0250000000000F54,
                    0x0250000000000F55,
                    0x0250000000000F56,
                    0x0250000000000F57,
                    0x0250000000000F58,
                    0x0250000000000F59,
                    0x0250000000000F5A,
                    0x0250000000000F5B,
                    0x0250000000000F5C,
                    0x0250000000000F5D,
                    0x0250000000000F5E,
                    0x0250000000000F61,
                    0x0250000000000F6D,
                    0x0250000000000F6F,
                }
            },
        };

        public static string GetTagFor(ulong guid) {
            return CuratedGUID.FirstOrDefault(x => x.Value.Contains(guid)).Key;
        }
    }
}