using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class LifeCycle
    {
        private List<Cell> cells;
        public LifeCycle()
        {
            Cells = new List<Cell>();
        }
        public LifeCycle(List<Cell> cells)
        {
            Cells = cells;
        }

        public List<Cell> Cells
        {
            get
            {
                return cells;
            }

            private set
            {
                cells = value;
            }
        }
        
        public void Cycle() {
            List<Cell> newCells = new List<Cell>();
            List<Cell> neighborCells;
            List<Cell> neighborsOfNeighborCells;
            foreach (Cell cell in cells)
            {
                neighborCells = getNeighborCells(cell);
                cell.NeighborCount = getNeighborCellCount(neighborCells);
                //check for survival
                if (cell.NeighborCount == 2 || cell.NeighborCount == 3) {
                    if (!checkCellCollectionForCell(newCells, cell))
                    {
                        newCells.Add(cell);
                    }
                    
                }
                //check for neighbor birth
                foreach (Cell neighborCell in neighborCells) {
                    neighborsOfNeighborCells = getNeighborCells(neighborCell);
                    neighborCell.NeighborCount = getNeighborCellCount(neighborsOfNeighborCells);
                    if (neighborCell.NeighborCount == 3)
                    {
                        if (!checkCellCollectionForCell(newCells, neighborCell))
                        {
                            newCells.Add(neighborCell);
                        }
                    }
                }
            }
            cells = newCells;
        }

        public int getNeighborCellCount(List<Cell> neighborCells) {
            int neighborCellCount = 0;
            foreach (Cell neighborCell in neighborCells)
            {
                if (checkCellCollectionForCell(cells, neighborCell))
                {
                    neighborCellCount++;
                }
            }
            return neighborCellCount;
        }

        public bool checkCellCollectionForCell(List<Cell> cellCollection, Cell cellInQuestion)
        {
            foreach (Cell cell in cellCollection)
            {
                if (cellInQuestion.LocationX == cell.LocationX && cellInQuestion.LocationY == cell.LocationY)
                {
                    return true;
                }
            }

            return false;
        }

        public List<Cell> getNeighborCells(Cell cell)
        {
            var neighborCells = new List<Cell>();
            var currentCellX = cell.LocationX;
            var currentCellY = cell.LocationY;
            neighborCells.Add(new Cell(currentCellX + 1, currentCellY + 1));
            neighborCells.Add(new Cell(currentCellX + 1, currentCellY));
            neighborCells.Add(new Cell(currentCellX + 1, currentCellY - 1));
            neighborCells.Add(new Cell(currentCellX, currentCellY + 1));
            neighborCells.Add(new Cell(currentCellX, currentCellY - 1));
            neighborCells.Add(new Cell(currentCellX - 1, currentCellY + 1));
            neighborCells.Add(new Cell(currentCellX - 1, currentCellY));
            neighborCells.Add(new Cell(currentCellX - 1, currentCellY - 1));
            return neighborCells;
        }
    }
}
