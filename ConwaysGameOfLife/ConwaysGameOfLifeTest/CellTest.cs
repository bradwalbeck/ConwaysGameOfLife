using System;
using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTest
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void CellConstructorTest()
        {
            Cell cell = new Cell(1, 2);
            
            Assert.AreEqual(cell.LocationX, 1);
            Assert.AreEqual(cell.LocationY, 2);
            Assert.AreEqual(cell.NeighborCount, 0);
        }

        [TestMethod]
        public void CellNeighborCountTest()
        {
            Cell cell = new Cell(1, 2);
            cell.NeighborCount = 3;
            Assert.AreEqual(cell.NeighborCount, 3);
            cell.neighborCountIncarment();
            Assert.AreEqual(cell.NeighborCount, 4);
        }
    }
}
