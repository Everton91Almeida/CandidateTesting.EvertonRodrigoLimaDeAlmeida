using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            Run();
        }

        private static void Run()
        {
            WriteInicialInformation();
            var fileService = ServiceProvider.GetService<IFileService>();
            var logService = ServiceProvider.GetService<ILogService<MinhaCDNLog>>();

            Console.WriteLine(logService.GetFormat());

            foreach (var item in fileService.GetFromStorage("C:/Users/evert/OneDrive/Área de Trabalho/input-01.txt"))
                Console.WriteLine(logService.Parse(item));
        }

        private static void WriteInicialInformation()
        {
            Console.WriteLine("#Version 1.0");
            Console.WriteLine($"#{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}");
        }

    }
}
