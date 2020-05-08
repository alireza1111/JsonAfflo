using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Globalization;

namespace JsonAfflo
{
    public class Program
    {
        public static void Main(string[] args)
        {
          //  LoadJson();
            LoadUpTerms();
        }

        private static void LoadUpTerms()
        {
            var ut = new UpTerms();
            var items = LoadJsonUp();
            for(int i=0; i<=items.Types.Count; i++)
            {
                Console.WriteLine(ut.Types[i].Enum.Value);
            }

        }

        public static UpTerms LoadJsonUp()
        {
            JsonSerializer serializer = new JsonSerializer();
            UpTerms items = new UpTerms();
            using (FileStream s = File.Open(@"C:\Users\xdaval\Documents\ALLFO\upp.json", FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    // deserialize only when there's "{" character in the stream
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        items = serializer.Deserialize<UpTerms>(reader);
                    }
                }
            }
            return items;
        }
            public static void LoadJson()
        {
            JsonSerializer serializer = new JsonSerializer();
            Terms items = new Terms();
            using (FileStream s = File.Open(@"C:\Users\xdaval\Documents\ALLFO\generalTerms.json", FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    // deserialize only when there's "{" character in the stream
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        items = serializer.Deserialize<Terms>(reader);
                    }
                }
            }

            for (int i = 0 ; i < items.Graph.Count; i++)
            {
                if (items.Graph[i].PrefLabel != null)
                    Console.WriteLine(string.Format("INSERT INTO KEYWORD (external_id, uuid, slug, text_en, text_sv, uri, vocabulary) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ON CONFLICT (slug,vocabulary) DO UPDATE SET slug = keyword.slug || 0;", 
                                                                           GetObject(items, i).ExternalId,
                                                                           GetObject(items, i).Uuid,
                                                                           GetObject(items, i).Slug,
                                                                           GetObject(items, i).TextEn,
                                                                           GetObject(items, i).TextSv,
                                                                           GetObject(items, i).Uri,
                                                                           GetObject(items, i).Vocabulary));
/*                if (items.Graph[i].SkosMember != null)
                    Console.WriteLine(string.Format("INSERT INTO KEYWORD_STRUCTURE (parent_keyword, child_keyword) values({0},{1});", GetParentId(items, i)))*/

            }

        }


        private static WellDefinedClass GetObject(Terms items, int i)
        {
            return new WellDefinedClass
            {
                ExternalId = items.Graph[i].Uri.Segments[3],
                TextEn = items.Graph[i].PrefLabel.Where(w => w.Lang.Equals(JsonAfflo.Lang.En)).Select(s => s.Value).FirstOrDefault() != null ? items.Graph[i].PrefLabel.Where(w => w.Lang.Equals(JsonAfflo.Lang.En)).Select(s => s.Value).FirstOrDefault(): items.Graph[i].PrefLabel.Where(w => w.Lang.Equals(JsonAfflo.Lang.Sv)).Select(s => s.Value).FirstOrDefault(),
                TextSv = items.Graph[i].PrefLabel.Where(w => w.Lang.Equals(JsonAfflo.Lang.Sv)).Select(s => s.Value).FirstOrDefault(),
                Uri = items.Graph[i].Uri.AbsoluteUri,
                Uuid = Guid.NewGuid(),
                Slug = items.Graph[i].PrefLabel.Where(w => w.Lang.Equals(JsonAfflo.Lang.En)).Select(s => s.Value).FirstOrDefault() != null ? GenerateSlug(items.Graph[i].PrefLabel.Where(w => w.Lang.Equals(JsonAfflo.Lang.En)).Select(s => s.Value).FirstOrDefault()) : GenerateSlug(items.Graph[i].PrefLabel.Where(w => w.Lang.Equals(JsonAfflo.Lang.Sv)).Select(s => s.Value).FirstOrDefault()),
                Vocabulary = "ALLFO"
            };
        }

        public static string GenerateSlug(string phrase)
        {
            string str = RemoveDiacritics(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }

}
