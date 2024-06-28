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

        //linkedList.RemoveFirst();
        //linkedList.RemoveLast();

        linkedList.ForEach(number =>
        {
            Console.WriteLine($"Each number in list: {number}");
        });

        Console.WriteLine(String.Join(", ", linkedList.ToArray()));
    }
}