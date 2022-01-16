using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class SudokuData
    {
        public int id { get; set; }
        public string sudoku { get; set; }
        public string level { get; set; }
        public string is_manual { get; set; }
    }
}
