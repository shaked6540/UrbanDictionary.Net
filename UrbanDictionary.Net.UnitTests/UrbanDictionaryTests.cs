using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using UrbanDictionary.Net.Models;

namespace UrbanDictionary.Net.UnitTests
{
    [TestClass]
    public class UrbanDictionaryTests
    {
        [TestMethod]
        public async Task DefineAsyncTest()
        {
            string term = "test";
            var result = await UrbanDictionary.DefineAsync(term);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task FailDefineAsyncText()
        {
            string term = "aksjdfhlakjshdflkjsdhflkzjxhcvlzkjxchvlkzjsdhfolkajsdhflakjsdfhlaskjdfhlaskjdhflksjdhf";
            var result = await UrbanDictionary.DefineAsync(term);
            Assert.IsTrue(result.ResultType == "no_results");
        }

        [TestMethod]
        public async Task GetFirstDefeinitionAsyncTest()
        {
            string term = "test";
            var result = await UrbanDictionary.GetFirstDefinitionAsync(term);

            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }

        [TestMethod]
        public void DefineTest()
        {
            string term = "test";
            var result = UrbanDictionary.Define(term);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FailDefineTest()
        {
            string term = "aksjdfhlakjshdflkjsdhflkzjxhcvlzkjxchvlkzjsdhfolkajsdhflakjsdfhlaskjdfhlaskjdhflksjdhf";
            var result = UrbanDictionary.Define(term);
            Assert.IsTrue(result.ResultType == "no_results");
        }

        public void GetFirstDefinitionTest()
        {
            string term = "test";
            var result = UrbanDictionary.GetFirstDefinition(term);

            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }

    }


}
