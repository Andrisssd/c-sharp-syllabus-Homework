using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Minesweeper.Core
{
    public class Board
    {
        public bool FirstClick = true;

        public Minesweeper Minesweeper { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int NumMines { get; set; }

        public Cell[,] Cells { get; set; }

        public Board(Minesweeper minesweeper, int width, int height, int mines)
        {
            this.Minesweeper = minesweeper;
            this.Width = width;
            this.Height = height;
            if(mines > (width * height)-1)
            {
                this.NumMines = (width * height)-1;
            }
            else
            {
                this.NumMines = mines;
            }
            this.Cells = new Cell[width, height];
            Counter.TotalMines = NumMines;
            Counter.TotalRegular = (width * height) - NumMines;
        }

        public void SetupBoard()
        {
            for (int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    var c = new Cell
                    {
                        XLoc = j,
                        YLoc = i,
                        CellState = CellState.Closed,
                        CellType = CellType.Regular,
                        CellSize = 50,
                        Board = this
                    };
                    c.SetupDesign();
                    c.MouseDown += Cell_MouseClick;
                    this.Cells[i, j] = c;
                    this.Minesweeper.Controls.Add(c);      
                }
            }
        }

        public void OpenAllCellsNeighbors(Cell cell)
        {
            if (cell.NumMines == 0)
            {
                int XPoint = cell.XLoc;
                int YPoint = cell.YLoc;

                for (int k = -1; k <= 1; k++)
                {
                    for (int kk = -1; kk <= 1; kk++)
                    {
                        try
                        {
                            Cell Cell = Cells[YPoint+k, XPoint+kk];
                            if(Cell.CellState == CellState.Closed)
                            {
                                Cell.OnClick();
                                OpenAllCellsNeighbors(Cell);
                            }
                        }
                        catch { };
                    }
                }
            }
        }

        public void GetNumOfMinesAroundCells()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for(int j = 0; j < Cells.GetLength(1); j++)
                {
                    int mineCount = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for(int kk = -1; kk <= 1; kk++)
                        {
                            try
                            {
                                Cell cell = this.Cells[i+k, j+kk];
                                if(cell.CellType == CellType.Mine)
                                {
                                    mineCount++;
                                }

                            }catch{ };
                        }
                    }
                        Cells[i, j].NumMines = mineCount;
                }
            }
        }

        public void PutMines()
        {
            int mineCount = 0;

            while(mineCount < NumMines)
            {
                int XRandom = new Random().Next(0, Cells.GetLength(1));
                int YRandom = new Random().Next(0, Cells.GetLength(0));

                Cell currentCell = Cells[XRandom, YRandom];
                if (currentCell.CellType != CellType.Mine && currentCell.CellState == CellState.Closed)
                {
                    currentCell.CellType = CellType.Mine;
                    mineCount++;
                }
            }
        }

        public void Cell_MouseClick(object sender, MouseEventArgs e)
        {
            var cell = (Cell) sender;
            
            if (cell.CellState == CellState.Opened)
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (FirstClick)
                    {
                        cell.CellState = CellState.Opened;
                        PutMines();
                        GetNumOfMinesAroundCells();
                        cell.OnClick();
                        OpenAllCellsNeighbors(cell);
                        FirstClick = false;
                        break;
                    }

                    cell.OnClick();
                    OpenAllCellsNeighbors(cell);
                    break;

                case MouseButtons.Right:
                    cell.OnFlag();
                    break;

                default:
                    return;
            }
        }
    }
}
