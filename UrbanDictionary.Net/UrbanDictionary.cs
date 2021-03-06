﻿using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UrbanDictionaryNet.Models;
using static System.Web.HttpUtility;

namespace UrbanDictionaryNet
{
    /// <summary>
    /// A class for getting information from urbandictionary.com
    /// </summary>
    public static class UrbanDictionary
    {
        private const string APILink = "http://api.urbandictionary.com/v0/define?term=";

        /// <summary>
        /// If true, all the other methods in this class will throw an exception when there were no results
        /// </summary>
        public static bool ThrowOnNotFound { get; set; } = false;


        /// <summary>
        /// Gets an <see cref="UrbanResult"/> object for the provided term.
        /// </summary>
        /// <param name="term">The word to define.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task<UrbanResult> DefineAsync(string term, CancellationToken cancellationToken = default)
        {
            try
            {
                var encodedTerm = UrlEncode(term);
                var fullLink = string.Concat(APILink, term);

                var json = await fullLink.GetStringAsync(cancellationToken).ConfigureAwait(false);
                UrbanResult urbanResult = JsonConvert.DeserializeObject<UrbanResult>(json);

                if (ThrowOnNotFound && urbanResult.ResultType == "no_results")
                    throw new UrbanDictionaryException("Nothing was found");
                


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
        public static async Task<string> GetFirstDefinitionAsync(string term, CancellationToken cancellationToken = default)
        {
            try
            {
                var def = await DefineAsync(term, cancellationToken).ConfigureAwait(false);
                var defi = def.Definitions.FirstOrDefault()?.Definition;

                if (ThrowOnNotFound && string.IsNullOrWhiteSpace(defi))
                    throw new UrbanDictionaryException("Nothing was found");

                return defi;
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
