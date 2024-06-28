using LinkedList;

public class Program
{
   
    public static void Main(string[] args)
    {
        SoftuniLinkedList linkedList = new SoftuniLinkedList();

        linkedList.AddFirst(new Node(1));
        linkedList.AddFirst(new Node(2));
        linkedList.AddLast(new Node(3));
        linkedList.AddLast(new Node(4));

        Node currentNode = linkedList.Head;

        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Value);
            currentNode = currentNode.Next;
        }
    }
}