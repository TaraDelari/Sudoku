using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuService.Models;
using System.Linq;

namespace SudokuServiceTests.Services
{
    [TestClass]
    public class BackTrackSolver_Solve
    {
        [TestMethod]
        public void UnsolvedBoard_SolvedBoardReturned()
        {
            //arrange
            int[] expectedResult = new int[]
            {
                8, 2, 7, 3, 1, 6, 5, 4, 9, 6, 4, 9, 7, 5, 2, 8, 3, 1, 5, 3, 1, 4, 8, 9, 6, 7, 2,
                4, 9, 6, 2, 3, 8, 1, 5, 7, 2, 1, 8, 5, 4, 7, 3, 9, 6, 7, 5, 3, 6, 9, 1, 2, 8, 4,
                3, 7, 4, 1, 6, 5, 9, 2, 8, 9, 6, 2, 8, 7, 3, 4, 1, 5, 1, 8, 5, 9, 2, 4, 7, 6, 3
            };
            SudokuBoard testBoard = new SudokuBoard(new int[]{8, 2, 0, 3, 0, 0, 0, 0, 9, 0, 0, 9, 7, 5, 0, 8, 0, 0, 0, 3, 0, 0, 8, 0, 6, 0, 0,
                    0, 0, 6, 2, 3, 0, 0, 0, 7, 2, 1, 8, 5, 4, 7, 0, 0, 0, 7, 0, 0, 0, 9, 0, 0, 8, 0,
                    0, 0, 4, 1, 0, 5, 0, 0, 8, 0, 6, 0, 0, 7, 0, 4, 1, 0, 0, 0, 5, 9, 0, 4, 7, 6, 3 });
            BacktrackBoardSolver solver = new BacktrackBoardSolver();

            //act
            Result<int[]> result = solver.Solve(testBoard);

            //assert
            Assert.IsTrue(result.IsSuccess);
            bool areEqual = AreEqual(expectedResult, result.Data);
            Assert.IsTrue(areEqual);
        }

        private bool AreEqual(int[] first, int[] second)
        {
            return first.SequenceEqual(second);
        }
    }
}
