using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UrbanDictionary.Net.Models;
using static System.Web.HttpUtility;

namespace UrbanDictionary.Net
{
    public static class UrbanDictionary
    {
        private const string APILink = "http://api.urbandictionary.com/v0/define?term=";

        /// <summary>
        /// Gets an <see cref="UrbanResult"/> object for the provided term.
        /// </summary>
        /// <param name="term">The word to define.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task<UrbanResult> DefineAsync(string term, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var encodedTerm = UrlEncode(term);
                var fullLink = string.Concat(APILink, term);

                var json = await fullLink.GetStringAsync(cancellationToken).ConfigureAwait(false);
                UrbanResult urbanResult = JsonConvert.DeserializeObject<UrbanResult>(json);

                return urbanResult;
            }
            catch (Exception ex)
            {
                throw new UrbanDictionaryException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gets a string that defines the provided term.
        /// </summary>
        /// <param name="term">The word to define.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task<string> GetFirstDefinitionAsync(string term, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var def = await DefineAsync(term, cancellationToken).ConfigureAwait(false);
                return def.Definitions.FirstOrDefault().Definition;
            }
            catch (Exception ex)
            {
                throw new UrbanDictionaryException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gets an <see cref="UrbanResult"/> object for the provided term.
        /// </summary>
        /// <param name="term">The word to define.</param>
        /// <returns>An <see cref="UrbanResult"/> object for the matching term</returns>
        public static UrbanResult Define(string term) => AsyncHelper.RunSync(async () => await DefineAsync(term));


        /// <summary>
        /// Gets a string containing the first definition of the provided term.
        /// </summary>
        /// <param name="term">The word to define.</param>
        /// <returns>A string containing the first definition of the provided term.</returns>
        public static string GetFirstDefinition(string term)=> Define(term).Definitions.FirstOrDefault().Definition;
        


    }
}
