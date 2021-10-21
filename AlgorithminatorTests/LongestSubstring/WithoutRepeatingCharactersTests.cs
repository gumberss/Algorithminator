using Algorithminator.LongestSubstring;
using Shouldly;
using System;
using Xunit;

namespace AlgorithminatorTests.LongestSubstring
{
    
    public class WithoutRepeatingCharactersTests
    {
        private readonly WithoutRepeatingCharacters _service;

        public WithoutRepeatingCharactersTests()
        {
            _service = new WithoutRepeatingCharacters();
        }

        [Theory]
        [InlineData("abcabcbb", "abc")]
        [InlineData("zzzabcdzzz", "zabcd")]
        public void Should_return_the_correct_sequence(String text, string expected)
        {
            var result = _service.From(text);

            result.ShouldBe(expected);
        }
    }
}
