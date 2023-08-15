using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ArgIsNull_ThrowArgNullExeption() {
            var stack = new Stack<string>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        } 
        
        [Test]
        [TestCase("a")]
        [TestCase("b")]
        [TestCase("c")]
        public void Push_ValidArg_AddObjectToTheStack(string item) {
            var stack = new Stack<string>();

            stack.Push(item);

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_StackIsEmpty_EqualsTo0()
        {
            var stack = new Stack<string>();

            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_StackIsEmpty_ThrowInvalidOperationExcrption()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackHasSomeObjects_ReturnsObject()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Pop();

            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackHasSomeObjects_RemovesLastObjectFromStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_StackIsEmpty_ThrowInvalidOperationExcrption()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackHasSomeObjects_DoesntRemoveLastObjectFromStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(3));
        } 
        
        [Test]
        public void Peek_StackHasSomeObjects_ReturnsLastObject()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("c"));
        }
    }
}
