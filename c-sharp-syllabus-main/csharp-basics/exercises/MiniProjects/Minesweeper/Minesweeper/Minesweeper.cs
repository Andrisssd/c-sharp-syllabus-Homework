using Minesweeper.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Minesweeper : Form
    {
        public Minesweeper()
        {
            InitializeComponent(this);

            var board = new Board(this, 9, 9, 10);
            board.SetupBoard();

            this.Width = board.Width * 52;
            this.Height = board.Height * 52 + 25;
            
        }

        public void Minesweeper_Load(object sender, EventArgs e)
        {
            
        }


    }
}
