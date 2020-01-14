using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Atributte;
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.BO
{
    public class Log
    {
        public Log(string row)
        {
            Provider = "MINHA CDN";
            LoadAttributesFromRow(row);
        }

        public string Provider { get; set; }

        [ItemLog("response-size", 0, typeof(int), @"^[^.]*")]
        public int? ResponseSize { get; set; }

        [ItemLog("status-code", 1, typeof(int), @"^[^.]*")]
        public int? StatusCode { get; set; }

        [ItemLog("cache-status", 2, typeof(string), null)]
        public string CacheStatus { get; set; }

        [ItemLog("http-method", 3, typeof(string), @"(?<="")(\w+)")]
        public string HttpMethod { get; set; }

        [ItemLog("uri-path", 3, typeof(string), @"(\/)(\w+.\w+)")]
        public string UriPath { get; set; }

        [ItemLog("time-taken", 4, typeof(int), @"^[^.]*")]
        public int? TimeTaken { get; set; }

        private void LoadAttributesFromRow(string row)
        {
            var values = row.Split('|');
            foreach (var property in GetType().GetProperties())
            {
                foreach (var attribute in property.CustomAttributes)
                {
                    var prop = GetType().GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);
                    if (null != prop && prop.CanWrite)
                    {
                        var type = (Type)prop.CustomAttributes.FirstOrDefault().ConstructorArguments[2].Value;
                        if (prop.CustomAttributes.FirstOrDefault().ConstructorArguments[3].Value != null)
                        {
                            var value = Regex.Match(values[(int)attribute.ConstructorArguments[1].Value],
                                prop.CustomAttributes.FirstOrDefault().ConstructorArguments[3].Value.ToString()).ToString();
                            prop.SetValue(this, Convert.ChangeType(value, type));
                        }
                        else
                            prop.SetValue(this, values[(int)attribute.ConstructorArguments[1].Value]);
                    }
                }
            }
        }

        private void Validate() { }

        public override string ToString()
        {
            return $"\"{Provider}\" {HttpMethod} {StatusCode} {UriPath} {TimeTaken} {ResponseSize} {CacheStatus}";
        }
    }
}
