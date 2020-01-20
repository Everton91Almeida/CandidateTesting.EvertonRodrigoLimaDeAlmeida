using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Service;
using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    public class LogServiceMinhaCDNLogTest
    {
        [Fact(DisplayName = "LogService MinhaCDNLog GetFormat")]
        [Trait("Service", "LogService")]
        public void LogService_GetFormat_ReturnMinhaCDNLogFormat()
        {
            //Arrange
            ILogService<MinhaCDNLog> logService = new LogService<MinhaCDNLog>();

            //Act
            var result = logService.GetFormat();

            //Assert
            Assert.Equal("provider http-method status-code uri-path time-taken response-size cache-status", result);
        }

        [Trait("Service", "LogService")]
        [Theory(DisplayName = "LogService MinhaCDNLog Parse")]
        [InlineData("312|200|HIT|\"GET /robots.txt HTTP / 1.1\"|100.2")]
        public void LogService_GetLogData_ReturnValueFromParse(string row)
        {
            //Arrange
            var logService = new LogService<MinhaCDNLog>();

            //Act
            var result = logService.Parse(row);

            //Assert
            Assert.Equal(new MinhaCDNLog()
            {
                CacheStatus = "HIT",
                HttpMethod = "GET",
                Provider = "\"MINHA CDN\"",
                ResponseSize = 312,
                StatusCode = 200,
                TimeTaken = 100,
                UriPath = "/robots.txt"
            }, result);
        }
    }
}
