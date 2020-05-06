using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

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
            /*            using StreamReader r = new StreamReader(@"C:\Users\xdaval\Documents\ALLFO\generalTerms.json");
                        string json = r.ReadToEnd();
                        TopLevel items = JsonConvert.DeserializeObject<TopLevel>(json);*/


            JsonSerializer serializer = new JsonSerializer();
            TopLevel items = new TopLevel();
            using (FileStream s = File.Open(@"C:\Users\xdaval\Documents\ALLFO\generalTerms.json", FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    // deserialize only when there's "{" character in the stream
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        items = serializer.Deserialize<TopLevel>(reader);
                    }
                }
            }

            for (int i = 0 ; i < items.Graph.Count; i++)
                if (items.Graph[i].PrefLabel != null)
                Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5}", items.Graph[i].Uri.Segments[3], System.Guid.NewGuid(), items.Graph[i].PrefLabel.Select(s => s.Lang.Value.Equals("en").).FirstOrDefault(), items.Graph[i].PrefLabel.Where(w => w.Lang.Value.Equals("sv")).Select(s => s.Value).FirstOrDefault(), items.Graph[i].Uri, "ALLFO"));
        }
    }

}
