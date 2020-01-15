using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Atributte;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO
{
    public class MinhaCDNLog : LogBase
    {
        public MinhaCDNLog() =>
            Provider = "MINHA CDN";

        [Log("response-size", 5, 0, typeof(int), @"^[^.]*")]
        public int? ResponseSize { get; set; }

        [Log("status-code", 2, 1, typeof(int), @"^[^.]*")]
        public int? StatusCode { get; set; }

        [Log("cache-status", 6, 2, typeof(string), null)]
        public string CacheStatus { get; set; }

        [Log("http-method", 1, 3, typeof(string), @"(?<="")(\w+)")]
        public string HttpMethod { get; set; }

        [Log("uri-path", 3, 3, typeof(string), @"(\/)(\w+.\w+)")]
        public string UriPath { get; set; }

        [Log("time-taken", 4, 4, typeof(int), @"^[^.]*")]
        public int? TimeTaken { get; set; }

        public override string ToString()
        {
            return $"\"{Provider}\" {HttpMethod} {StatusCode} {UriPath} {TimeTaken} {ResponseSize} {CacheStatus}";
        }
    }
}
