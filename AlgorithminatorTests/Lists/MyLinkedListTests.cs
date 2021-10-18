using Algorithminator.Lists;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlgorithminatorTests.Lists
{
    public class MyLinkedListTests
    {
        private readonly MyLinkedList<int> _list;

        public MyLinkedListTests()
        {
            _list = new MyLinkedList<int>();
        }

        [Fact]
        public void Should_insert_new_element_at_head()
        {
            _list.InsertHead(10);

            _list.Head().ShouldBe(10);
            _list.Count.ShouldBe(1);
        }

        [Fact]
        public void Should_insert_new_element_at_head_many_times()
        {
            _list.InsertHead(10);
            _list.InsertHead(20);

            _list.Head().ShouldBe(20);
            _list.Count.ShouldBe(2);
        }
    }
}
