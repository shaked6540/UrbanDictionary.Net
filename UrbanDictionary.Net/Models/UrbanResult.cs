using Newtonsoft.Json;
using System.Collections.Generic;

namespace UrbanDictionaryNet.Models
{
    public class UrbanResult
    {
        /// <summary>
        /// The tags associated with the term
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// The type of the results
        /// </summary>
        [JsonProperty("result_type")]
        public string ResultType { get; set; }

        /// <summary>
        /// A list of different definitions of the term
        /// </summary>
        [JsonProperty("list")]
        public List<UrbanDefinition> Definitions { get; set; }

        /// <summary>
        /// A list of links to sound files related to the term
        /// </summary>
        [JsonProperty("sounds")]
        public List<string> Sounds { get; set; }
    }
}
