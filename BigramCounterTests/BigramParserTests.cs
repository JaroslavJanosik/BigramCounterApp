using BigramParseApp;
using Xunit;

namespace BigramCounterTests
{
    public class BigramParserTests
    {
        string[] wordArray;

        public BigramParserTests()
        {
           wordArray = new string[] { "the", "quick", "brown", "fox", "and", "the", "quick", "blue", "hare" };
        }

        [Fact]
        public void CreateArrayIfInputIsEmptyString()
        {
            string[] result = BigramCounter.ParseTextIntoWords("");
            Assert.Equal(1, result.Length);
        }

        [Fact]
        public void CreateArrayForInputString()
        {
            string[] result = BigramCounter.ParseTextIntoWords("The quick brown fox and the quick blue hare.");
            Assert.Equal(wordArray, result);
        }

        [Fact]
        public void CreateArrayIfInputStringContainSpecChars()
        {
            string[] result = BigramCounter.ParseTextIntoWords("   \t~!@The #quick$%^  &*(  \nbrown45 fo)x _and \rthe quick +{b;l'u\\e} hare??\n\n    ");
            Assert.Equal(wordArray, result);
        }
    }
}
