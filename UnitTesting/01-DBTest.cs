using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class DBTest
    {
        private Database database;

        [TestMethod]
        public void CanConstructorTake16Elements()
        {
            int[] testArray = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
            this.database = new Database(testArray);
            Assert.AreEqual(this.database.Size, 16);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConstructorShouldNotAcceptMoreThan16Numbers()
        {
            int[] testArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            this.database = new Database(testArray);
        }

        [TestMethod]
        public void TryToRemoveAnElementIfThereAreElementsToRemove()
        {
            this.database = new Database(1, 2, 3, 4, 5);
            this.database.Remove();
            Assert.AreEqual(this.database.Size, 4);
            Assert.IsTrue(this.database[3] != 0);
            Assert.IsTrue(this.database[4] == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemovingElementFromEmptyCollectionShouldThrowException()
        {
            this.database = new Database(1);
            this.database.Remove();
            this.database.Remove();
        }

        [TestMethod]
        public void ComparePrintingResults()
        {
            this.database = new Database(1,2,3);
            Assert.AreEqual("1, 2, 3", this.database.Fetch());
        }
    }
}
