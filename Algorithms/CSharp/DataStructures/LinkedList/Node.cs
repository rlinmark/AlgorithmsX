namespace CSharp.DataStructures.LinkedList
{
    /// <summary>
    /// Data structure element used within LinkedList.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Value stored in Node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Reference to next Node in list.
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Initializes an instance of the Node.
        /// </summary>
        /// <param name="value">The value to set in Node</param>
        public Node(T value)
        {
            Value = value;
        }
    }
}
