using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Minesweeper.Core;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper.Tests
{
    [TestClass]
    public class CellTests
    {
        private Cell _cell;

        [TestInitialize]
        public void Setup()
        {
            _cell = new Cell();
        }

        [TestMethod]
        public void OnFlag_ShouldSetCellTypeToFlagged()
        {
            //Arrange
            string expectedType = "Flagged";
            //Act
            _cell.OnFlag();
            string actualType = _cell.CellType.ToString();
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedType, actualType);
        }

        [TestMethod]
        public void OnFlag_ShouldSetMineToFlaggedMine()
        {
            //Arrange
            string expectedType = "FlaggedMine";
            _cell.CellType = CellType.Mine;
            //Act
            _cell.OnFlag();
            string actualType = _cell.CellType.ToString();
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedType, actualType);
        }

        [TestMethod]
        [DataRow(1, "0x0000FE")]
        [DataRow(2, "0x186900")]
        [DataRow(3, "0xAE0107")]
        [DataRow(4, "0x000177")]
        [DataRow(5, "0x8D0107")]
        [DataRow(6, "0x007A7C")]
        [DataRow(7, "0x902E90")]
        [DataRow(8, "0x000000")]
        [DataRow(0, "0xffffff")]
        public void GetCellColour_NumMinesAndColor_ShouldBeEqual(int numOfMines, string color)
        {
            //Arrange
            _cell.NumMines = numOfMines;
            Color expectedColor = ColorTranslator.FromHtml(color);
            //Act
            Color actualColor = _cell.GetCellColour();
            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedColor, actualColor);
        }
    }
}
