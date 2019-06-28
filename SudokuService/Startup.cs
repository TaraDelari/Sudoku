using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SudokuService;
using SudokuService.Contracts;
using SudokuService.Models;
using SudokuService.Services;

[assembly: WebJobsStartup(typeof(Startup))]
namespace SudokuService
{
    class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddTransient<ISudokuBoardSolver, BacktrackSudokuBoardSolver>();
            builder.Services.AddTransient<SudokuBoardService>();
        }
    }
}
