using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace UrbanDictionary.Net.Models
{

    [Serializable]
    public class UrbanDictionaryException : Exception
    {
        public UrbanDictionaryException() { }
        public UrbanDictionaryException(string message) : base(message) { }
        public UrbanDictionaryException(string message, Exception inner) : base(message, inner) { }
        protected UrbanDictionaryException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }
    }
}
