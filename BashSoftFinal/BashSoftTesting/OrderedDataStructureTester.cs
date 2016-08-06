using System;
using System.Collections.Generic;
using Executor.Contracts;
using Executor.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BashSoftTesting
{
    [TestClass]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [TestInitialize]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [TestMethod]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrowsException()
        {
            this.names.Add(null);
        }

        [TestMethod]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            Assert.AreEqual("Balkan, Georgi, Rosen", string.Join(", ", this.names));
        }

        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                names.Add($"number{i+1}");
            }
            Assert.AreEqual(17, this.names.Size);
            Assert.AreNotEqual(16, this.names.Capacity);
        }

        [TestMethod]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string> stringList = new List<string>() {"Pesho", "Gosho"};
            names.AddAll(stringList);
            Assert.AreEqual(2, names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingAllFromNullThrowsException()
        {
            List<string> stringList = null;
            names.AddAll(stringList);
        }

        [TestMethod]
        public void TestAddAllKeepsSorted()
        {
            List<string> stringList = new List<string>() { "NNNN", "KKKK", "AAAA", "ZZZZ", "BBBB" };
            names.AddAll(stringList);
            Assert.AreEqual("AAAA, BBBB, KKKK, NNNN, ZZZZ", string.Join(", ", names));
        }

        [TestMethod]
        public void TestRemoveValidElementDecreasesSize()
        {
            names.Add("Pesho");
            names.Add("Gosho");
            names.Add("Ivan");
            names.Remove("Pesho");
            Assert.AreEqual(2, this.names.Size);
        }

        [TestMethod]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            names.Add("Nasko");
            names.Add("Ivan");
            names.Remove("Ivan");
            Assert.IsFalse(this.names.Remove("Ivan"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemovingNullThrowsException()
        {
            names.Add("Nasko");
            names.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJoinWithNull()
        {
            names.Add("Nasko");
            names.Add("Ivan");
            names.Add("Gosho");
            names.JoinWith(null);
        }

        [TestMethod]
        public void TestJoinWorksFine()
        {
            names.Add("Nasko");
            names.Add("Ivan");
            Assert.AreEqual("Ivan, Nasko", names.JoinWith(", "));
        }
    }
}
