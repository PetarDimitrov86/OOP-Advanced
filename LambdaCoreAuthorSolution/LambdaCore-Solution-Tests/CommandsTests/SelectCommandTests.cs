using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LambdaCore_Solution_Tests
{
    using LambdaCore_Solution.Commands;
    using LambdaCore_Solution.Core;
    using LambdaCore_Solution.Interfaces;
    using LambdaCore_Solution.Models.Cores;

    [TestClass]
    public class SelectCommandTests
    {

        private IPowerPlant testNuclearPowerPlant;

        [TestInitialize]
        public void SetUp()
        {
            this.testNuclearPowerPlant = new NuclearPowerPlant();
        }

        [TestMethod]
        public void TestSelect_WithUnexistentCore_ShouldReturnErrorMessage()
        {
            ICommand testCommand = new SelectCommand(this.testNuclearPowerPlant, "A");
            String actualMessage = testCommand.Execute();

            String expectedMessage = "Failed to select Core A!";
            Assert.AreEqual(expectedMessage, actualMessage, "Select command does not work correctly!");
        }

        [TestMethod]
        public void TestSelect_WithExistentCore_ShouldReturnSuccessMessage()
        {
            ICore dummyCore = new SystemCore("A", 20);
            this.testNuclearPowerPlant.AttachCore(dummyCore);

            ICommand testCommand = new SelectCommand(this.testNuclearPowerPlant, "A");
            String actualMessage = testCommand.Execute();

            String expectedMessage = "Currently selected Core A!";
            Assert.AreEqual(expectedMessage, actualMessage, "Select command does not work correctly!");
        }

        [TestMethod]
        public void TestSelect_WithExistentCore_ShouldSetCurrentlySelectedCoreCorrectly()
        {
            ICore dummyCore = new SystemCore("A", 20);
            this.testNuclearPowerPlant.AttachCore(dummyCore);

            ICommand testCommand = new SelectCommand(this.testNuclearPowerPlant, "A");
            testCommand.Execute();

            Assert.AreEqual(
                this.testNuclearPowerPlant.CurrentlySelectedCore,
                dummyCore,
                "Select command does not work correctly!");
        }
    }
}
