﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var topLevel = TopLevel.FromJson(jsonString);

namespace JsonAfflo
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;


    public partial class Terms
    {
        [JsonProperty("@context", NullValueHandling = NullValueHandling.Ignore)]
        public Context Context { get; set; }

        [JsonProperty("graph", NullValueHandling = NullValueHandling.Ignore)]
        public List<Graph> Graph { get; set; }
    }

    public partial class Context
    {
        [JsonProperty("skos", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Skos { get; set; }

        [JsonProperty("isothes", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Isothes { get; set; }

        [JsonProperty("rdfs", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Rdfs { get; set; }

        [JsonProperty("owl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Owl { get; set; }

        [JsonProperty("dct", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Dct { get; set; }

        [JsonProperty("dc11", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Dc11 { get; set; }

        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("lang", NullValueHandling = NullValueHandling.Ignore)]
        public string Lang { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("graph", NullValueHandling = NullValueHandling.Ignore)]
        public string Graph { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("prefLabel", NullValueHandling = NullValueHandling.Ignore)]
        public string PrefLabel { get; set; }

        [JsonProperty("altLabel", NullValueHandling = NullValueHandling.Ignore)]
        public string AltLabel { get; set; }

        [JsonProperty("hiddenLabel", NullValueHandling = NullValueHandling.Ignore)]
        public string HiddenLabel { get; set; }

        [JsonProperty("broader", NullValueHandling = NullValueHandling.Ignore)]
        public string Broader { get; set; }

        [JsonProperty("narrower", NullValueHandling = NullValueHandling.Ignore)]
        public string Narrower { get; set; }

        [JsonProperty("related", NullValueHandling = NullValueHandling.Ignore)]
        public string Related { get; set; }

        [JsonProperty("inScheme", NullValueHandling = NullValueHandling.Ignore)]
        public string InScheme { get; set; }

        [JsonProperty("exactMatch", NullValueHandling = NullValueHandling.Ignore)]
        public string ExactMatch { get; set; }

        [JsonProperty("closeMatch", NullValueHandling = NullValueHandling.Ignore)]
        public string CloseMatch { get; set; }

        [JsonProperty("broadMatch", NullValueHandling = NullValueHandling.Ignore)]
        public string BroadMatch { get; set; }

        [JsonProperty("narrowMatch", NullValueHandling = NullValueHandling.Ignore)]
        public string NarrowMatch { get; set; }

        [JsonProperty("relatedMatch", NullValueHandling = NullValueHandling.Ignore)]
        public string RelatedMatch { get; set; }
    }

    public partial class Graph
    {
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Uri { get; set; }

/*        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public List<TypeElement> Type { get; set; }*/

        [JsonProperty("prefLabel", NullValueHandling = NullValueHandling.Ignore)]
        public List<PrefLabel> PrefLabel { get; set; }

/*        [JsonProperty("http://www.yso.fi/onto/yso-meta/2007-03-02/deprecatedHasThematicGroup", NullValueHandling = NullValueHandling.Ignore)]
        public HttpWwwYsoFiOntoYsoMeta20070302_DeprecatedHasThematicGroup HttpWwwYsoFiOntoYsoMeta20070302DeprecatedHasThematicGroup { get; set; }*/

        [JsonProperty("skos:member", NullValueHandling = NullValueHandling.Ignore)]
        public List<HttpWwwYsoFiOntoYsoMeta20070302_DeprecatedHasThematicGroup> SkosMember { get; set; }
    }

    public partial class HttpWwwYsoFiOntoYsoMeta20070302_DeprecatedHasThematicGroup
    {
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Uri { get; set; }
    }

    public partial class PrefLabel
    {
        [JsonProperty("lang", NullValueHandling = NullValueHandling.Ignore)]
        public Lang? Lang { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    public enum Lang { En, Fi, Sv };

    public enum TypeEnum { IsothesConceptGroup, SkosCollection, SkosConcept };

    public partial struct TypeElementUP
    {
        public TypeEnum? Enum;
        public Uri PurpleUri;

        public static implicit operator TypeElementUP(TypeEnum Enum) => new TypeElementUP { Enum = Enum };
        public static implicit operator TypeElementUP(Uri PurpleUri) => new TypeElementUP { PurpleUri = PurpleUri };
    }

    public partial class TopLevel
    {
        public static TopLevel FromJson(string json) => JsonConvert.DeserializeObject<TopLevel>(json, JsonAfflo.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this TopLevel self) => JsonConvert.SerializeObject(self, JsonAfflo.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                LangConverter.Singleton,
                TypeElementConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class LangConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Lang) || t == typeof(Lang?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "en":
                    return Lang.En;
                case "fi":
                    return Lang.Fi;
                case "sv":
                    return Lang.Sv;
            }
            throw new Exception("Cannot unmarshal type Lang");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Lang)untypedValue;
            switch (value)
            {
                case Lang.En:
                    serializer.Serialize(writer, "en");
                    return;
                case Lang.Fi:
                    serializer.Serialize(writer, "fi");
                    return;
                case Lang.Sv:
                    serializer.Serialize(writer, "sv");
                    return;
            }
            throw new Exception("Cannot marshal type Lang");
        }

        public static readonly LangConverter Singleton = new LangConverter();
    }

    internal class TypeElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeElementUP) || t == typeof(TypeElementUP?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "isothes:ConceptGroup":
                            return new TypeElementUP { Enum = TypeEnum.IsothesConceptGroup };
                        case "skos:Collection":
                            return new TypeElementUP { Enum = TypeEnum.SkosCollection };
                        case "skos:Concept":
                            return new TypeElementUP { Enum = TypeEnum.SkosConcept };
                    }
                    try
                    {
                        var uri = new Uri(stringValue);
                        return new TypeElementUP { PurpleUri = uri };
                    }
                    catch (UriFormatException) { }
                    break;
            }
            throw new Exception("Cannot unmarshal type TypeElement");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (TypeElementUP)untypedValue;
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case TypeEnum.IsothesConceptGroup:
                        serializer.Serialize(writer, "isothes:ConceptGroup");
                        return;
                    case TypeEnum.SkosCollection:
                        serializer.Serialize(writer, "skos:Collection");
                        return;
                    case TypeEnum.SkosConcept:
                        serializer.Serialize(writer, "skos:Concept");
                        return;
                }
            }
            if (value.PurpleUri != null)
            {
                serializer.Serialize(writer, value.PurpleUri.ToString());
                return;
            }
            throw new Exception("Cannot marshal type TypeElement");
        }

        public static readonly TypeElementConverter Singleton = new TypeElementConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "isothes:ConceptGroup":
                    return TypeEnum.IsothesConceptGroup;
                case "skos:Collection":
                    return TypeEnum.SkosCollection;
                case "skos:Concept":
                    return TypeEnum.SkosConcept;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.IsothesConceptGroup:
                    serializer.Serialize(writer, "isothes:ConceptGroup");
                    return;
                case TypeEnum.SkosCollection:
                    serializer.Serialize(writer, "skos:Collection");
                    return;
                case TypeEnum.SkosConcept:
                    serializer.Serialize(writer, "skos:Concept");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}