using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecyclingStation.Core;
using RecyclingStation.Models.Garbage_Disposal_Strategies;
using RecyclingStation.Models.Wastes;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Interfaces;

namespace UnitTestProject1
{
    [TestClass]
    public class StrategyHolderTest
    {
        private IStrategyHolder strategyHolder;

        [TestInitialize]
        public void TestInitializer()
        {
            this.strategyHolder = new StrategyHolder();
        }

        [TestMethod]
        public void ConstructorShouldInitializeTheDictionary()
        {
            Assert.IsTrue(this.strategyHolder.GetDisposalStrategies != null);
        }

        [TestMethod]
        public void CheckIfAllStrategiesAreProperlyInserted()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableGarbage), new RecyclableStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableGarbage), new BurnableStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableGarbage), new StorableStrategy());
            Assert.AreEqual(3, this.strategyHolder.GetDisposalStrategies.Count);       
        }

        [TestMethod]
        public void AddingAnInvalidTypeToAddStrategyMethodShouldReturnFalse()
        {
            Assert.IsFalse(this.strategyHolder.AddStrategy(typeof(CommandInterpreter), new RecyclableStrategy()));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingSameTypeOfGarbageTwiceShouldThrowError()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableGarbage), new RecyclableStrategy());
            this.strategyHolder.AddStrategy(typeof(RecyclableGarbage), new RecyclableStrategy());
        }

        [TestMethod]
        public void RemovingNonExistingStrategyShouldReturnFalse()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableGarbage), new RecyclableStrategy());
            Assert.IsFalse(this.strategyHolder.RemoveStrategy(typeof(BurnableGarbage)));
        }

        [TestMethod]
        public void StrategyHolderShouldRemoveACorrectlyGivenStrategy()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableGarbage), new RecyclableStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableGarbage), new BurnableStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableGarbage), new StorableStrategy());
            this.strategyHolder.RemoveStrategy(typeof(RecyclableGarbage));
            Assert.AreEqual(2, this.strategyHolder.GetDisposalStrategies.Count);
            this.strategyHolder.RemoveStrategy(typeof(BurnableGarbage));
            Assert.AreEqual(1, this.strategyHolder.GetDisposalStrategies.Count);
        }
    }
}
