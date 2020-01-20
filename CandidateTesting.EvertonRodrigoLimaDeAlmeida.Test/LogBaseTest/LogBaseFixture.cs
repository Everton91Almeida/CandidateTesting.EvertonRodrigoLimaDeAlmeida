using Bogus;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    [CollectionDefinition(nameof(LogBaseCollection))]
    public class LogBaseCollection : ICollectionFixture<LogBaseFixture> { }

    public class LogBaseFixture : IDisposable
    {
        public LogBase GetLog() =>
            CreteLogs(1).FirstOrDefault();

        public IEnumerable<LogBase> GetLogs() =>
            CreteLogs(50);

        private IEnumerable<LogBase> CreteLogs(int amount) =>
            new Faker<LogBase>("pt_BR")
            .CustomInstantiator(f => new LogBase(f.Hacker.Phrase()))
            .Generate(amount);

        public void Dispose() =>
            GC.SuppressFinalize(this);
    }
}
