using Newtonsoft.Json;

namespace UrbanDictionaryNet.Models
{
    public class UrbanDefinition
    {
        /// <summary>
        /// The unique id of the definition
        /// </summary>
        [JsonProperty("defid")]
        public ulong DefinitionId { get; set; }

        /// <summary>
        /// The word that was defined
        /// </summary>
        [JsonProperty("word")]
        public string Word { get; set; }

        /// <summary>
        /// The author of the definition
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// A permanent link to the definition
        /// </summary>
        [JsonProperty("permalink")]
        public string PermaLink { get; set; }

        /// <summary>
        /// The definition of the <see cref="Word"/>
        /// </summary>
        [JsonProperty("definition")]
        public string Definition { get; set; }

        /// <summary>
        /// An example of how the word can be used in a sentence
        /// </summary>
        [JsonProperty("example")]
        public string Example { get; set; }

        /// <summary>
        /// The amount of thumbs up this definition recieved
        /// </summary>
        [JsonProperty("thumbs_up")]
        public int ThumbsUp { get; set; }

        /// <summary>
        /// The amount of thumbs down this definition recieved
        /// </summary>
        [JsonProperty("thumbs_down")]
        public int ThumbsDown { get; set; }

        [JsonProperty("current_vote")]
        public int? CurrentVote { get; set; }
    }
}
