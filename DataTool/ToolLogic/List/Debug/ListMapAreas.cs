using System;
using System.Collections.Generic;
using DataTool.DataModels;
using DataTool.Flag;
using DataTool.Helper;
using DataTool.JSON;
using TankLib;
using TankLib.STU.Types;
using static DataTool.Program;
using static DataTool.Helper.Logger;
using static DataTool.Helper.STUHelper;
using static DataTool.Helper.IO;
using System.IO;
using DataTool.SaveLogic;
using System.Linq;
using System.Text;

namespace DataTool.ToolLogic.List
{
    [Tool("list-map-areas", Description = "List map areas", CustomFlags = typeof(ListFlags))]
    public class ListMapAreas : JSONTool, ITool
    {
        public void Parse(ICLIFlags toolFlags)
        {
            var flags = (ListFlags)toolFlags;
            Dictionary<teResourceGUID, MapHeader> maps = GetMaps();

            /*if (flags.JSON) {
                OutputJSON(maps, flags);
                return;
            }*/

            var iD = new IndentHelper();
            List<temp> outData = new List<temp>();
            foreach (var map in maps)
            {
                STUMapHeader mapHeader = GetInstance<STUMapHeader>(map.Key);
                if (mapHeader == null) continue;

                MapHeader mapInfo = map.Value;
                mapInfo.Name = mapInfo.Name ?? "Title Screen";
                FindLogic.Combo.ComboInfo info = new FindLogic.Combo.ComboInfo();
                LoudLog("\tFinding");
                FindLogic.Combo.Find(info, mapHeader.m_map);

                for (int i = 0; i < mapHeader.m_D97BC44F.Length; i++)
                {
                    var variantModeInfo = mapHeader.m_D97BC44F[i];
                    var variantResultingMap = mapHeader.m_78715D57[i];
                    var variantGUID = variantResultingMap.m_BF231F12;

                    using (Stream stream = OpenFile(variantGUID))
                    {
                        if (stream == null)
                        {
                            // not shipping
                            continue;
                        }
                    }

                    string variantName = Map.GetVariantName(variantModeInfo, variantResultingMap);

                    teMapPlaceableData placeableAreas = Map.GetPlaceableData(mapHeader, variantGUID, Enums.teMAP_PLACEABLE_TYPE.AREA);

                    LoudLog($"{mapInfo.Name} ({variantName}) {placeableAreas.Header.PlaceableCount}");

                    int areaIndex = 1;
                    Dictionary<int, teMapPlaceableArea.Box[]> boxData = new Dictionary<int, teMapPlaceableArea.Box[]>();

                    foreach (teMapPlaceableArea areaPlaceable in placeableAreas.Placeables) {
                        LoudLog($"{areaPlaceable.Header.BoxCount} boxes");

                        boxData.Add(areaIndex, areaPlaceable.Boxes);

                        foreach (teMapPlaceableArea.Box box in areaPlaceable.Boxes) {
                            LoudLog($"\tOrientation: {box.Orientation}");
                            LoudLog($"\tTranslation: {box.Translation}");
                            LoudLog($"\tExtents: {box.Extents}");
                            LoudLog($"\tidfk: {box.Unknown}");
                            LoudLog($"");
                        }

                        areaIndex++;
                    }

                    outData.Add(new temp($"{mapInfo.Name} ({variantName})", placeableAreas.Header.PlaceableCount, boxData));
                }
            }

            OutputJSON(outData, flags);
        }

        public static MapHeader GetMap(ulong key)
        {
            var map = GetInstance<STUMapHeader>(key);
            if (map == null) return null;

            return new MapHeader(map, key);
        }

        public Dictionary<teResourceGUID, MapHeader> GetMaps()
        {
            Dictionary<teResourceGUID, MapHeader> @return = new Dictionary<teResourceGUID, MapHeader>();

            foreach (teResourceGUID key in TrackedFiles[0x9F])
            {
                MapHeader map = GetMap(key);
                if (map == null) continue;

                @return[key] = map;
            }

            return @return;
        }

        private struct temp {
            public temp(string mapName, uint placeableCount, Dictionary<int, teMapPlaceableArea.Box[]> areas) {
                MapName = mapName;
                PlaceableCount = PlaceableCount;
                Areas = areas;
            }

            public string MapName { get; set; }
            public uint PlaceableCount { get; set; }
            public Dictionary<int, teMapPlaceableArea.Box[]> Areas { get; set; }
        }
    }
}
