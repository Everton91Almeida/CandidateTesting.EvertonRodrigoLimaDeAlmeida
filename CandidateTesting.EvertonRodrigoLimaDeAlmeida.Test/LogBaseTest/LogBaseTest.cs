using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;
using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    [Collection(nameof(LogBaseCollection))]
    public class LogBaseTest
    {
        private readonly LogBaseFixture LogBaseFixture;

        public LogBaseTest(LogBaseFixture logBaseFixture) =>
            LogBaseFixture = logBaseFixture;

        [Fact(DisplayName = "LogBase ToString")]
        [Trait("BO", "Log")]
        public void LogBase_ToString_ReturnToStringValue()
        {
            var logs = LogBaseFixture.GetLogs();

            Assert.All(logs, l =>
            {
                var expected = l.Provider;
                var result = l.ToString();
                Assert.Equal(expected, result);
            });
        }
    }
}
