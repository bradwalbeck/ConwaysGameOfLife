
namespace ConwaysGameOfLife
{
    public class Cell
    {
        private int neighborCount, locationX, locationY;

        public Cell(int locationX, int locationY) {
            LocationX = locationX;
            LocationY = locationY;
            NeighborCount = 0;
        }

        public int LocationX
        {
            get
            {
                return locationX;
            }

            private set
            {
                locationX = value;
            }
        }

        public int LocationY
        {
            get
            {
                return locationY;
            }

            private set
            {
                locationY = value;
            }
        }

        public int NeighborCount
        {
            get
            {
                return neighborCount;
            }

            set
            {
                neighborCount = value;
            }
        }
    }
}
