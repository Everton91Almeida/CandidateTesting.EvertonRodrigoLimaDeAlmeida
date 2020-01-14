using CandidateTesting.EvertonRodrigoLimaDeAlmeida.BO;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = GetFileText().GetAwaiter().GetResult().Trim().Replace("\r", "").Split('\n');
            foreach (var item in text)
            {
                Console.WriteLine(item);
                Console.WriteLine(new Log(item));
            }

            Console.Read();
        }

        private async static Task<string> GetFileText()
        {
            using (var http = new HttpClient())
            {
                return await http.GetStringAsync("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt");
            }
        }
    }
}
