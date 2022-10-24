using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernIconLib.Asset.Icon
{
    public class IconCode
    {
        public string Name { get; set; }
        public int Code { get; set; } = 0;
        public string[] Cateogy { get; set; }
        public string[] Tags { get; set; }
        public string CharString => Char.ConvertFromUtf32(Code);

        public IconCode()
        {

        }
        public IconCode(string name, int code, string[] category, string[] tags)
        {
            Name = name;
            Code = code;
            Cateogy = category;
            Tags = tags;
        }


        public override string ToString()
        {
            return $"{Name}({Code:X})";
        }
    }
}
