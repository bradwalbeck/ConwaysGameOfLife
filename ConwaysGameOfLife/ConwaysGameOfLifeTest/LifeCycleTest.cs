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

            List<Cell> blinkerTextCellsHorizonal = new List<Cell>();
            blinkerTextCellsHorizonal.Add(new Cell(1, 2));
            blinkerTextCellsHorizonal.Add(new Cell(2, 2));
            blinkerTextCellsHorizonal.Add(new Cell(3, 2));

            LifeCycle lifeCycle = new LifeCycle(blinkerTextCellsVertical);

            lifeCycle.Cycle();

            CollectionAssert.AreEqual(blinkerTextCellsHorizonal, lifeCycle.Cells);
        }
    }
}
