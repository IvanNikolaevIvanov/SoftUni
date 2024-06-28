namespace LinkedList
{
    public class SoftuniLinkedList
    {
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(Node node)
        {
            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Head.Previous = node;
            node.Next = Head;
            Head = node;
            Count++;
        }

        public void AddFirst(int value)
        {
            AddFirst(new Node(value));
        }

        public void RemoveFirst()
        {
            int oldHead = Head.Value;
            Head = Head.Next;

        }

        public void AddLast(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Tail.Next = node;
            node.Previous = Tail;
            Tail = node;
        }
    }
}
