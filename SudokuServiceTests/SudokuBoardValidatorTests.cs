using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuService.Models;
using SudokuService.Services;

namespace SudokuServiceTests
{
    [TestClass]
    public class SudokuBoardValidatorTests
    {
        [TestMethod]
        public void ValidBoard_True()
        {
            //arrange
            int[] cellvalues = new int[]{1, 8, 2, 0, 0, 0, 0, 0, 4, 0, 0, 7, 1, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0,
                6, 3, 9, 7, 0, 0, 0, 4, 0, 0, 6, 2, 0, 7, 3, 0, 0, 3, 0, 0, 0, 8, 9, 6, 0, 0, 7, 5, 0, 4, 3, 1, 8, 6, 0, 1,
                8, 0, 0, 5, 0, 0, 0, 0, 6, 4, 0, 0, 2, 0, 0, 0 };
            SudokuBoard board = new SudokuBoard(cellvalues);

            //act
            Result result = SudokuBoardValidator.Validate(board);

            //assert
            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public void RowNeighboursSame_False()
        {
            //arrange
            int[] cellvalues = new int[]{1, 1, 2, 0, 0, 0, 0, 0, 4, 0, 0, 7, 1, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0,
                6, 3, 9, 7, 0, 0, 0, 4, 0, 0, 6, 2, 0, 7, 3, 0, 0, 3, 0, 0, 0, 8, 9, 6, 0, 0, 7, 5, 0, 4, 3, 1, 8, 6, 0, 1,
                8, 0, 0, 5, 0, 0, 0, 0, 6, 4, 0, 0, 2, 0, 0, 0 };
            SudokuBoard board = new SudokuBoard(cellvalues);

            //act
            Result result = SudokuBoardValidator.Validate(board);

            //assert
            Assert.IsFalse(result.IsSuccess);

        }

        [TestMethod]
        public void ColumnNeighboursSame_False()
        {
            //arrange
            int[] cellvalues = new int[]{1, 8, 2, 0, 0, 0, 0, 0, 4, 0, 0, 7, 1, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0,
                6, 3, 9, 7, 0, 0, 0, 4, 0, 0, 6, 2, 0, 7, 3, 0, 1, 3, 0, 0, 0, 8, 9, 6, 0, 0, 7, 5, 0, 4, 3, 1, 8, 6, 0, 1,
                8, 0, 0, 5, 0, 0, 0, 0, 6, 4, 0, 0, 2, 0, 0, 0 };
            SudokuBoard board = new SudokuBoard(cellvalues);

            //act
            Result result = SudokuBoardValidator.Validate(board);

            //assert
            Assert.IsFalse(result.IsSuccess);

        }

        [TestMethod]
        public void BoxNeighboursSame_False()
        {
            //arrange
            int[] cellvalues = new int[]{1, 8, 2, 0, 0, 0, 0, 0, 4, 8, 0, 7, 1, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0,
                6, 3, 9, 7, 0, 0, 0, 4, 0, 0, 6, 2, 0, 7, 3, 0, 1, 3, 0, 0, 0, 8, 9, 6, 0, 0, 7, 5, 0, 4, 3, 1, 8, 6, 0, 1,
                8, 0, 0, 5, 0, 0, 0, 0, 6, 4, 0, 0, 2, 0, 0, 0 };
            SudokuBoard board = new SudokuBoard(cellvalues);

            //act
            Result result = SudokuBoardValidator.Validate(board);

            //assert
            Assert.IsFalse(result.IsSuccess);

        }
    }
}
