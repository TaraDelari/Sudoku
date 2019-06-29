using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SudokuService.Models;

namespace SudokuService
{
    public class SudokuSolver
    {
        private Services.Sudoku _service;

        public SudokuSolver(Services.Sudoku service)
        {
            _service = service;
        }


        [FunctionName("SudokuSolver")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Solve")] HttpRequest req)
        {
            try
            {
                return HandleRequest(req);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

        private IActionResult HandleRequest(HttpRequest req)
        {
            if (!TryReadRequest(req, out SudokuBoard board))
                return new BadRequestObjectResult("Please pass a board");

            Result<int[]> result = _service.Solve(board);
            if (result.IsSuccess)
                return new OkObjectResult(result.Data);
            else
                return new BadRequestObjectResult("Please pass a valid board");
        }

        private bool TryReadRequest(HttpRequest req, out SudokuBoard board)
        {
            board = null;

            string content = new StreamReader(req.Body).ReadToEndAsync().Result;
            if (string.IsNullOrEmpty(content))
                return false;

            try
            {
                SolveRequest solveRequest = JsonConvert.DeserializeObject<SolveRequest>(content);
                board = new SudokuBoard(solveRequest.BoardFields);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
