using Mendo.UWP;
using Mendo.UWP.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZeroFlip.Lib
{
    public class Game : ViewModelBase
    {
        public ZeroGrid Grid { get; private set; }
        public int Level { get { return GetV(1); } set { Set(value); } }
        public int CurrentScore { get { return GetV(0); } set { Set(value); } }
        public int GameScore { get { return GetV(0); } set { Set(value); } }

        public bool? NotesMode { get { return GetV(false); } set { Set(value); if (!value.Value) { Notes0 = Notes1 = Notes2 = Notes3 = false; } } }
        public bool? Notes0 { get { return GetV(false); } set { Set(value); if (value.Value) { Notes1 = Notes2 = Notes3 = false; } } }
        public bool? Notes1 { get { return GetV(false); } set { Set(value); if (value.Value) { Notes0 = Notes2 = Notes3 = false; } } } 
        public bool? Notes2 { get { return GetV(false); } set { Set(value); if (value.Value) { Notes0 = Notes1 = Notes3 = false; } } } 
        public bool? Notes3 { get { return GetV(false); } set { Set(value); if (value.Value) { Notes0 = Notes1 = Notes2 = false; } } } 

        public BindableCollection<Tile[]> Rows { get { return Get<BindableCollection<Tile[]>>(); } set { Set(value); } }
        public BindableCollection<int> RowSum { get { return Get<BindableCollection<int>>(); } set { Set(value); } }
        public BindableCollection<int> RowZeros { get { return Get<BindableCollection<int>>(); } set { Set(value); } }
        public BindableCollection<int> ColumnSum { get { return Get<BindableCollection<int>>(); } set { Set(value); } }
        public BindableCollection<int> ColumnZeros { get { return Get<BindableCollection<int>>(); } set { Set(value); } }

        private bool gameWon = false;
        private int winningSpree = 0;
        private int losingSpree = 0;
        private int multipliersRevealed = 0;

        public event EventHandler<GameEndedEventArgs> GameEnded;

        public Game()
        {

        }


        public void NewGame(int level = 1, int size = 5)
        {
            Level = level;
            CurrentScore = 0;
            multipliersRevealed = 0;

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
            if (NotesMode.HasValue && NotesMode.Value)
            {
                if (Notes0.HasValue && Notes0.Value)
                    t.HintZero = !t.HintZero;
                else if(Notes1.HasValue && Notes1.Value)
                    t.HintOne = !t.HintOne;
                else if (Notes2.HasValue && Notes2.Value)
                    t.HintTwo = !t.HintTwo;
                else if(Notes3.HasValue && Notes3.Value)
                    t.HintThree = !t.HintThree;
            }
            else
            {
                Grid.RevealTile(t);
                UpdateScore(t.Value);
            }
        }

        private void UpdateScore(int value)
        {
            if (CurrentScore == 0)
                CurrentScore = 1;

            CurrentScore *= value;

            if (value > 1)
                multipliersRevealed++;

            if (value == 0)
            {
                Grid.RevealBoard();
                GameScore += CurrentScore;
                gameWon = false;
                GameEnded?.Invoke(this, new GameEndedEventArgs { Header = Constants.LoseHeader, Message = Constants.LoseMessage, NextLevel = GetNextLevel() });
            }
            else if (CurrentScore == Grid.TotalPoints)
            {
                Grid.RevealBoard();
                GameScore += CurrentScore;
                gameWon = true;
                GameEnded?.Invoke(this, new GameEndedEventArgs { Header = Constants.WinHeader, Message = Constants.WinMessage, NextLevel = GetNextLevel() });
            }
        }

        private int GetNextLevel()
        {
            if (gameWon)
            {
                losingSpree = 0;
                winningSpree += 1;
                if (winningSpree >= 7)
                    return 8;

                return Level + 1;
            }
            else
            {
                winningSpree = 0;
                losingSpree += 1;
                //if (CurrentScore <= 1)
                //    return 1;

                var numberOfMultipliers = Grid.GetNumberOfMultipliers();

                //lost on first move, drop all the way down
                if (multipliersRevealed == 0)
                    return 1;
                // lost just before the end, stay in same level
                else if (multipliersRevealed == numberOfMultipliers - 1)
                    return Level;
                // lost more than half the way through the grid, and have beem losing a lot, drop half the levels
                else if (multipliersRevealed > numberOfMultipliers / 2 && losingSpree > 2)
                    return Math.Max(1, Level / 2);
                // lost more than half the way through the map, but haven't lost a lot, drop just one level
                else if (multipliersRevealed > numberOfMultipliers / 2 && losingSpree <= 2)
                    return Level - 1;
                // lost fairly early on, drop half the levels
                else if (multipliersRevealed < numberOfMultipliers / 2)
                    return Math.Max(1, Level / 2);
                // I don't know what happend, here have a repeat
                else
                    return Level;
            }
        }
    }
}
