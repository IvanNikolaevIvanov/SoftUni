using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList
    {
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public void Add(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Tail.Next = node;
            Tail = node;


        }
    }
}
