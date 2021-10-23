using System;

namespace Algorithminator.DataStructs.BinaryTrees
{
    public class MyBinaryTree<T> where T : IComparable<T>
    {
        public MyBinaryNode<T> Source { get; set; }

        public void Insert(T item)
        {
            if (Source is null)
            {
                Source = new MyBinaryNode<T>(null, item);
                return;
            }

            Source.Insert(item);

            Source = Source?.Parent ?? Source;
        }
    }

    public class MyBinaryNode<T> where T : IComparable<T>
    {
        public MyBinaryNode<T> Left { get; private set; }

        public MyBinaryNode<T> Right { get; private set; }

        public MyBinaryNode<T> Parent { get; private set; }
        public T Value { get; private set; }

        public MyBinaryNode(MyBinaryNode<T> parent, T value)
        {
            Value = value;
            Parent = parent;
        }

        public int Height => GetHeight();

        private int GetHeight()
        {
            if (Left is null && Right is null) return 1;

            int leftHeight = 0, rightHeigh = 0;

            if (Left is not null)
                leftHeight = Left.Height;

            if (Right is not null)
                rightHeigh = Right.Height;

            return
                leftHeight > rightHeigh
                ? leftHeight + 1
                : rightHeigh + 1;
        }

        private int GetFactor()
        {
            int leftHeight = 0, rightHeight = 0;

            if (Left is not null)
                leftHeight = Left.Height;

            if (Right is not null)
                rightHeight = Right.Height;

            return rightHeight - leftHeight;
        }

        public int RightDepth { get; set; }

        public int LeftDepth { get; set; }

        internal int Insert(T item)
        {
            if (Value.CompareTo(item) < 0)
            {
                if (Right is null)
                {
                    Right = new MyBinaryNode<T>(this, item);
                    RightDepth = 1;
                    if (this.Parent is null)
                    {
                        Balance(false);

                    }
                }
                else
                {
                    RightDepth = 1 + Right.Insert(item);
                    if (this.Parent is null)
                    {
                        Balance(false);

                    }
                }

                return RightDepth;
            }
            else
            {
                if (Left is null)
                {
                    Left = new MyBinaryNode<T>(this, item);
                    LeftDepth = 1;

                }
                else
                {
                    LeftDepth = 1 + Left.Insert(item);
                    if (this.Parent is null)
                    {
                        Balance(true);

                    }

                }

                return LeftDepth;
            }


        }

        public void Balance(bool leftInsert)
        {
            var rightInsert = !leftInsert;

            var sourceFactor = this.GetFactor();

            if (sourceFactor == 0) return;

            if (rightInsert && (sourceFactor == 2 || sourceFactor == -2))
            {
                var source = GetSource();

                if (source.GetFactor() == 2 && source.Right.GetFactor() == 1)
                {
                    var newMainNode = source.Right;
                    var newMainNodeParent = source.Parent;

                    source.Parent = newMainNode;
                    source.Right = newMainNode.Left;
                    source.Right.Parent = source;
                    newMainNode.Parent = newMainNodeParent;
                    newMainNode.Left = source;
                }
            }

            if (leftInsert)
            {
             


            }
        }

        private MyBinaryNode<T> GetSource()
        {
            if (Parent is null) return this;

            return Parent.GetSource();
        }
    }
}
