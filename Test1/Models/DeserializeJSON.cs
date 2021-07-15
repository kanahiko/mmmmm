using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Models
{
    public class DeserializeJSON
    {
        public static List<CodeValue> DeserializeToCodeValue(IEnumerable<Dictionary<string, string>> json)
        {
            List<CodeValue> codes = new List<CodeValue>();
            foreach(var item in json)
            {
                if (item.Count() > 0)
                {
                    foreach(var dicItem in item)
                    {
                        int code = 0;
                        if ( int.TryParse(dicItem.Key, out code))
                        {
                            codes.Add(new CodeValue() { code = code, Value = dicItem.Value });
                        }
                    }
                }
            }

            return codes;
        }
    }
}
