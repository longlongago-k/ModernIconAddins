using ModernIconLib.Asset.Icon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ModernIconLib.CodeList
{
    /// <summary>
    /// GoogleMaterial icons のcodepointファイルを内部形式(CSV)に変換するクラス
    /// </summary>
    public class GoogleMaterialIconCodeListReader
    {
        public static IconCode[] ReadFromFile(string filename)
        {
            return ReadFromString(File.ReadAllText(filename));
        }
        public static IconCode[] ReadFromString(string txt)
        {
            return txt.Split('\r', '\n')
            .Select(line => line.Split(' ')).Where(line => line.Length == 2)
            .Select(line => new IconCode(line[1].Trim(), int.Parse(line[0], System.Globalization.NumberStyles.HexNumber),
            line[2].Split(';'),
            line[3].Split(';')
            ))
            .ToArray();
        }
        public static IconCode[] ReadFromCsvString(string txt)
        {
            return txt.Split('\r', '\n')
            .Skip(1)//skip header
            .Select(line => line.Split(',')).Where(line => line.Length == 4)
            .Select(line => new IconCode( line[1].Trim(), int.Parse(line[0], System.Globalization.NumberStyles.HexNumber),
            string.IsNullOrEmpty(line[2]) ? Array.Empty<string>() : line[2].Split(';'),
            string.IsNullOrEmpty(line[3]) ? Array.Empty<string>() : line[3].Split(';')
            ))
            .ToArray();
        }
        public static IconCode[] ReadFromUrl(Uri url)
        {
            WebClient wc = new WebClient();
            string txt = wc.DownloadString(url);
            return ReadFromString(txt);

        }
        public static string DownloadFromUrl(Uri url)
        {
            WebClient wc = new WebClient();
            string txt = wc.DownloadString(url);
            return txt;

        }
    }
}
