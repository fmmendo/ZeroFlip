using Mendo.UWP;
using Mendo.UWP.Common;
using System;
using System.Linq;

namespace ZeroFlip.Lib
{
    public class Game : ViewModelBase
    {
        public ZeroGrid Grid { get; private set; }
        public int Level { get; private set; }
        public int CurrentScore { get; private set; }
        public int GameScore { get; private set; }

        public BindableCollection<Tile[]> Rows { get { return Get<BindableCollection<Tile[]>>(); } set { Set(value); } }
        public BindableCollection<int> RowSum { get { return Get<BindableCollection<int>>(); } set { Set(value); } }
        public BindableCollection<int> RowZeros { get { return Get<BindableCollection<int>>(); } set { Set(value); } }
        public BindableCollection<int> ColumnSum { get { return Get<BindableCollection<int>>(); } set { Set(value); } }
        public BindableCollection<int> ColumnZeros { get { return Get<BindableCollection<int>>(); } set { Set(value); } }

        private bool gameWon = false;
        private int winningSpree = 0;

        public event EventHandler<GameEndedEventArgs> GameEnded;

        public Game()
        {
        }

        public void NewGame(int level = 1, int size = 5)
        {
            Level = level;
            CurrentScore = 0;

            Grid = new ZeroGrid(level, size);

            Rows = new BindableCollection<Tile[]>();
            RowSum = new BindableCollection<int>();
            RowZeros = new BindableCollection<int>();
            ColumnSum = new BindableCollection<int>();
            ColumnZeros = new BindableCollection<int>();

            for (int i = 0; i < Grid.GridSize; i++)
            {
                Rows.Add(Grid.GetRow(i).ToArray());

                RowSum.Add(Grid.GetRowSum(i));
                ColumnSum.Add(Grid.GetColumnSum(i));

                RowZeros.Add(Grid.GetRowZeros(i));
                ColumnZeros.Add(Grid.GetColumnZeros(i));
            }
        }

        public void TileClick(Tile t)
        {
            Grid.RevealTile(t);
            UpdateScore(t.Value);
        }

        private void UpdateScore(int value)
        {
            if (CurrentScore == 0)
                CurrentScore = 1;

            CurrentScore *= value;

            if (value == 0)
            {
                Grid.RevealBoard();
                GameScore += CurrentScore;
                gameWon = true;
                GameEnded?.Invoke(this, new GameEndedEventArgs { Message = "Game Over", NextLevel = GetNextLevel() });
            }
            else if (CurrentScore == Grid.TotalPoints)
            {
                Grid.RevealBoard();
                gameWon = false;
                GameEnded?.Invoke(this, new GameEndedEventArgs { Message = "You Win", NextLevel = GetNextLevel() });
            }
        }

        private int GetNextLevel()
        {
            if (gameWon)
            {
                winningSpree += 1;
                if (winningSpree >= 7)
                    return 8;

                return Level + 1;
            }
            else
            {
                if (CurrentScore <= 1)
                    return 1;

                return Math.Min(Level, Grid.GetNumberOfMultipliersFlipped());
            }
        }
    }
}
