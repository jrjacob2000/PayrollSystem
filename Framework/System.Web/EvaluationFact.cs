using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace System.Web
{
    [DataContract]
    public class EvaluationFact : Dictionary<string, string>
    {
        public string GetValue(string key)
        {
            return this[key];
        }
    }
}