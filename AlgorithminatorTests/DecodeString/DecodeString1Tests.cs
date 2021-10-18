using Algorithminator.DecodeString;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithminatorTests.DecodeString
{
    public class DecodeString1Tests
    {
        private readonly DecodeString1 _service;

        public DecodeString1Tests()
        {
            _service = new DecodeString1();
        }

        [Fact]
        public void Should_return_the_same_string_when_normal_string()
        {
            var message = "lalapo";

            var result = _service.Decode(message);

            result.ShouldBe("lalapo");
        }

        [Fact]
        public void Should_decode_a_string_when_repeat_times()
        {
            var message = "2[lalapo]u";

            var result = _service.Decode(message);

            result.ShouldBe("lalapolalapou");
        }

        [Fact]
        public void Should_decode_a_string_when_repeat_times_many_times()
        {
            var message = "2[la]3[po]";

            var result = _service.Decode(message);

            result.ShouldBe("lalapopopo");
        }

        [Fact]
        public void Should_decode_a_string_when_repeat_times_inside_a_repeat_time()
        {
            var message = "hh2[la3[po]]";

            var result = _service.Decode(message);

            result.ShouldBe("hhlapopopolapopopo");
        }
    }
}
