using Algorithminator.DataStructs.BinaryTrees;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithminatorTests.DataStructs.BynaryTrees
{
    public class MyBinaryTreeTests
    {

        [Fact]
        public void MyTestMethod()
        {
            var toInsert = new[] { 8, 4, 10, 9, 15, 12 };

            var binaryTree = new MyBinaryTree<int>();

            foreach (var item in toInsert)
            {
                binaryTree.Insert(item);
            }

            binaryTree.Source.Value.ShouldBe(10);
            binaryTree.Source.Left.Value.ShouldBe(8);

            binaryTree.Source.Left.Left.Value.ShouldBe(4);
            binaryTree.Source.Left.Right.Value.ShouldBe(9);

            binaryTree.Source.Right.Value.ShouldBe(15);

            binaryTree.Source.Right.Left.Value.ShouldBe(12);
        }
    }
}
