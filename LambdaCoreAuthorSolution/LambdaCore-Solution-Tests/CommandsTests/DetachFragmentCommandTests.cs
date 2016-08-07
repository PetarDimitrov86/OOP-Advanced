using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LambdaCore_Solution_Tests
{
    using LambdaCore_Solution.Commands;
    using LambdaCore_Solution.Core;
    using LambdaCore_Solution.Interfaces;
    using LambdaCore_Solution.Models.Cores;
    using LambdaCore_Solution.Models.Fragments;

    [TestClass]
    public class DetachFragmentCommandTests
    {

    private IPowerPlant testNuclearPowerPlant;

    [TestInitialize]
    public void SetUp() {
        this.testNuclearPowerPlant = new NuclearPowerPlant();
    }

    [TestMethod]
    public void TestDetach_WithNoSelectedCore_ShouldReturnFailureMessage() {
        ICommand testCommand = new DetachFragmentCommand(this.testNuclearPowerPlant);
        String actualMessage = testCommand.Execute();

        String expectedMessage = "Failed to detach Fragment!";
        Assert.AreEqual(expectedMessage, actualMessage, "DetachFragment command does not work correctly!");
    }

    [TestMethod]
    public void TestDetach_WithSelectedCore_WithNoFragments_ShouldReturnFailureMessage() {
        ICore dummyCore = new SystemCore("A", 100);
        this.testNuclearPowerPlant.AttachCore(dummyCore);
        this.testNuclearPowerPlant.SelectCore("A");

        ICommand testCommand = new DetachFragmentCommand(this.testNuclearPowerPlant);
        String actualMessage = testCommand.Execute();

        String expectedMessage = "Failed to detach Fragment!";
        Assert.AreEqual(expectedMessage, actualMessage, "DetachFragment command does not work correctly!");
    }

    [TestMethod]
    public void TestDetach_WithSelectedCore_WithOneFragment_ShouldReturnSuccessMessage() {
        ICore dummyCore = new SystemCore("A", 100);
        IFragment dummyFragment = new NuclearFragment("Test", 1);
        dummyCore.AttachFragment(dummyFragment);

        this.testNuclearPowerPlant.AttachCore(dummyCore);
        this.testNuclearPowerPlant.SelectCore("A");

        ICommand testCommand = new DetachFragmentCommand(this.testNuclearPowerPlant);
        String actualMessage = testCommand.Execute();

        String expectedMessage = "Successfully detached Fragment Test from Core A!";
        Assert.AreEqual(expectedMessage, actualMessage, "DetachFragment command does not work correctly!");
    }

    [TestMethod]
    public void TestDetach_WithSelectedCore_WithTwoFragments_ShouldDetachTopFragment() {
        ICore dummyCore = new SystemCore("A", 100);
        IFragment dummyFragment = new NuclearFragment("Test", 1);
        IFragment anotherDummyFragment = new NuclearFragment("Test2", 1);
        dummyCore.AttachFragment(dummyFragment);
        dummyCore.AttachFragment(anotherDummyFragment);

        this.testNuclearPowerPlant.AttachCore(dummyCore);
        this.testNuclearPowerPlant.SelectCore("A");

        ICommand testCommand = new DetachFragmentCommand(this.testNuclearPowerPlant);
        String actualMessage = testCommand.Execute();

        String expectedMessage = "Successfully detached Fragment Test2 from Core A!";
        Assert.AreEqual(expectedMessage, actualMessage, "DetachFragment command does not work correctly!");
    }
    }
}
