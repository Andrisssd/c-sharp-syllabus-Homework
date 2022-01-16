using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
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
        private string currentLevel = "manual";
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
                SudokuData[] sudokus = GetCellsFromDB("easy").Where(x=>x.is_manual!="true").ToArray();
                int randomIndex = new Random().Next(sudokus.Length);
                SudokuData sudoku = sudokus[randomIndex];
                int sudokusId = sudoku.id;
                string[] numbers = sudoku.sudoku.Split(" ");

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
                tBSudokuNumber.Text = $"{sudokusId}";
                tBDifficultyLevel.Text = "Easy";
                currentLevel = "easy";
                GameStarted = true;
                return;
            }
            foreach (var cell in this._cells)
            {
                cell.Text = "";
                cell.ReadOnly = false;
            }

            tBDifficultyLevel.Text = "Non";
            currentLevel = "manual";
            tBSudokuNumber.Text = "X";
            GameStarted = false;
        }

        private TextBox[] GetCells()
        {
            IEnumerable<TextBox> allTexboxes = Controls.OfType<TextBox>();
            TextBox[] sortedTextBoxes = allTexboxes
                                     .Where(i => String.IsNullOrEmpty(i.Text) && i.Name != "tBDifficultyLevel" &&
                                     i.Name != "tBSudokuNumber" &&
                                     i.Name != "textBox2" &&
                                     i.Name != "textBox1")
                                     .OrderBy(i => i.Name)
                                     .ToArray();
            return sortedTextBoxes;
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            if (GameStarted)
            {
                var allCells = Controls.OfType<TextBox>().Where(cell => cell.Name != "tBDifficultyLevel" &&
                cell.Name != "tBSudokuNumber" &&
                cell.Name != "textBox2" && 
                cell.Name != "textBox1").ToArray();
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
                SudokuData[] sudokus = GetCellsFromDB("hard").Where(x=>x.is_manual!="true").ToArray();
                int randomIndex = new Random().Next(sudokus.Length);
                SudokuData sudoku = sudokus[randomIndex];
                int sudokusId = sudoku.id;
                string[] numbers = sudoku.sudoku.Split(" ");

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
                tBSudokuNumber.Text = $"{sudokusId}";
                tBDifficultyLevel.Text = "Hard";
                currentLevel = "hard";
                GameStarted = true;
                return;
            }
            foreach (var cell in this._cells)
            {
                cell.Text = "";
                cell.ReadOnly = false;
            }

            tBDifficultyLevel.Text = "Non";
            currentLevel = "manual";
            tBSudokuNumber.Text = "X";
            GameStarted = false;
        }

        private void bStartMiddleGame_Click(object sender, EventArgs e)
        {
            if (!GameStarted)
            {
                SudokuData[] sudokus = GetCellsFromDB("medium").Where(x=>x.is_manual!="true").ToArray();
                int randomIndex = new Random().Next(sudokus.Length);
                SudokuData sudoku = sudokus[randomIndex];
                int sudokusId = sudoku.id;
                string[] numbers = sudoku.sudoku.Split(" ");

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
                tBSudokuNumber.Text = $"{sudokusId}";
                tBDifficultyLevel.Text = "Medium";
                currentLevel = "medium";
                GameStarted = true;
                return;
            }
            foreach (var cell in this._cells)
            {
                cell.Text = "";
                cell.ReadOnly = false;
            }

            tBDifficultyLevel.Text = "Non";
            currentLevel = "manual";
            tBSudokuNumber.Text = "X";
            GameStarted = false;
        }

        private SudokuData[] GetCellsFromDB(string level)
        {
            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SudokuData>("select * from TableSudoku", new DynamicParameters()).ToList();
                var neededSudokus = output.Where(x => x.level == level).ToArray();
                return neededSudokus;
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private void bSaveCells_Click(object sender, EventArgs e)
        {
            using(var cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SudokuData data = new SudokuData();
                var allCells = Controls.OfType<TextBox>().Where(cell => cell.Name != "tBDifficultyLevel" &&
                cell.Name != "tBSudokuNumber" &&
                cell.Name != "textBox2" &&
                cell.Name != "textBox1").ToArray();
                
                var numbers = new List<string>();
                for(int i =0; i<81; i++)
                {
                    if(allCells[i].Text == "")
                    {
                        numbers.Add("X");
                    }
                    else
                    {
                        numbers.Add(allCells[i].Text);
                    }
                }
                string[] numbersArr = numbers.ToArray();
                Array.Reverse(numbersArr);
                string numbersStr = string.Join(" ", numbersArr);
                data.sudoku = numbersStr;
                data.level = currentLevel;
                data.is_manual = "true";
                

                cnn.Execute("insert into TableSudoku (sudoku, level, is_manual) values (@sudoku, @level, @is_manual);",data);
            }
        }
    }
}