using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonAfflo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoadJson();
          //  Console.WriteLine(items..)
        }

        public static void LoadJson()
        {
            using StreamReader r = new StreamReader(@"C:\Users\xdaval\Documents\ALLFO\generalTerms.json");
            string json = r.ReadToEnd();
            List<Context> items = JsonConvert.DeserializeObject<List<Context>>(json);
        }
    }

}
