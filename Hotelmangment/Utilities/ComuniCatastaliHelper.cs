using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hotel.Utilities
{
    public static class ComuniCatastaliHelper
    {
        private static Dictionary<string, string> codiciCatastali;

        static ComuniCatastaliHelper()
        {
            CaricaCodiciCatastali();
        }

        private static void CaricaCodiciCatastali()
        {
            codiciCatastali = new Dictionary<string, string>();

            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "comuniitaliani.csv");

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');

                if (parts.Length >= 2)
                {
                    var comune = parts[0].Trim();
                    var codiceCatastale = parts[1].Trim();

                    if (!codiciCatastali.ContainsKey(comune))
                    {
                        codiciCatastali.Add(comune, codiceCatastale);
                    }
                }
            }
        }

        public static string GetCodiceCatastale(string comune)
        {
            if (codiciCatastali.TryGetValue(comune, out string codice))
            {
                return codice;
            }

            throw new ArgumentException("Comune non valido");
        }
    }
}
