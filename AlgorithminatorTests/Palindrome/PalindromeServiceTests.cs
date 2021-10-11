using Algorithminator.Palindrome;
using Shouldly;
using Xunit;

namespace AlgorithminatorTests.Palindrome
{
    
    public class PalindromeServiceTests
    {
        private PalindromeService _service;

        public PalindromeServiceTests()
        {
            _service = new PalindromeService();
        }

        [Theory]
        [InlineData("paap")]
        [InlineData("paiap")]
        [InlineData("ada")]
        [InlineData("a")]
        public void Should_return_true_when_the_text_is_palindrome(string text)
        {
            var result = _service.Palindrome(text);

            result.ShouldBeTrue(); 
        }


        [Theory]
        [InlineData("paa")]
        [InlineData("not")]
        [InlineData("palindrome")]
        
        public void Should_return_false_when_the_text_is_not_palindrome(string text)
        {
            var result = _service.Palindrome(text);
            
            result.ShouldBeFalse();
        }
    }
}
