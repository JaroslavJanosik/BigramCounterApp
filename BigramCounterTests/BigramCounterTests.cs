using System;
using System.Collections.Generic;
using BigramParseApp;
using Xunit;

namespace BigramCounterTests
{
    public class BigramCounterTests
    {
        Dictionary<string, int> bigramTestCollection;
        public BigramCounterTests()
        {
            bigramTestCollection = new Dictionary<string, int>()
            {
                { "the quick", 2 },
                { "quick blue", 1 },
                { "blue hare", 1 },
                { "fox and", 1 },
                { "quick brown", 1 },
                { "and the", 1 },
                { "brown fox", 1 }
            };
        }

        [Fact]
        public void ThrowsExceptionIfEmptyStringOrNull()
        {
            Assert.Throws<Exception>(() => BigramCounter.CountBigrams(""));            
        }        

        [Fact]
        public void CountsZeroBigramForOneWord()
        {
            var testCollection = new Dictionary<string, int>() {};
            var result = BigramCounter.CountBigrams("The");

            Assert.Equal(testCollection, result);
        }

        [Fact]
        public void CountsOneBigramForTwoWords()
        {
            var testCollection = new Dictionary<string, int>() 
            {
                { "the quick", 1 }
            };
            var result = BigramCounter.CountBigrams("The quick");

            Assert.Equal(testCollection, result);
        }

        [Fact]
        public void CountsProperlyForBasicSentence()
        {
            var result = BigramCounter.CountBigrams("The quick brown fox and the quick blue hare.");
            Assert.Equal(bigramTestCollection, result);
        }

        [Fact]
        public void CountsProperlyIfInputContainsSpecChars()
        {
            var result = BigramCounter.CountBigrams("   \t~!@The #quick$%^  &*(  \nbrown45 fo)x _and \rthe quick +{b;l'u\\e} hare??\n\n    ");
            Assert.Equal(bigramTestCollection, result);
        }
    }
}
