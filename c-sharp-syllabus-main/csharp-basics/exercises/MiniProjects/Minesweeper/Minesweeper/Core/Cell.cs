using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper;

namespace Minesweeper.Core
{
    public enum CellType
    {
        Regular, Mine, Flagged, FlaggedMine
    }

    public enum CellState
    {
        Opened, Closed
    }
        public class Cell : Button
    {
        public int XLoc { get; set; }
        public int YLoc { get; set; }
        public int CellSize { get; set; }
        public CellState CellState { get; set; }
        public CellType CellType { get; set; }
        public int NumMines { get; set; }
        public Board Board { get; set; }

        public void SetupDesign()
        {
            this.Location = new Point(XLoc * CellSize, YLoc * CellSize);
            this.Size = new Size(CellSize, CellSize);
            this.UseVisualStyleBackColor = false;
            this.Font = new Font("Verdana", 15.75F, FontStyle.Bold);
        }

        public void OnFlag()
        {
            if (this.CellType != CellType.Flagged)
            {
                this.BackColor = Color.Gray;
                this.ForeColor = Color.White;
                this.Text = "?";
                if (this.CellType == CellType.Mine)
                {
                    this.CellType = CellType.FlaggedMine;
                    Counter.MinesFlagged++;
                    Counter.CheckForWin();
                    return;
                }

                this.CellType = CellType.Flagged;
                return;
            }

            if(this.CellType == CellType.FlaggedMine)
            {
                Counter.MinesFlagged--;
            }

            this.Text = String.Empty;
            this.BackColor = DefaultBackColor;
            this.ForeColor = DefaultForeColor;
            this.CellType = CellType.Regular;
            Counter.CheckForWin();
        }

        public void OnClick(bool recursiveCall = false)
        {
            if (!recursiveCall && this.CellType != CellType.Mine)
            {
                this.CellState = CellState.Opened;
                this.BackColor = ColorTranslator.FromHtml("#cccfcf");
                this.ForeColor = GetCellColour();
                if (NumMines > 0)
                {
                    this.Text = NumMines.ToString();
                }
                else
                {
                    this.Text = String.Empty;
                }

                Counter.OpenedRegular++;
                Counter.CheckForWin();
                return;
            }

            this.Text = "M";
            Counter.RebootCounter();
            MessageBox.Show("Game end!");
            Application.Restart();
            Environment.Exit(0);
        }

        /// <summary>
        /// Return the colour code associated with the number of surrounding mines
        /// </summary>
        /// <returns></returns>
        public Color GetCellColour()
        {
            switch (this.NumMines)
            {
                case 1:
                    return ColorTranslator.FromHtml("0x0000FE"); // 1
                case 2:
                    return ColorTranslator.FromHtml("0x186900"); // 2
                case 3:
                    return ColorTranslator.FromHtml("0xAE0107"); // 3
                case 4:
                    return ColorTranslator.FromHtml("0x000177"); // 4
                case 5:
                    return ColorTranslator.FromHtml("0x8D0107"); // 5
                case 6:
                    return ColorTranslator.FromHtml("0x007A7C"); // 6
                case 7:
                    return ColorTranslator.FromHtml("0x902E90"); // 7
                case 8:
                    return ColorTranslator.FromHtml("0x000000"); // 8
                default:
                    return ColorTranslator.FromHtml("0xffffff");
            }
        }
    }
}
