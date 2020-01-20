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
            //Arrange
            var log = LogBaseFixture.GetLog();

            //Act
            var result = log.ToString();

            //Assert
            Assert.Equal(log.Provider, result);
        }
    }
}
