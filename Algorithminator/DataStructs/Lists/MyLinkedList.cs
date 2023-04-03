
namespace Algorithminator.Lists
{
    public class MyLinkedList<T>
    {
        public int Count { get; private set; }

        public MyLinkedList()
        {
            Count = 0;
        }

        private MyLinkedNode<T> _first;
        private MyLinkedNode<T> _last;

        public T InsertTail(T node)
        {
            var oldLast = _last;
            _last = new MyLinkedNode<T>(node);
            oldLast.Next = _last;
            _last.Before = oldLast;
            Count++;
            return node;
        }

        public T InsertHead(T node)
        {
            var oldFirst = _first;
            _first = new MyLinkedNode<T>(node);
            _first.Next = oldFirst;
            if (oldFirst is not null) oldFirst.Before = _first;
            Count++;
            return node;
        }

        public T InsertAfter(T node)
        {
            return node;
        }

        public T InsertBefore(T node)
        {
            return node;
        }

        public T Head()
        {
            if (Count > 0)
                return _first.Element;

            return default(T);
        }

        public T Tail()
        {
            if (Count > 0)
                return _last.Element;

            return default(T);
        }

    }

    public class MyLinkedNode<T>
    {
        public MyLinkedNode(T node)
        {
            Element = node;
        }

        public MyLinkedNode<T> Next { get; set; }

        public MyLinkedNode<T> Before { get; set; }

        public T Element { get; set; }
    }
}
