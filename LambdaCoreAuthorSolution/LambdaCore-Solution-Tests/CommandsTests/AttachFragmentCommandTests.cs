using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LambdaCore_Solution_Tests
{
    using LambdaCore_Solution.Commands;
    using LambdaCore_Solution.Core;
    using LambdaCore_Solution.Enums;
    using LambdaCore_Solution.Interfaces;
    using LambdaCore_Solution.Models.Cores;

    [TestClass]
    public class AttachFragmentCommandTests
    {

        private IPowerPlant testNuclearPowerPlant;

        [TestInitialize]
        public void SetUp()
        {
            this.testNuclearPowerPlant = new NuclearPowerPlant();
        }

        [TestMethod]
        public void TestAttach_WithUnselectedCore_ShouldReturnFailureMessage()
        {
            ICommand testCommand = new AttachFragmentCommand(
                this.testNuclearPowerPlant,
                FragmentType.Nuclear,
                "Test",
                1);
            String actualMessage = testCommand.Execute();

            String expectedMessage = "Failed to attach Fragment Test!";
            Assert.AreEqual(expectedMessage, actualMessage, "AttachFragment command does not work correctly!");
        }

        [TestMethod]
        public void TestAttach_WithInvalidPressureAffection_ShouldReturnFailureMessage()
        {
            ICore dummyCore = new SystemCore("A", 100);
            this.testNuclearPowerPlant.AttachCore(dummyCore);
            this.testNuclearPowerPlant.SelectCore("A");

            ICommand testCommand = new AttachFragmentCommand(
                this.testNuclearPowerPlant,
                FragmentType.Nuclear,
                "Test",
                -1);
            String actualMessage = testCommand.Execute();

            String expectedMessage = "Failed to attach Fragment Test!";
            Assert.AreEqual(expectedMessage, actualMessage, "AttachFragment command does not work correctly!");
        }

        [TestMethod]
        public void TestAttach_WithSelectedCore_ShouldReturnSuccessMessage()
        {
            ICore dummyCore = new SystemCore("A", 100);
            this.testNuclearPowerPlant.AttachCore(dummyCore);
            this.testNuclearPowerPlant.SelectCore("A");

            ICommand testCommand = new AttachFragmentCommand(
                this.testNuclearPowerPlant,
                FragmentType.Nuclear,
                "Test",
                1);
            String actualMessage = testCommand.Execute();

            String expectedMessage = "Successfully attached Fragment Test to Core A!";
            Assert.AreEqual(expectedMessage, actualMessage, "AttachFragment command does not work correctly!");
        }
    }
}
