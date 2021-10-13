using Algorithminator.Sums;
using Shouldly;
using Xunit;

namespace AlgorithminatorTests.Sums
{
    public class ThreeSumTests
    {
        private readonly ThreeSum _service;

        public ThreeSumTests()
        {
            _service = new ThreeSum();
        }

        [Fact]
        public void Should_return_the_three_numbers_in_the_array_that_when_summed_is_the_number()
        {
            var number = 17;
            var array = new[] { 18, 7, 6, 4, 3, 1 };

            var result = _service.Exists(number, array);

            result[0].ShouldBeEquivalentTo(new int[] { 7, 6, 4 });
            result[1].ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Shoud_return_the_many_three_numbers_in_the_array_that_when_summed_is_the_number()
        {
            var number = 11;
            var array = new[] { 18, 7, 6, 4, 3, 1 };

            var result = _service.Exists(number, array);

            result[0].ShouldBeEquivalentTo(new int[] { 7, 3, 1 });
            result[1].ShouldBeEquivalentTo(new int[] { 6, 4, 1 });
            result[2].ShouldBeEquivalentTo(null);
        }

    }
}
