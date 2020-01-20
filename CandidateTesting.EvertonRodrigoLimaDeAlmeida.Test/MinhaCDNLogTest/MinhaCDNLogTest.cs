using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;
using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    [Collection(nameof(MinhaCDNLogCollection))]
    public class MinhaCDNLogTest
    {
        private readonly MinhaCDNLogFixture LogBaseFixture;

        public MinhaCDNLogTest(MinhaCDNLogFixture logBaseFixture) =>
            LogBaseFixture = logBaseFixture;

        [Fact(DisplayName = "MinhaCDNLog ToString")]
        [Trait("BO", "Log")]
        public void MinhaCDNLog_ToString_ReturnToStringValue()
        {
            //Arrange
            var log = LogBaseFixture.GetLog();

            //Act
            var result = log.ToString();
            var expected = $"{log.Provider} {log.HttpMethod} {log.StatusCode} {log.UriPath} {log.TimeTaken} {log.ResponseSize} {log.CacheStatus}";

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
