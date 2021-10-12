using Algorithminator.FrequencyNumbers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithminatorTests.FrequencyNumbers
{
    public class FrequencyNumberTests
    {
        private readonly FrequencyNumber _service;

        public FrequencyNumberTests()
        {
            _service = new FrequencyNumber();
        }

        [Fact]
        public void Should_return_the_two_numbers_with_most_frequency_inside_the_array()
        {
            var array = new int[] { 1, 1, 1, 2, 2, 3, 3, 4, 4, 4, 4 };

            var result = _service.FrequencyNumbers(array, 2);

            result.ShouldBeEquivalentTo(new[] { 4, 1 });
        }

        [Fact]
        public void Should_return_the_tree_numbers_with_most_frequency_inside_the_array()
        {
            var array = new int[] { 
                1, 1, 1, 
                2, 2, 2, 2, 2, 
                3, 3, 
                4, 4, 4, 4 };

            var result = _service.FrequencyNumbers(array, 3);

            result.ShouldBeEquivalentTo(new[] { 2, 4, 1 });
        }
    }
}
