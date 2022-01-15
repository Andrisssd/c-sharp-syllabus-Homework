using System.IO;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private string _pathEasy = "./Easy.txt";
        private string _pathHard = "./Hard.txt";
        private string _pathMiddle = "./Middle.txt";
        private const int WIDTH = 9;
        private const int HEIGHT = 9;
        private bool GameStarted = false;
        private TextBox[] _cells;

        public Form1()
        {
            InitializeComponent();
            _cells = GetCells();
        }

        private void bStartEasyGame_Click(object sender, EventArgs e)
        {
            if (!GameStarted)
            {
                string path = Path.GetFullPath(_pathEasy);
                int sudokuVars = File.ReadAllLines(path).Count();
                int randomIndex = new Random().Next(sudokuVars);
                string[] numbers = File.ReadAllLines(path).Select(line => line.Split(" ")).ToArray()[randomIndex];
                int index = 0;
                for (int j = 0; j < WIDTH * HEIGHT; j++)
                {
                    if (numbers[j] == "X")
                    {
                        _cells[index].Text = "";
                        index++;
                    }
                    else
                    {
                        _cells[index].Text = numbers[j];
                        _cells[index].ReadOnly = true;
                        index++;
                    }

                }
                tBSudokuNumber.Text = numbers.Last().ToString();
                tBDifficultyLevel.Text = "Easy";
                GameStarted = true;
                return;
            }
            foreach(var cell in this._cells)
            {
                cell.Text = "";
                cell.ReadOnly = false;
            }

            tBDifficultyLevel.Text = "Non";
            tBSudokuNumber.Text = "X";
            GameStarted = false;
        }

        private TextBox[] GetCells()
        {
            IEnumerable<TextBox> allTexboxes = Controls.OfType<TextBox>();
            TextBox[] sortedTextBoxes = allTexboxes
                                     .Where(i => String.IsNullOrEmpty(i.Text) && i.Name != "tBSudokuNumber")
                                     .OrderBy(i => i.Name)
                                     .ToArray();
            return sortedTextBoxes;
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            if (GameStarted)
            {
                var allCells = Controls.OfType<TextBox>().Where(cell => cell.Name != "tBDifficultyLevel" && cell.Name != "tBSudokuNumber").ToArray();
                bool allCellValuesAreNumbers = true;
                bool allCellLengthIsOne = true;
                bool allRowsAreUnique = true;
                bool allColumnsAreUnique = true;
                bool allBoxesAreUnique = true;
                foreach (var cell in allCells)
                {
                    if (cell.Text != "")
                    {
                        if (!Char.IsDigit(cell.Text[0]))
                        {
                            allCellValuesAreNumbers = false;
                        }

                        if (cell.Text.Length != 1)
                        {
                            allCellLengthIsOne = false;
                        }
                    }
                    else
                    {
                        allCellValuesAreNumbers = false;
                    }
                }
                if (allCellLengthIsOne && allCellValuesAreNumbers)
                {
                    for(int i = 0; i < 9; i++)
                    {
                        var row = new HashSet<int>();
                        for(int j = 0; j < 9; j++)
                        {
                            row.Add(int.Parse(allCells[(i * 9) + j].Text));
                        }

                        if (row.Count() != 9)
                        {
                            allRowsAreUnique = false;
                        }
                    }

                    for (int i = 0; i < 81; i += 9)
                    {
                        var column = new HashSet<int>();
                        for (int j = 0; j < 9; j++)
                        {
                            column.Add(int.Parse(allCells[i + j].Text));
                        }

                        if(column.Count() != 9)
                        {
                            allColumnsAreUnique = false;
                        }
                    }

                    for(int i = 0; i <= 60; i+=27)
                    {
                        var box = new HashSet<int>();
                        for(int j =0; j<3; j++)
                        {
                            for(int k =0; k <= 19; k += 9)
                            {
                                box.Add(int.Parse((allCells[j + k + i].Text)));
                            }
                        }

                        if(box.Count() != 9)
                        {
                            allBoxesAreUnique = false;
                        }
                    }

                    if (allBoxesAreUnique && allColumnsAreUnique && allRowsAreUnique)
                    {
                        MessageBox.Show("You win!");
                        return;
                    }
                }
            }

            MessageBox.Show("Something wrong, try again.");
        }

        private void bStartHardGame_Click(object sender, EventArgs e)
        {
            if (!GameStarted)
            {
                string path = Path.GetFullPath(_pathHard);
                int sudokuVars = File.ReadAllLines(path).Count();
                int randomIndex = new Random().Next(sudokuVars);
                string[] numbers = File.ReadAllLines(path).Select(line => line.Split(" ")).ToArray()[randomIndex];
                int index = 0;
                for (int j = 0; j < WIDTH * HEIGHT; j++)
                {
                    if (numbers[j] == "X")
                    {
                        _cells[index].Text = "";
                        index++;
                    }
                    else
                    {
                        _cells[index].Text = numbers[j];
                        _cells[index].ReadOnly = true;
                        index++;
                    }

                }
                tBSudokuNumber.Text = numbers.Last().ToString();
                tBDifficultyLevel.Text = "Hard";
                GameStarted = true;
                return;
            }
            foreach (var cell in this._cells)
            {
                cell.Text = "";
                cell.ReadOnly = false;
            }

            tBDifficultyLevel.Text = "Non";
            tBSudokuNumber.Text = "X";
            GameStarted = false;
        }

        private void bStartMiddleGame_Click(object sender, EventArgs e)
        {
            if (!GameStarted)
            {
                string path = Path.GetFullPath(_pathMiddle);
                int sudokuVars = File.ReadAllLines(path).Count();
                int randomIndex = new Random().Next(sudokuVars);
                string[] numbers = File.ReadAllLines(path).Select(line => line.Split(" ")).ToArray()[randomIndex];
                int index = 0;
                for (int j = 0; j < WIDTH * HEIGHT; j++)
                {
                    if (numbers[j] == "X")
                    {
                        _cells[index].Text = "";
                        index++;
                    }
                    else
                    {
                        _cells[index].Text = numbers[j];
                        _cells[index].ReadOnly = true;
                        index++;
                    }

                }
                tBSudokuNumber.Text = numbers.Last().ToString();
                tBDifficultyLevel.Text = "Medium";
                GameStarted = true;
                return;
            }
            foreach (var cell in this._cells)
            {
                cell.Text = "";
                cell.ReadOnly = false;
            }

            tBDifficultyLevel.Text = "Non";
            tBSudokuNumber.Text = "X";
            GameStarted = false;
        }
    }
}