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
        private const int WIDTH = 9;
        private const int HEIGHT = 9;
        private string currentLevel = "manual";
        private TextBox[] _cells;
        private SudokuData _data;
        private bool gameStarted = false;

        public Form1()
        {
            InitializeComponent();
            _cells = GetCells();
            LoadSaveList();
            textBox3.ReadOnly = true;
            cBLoadList.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void bStartEasyGame_Click(object sender, EventArgs e)
        {
            MakeField("easy");
        }

        private TextBox[] GetCells()
        {
            IEnumerable<TextBox> allTexboxes = Controls.OfType<TextBox>();
            TextBox[] sortedTextBoxes = allTexboxes
                                     .Where(i => i.Name != "tBDifficultyLevel" &&
                                     i.Name != "tBSudokuNumber" &&
                                     i.Name != "textBox2" &&
                                     i.Name != "textBox1")
                                     .OrderBy(i => i.Name)
                                     .ToArray();
            return sortedTextBoxes;
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            var allCells = Controls.OfType<TextBox>().Where(cell => cell.Name != "tBDifficultyLevel" &&
            cell.Name != "tBSudokuNumber" &&
            cell.Name != "textBox2" &&
            cell.Name != "textBox1" &&
            cell.Name != "textBox3").ToArray();
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
                for (int i = 0; i < 9; i++)
                {
                    var row = new HashSet<int>();
                    for (int j = 0; j < 9; j++)
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

                    if (column.Count() != 9)
                    {
                        allColumnsAreUnique = false;
                    }
                }

                for (int i = 0; i <= 60; i += 27)
                {
                    var box = new HashSet<int>();
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k <= 19; k += 9)
                        {
                            box.Add(int.Parse((allCells[j + k + i].Text)));
                        }
                    }

                    if (box.Count() != 9)
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

            MessageBox.Show("Something wrong, try again.");
        }

        private void bStartHardGame_Click(object sender, EventArgs e)
        {
            MakeField("hard");
        }

        private void bStartMiddleGame_Click(object sender, EventArgs e)
        {
            MakeField("medium");
        }

        private SudokuData[] GetCellsFromDB(string level = "", bool fromSaves = false)
        {
            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string table;
                if (fromSaves)
                {
                    table = "TableSaves";
                }
                else
                {
                    table = "TableSudoku";
                }
                var output = cnn.Query<SudokuData>($"select * from {table}", new DynamicParameters()).ToList();
                List<SudokuData> neededSudokus;
                if (level != "")
                {
                    neededSudokus = output.Where(x => x.level == level).ToList();
                }
                else
                {
                    neededSudokus = output;
                }

                return neededSudokus.ToArray();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private void bSaveCells_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                using (var cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    SudokuData data = new SudokuData();
                    var allCells = GetCells();
                    var numbers = new List<string>();
                    for (int i = 0; i < 81; i++)
                    {
                        if (allCells[i].Text == "")
                        {
                            numbers.Add("X");
                        }
                        else
                        {
                            numbers.Add(allCells[i].Text);
                        }
                    }
                    string[] numbersArr = numbers.ToArray();
                    string numbersStr = string.Join(" ", numbersArr);
                    data.id = int.Parse(tBSudokuNumber.Text);
                    data.sudoku = numbersStr;
                    data.level = currentLevel;
                    data.c_time = DateTime.Now.ToString();
                    data.closed_cells = _data.closed_cells;


                    cnn.Execute("insert into TableSaves (id, sudoku, level, c_time, closed_cells) values (@id, @sudoku, @level, @c_time, @closed_cells);", data);

                    LoadSaveList();
                }

                return;
            }

            MessageBox.Show("Load or start game to save it");
        }

        private void LoadSaveList()
        {
            var data = GetCellsFromDB(fromSaves: true);
            if (data.Count() > 0)
            {
                cBLoadList.DataSource = data.Select(x => x.c_time.ToString()).ToArray();
            }
        }

        private void bLoadSave_Click(object sender, EventArgs e)
        {
            LoadField();
        }

        private void MakeField(string level)
        {
            gameStarted = true;
            foreach (var cell in this._cells)
            {
                if (cell.Name != "textBox3")
                {
                    cell.Text = "";
                    cell.ReadOnly = false;
                }
            }

            _data = null;
            int currentId = 0;
            int.TryParse(tBSudokuNumber.Text, out currentId);
            SudokuData[] sudokus = GetCellsFromDB(level).Where(x=>x.id!=currentId).ToArray();
            int randomIndex = new Random().Next(sudokus.Length);
            SudokuData sudoku = sudokus[randomIndex];
            _data = sudoku;
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
            tBDifficultyLevel.Text = level.Substring(0, 1).ToUpper() + level.Substring(1).ToLower(); ;
            currentLevel = level;
            return;
        }

        private void LoadField()
        {
            if (cBLoadList.Items.Count != 0)
            {
                gameStarted = true;
                var time = cBLoadList.Text;
                foreach (var cell in this._cells)
                {
                    if (cell.Name != "textBox3")
                    {
                        cell.Text = "";
                        cell.ReadOnly = false;
                    }
                }
                _data = null;
                SudokuData[] sudokus = GetCellsFromDB(fromSaves: true).Where(x => x.c_time == time).ToArray();
                int randomIndex = new Random().Next(sudokus.Length);
                SudokuData sudoku = sudokus[randomIndex];
                _data = sudoku;
                int[] cellStates = sudoku.closed_cells.Split(" ").Select(x => int.Parse(x.ToString())).ToArray();
                int sudokusId = sudoku.id;
                string[] numbers = sudoku.sudoku.Split(" ");

                int index = 0;
                for (int j = 0; j < WIDTH * HEIGHT; j++)
                {
                    if (cellStates[index] == 1)
                    {
                        _cells[index].ReadOnly = true;
                    }

                    if (numbers[j] == "X")
                    {
                        _cells[index].Text = "";
                        index++;
                    }
                    else
                    {
                        _cells[index].Text = numbers[j];
                        index++;
                    }
                }
                tBSudokuNumber.Text = $"{sudokusId}";
                tBDifficultyLevel.Text = sudoku.level;
                currentLevel = sudoku.level;
                return;
            }

            MessageBox.Show("No save selected!");
        }
    }
}