using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder.Cli
{
    internal class Options
    {
        [Option('j', "jwt", Required = false, HelpText = "Decode JWT token.")]
        public string Jwt { get; set; }

        [Option('b', "base64", Required = false, HelpText = "Decode base64 string.")]
        public string Base64 { get; set; }

        [Option('u', "url", Required = false, HelpText = "Decode url string.")]
        public string Url { get; set; }

        [Option('e', "encode", Required = false, HelpText = "Flips decode to encode where possible.")]
        public bool Encode { get; set; }
    }
}
