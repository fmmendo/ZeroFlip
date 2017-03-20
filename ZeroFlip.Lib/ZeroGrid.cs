using Mendo.UWP.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZeroFlip.Lib
{
    public class ZeroGrid : ViewModelBase
    {
        public int GridSize => gridSize;
        public int TotalPoints => maxPoints;

        private int score;
        private int level;
        private int gridSize;
        private int numberOfCells;
        private int maxPoints;

        private Tile[,] grid;
        private Random Random = new Random();

        public ZeroGrid(int level = 1, int gridSize = 5)
        {
            this.level = level;
            this.gridSize = gridSize;

            numberOfCells = gridSize * gridSize;
            score = 0;

            CreateGrid(level);
        }

        public IEnumerable<Tile> GetRow(int row)
        {
            for (int i = 0; i < gridSize; i++)
                yield return grid[row, i];
        }

        public IEnumerable<Tile> GetColumn(int column)
        {
            for (int i = 0; i < gridSize; i++)
                yield return grid[i, column];
        }

        public int GetRowSum(int row)
        {
            return GetRow(row).Sum(t => t.Value);
        }

        public int GetRowZeros(int row)
        {
            return GetRow(row).Where(t => t.Value == 0).Count();
        }

        public int GetColumnSum(int column)
        {
            return GetColumn(column).Sum(t => t.Value);
        }

        public int GetColumnZeros(int column)
        {
            return GetColumn(column).Where(t => t.Value == 0).Count();
        }

        public void RevealTile(Tile t)
        {
            t.Revealed = true;
        }

        public void RevealTile(int row, int column)
        {
            grid[row, column].Revealed = true;
        }

        public void RevealBoard()
        {
            for (int i = 0; i < gridSize; i++)
                for (int j = 0; j < gridSize; j++)
                    grid[i, j].Revealed = true;
        }

        private void ResetGrid()
        {
            grid = new Tile[gridSize, gridSize];

            for (int i = 0; i < gridSize; i++)
                for (int j = 0; j < gridSize; j++)
                    grid[i, j] = new Tile { Value = 1 };
        }

        public int GetNumberOfMultipliersFlipped()
        {
            int num = 0;
            for (int i = 0; i < gridSize; i++)
                for (int j = 0; j < gridSize; j++)
                    if (grid[i, j].Revealed && grid[i, j].Value > 1)
                        num++;
            return num;
        }

        private void CreateGrid(int level = 1)
        {
            ResetGrid();

            // get the score range for current level
            var data = ScoringData.LevelMinMax.FirstOrDefault(l => l.Level == level);
            // get tile configurations for range of scores
            var scores = ScoringData.ScoreList.Where(i => i.Points >= data.Min && i.Points <= data.Max);
            // get a config for the current game
            var config = scores.ElementAt(Random.Next(scores.Count()));
            maxPoints = config.Points;

            var tileValues = new List<int>();

            for (int i = 0; i < config.Threes; i++)
                tileValues.Add(3);
            for (int i = 0; i < config.Twos; i++)
                tileValues.Add(2);
            for (int i = 0; i < level + gridSize; i++)
                tileValues.Add(0);

            var positions = GetListOfGridCells().ToList();
            while (tileValues.Count() > 0)
            {
                var tile = positions.ElementAt(Random.Next(positions.Count()));
                positions.Remove(tile);

                int count = 0;
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        if (count == tile)
                        {
                            grid[i, j].Value = tileValues.First();
                            tileValues.RemoveAt(0);
                            i = j = gridSize;
                            break;
                        }
                        count++;
                    }
                }
            }
        }

        private IEnumerable<int> GetListOfGridCells()
        {
            for (int i = 0; i < numberOfCells; i++)
                yield return i;
        }
    }
}
