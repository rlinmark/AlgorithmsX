namespace CSharp.DataStructures.LinkedList
{
    /// <summary>
    /// Data structure to store elements in a linked list.
    /// </summary>
    /// <typeparam name="T">The type of element to store in LinkedList</typeparam>
    public class LinkedList<T>
    {
        /// <summary>
        /// Reference to the fist element in list.
        /// </summary>
        public Node<T> Head { get; private set; }

        /// <summary>
        /// Reference to last element in list.
        /// </summary>
        public Node<T> Tail { get; private set; }

        /// <summary>
        /// The number of elements in list.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Initializes a new instance of the LinkedList.
        /// </summary>
        public LinkedList() { }

        /// <summary>
        /// Adds value to end of list.
        /// </summary>
        /// <param name="value">The value to add to list</param>
        public void InsertLast(T value)
        {
            if (Size == 0)
            {
                Head = new Node<T>(value);
                Tail = Head;
            }
            else
            {
                var currentNode = Tail;
                currentNode.Next = new Node<T>(value);
                Tail = currentNode.Next;
            }

            Size++;
        }

        /// <summary>
        /// Adds value to start of list.
        /// </summary>
        /// <param name="value">The value to add to list</param>
        public void InsertFirst(T value)
        {
            if (Size == 0)
            {
                Head = new Node<T>(value);
                Tail = Head;
            }
            else
            {
                var currentNode = Head;
                var newNode = new Node<T>(value)
                {
                    Next = currentNode
                };
                Head = newNode;
            }

            Size++;
        }

        /// <summary>
        /// Removes value from the end of the list.
        /// </summary>
        public void RemoveLast()
        {
            if (Size != 0)
            {
                if (Size == 1)
                {
                    Head = null;
                    Tail = Head;
                }
                else
                {
                    var currentNode = Head;

                    while (currentNode.Next != Tail)
                    {
                        currentNode = currentNode.Next;
                    }

                    currentNode.Next = null;
                    Tail = currentNode;
                }

                Size--;
            }
        }

        /// <summary>
        /// Removes value from the start of the list.
        /// </summary>
        public void RemoveFirst()
        {
            if (Size != 0)
            {
                if (Size == 1)
                {
                    Head = null;
                    Tail = Head;
                }
                else
                {
                    Head = Head.Next;
                }

                Size--;
            }
        }

        /// <summary>
        /// Determines if supplied value is found in list.
        /// </summary>
        /// <param name="value">THe value to search for in list</param>
        /// <returns>Whether or not value was found</returns>
        public bool Contains(T value)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }

        /// <summary>
        /// Removes all values from the list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = Head;
            Size = 0;
        }

        /// <summary>
        /// Removes first occurance of specified value from list.
        /// </summary>
        /// <param name="value">The value to remove from list</param>
        public void Remove(T value)
        {
            var currentNode = Head;
            Node<T> previous = null;


            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    if (previous == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = currentNode.Next;

                        if (currentNode.Next == null)
                        {
                            Tail = previous;
                        }

                        Size--;
                    }
                }

                previous = currentNode;
                currentNode = currentNode.Next;
            }
        }
    }
}
