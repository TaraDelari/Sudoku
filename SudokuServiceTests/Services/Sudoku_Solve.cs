using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SudokuService.Contracts;
using SudokuService.Models;
using SudokuService.Services;

namespace SudokuServiceTests.Services
{
    [TestClass]
    public class Sudoku_Solve
    {
        [TestMethod]
        public void InvalidBoard_FailureReturned()
        {
            //arrange
            Result expectedResult = new Result
            {
                IsSuccess = false,
                Error = "Test error"
            };
            SudokuBoard testBoard = new SudokuBoard(new int[]{1, 1, 2, 0, 0, 0, 0, 0, 4, 0, 0, 7, 1, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0,
                6, 3, 9, 7, 0, 0, 0, 4, 0, 0, 6, 2, 0, 7, 3, 0, 0, 3, 0, 0, 0, 8, 9, 6, 0, 0, 7, 5, 0, 4, 3, 1, 8, 6, 0, 1,
                8, 0, 0, 5, 0, 0, 0, 0, 6, 4, 0, 0, 2, 0, 0, 0 });

            Mock<IBoardValidator> boardValidatorMock = new Mock<IBoardValidator>();
            boardValidatorMock.Setup(x => x.Validate(It.IsAny<SudokuBoard>())).Returns(expectedResult);
            Mock<IBoardSolver> boardSolverMock = new Mock<IBoardSolver>();

            Sudoku sudoku = new Sudoku(boardSolverMock.Object, boardValidatorMock.Object);

            //act
            Result result = sudoku.Solve(testBoard);

            //assert
            boardValidatorMock.Verify(x => x.Validate(testBoard), Times.Once);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(expectedResult.Error, result.Error);
        }

        [TestMethod]
        public void ValidBoard_SolvedBoardReturned()
        {
            //arrange
            Result expectedResult = new Result();

            SudokuBoard testBoard = new SudokuBoard(new int[]{1, 1, 2, 0, 0, 0, 0, 0, 4, 0, 0, 7, 1, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0,
                6, 3, 9, 7, 0, 0, 0, 4, 0, 0, 6, 2, 0, 7, 3, 0, 0, 3, 0, 0, 0, 8, 9, 6, 0, 0, 7, 5, 0, 4, 3, 1, 8, 6, 0, 1,
                8, 0, 0, 5, 0, 0, 0, 0, 6, 4, 0, 0, 2, 0, 0, 0 });
            Result<int[]> testResult = new Result<int[]>
            {
                IsSuccess = true,
                Data = new int[]{1, 1, 2, 0, 0, 0, 0, 0, 4, 0, 0, 7, 1, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0,
                6, 3, 9, 7, 0, 0, 0, 4, 0, 0, 6, 2, 0, 7, 3, 0, 0, 3, 0, 0, 0, 8, 9, 6, 0, 0, 7, 5, 0, 4, 3, 1, 8, 6, 0, 1,
                8, 0, 0, 5, 0, 0, 0, 0, 6, 4, 0, 0, 2, 0, 0, 0 }
            };

            Mock<IBoardValidator> boardValidatorMock = new Mock<IBoardValidator>();
            boardValidatorMock.Setup(x => x.Validate(It.IsAny<SudokuBoard>())).Returns(expectedResult);
            Mock<IBoardSolver> boardSolverMock = new Mock<IBoardSolver>();
            boardSolverMock.Setup(x => x.Solve(It.IsAny<SudokuBoard>())).Returns(testResult);

            Sudoku sudoku = new Sudoku(boardSolverMock.Object, boardValidatorMock.Object);

            //act
            Result<int[]> result = sudoku.Solve(testBoard);

            //assert
            boardValidatorMock.Verify(x => x.Validate(testBoard), Times.Once);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(result.Data, testResult.Data);
        }
    }
}
