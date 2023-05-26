using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.csv2json
{
    static internal class Util
    {
        public static List<dynamic> Convert2Json(string input)
        {   
            char SEPARATOR = ',';
            var objects = new List<dynamic>();
            var rows = input.Split('\n').ToList();
            var headers = rows[0].Split(SEPARATOR);
            rows.RemoveAt(0);

            foreach (var row in rows)
            {
                var values = row.Split(SEPARATOR);
                dynamic obj = new ExpandoObject();
                var dict = (IDictionary<string, object>)obj;
                for (int i = 0; i < headers.Length; i++)
                {
                    dict[headers[i]] = values[i];
                }
                objects.Add(obj);
            }
            return objects;
        }
    }
}
