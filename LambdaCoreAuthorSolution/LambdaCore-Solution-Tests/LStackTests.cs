using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LambdaCore_Solution_Tests
{
    using LambdaCore_Solution.Collection;
    using LambdaCore_Solution.Interfaces;
    using LambdaCore_Solution.Models.Fragments;

    [TestClass]
    public class LStackTests
    {

    private LStack<IFragment> testStack;

    [TestInitialize]
    public void SetUp() {
        this.testStack = new LStack<IFragment>();
    }

    [TestMethod]
    public void TestadditionOfElement_WithOneElement_ShouldWorkFine() {
        IFragment dummyFragment = new NuclearFragment("Test", 1);

        this.testStack.Push(dummyFragment);

        foreach (var fragment in this.testStack)
        {
            Assert.AreEqual(dummyFragment, fragment, "The addition of elements in the stack does not work properly!");
        }
    }

    [TestMethod]
    public void TestSizeOfStack_WithTwoElements_ShouldReturnCorrectValue() {

        IFragment dummyFragment = new NuclearFragment("Test", 1);
        IFragment anotherDummyFragment = new NuclearFragment("Test2", 1);

        this.testStack.Push(dummyFragment);
        this.testStack.Push(anotherDummyFragment);

        int stackSize = this.testStack.Count();
        Assert.AreEqual(2, stackSize);
    }

    [TestMethod]
    public void TestElementRemoval_RemoveWithTwoElements_ShouldDecreaseStackSize() {
        IFragment dummyFragment = new NuclearFragment("Test", 1);
        IFragment anotherDummyFragment = new NuclearFragment("Test2", 1);

        this.testStack.Push(dummyFragment);
        this.testStack.Push(anotherDummyFragment);

        this.testStack.Pop();

        int stackSize = this.testStack.Count();
        Assert.AreEqual(1, stackSize);
    }

    [TestMethod]
    public void TestElementRemoval_RemoveWithTwoElements_ShouldReturnTopElement() {
        IFragment dummyFragment = new NuclearFragment("Test", 1);
        IFragment anotherDummyFragment = new NuclearFragment("Test2", 1);

        this.testStack.Push(dummyFragment);
        this.testStack.Push(anotherDummyFragment);

        IFragment removedElement = this.testStack.Pop();

        Assert.AreEqual(removedElement, anotherDummyFragment);
    }

    [TestMethod]
    public void TestPeek_PeekWithOneElement_ShouldReturnElement() {
        IFragment dummyFragment = new NuclearFragment("Test", 1);

        this.testStack.Push(dummyFragment);

        IFragment peekedFragment = this.testStack.Peek();

        Assert.AreEqual(peekedFragment, dummyFragment);
    }

    [TestMethod]
    public void TestPeek_PeekWithOneElement_ShouldNotDecreaseSizeOfStack() {
        IFragment dummyFragment = new NuclearFragment("Test", 1);

        this.testStack.Push(dummyFragment);

        IFragment peekedFragment = this.testStack.Peek();

        int stackSize = this.testStack.Count();
        Assert.AreEqual(1, stackSize);
    }

    [TestMethod]
    public void TestPeek_PeekWithTwoElements_ShouldReturnTopElement() {
        IFragment dummyFragment = new NuclearFragment("Test", 1);
        IFragment anotherDummyFragment = new NuclearFragment("Test2", 1);

        this.testStack.Push(dummyFragment);
        this.testStack.Push(anotherDummyFragment);

        IFragment removedElement = this.testStack.Peek();

        Assert.AreEqual(removedElement, anotherDummyFragment);
    }

    [TestMethod]
    public void TestIsEmpty_WithZeroElements_ShouldReturnTrue() {
        Boolean isEmpty = this.testStack.IsEmpty();
        Assert.AreEqual(true, isEmpty);
    }

    [TestMethod]
    public void TestIsEmpty_WithTwoElements_ShouldReturnFalse() {
        IFragment dummyFragment = new NuclearFragment("Test", 1);
        IFragment anotherDummyFragment = new NuclearFragment("Test2", 1);

        this.testStack.Push(dummyFragment);
        this.testStack.Push(anotherDummyFragment);

        bool isEmpty = this.testStack.IsEmpty();
        Assert.AreEqual(false, isEmpty);
    }
    }
}
