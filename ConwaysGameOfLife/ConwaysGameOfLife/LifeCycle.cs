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
            //List<Cell> newCells = new List<Cell>();
            //foreach (Cell cell in cells) {
            //
            //}


        }
    }
}
