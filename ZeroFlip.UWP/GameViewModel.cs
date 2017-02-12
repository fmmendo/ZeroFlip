using Mendo.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public GameViewModel()
        {
        }

        public void GenerateGrid(int level = 1, int size = 5)
        {
            grid = new ZeroGrid(level, size);


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
    }
}
