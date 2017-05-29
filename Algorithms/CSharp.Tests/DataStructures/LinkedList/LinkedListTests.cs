using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CSharp.Tests.DataStructures.LinkedList
{
    public class LinkedListTests
    {
        [Fact]
        public void Initialize()
        {
            //Assign
            const int expectedSize = 0;

            //Act
            var linkedList = new CSharp.DataStructures.LinkedList.LinkedList<int>();

            //Assert
            Assert.Null(linkedList.Head);
            Assert.Null(linkedList.Tail);
            Assert.Equal(expectedSize, linkedList.Size);
        }

        [Theory, ClassData(typeof(InsertLastTestCase))]
        public void InsertLast(List<int> values, int expectedHeadValue, int expectedTailValue, int expectedLength)
        {
            //Assign
            var linkedList = new CSharp.DataStructures.LinkedList.LinkedList<int>();

            //Act
            foreach (var value in values)
            {
                linkedList.InsertLast(value);
            }

            //Assert
            Assert.Equal(expectedHeadValue, linkedList.Head?.Value);
            Assert.Equal(expectedTailValue, linkedList.Tail?.Value);
            Assert.Equal(expectedLength, linkedList.Size);
        }

        [Theory, ClassData(typeof(InsertFirstTestCase))]
        public void InsertFirst(List<int> values, int expectedHeadValue, int expectedTailValue, int expectedLength)
        {
            //Assign
            var linkedList = new CSharp.DataStructures.LinkedList.LinkedList<int>();

            //Act
            foreach (var value in values)
            {
                linkedList.InsertFirst(value);
            }

            //Assert
            Assert.Equal(expectedHeadValue, linkedList.Head?.Value);
            Assert.Equal(expectedTailValue, linkedList.Tail?.Value);
            Assert.Equal(expectedLength, linkedList.Size);
        }

        [Theory, ClassData(typeof(RemoveLastTestCase))]
        public void RemoveLast(List<int> values, int? expectedHeadValue, int? expectedTailValue, int expectedLength)
        {
            //Assign
            var linkedList = new CSharp.DataStructures.LinkedList.LinkedList<int>();
            foreach (var value in values)
            {
                linkedList.InsertLast(value);
            }

            //Act
            linkedList.RemoveLast();

            //Assert
            Assert.Equal(expectedHeadValue, linkedList.Head?.Value);
            Assert.Equal(expectedTailValue, linkedList.Tail?.Value);
            Assert.Equal(expectedLength, linkedList.Size);
        }

        [Theory, ClassData(typeof(RemoveFirstTestCase))]
        public void RemoveFirst(List<int> values, int? expectedHeadValue, int? expectedTailValue, int expectedLength)
        {
            //Assign
            var linkedList = new CSharp.DataStructures.LinkedList.LinkedList<int>();
            foreach (var value in values)
            {
                linkedList.InsertLast(value);
            }

            //Act
            linkedList.RemoveFirst();

            //Assert
            Assert.Equal(expectedHeadValue, linkedList.Head?.Value);
            Assert.Equal(expectedTailValue, linkedList.Tail?.Value);
            Assert.Equal(expectedLength, linkedList.Size);
        }

        [Theory, ClassData(typeof(RemoveTestCase))]
        public void Remove(List<int> values, int removeValue, int? expectedHeadValue, int? expectedTailValue, int expectedLength)
        {
            //Assign
            var linkedList = new CSharp.DataStructures.LinkedList.LinkedList<int>();
            foreach (var value in values)
            {
                linkedList.InsertLast(value);
            }

            //Act
            linkedList.Remove(removeValue);

            //Assert
            Assert.Equal(expectedHeadValue, linkedList.Head?.Value);
            Assert.Equal(expectedTailValue, linkedList.Tail?.Value);
            Assert.Equal(expectedLength, linkedList.Size);
        }

        [Theory, ClassData(typeof(ClearTestCase))]
        public void Clear(List<int> values)
        {
            //Assign
            var expectedLength = 0;
            var linkedList = new CSharp.DataStructures.LinkedList.LinkedList<int>();
            foreach (var value in values)
            {
                linkedList.InsertLast(value);
            }

            //Act
            linkedList.Clear();

            //Assert
            Assert.Null(linkedList.Head);
            Assert.Null(linkedList.Tail);
            Assert.Equal(expectedLength, linkedList.Size);
        }

        [Theory, ClassData(typeof(ContainsTestCase))]
        public void Contains(List<int> values, int searchValue, bool expectedValue)
        {
            //Assign
            var linkedList = new CSharp.DataStructures.LinkedList.LinkedList<int>();
            foreach (var value in values)
            {
                linkedList.InsertLast(value);
            }

            //Act
            var isFound = linkedList.Contains(searchValue);

            //Assert
            Assert.Equal(expectedValue, isFound);
        }
    }


    public class InsertLastTestCase : IEnumerable<object[]>
    {
        private readonly List<object[]> _testCases = new List<object[]>()
        {
            new object[]{new List<int>() { 5 }, 5, 5, 1},
            new object[]{new List<int>() { 1, 2, 3, 4, 5 }, 1, 5, 5},
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _testCases.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class InsertFirstTestCase : IEnumerable<object[]>
    {
        private readonly List<object[]> _testCases = new List<object[]>()
        {
            new object[]{new List<int>() { 1 }, 1, 1, 1},
            new object[]{new List<int>() { 1, 2, 3, 4, 5 }, 5, 1, 5},
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _testCases.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class RemoveLastTestCase : IEnumerable<object[]>
    {
        private readonly List<object[]> _testCases = new List<object[]>()
        {
            new object[]{new List<int>() { 1 }, null, null, 0},
            new object[]{new List<int>() { 1, 2, 3, 4, 5 }, 1, 4, 4},
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _testCases.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class RemoveFirstTestCase : IEnumerable<object[]>
    {
        private readonly List<object[]> _testCases = new List<object[]>()
        {
            new object[]{new List<int>() { 1 }, null, null, 0},
            new object[]{new List<int>() { 1, 2, 3, 4, 5 }, 2, 5, 4},
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _testCases.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class RemoveTestCase : IEnumerable<object[]>
    {
        private readonly List<object[]> _testCases = new List<object[]>()
        {
            new object[]{new List<int>(), 1, null, null, 0},
            new object[]{new List<int>() { 1 }, 1, null, null, 0},
            new object[]{new List<int>() { 1, 2, 3, 4, 5 }, 1, 2, 5, 4},
            new object[]{new List<int>() { 1, 2, 3, 4, 5 }, 5, 1, 4, 4},
            new object[]{new List<int>() { 1, 2, 3, 4, 5 }, 3, 1, 5, 4},
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _testCases.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class ClearTestCase : IEnumerable<object[]>
    {
        private readonly List<object[]> _testCases = new List<object[]>()
        {
            new object[]{new List<int>()},
            new object[]{new List<int>() { 1 }},
            new object[]{new List<int>() { 1, 2, 3, 4, 5 }},
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _testCases.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class ContainsTestCase : IEnumerable<object[]>
    {
        private readonly List<object[]> _testCases = new List<object[]>()
        {
            new object[]{new List<int>(), 1, false},
            new object[]{new List<int>() { 1 }, 1, true},
            new object[]{new List<int>() { 1 }, 2, false},
            new object[]{new List<int>() { 1, 2, 3, 4, 5 }, 5, true},
            new object[]{new List<int>() { 1, 2, 3, 4, 5 }, 6, false},
        };

        public IEnumerator<object[]> GetEnumerator()
        { return _testCases.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
}
