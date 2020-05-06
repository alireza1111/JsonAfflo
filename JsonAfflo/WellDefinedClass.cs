using System;
using System.Collections.Generic;
using System.Text;

namespace JsonAfflo
{
    public sealed class WellDefinedClass
    {
        public string ExternalId { get; set; }
        public Guid Uuid { get; set; }
        public string Slug { get; set; }
        public string TextEn { get; set; }
        public string TextSv { get; set; }
        public string Uri { get; set; }
        public string Vocabulary { get; set; }
    }
}
