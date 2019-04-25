using System;
using System.Collections.Generic;
using System.Text;
using Sciendo.Config;

namespace WIE
{
    public class WieConfig
    {
        [ConfigProperty("input")]
        public string InputFile { get; set; }

        [ConfigProperty("output")]
        public string OutputFile { get; set; }

        [ConfigProperty("do")]
        public ProcessType ProcessType { get; set; }

        public string SimpleWordsSeparator => " ";
    }
}
