using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConwaysGameOfLifeTest
{

    /// <summary>
    /// Test class for ConwaysGameOfLife.LifeCycle class.
    /// </summary>

    [TestClass]
    public class LifeCycleTest
    {

        /// <summary>
        /// 
        /// </summary>

        [TestMethod]
        public void LifeCycleDefaultConstructorTest()
        {
            LifeCycle lifeCycle = new LifeCycle();
            CollectionAssert.AreEqual(new List<Cell>(), lifeCycle.Cells);
        }

        /// <summary>
        /// 
        /// </summary>

        [TestMethod]
        public void LifeCycleListConstructorTest()
        {
            Cell cell1 = new Cell(1, 2);
            Cell cell2 = new Cell(3, 4);
            Cell cell3 = new Cell(5, 6);

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

        /// <summary>
        /// Tests LifeCycle.checkCellCollectionForCell().
        /// </summary>

        [TestMethod()]
        public void CheckCellCollectionForCellTest()
        {
            List<Cell> checkCellCollectionForCellTestCells = new List<Cell>();
            checkCellCollectionForCellTestCells.Add(new Cell(1, 2));
            checkCellCollectionForCellTestCells.Add(new Cell(111, 55));
            checkCellCollectionForCellTestCells.Add(new Cell(3, 2));

            LifeCycle lifeCycle = new LifeCycle(checkCellCollectionForCellTestCells);

            Assert.IsFalse(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(0, 0)));
            Assert.IsTrue(lifeCycle.checkCellCollectionForCell(lifeCycle.Cells, new Cell(111, 55)));

        }


        /// <summary>
        /// Tests LifeCycle.GetNeighborCell().
        /// </summary>

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

        /// <summary>
        /// Tests LifeCycle.GetNeighborCellCount().
        /// </summary>

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


        /// <summary>
        /// Blinker (period 2) - Simple Oscillator
        /// Test to ensure that well known simple oscillator patterns behave as expected. 
        /// See image for expected permutations:
        /// ./testPatternImages/Game_of_life_blinker.gif
        ///
        ///   1 2 3    1 2 3             
        /// 1   x    1           
        /// 2   x    2 x x x      
        /// 3   x    3                      
        /// 
        /// </summary>

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


        /// <summary>
        /// Block - Still lifes
        /// Test to ensure that well known still life patterns behave as expected. 
        /// See image for expected permutations:
        /// ./testPatternImages/Game_of_life_block_with_border.svg
        /// 
        ///   6 7 8 9                
        /// 4             
        /// 5   x x        
        /// 6   x x                  
        /// 7
        /// 
        /// </summary>

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

