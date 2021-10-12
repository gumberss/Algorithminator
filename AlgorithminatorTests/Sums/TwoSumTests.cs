using Algorithminator.Sums;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithminatorTests.Sums
{
    public class TwoSumTests
    {
        private readonly TwoSum _service;

        public TwoSumTests()
        {
            _service = new TwoSum();
        }

        [Fact]
        public void Shoud_return_the_numbers_in_the_array_that_when_summed_is_the_number()
        {
            var number = 9;
            var array = new[] { 18, 7, 6, 4, 3, 1 };

            var result = _service.Exists(number, array);

            result.ShouldBeEquivalentTo(new[] { 6, 3 });
        }

        [Fact]
        public void Shoud_not_return_the_numbers_in_the_array_that_when_there_is_no_sum_that_make_the_number()
        {
            var number = 9;
            var array = new[] { 18, 7, 6, 4, 0, 1 };

            var result = _service.Exists(number, array);

            result.ShouldBeEquivalentTo(new int[0]);
        }

    }
}
