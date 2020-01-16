using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida
{
    public class Program
    {
        private static ServiceProvider ServiceProvider;

        static void Main(string[] args)
        {
            ServiceProvider = new ServiceCollection()
                .AddTransient(typeof(ILogService<>), typeof(LogService<>))
                .AddTransient<IFileService, FileService>()
                .BuildServiceProvider();

            Run().Wait();
        }

        private static async Task Run()
        {
            var fileService = ServiceProvider.GetService<IFileService>();
            var logService = ServiceProvider.GetService<ILogService<MinhaCDNLog>>();
            var result = new StringBuilder();

            Console.WriteLine("Enter the source URL value...");
            var sourceUrl = Console.ReadLine();

            Console.WriteLine("Enter the target path value...");
            var targetPath = Console.ReadLine();

            result.AppendLine("#Version 1.0");
            result.AppendLine($"#{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
            result.AppendLine(logService.GetFormat());

            foreach (var item in (await fileService.GetString(sourceUrl)).Split('\n'))
                result.AppendLine(logService.Parse(item).ToString());

            Console.WriteLine(result.ToString());
            fileService.SaveAsFile(targetPath, result.ToString());
        }
    }
}
