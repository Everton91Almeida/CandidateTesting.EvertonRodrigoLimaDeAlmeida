using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Service;
using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    [Collection(nameof(LogServiceMinhaCDNLogCollection))]
    public class LogServiceMinhaCDNLogTest
    {
        private readonly LogServiceMinhaCDNLogFixture ServiceFixture;

        public LogServiceMinhaCDNLogTest(LogServiceMinhaCDNLogFixture serviceFixture) =>
            ServiceFixture = serviceFixture;

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

        [Fact(DisplayName = "LogService MinhaCDNLog Parse")]
        [Trait("Service", "LogService")]
        public void LogService_GetLogData_ReturnValueFromParse()
        {
            ILogService<MinhaCDNLog> logService = new LogService<MinhaCDNLog>();
            var rows = ServiceFixture.GetRows();

            Assert.All(rows, r =>
            {
                var result = logService.Parse(r);
                Assert.NotNull(result.ResponseSize);
                Assert.NotNull(result.StatusCode);
                Assert.NotNull(result.CacheStatus);
                Assert.NotNull(result.HttpMethod);
                Assert.NotNull(result.UriPath);
                Assert.NotNull(result.TimeTaken);
            });
        }
    }
}
