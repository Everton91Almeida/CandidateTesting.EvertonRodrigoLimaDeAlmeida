using Bogus;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    [CollectionDefinition(nameof(MinhaCDNLogCollection))]
    public class MinhaCDNLogCollection : ICollectionFixture<MinhaCDNLogFixture> { }

    public class MinhaCDNLogFixture : IDisposable
    {
        public MinhaCDNLog GetLog() =>
            CreteLogs(1).FirstOrDefault();

        public IEnumerable<MinhaCDNLog> GetLogs() =>
            CreteLogs(50).ToList();

        private IEnumerable<MinhaCDNLog> CreteLogs(int amount) =>
            new Faker<MinhaCDNLog>("pt_BR")
            .CustomInstantiator(f => new MinhaCDNLog(
                f.Random.Number(100, 999),
                f.Random.Number(100, 999),
                f.Random.ArrayElement(new string[] { "HIT", "MISS", "REFRESH_HIT" }),
                f.Random.ArrayElement(new string[] { "GET", "POST", "PUT", "DELETE" }),
                f.Internet.UrlWithPath(fileExt: "txt"),
                f.Random.Number(0, int.MaxValue)))
            .Generate(amount);

        public void Dispose() =>
            GC.SuppressFinalize(this);
    }
}