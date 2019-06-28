using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SudokuService.Models;
using SudokuService.Services;
using System;

namespace SudokuService
{
    public class SudokuSolver
    {
        private SudokuBoardService _service;

        public SudokuSolver(SudokuBoardService service)
        {
            _service = service;
        }


        [FunctionName("SudokuSolver")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Solve")] HttpRequest req, ILogger log)
        {

            string content = await new StreamReader(req.Body).ReadToEndAsync();
            if (string.IsNullOrEmpty(content))
                return new BadRequestObjectResult("PLease pass a board");

            try
            {
                SolveRequest solveRequest = JsonConvert.DeserializeObject<SolveRequest>(content);

                Result<int[]> result = _service.Solve(solveRequest);
                if (result.IsSuccess)
                    return new OkObjectResult(result.Data);
                else
                    return new BadRequestObjectResult("PLease pass a valid board");
            }
            catch
            {
                return new BadRequestObjectResult("PLease pass a board");
            }
        }
    }
}
