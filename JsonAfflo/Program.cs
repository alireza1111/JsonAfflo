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
            TopLevel items = JsonConvert.DeserializeObject<TopLevel>(json);
            for (int i = 0; i < items.Graph.Count; i++)
                Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5}", items.Graph[i].Uri.Segments[3], System.Guid.NewGuid(), items.Graph[i].PrefLabel[0].Value, items.Graph[i].PrefLabel[2].Value, items.Graph[i].Uri, "ALLFO"));
        }
    }

}
