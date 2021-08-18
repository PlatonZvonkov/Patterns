using NUnit.Framework;
using ClassLibrary;
using System;

namespace nUnitTests
{
    [TestFixture]
    public class MyQueueTests
    {
        [SetUp]
        public void Setup()
        {
           //Also each test is testing constructor overload
        }

        [Test]
        public void Enqueue_IfEmpty_CreatesNotEmpty()
        {
            //Arrange
            MyQueue<string> q = new MyQueue<string>();
            Assert.That(q.Count.Equals(0));
            //Act
            q.Enqueue(null);
            //Assert
            Assert.That(q.Count.Equals(1));
        }
        [Test]
        public void Enqueue_IsWorkingNormally()
        {
            //Arrange
            MyQueue<string> q = new MyQueue<string>();            
            //Act
            q.Enqueue("");
            q.Enqueue("");
            q.Enqueue("");
            //Assert
            Assert.That(q.Count.Equals(3));
        }
        [Test]
        public void Dequeue_OnEmpty_ThrowsException()
        {
            //Arrange
            MyQueue<int> q = new MyQueue<int>();                       
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(()=>q.Dequeue());
        }
        [Test]
        public void Dequeue_AndEnquqe_IsWorkingNormally()
        {
            //Arrange
            MyQueue<string> q = new MyQueue<string>();            
            //Act
            q.Enqueue("");
            q.Enqueue("");
            q.Dequeue();
            q.Enqueue("");
            //Assert
            Assert.That(q.Count.Equals(2));
        }
        [Test]
        public void Dequeue_IsRemoving_FristInLine()
        {
            //Arrange
            MyQueue<int> q = new MyQueue<int>() ;
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            int expected = 1;
            //Act
           
            //Assert
            Assert.That(q.Dequeue().Equals(expected));
        }
        [Test]
        public void Peek_OnEmpty_ThrowsException()
        {
            //Arrange
            MyQueue<int> q = new MyQueue<int>();
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => q.Peek());
        }
        [Test]
        public void Peek_Returns_First()
        {
            //Arrange
            MyQueue<int> q = new MyQueue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);            
            //Act

            //Assert
            Assert.That(q.Dequeue().Equals(1));
        }
        [Test]
        public void ToArray_WorkingNormally()
        {
            //Arrange
            MyQueue<int> q = new MyQueue<int>();
            q.Enqueue(1);
            q.Enqueue(2);           
            q.Enqueue(3);
            //Act
            int[] actual = q.ToArray();
            int[] expected = new int[] { 1, 2, 3};
            //Assert
            Assert.That(actual.GetType() == expected.GetType());
            Assert.That(actual.Length == expected.Length);
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void Clear_WorkingNormally()
        {
            //Arrange
            MyQueue<int> q = new MyQueue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            //Act
            q.Clear();
            q.Enqueue(4);
            //Assert
            Assert.That(q.Count == 1);
            Assert.That(q.Peek() == 4);
        }
    }
}