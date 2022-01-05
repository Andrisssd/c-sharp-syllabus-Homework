using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Minesweeper;

namespace Minesweeper.Core
{
    internal static class Counter
    {
        public static int TotalMines = 0;
        public static int MinesFlagged = 0;
        public static int TotalRegular = 0;
        public static int OpenedRegular = 0;

        public static void CheckForWin()
        {
            if(TotalMines == MinesFlagged && TotalRegular == OpenedRegular)
            {
                RebootCounter();
                MessageBox.Show("You win!");
                Application.Restart();
                Environment.Exit(0);
            }
        }

        public static void RebootCounter()
        {
            TotalMines = 0;
            MinesFlagged = 0;
            TotalRegular = 0;
            OpenedRegular = 0;
        }
    }
}
