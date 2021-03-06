﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using JsonAfflo;
//
//    var upTerms = UpTerms.FromJson(jsonString);
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonAfflo
{
public partial class UpTerms
    {
        [JsonProperty("@context", NullValueHandling = NullValueHandling.Ignore)]
        public Context Context { get; set; }

        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
        public List<TypeElementUP> Types { get; set; }
    }

    public partial class UpContext
    {
        [JsonProperty("skos", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Skos { get; set; }

        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("rdfs", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Rdfs { get; set; }

        [JsonProperty("onki", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Onki { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("superclass", NullValueHandling = NullValueHandling.Ignore)]
        public Superclass Superclass { get; set; }

        [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
        public string Types { get; set; }

        [JsonProperty("@language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("@base", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Base { get; set; }
    }

    public partial class Superclass
    {
        [JsonProperty("@id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("@type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}

