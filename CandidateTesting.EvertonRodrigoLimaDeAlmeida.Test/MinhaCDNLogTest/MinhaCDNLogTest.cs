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
            var logs = LogBaseFixture.GetLogs();

            Assert.All(logs, l =>
            {
                var expected = $"{l.Provider} {l.HttpMethod} {l.StatusCode} {l.UriPath} {l.TimeTaken} {l.ResponseSize} {l.CacheStatus}";
                var result = l.ToString();
                Assert.Equal(expected, result);
            });
        }
    }
}
