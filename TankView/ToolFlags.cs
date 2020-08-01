﻿using DataTool.Flag;

namespace TankView {
    public class ToolFlags : ICLIFlags {
        [CLIFlag(Default = null, Flag = "language", Help = "Language to load", NeedsValue = true, Valid = new[] { "deDE", "enUS", "esES", "esMX", "frFR", "itIT", "jaJP", "koKR", "plPL", "ptBR", "ruRU", "zhCN", "zhTW" })]
        [Alias("L")]
        [Alias("lang")]
        public string Language;

        [CLIFlag(Default = null, Flag = "speech-language", Help = "Speech Language to load", NeedsValue = true, Valid = new[] { "deDE", "enUS", "esES", "esMX", "frFR", "itIT", "jaJP", "koKR", "plPL", "ptBR", "ruRU", "zhCN", "zhTW" })]
        [Alias("T")]
        [Alias("speechlang")]
        public string SpeechLanguage;

        public override bool Validate() => true;
    }
}
