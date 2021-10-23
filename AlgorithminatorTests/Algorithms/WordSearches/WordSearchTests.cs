using Algorithminator.WordSearches;
using Shouldly;
using Xunit;

namespace AlgorithminatorTests.WordSearches
{
    public class WordSearchTests
    {
        private readonly WordSearch _service;

        public WordSearchTests()
        {
            _service = new WordSearch();
        }

        [Fact]
        public void Should_can_made_the_word_when_word_inside_a_matrix_with_one_dimension()
        {
            char[,] matrix = new char[,]
            {
                { 'E', 'V', 'O', 'L' }
            };

            var word = "LOVE";

            var result = _service.CanMake(word, matrix);

            result.ShouldBeTrue();
        }

        [Fact]
        public void Should_can_made_the_word_when_word_inside_a_matrix_with_many_dimension()
        {
            char[,] matrix = new char[,]
            {
                { 'O', 'L', 'K' },
                { 'V', 'E', 'J' }
            };

            var word = "LOVE";

            var result = _service.CanMake(word, matrix);

            result.ShouldBeTrue();
        }

        [Fact]
        public void Should_can_not_made_the_word_when_letter_inside_the_matrix_can_not_make_the_word()
        {
            char[,] matrix = new char[,]
            {
                { 'O', 'L' },
                { 'E', 'I'}
            };

            var word = "LOVE";

            var result = _service.CanMake(word, matrix);

            result.ShouldBeFalse();
        }

        [Fact]
        public void Should__not_made_the_word_when_letter_inside_the_matrix_can_make_the_word_only_if_repeat()
        {
            char[,] matrix = new char[,]
            {
                { 'O', 'L' },
                { 'E', 'V'}
            };

            var word = "LOOVE";

            var result = _service.CanMake(word, matrix);

            result.ShouldBeFalse();
        }
    }
}
