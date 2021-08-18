using System;
using NUnit.Framework;
using ClassLibrary;


namespace nUnitTests
{
    [TestFixture]
    public class MyStackTests
    {
        [SetUp]
        public void Setup()
        {
            //Also each test is testing constructor overload
        }
        [Test]
        public void Push_IfEmpty_CreatesNotEmpty()
        {
            //Arrange
            MyStack<string> s = new MyStack<string>();
            Assert.That(s.Count.Equals(0));
            //Act
            s.Push("1");
            //Assert
            Assert.That(s.Count.Equals(1));
        }
        [Test]
        public void Push_IsWorkingNormally()
        {
            //Arrange
            MyStack<string> s = new MyStack<string>();
            //Act
            s.Push("");
            s.Push("");
            s.Push("");
            //Assert
            Assert.That(s.Count.Equals(3));
        }
        [Test]
        public void Pop_OnEmpty_ThrowsException()
        {
            //Arrange
            MyStack<int> s = new MyStack<int>();
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => s.Pop());
        }

        [Test]
        public void Pop_AndPush_IsWorkingNormally()
        {
            //Arrange
            MyStack<string> s = new MyStack<string>();
            //Act
            s.Push("");
            s.Push("");
            s.Pop();
            s.Push("");
            //Assert
            Assert.That(s.Count.Equals(2));
        }
        [Test]
        public void Pop_IsRemoving_last()
        {
            //Arrange
            MyStack<int> s = new MyStack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            int expected = 3;
            //Act

            //Assert
            Assert.That(s.Pop().Equals(expected));
        }
        [Test]
        public void Peek_OnEmpty_ThrowsException()
        {
            //Arrange
            MyStack<int> s = new MyStack<int>();
            //Act
            //Assert
            Assert.Throws<NullReferenceException>(() => s.Peek());            
        }
        [Test]
        public void Peek_Returns_Top()
        {
            //Arrange
            MyStack<int> s = new MyStack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            //Act

            //Assert
            Assert.That(s.Peek().Equals(3));
        }
        [Test]
        public void ToArray_WorkingNormally()
        {
            //Arrange
            MyStack<int> s = new MyStack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            //Act
            int[] actual = s.ToArray();
            int[] expected = new int[] {3,2,1};
            //Assert
            Assert.That(actual.Length == expected.Length);
            Assert.That(actual.GetType() == expected.GetType());
        }
        [Test]
        public void Clear_WorkingNormally() 
        {
            //Arrange
            MyStack<int> s = new MyStack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            //Act
            s.Clear();
            s.Push(5);            
            //Assert
            Assert.That(s.Count == 1);
            Assert.That(s.Peek() ==5);
        }
    }
}
