using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFlip.Lib
{
    public class ZeroGrid
    {
        private int level;
        private int gridSize;
        private int[,] grid;

        public ZeroGrid(int level = 1, int gridSize = 5)
        {
            this.level = level;
            this.gridSize = gridSize;
            grid = new int[gridSize, gridSize];
        }

        public IEnumerable<int> GetRow(int row)
        {
            for (int i = 0; i < gridSize; i++)
                yield return grid[row, i];
        }

        public IEnumerable<int> GetColumn(int column)
        {
            for (int i = 0; i < gridSize; i++)
                yield return grid[i, column];
        }

        public int GetRowSum(int row)
        {
            return GetRow(row).Sum();
        }

        public int GetRowZeros(int row)
        {
            return GetRow(row).Select(i => i == 0).Count();
        }

        public int GetColumnSum(int column)
        {
            return GetColumn(column).Sum();
        }

        public int GetColumnZeros(int column)
        {
            return GetColumn(column).Select(i => i == 0).Count();
        }
    }
}
