using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Minesweeper.Core;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper.Tests
{
    [TestClass]
    public class BoardTests
    {
        private Minesweeper _minesweeper;
        private Dictionary<string,Board> _board;
        private Cell _cell;

        [TestInitialize]
        public void Setup()
        {
            _minesweeper = new Minesweeper();

            var boardFiveFiveZero = new Board(_minesweeper, 5, 5, 0);
            var boardOneOneOne = new Board(_minesweeper, 1, 1, 1);
            var boardFiveFiveFive = new Board(_minesweeper, 5, 5, 5);
            var boardTwentyTwentyOne = new Board(_minesweeper, 20, 20, 1);

            _board = new Dictionary<string, Board>();
            _board.Add("FiveFiveZero",boardFiveFiveZero);
            _board.Add("OneOneOne", boardOneOneOne);
            _board.Add("FiveFiveFive", boardFiveFiveFive);
            _board.Add("TwentyTwentyOne", boardTwentyTwentyOne);

            var cell = new Cell();
        }

        [TestMethod]
        public void SetupBoard_FiveFiveZeroBoard_ShouldIncrementCellsCount()
        {
            //Arrange
            int expectedCellsCount = 25;
            //Act
            Board board = _board["FiveFiveZero"];
            board.SetupBoard();

            int actualCellsCount = board.Cells.GetLength(0) * board.Cells.GetLength(1);
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedCellsCount, actualCellsCount);
        }

        [TestMethod]
        public void SetupBoard_OneOneOneBoard_ShouldIncrementCellsCount()
        {
            //Arrange
            int expectedCellsCount = 1;
            //Act
            Board board = _board["OneOneOne"];
            board.SetupBoard();

            int actualCellsCount = board.Cells.GetLength(0) * board.Cells.GetLength(1);
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedCellsCount, actualCellsCount);
        }

        [TestMethod]
        public void PutMines_FiveFiveZeroBoard_ShouldPutZeroBombs()
        {
            //Arrange
            int expectedMineCount = 0;
            //Act
            Board board = _board["FiveFiveZero"];
            board.SetupBoard();
            board.PutMines();

            int actualMineCount = 0;

            for(int i = 0; i < board.Cells.GetLength(0); i++)
            {
                for(int j = 0; j < board.Cells.GetLength(1); j++)
                {
                    if(board.Cells[i,j].CellType == CellType.Mine)
                    {
                        actualMineCount++;
                    }
                }
            }
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMineCount, actualMineCount);
        }

        [TestMethod]
        public void PutMines_FiveFiveFiveBoard_ShouldPutFiveBombs()
        {
            //Arrange
            int expectedMineCount = 5;
            //Act
            Board board = _board["FiveFiveFive"];
            board.SetupBoard();
            board.PutMines();

            int actualMineCount = 0;

            for (int i = 0; i < board.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < board.Cells.GetLength(1); j++)
                {
                    if (board.Cells[i, j].CellType == CellType.Mine)
                    {
                        actualMineCount++;
                    }
                }
            }
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMineCount, actualMineCount);
        }

        [TestMethod]
        public void PutMines_OneOneOneBoard_ShouldPutZeroBombs()
        {
            //Arrange
            int expectedMineCount = 0;
            //Act
            Board board = _board["OneOneOne"];
            board.SetupBoard();
            board.PutMines();

            int actualMineCount = 0;

            for (int i = 0; i < board.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < board.Cells.GetLength(1); j++)
                {
                    if (board.Cells[i, j].CellType == CellType.Mine)
                    {
                        actualMineCount++;
                    }
                }
            }
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMineCount, actualMineCount);
        }

        [TestMethod]
        public void OpenAllCellsNeighbors_FiveFiveZeroBoard_ShouldOpenAllCells()
        {
            //Arrange
            int expectedOpenCellCount = 25;
            //Act
            Board board = _board["FiveFiveZero"];
            board.SetupBoard();

            Cell cell = board.Cells[2, 2];
            cell.OnClick();
            board.OpenAllCellsNeighbors(cell);

            int actualOpenCellCount = 0;

            for (int i = 0; i < board.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < board.Cells.GetLength(1); j++)
                {
                    if (board.Cells[i, j].CellState == CellState.Opened)
                    {
                        actualOpenCellCount++;
                    }
                }
            }
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedOpenCellCount, actualOpenCellCount);
        }
    }
}
