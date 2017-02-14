using Mendo.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ZeroFlip.Lib;
using ZeroFlip.UWP.Common;

namespace ZeroFlip.UWP
{
    public class GameViewModel : ViewModelBase
    {
        ZeroGrid grid;
        public int Level { get; set; }

        public BindableCollection<Tile[]> Rows { get { return Get(new BindableCollection<Tile[]>()); } set { Set(value); } }

        public BindableCollection<int> RowSum { get { return Get(new BindableCollection<int>()); } set { Set(value); } }
        public BindableCollection<int> RowZeros { get { return Get(new BindableCollection<int>()); } set { Set(value); } }

        public BindableCollection<int> ColumnSum { get { return Get(new BindableCollection<int>()); } set { Set(value); } }
        public BindableCollection<int> ColumnZeros { get { return Get(new BindableCollection<int>()); } set { Set(value); } }

        public int Score { get { return grid.Score; } }

        public GameViewModel()
        {
        }

        public void NewGame()
        {
            GenerateGrid(1, 5);
        }

        public void GenerateGrid(int level = 1, int size = 5)
        {
            grid = new ZeroGrid(level, size);
            grid.GameEnded += Grid_GameEnded;

            Rows = new BindableCollection<Tile[]>();

            RowSum = new BindableCollection<int>();
            RowZeros = new BindableCollection<int>();
            ColumnSum = new BindableCollection<int>();
            ColumnZeros = new BindableCollection<int>();

            for (int i = 0; i < grid.GridSize; i++) {
                Rows.Add(grid.GetRow(i).ToArray());

                RowSum.Add(grid.GetRowSum(i));
                ColumnSum.Add(grid.GetColumnSum(i));

                RowZeros.Add(grid.GetRowZeros(i));
                ColumnZeros.Add(grid.GetColumnZeros(i));
            }
        }

        private async void Grid_GameEnded(object sender, GameEndedEventArgs args)
        {
            grid.GameEnded += Grid_GameEnded;

            MessageDialog md = new MessageDialog(args.Message);
            
            var result = await md.ShowAsync();

            GenerateGrid(args.NextLevel);
        }

        public void TileClick(Tile t)
        {
            grid.RevealTile(t);

            OnPropertyChanged(nameof(Score));
        }
    }
}
