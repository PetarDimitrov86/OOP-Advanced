using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecyclingStation.Models.Garbage_Disposal_Strategies;
using RecyclingStation.Models.Wastes;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Interfaces;

namespace UnitTestProject1
{
    [TestClass]
    public class GarbageProcessorTest
    {
        private IGarbageProcessor garbageProcessor;

        [TestInitialize]
        public void InitializeTest()
        {
            this.garbageProcessor = new GarbageProcessor();
        }

        [TestMethod]
        public void CheckGarbageProcessorInitializationWithAGivenStrategyHolder()
        {
            IStrategyHolder testStrategy = new StrategyHolder();
            testStrategy.AddStrategy(typeof(RecyclableGarbage), new RecyclableStrategy());
            this.garbageProcessor = new GarbageProcessor(testStrategy);
            Assert.AreEqual(1, this.garbageProcessor.StrategyHolder.GetDisposalStrategies.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GarbageProcessorShouldThrowErrorIfNoStrategyIsPresentForGivenType()
        {
            IStrategyHolder testStrategy = new StrategyHolder();
            testStrategy.AddStrategy(typeof(RecyclableGarbage), new RecyclableStrategy());
            this.garbageProcessor = new GarbageProcessor(testStrategy);
            IWaste burnableWasteTestObject = new BurnableGarbage("RecyclMePls", 10, 10);
            IProcessingData tempData = this.garbageProcessor.ProcessWaste(burnableWasteTestObject);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GivingNullGarbageToProcessShouldThrowError()
        {
            IStrategyHolder testStrategy = new StrategyHolder();
            testStrategy.AddStrategy(typeof(RecyclableGarbage), new RecyclableStrategy());
            this.garbageProcessor = new GarbageProcessor(testStrategy);
            IWaste burnableWasteTestObject = null;
            IProcessingData tempData = this.garbageProcessor.ProcessWaste(burnableWasteTestObject);
        }

        [TestMethod]
        public void GarbageProcessorEmptyConstructorShouldGiveAnEmptyStrategyHolder()
        {
            Assert.AreEqual(0, this.garbageProcessor.StrategyHolder.GetDisposalStrategies.Count);
        }

        [TestMethod]
        public void GarbageProcessorProperlyProcessingBurnableGarbageWithBurnableStrategy()
        {
            IStrategyHolder testStrategy = new StrategyHolder();
            testStrategy.AddStrategy(typeof(BurnableGarbage), new BurnableStrategy());
            this.garbageProcessor = new GarbageProcessor(testStrategy);
            IWaste burnableWasteTestObject = new BurnableGarbage("BurnItUp", 10, 10);
            IProcessingData tempData = this.garbageProcessor.ProcessWaste(burnableWasteTestObject);
            Assert.AreEqual(0, tempData.CapitalBalance);
            Assert.AreEqual(80, tempData.EnergyBalance);
        }

        [TestMethod]
        public void GarbageProcessorProperlyProcessingRecyclableGarbageWithRecyclableStrategy()
        {
            IStrategyHolder testStrategy = new StrategyHolder();
            testStrategy.AddStrategy(typeof(RecyclableGarbage), 
                new RecyclableStrategy());
            this.garbageProcessor = new GarbageProcessor(testStrategy);
            IWaste burnableWasteTestObject = new RecyclableGarbage("RecyclMePls", 10, 10);
            IProcessingData tempData = this.garbageProcessor.ProcessWaste(burnableWasteTestObject);
            Assert.AreEqual(4000, tempData.CapitalBalance);
            Assert.AreEqual(-50, tempData.EnergyBalance);
        }

        [TestMethod]
        public void GarbageProcessorProperlyProcessingStorableGarbageWithStorableStrategy()
        {
            IStrategyHolder testStrategy = new StrategyHolder();
            testStrategy.AddStrategy(typeof(StorableGarbage),
                new StorableStrategy());
            this.garbageProcessor = new GarbageProcessor(testStrategy);
            IWaste burnableWasteTestObject = new StorableGarbage("WasteOfStorage", 10, 10);
            IProcessingData tempData = this.garbageProcessor.ProcessWaste(burnableWasteTestObject);
            Assert.AreEqual(-65, tempData.CapitalBalance);
            Assert.AreEqual(-13, tempData.EnergyBalance);
        }
    }
}