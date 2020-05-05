using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonAfflo
{
    public class Context
    {
        public string skos { get; set; }
        public string isothes { get; set; }
        public string rdfs { get; set; }
        public string owl { get; set; }
        public string dct { get; set; }
        public string dc11 { get; set; }
        public string uri { get; set; }
        public string type { get; set; }
        public string lang { get; set; }
        public string value { get; set; }
        public string graph { get; set; }
        public string label { get; set; }
        public string prefLabel { get; set; }
        public string altLabel { get; set; }
        public string hiddenLabel { get; set; }
        public string broader { get; set; }
        public string narrower { get; set; }
        public string related { get; set; }
        public string inScheme { get; set; }
        public string exactMatch { get; set; }
        public string closeMatch { get; set; }
        public string broadMatch { get; set; }
        public string narrowMatch { get; set; }
        public string relatedMatch { get; set; }
    }

    public class PrefLabel
    {
        public string lang { get; set; }
        public string value { get; set; }
    }

    public class HttpWwwYsoFiOntoYsoMeta20070302DeprecatedHasThematicGroup
    {
        public string uri { get; set; }
    }

    public class SkosMember
    {
        public string uri { get; set; }
    }

    public class Graph
    {
        public string uri { get; set; }
        public IList<string> type { get; set; }
        public IList<PrefLabel> prefLabel { get; set; }
/*        public HttpWwwYsoFiOntoYsoMeta20070302DeprecatedHasThematicGroup http://www.yso.fi/onto/yso-meta/2007-03-02/deprecatedHasThematicGroup { get; set; }*/
        public IList<SkosMember> skosmember { get; set; }
}

public class GeneralTerms
{
        public Context @context { get; set; }
        public IList<Graph> graph { get; set; }
}

}
