using System;
using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConwaysGameOfLifeTest
{
    [TestClass]
    public class LifeCycleTest
    {
        Cell cell1 = new Cell(1, 2);
        Cell cell2 = new Cell(3, 4);
        Cell cell3 = new Cell(5, 6);

        [TestMethod]
        public void LifeCycleDefaultConstructorTest()
        {
            LifeCycle lifeCycle = new LifeCycle();
            CollectionAssert.AreEqual(new List<Cell>(), lifeCycle.Cells);
        }

        [TestMethod]
        public void LifeCycleListConstructorTest()
        {

            List<Cell> testCellsExpected = new List<Cell>();
            testCellsExpected.Add(cell1);
            testCellsExpected.Add(cell2);
            testCellsExpected.Add(cell3);

            List<Cell> testCells = new List<Cell>();
            testCells.Add(cell1);
            testCells.Add(cell2);
            testCells.Add(cell3);

            LifeCycle lifeCycle = new LifeCycle(testCells);

            CollectionAssert.AreEqual(testCellsExpected, lifeCycle.Cells);
        }

        [TestMethod()]
        public void CheckCellCollectionForCellTest()
        {
            LifeCycle lifeCycle = new LifeCycle();

            List<Cell> shouldBeTrueCells = new List<Cell>();
            shouldBeTrueCells.Add(new Cell(1, 2));
            shouldBeTrueCells.Add(new Cell(111, 55));
            shouldBeTrueCells.Add(new Cell(3, 2));

            Assert.IsFalse(lifeCycle.checkCellCollectionForCell(new List<Cell>(), new Cell(0, 0)));
            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(shouldBeTrueCells, new Cell(111, 55)));

        }

        [TestMethod]
        public void LifeCycleGetNeighborCellTest()
        {
            List<Cell> getNeighborCellCountCells = new List<Cell>();
            getNeighborCellCountCells.Add(new Cell(2, 1));
            getNeighborCellCountCells.Add(new Cell(2, 2));
            getNeighborCellCountCells.Add(new Cell(2, 3));

            LifeCycle lifeCycle = new LifeCycle(getNeighborCellCountCells);
            List<Cell> getNeighborCellsTestCells = lifeCycle.getNeighborCells(new Cell(1, 1));

            Assert.IsTrue(getNeighborCellsTestCells.Count == 8);

            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(getNeighborCellsTestCells, new Cell(2, 2)));
            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(getNeighborCellsTestCells, new Cell(2, 1)));
            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(getNeighborCellsTestCells, new Cell(2, 0)));

            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(getNeighborCellsTestCells, new Cell(1, 2)));
            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(getNeighborCellsTestCells, new Cell(1, 2)));

            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(getNeighborCellsTestCells, new Cell(0, 2)));
            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(getNeighborCellsTestCells, new Cell(0, 1)));
            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(getNeighborCellsTestCells, new Cell(0, 0)));

            Assert.IsFalse(lifeCycle.checkCellCollectionForCell(getNeighborCellsTestCells, new Cell(1, 1)));
        }

        [TestMethod]
        public void LifeCycleGetNeighborCellCountTest()
        {
            List<Cell> getNeighborCellCountCells = new List<Cell>();
            getNeighborCellCountCells.Add(new Cell(2, 1));
            getNeighborCellCountCells.Add(new Cell(2, 2));
            getNeighborCellCountCells.Add(new Cell(2, 3));

            LifeCycle lifeCycle = new LifeCycle(getNeighborCellCountCells);
            List<Cell> getNeighborCellsTestCells = lifeCycle.getNeighborCells(new Cell(1, 1));

            Assert.IsTrue(lifeCycle.getNeighborCellCount(getNeighborCellsTestCells) == 2);

            getNeighborCellsTestCells.RemoveAt(0);

            Assert.IsFalse(lifeCycle.getNeighborCellCount(getNeighborCellsTestCells) == 2);
        }



        // Blinker
        //   1 2 3    1 2 3             
        // 1   x    1           
        // 2   x    2 x x x      
        // 3   x    3                      

        [TestMethod]
        public void LifeCycleCycleTestBlinker()
        {

            List<Cell> blinkerTextCellsVertical = new List<Cell>();
            blinkerTextCellsVertical.Add(new Cell(2, 1));
            blinkerTextCellsVertical.Add(new Cell(2, 2));
            blinkerTextCellsVertical.Add(new Cell(2, 3));

            LifeCycle lifeCycle = new LifeCycle(blinkerTextCellsVertical);


            lifeCycle.Cycle();

            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(1, 2)));
            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(2, 2)));
            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(3, 2)));

            Assert.IsFalse(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(2, 3)));
            Assert.IsTrue(lifeCycle.Cells.Count == 3);

            lifeCycle.Cycle();

            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(2, 1)));
            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(2, 2)));
            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(2, 3)));

            Assert.IsFalse(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(1, 2)));
            Assert.IsTrue(lifeCycle.Cells.Count == 3);
        }

        // Block; still life
        //   6 7 8 9                
        // 4             
        // 5   x x        
        // 6   x x                  
        // 7

        [TestMethod]
        public void LifeCycleCycleTestBlock()
        {

            List<Cell> blockTestCells = new List<Cell>();
            blockTestCells.Add(new Cell(7, 5));
            blockTestCells.Add(new Cell(8, 5));
            blockTestCells.Add(new Cell(7, 6));
            blockTestCells.Add(new Cell(8, 6));

            LifeCycle lifeCycle = new LifeCycle(blockTestCells);


            for (var counter = 0; counter < 4; counter++)
            {
                lifeCycle.Cycle();

                Assert.IsTrue(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(7, 5)));
                Assert.IsTrue(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(8, 5)));
                Assert.IsTrue(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(7, 6)));
                Assert.IsTrue(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(8, 6)));

                Assert.IsFalse(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(2, 3)));
                Assert.IsTrue(lifeCycle.Cells.Count == 4);
            }
        }
    }
}

