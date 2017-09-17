﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using STULib;
using STULib.Types;
using static DataTool.Program;
using static DataTool.Helper.IO;

namespace DataTool.Helper {
    public class STUHelper {
        public static string GetDescriptionString(ulong key) {
            STUDescription description = GetInstance<STUDescription>(key);
            return GetString(description?.String);
        }
        
        public static ISTU OpenSTUSafe(ulong key) {
            using (Stream stream = OpenFile(key)) {
                if (stream == null) {
                    return null;
                }
                return ISTU.NewInstance(stream, BuildVersion);
            }
        }

        public static T[] GetInstances<T>(ulong key) {
            ISTU stu = OpenSTUSafe(key);
            if(stu == null) {
                return new T[0];
            }
            return stu.Instances.OfType<T>().ToArray();
        }

        public static T GetInstance<T>(ulong key) {
            ISTU stu = OpenSTUSafe(key);
            if(stu == null) {
                return null;
            }
            return stu.Instances.OfType<T>().FirstOrDefault();
        }
    }
}
