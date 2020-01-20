using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Service;
using System.Threading.Tasks;
using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    public class FileServiceTest
    {
        [Theory(DisplayName = "LogService GetString")]
        [Trait("Service", "FileService")]
        [InlineData("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt")]
        public async Task FileService_GetString_ReturnLogStringFromService(string url)
        {
            IFileService fileService = new FileService();

            var result = await fileService.GetString(url);

            Assert.NotNull(result);
        }
    }
}
