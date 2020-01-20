using Bogus;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    [CollectionDefinition(nameof(LogServiceMinhaCDNLogCollection))]
    public class LogServiceMinhaCDNLogCollection : ICollectionFixture<LogServiceMinhaCDNLogFixture> { }

    public class LogServiceMinhaCDNLogFixture : IDisposable
    {
        public string GetRow() =>
            CreateRow(1)
            .FirstOrDefault();

        public IEnumerable<string> GetRows() =>
            CreateRow(50);

        private IEnumerable<string> CreateRow(int amount) =>
            new Faker<string>("pt_BR")
            .CustomInstantiator(f =>
            {
                var responseSize = f.Random.Number(100, 999);
                var statusCode = f.Random.Number(100, 999);
                var cacheStatus = f.Random.ArrayElement(new string[] { "HIT", "MISS", "REFRESH_HIT" });
                var httpMethod = f.Random.ArrayElement(new string[] { "GET", "POST", "PUT", "DELETE" }).ToUpper();
                var uriPath = f.Internet.UrlWithPath(fileExt: "txt");
                var timeTaken = f.Random.Number(0, int.MaxValue);
                return $"{responseSize}|{statusCode}|{cacheStatus}|\"{httpMethod} {uriPath} HTTP / 1.1\"|{timeTaken}";
            }).Generate(amount);

        public void Dispose() =>
            GC.SuppressFinalize(this);
    }
}