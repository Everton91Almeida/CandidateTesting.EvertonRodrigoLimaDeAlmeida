using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Service
{
    public class LogService<TLog> : ILogService<TLog> where TLog : LogBase
    {
        private readonly IEnumerable<LogData> LogData;

        public LogService() =>
            LogData = GetLogData();

        public string GetFormat() =>
            string.Join(' ', LogData.OrderBy(l => l.Position).Select(l => l.Name)).Trim();

        private IEnumerable<LogData> GetLogData()
        {
            foreach (var property in typeof(TLog).GetProperties())
            {
                var prop = typeof(TLog).GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && prop.CanWrite)
                {
                    yield return new LogData()
                    {
                        Name = prop.CustomAttributes.FirstOrDefault().ConstructorArguments[0].Value.ToString(),
                        Position = (int)prop.CustomAttributes.FirstOrDefault().ConstructorArguments[1].Value,
                    };
                }
            }
        }

        public TLog Parse(string row)
        {
            var log = (TLog)Activator.CreateInstance(typeof(TLog));
            var values = row.Split('|');
            foreach (var property in typeof(TLog).GetProperties())
            {
                foreach (var attribute in property.CustomAttributes)
                {
                    if (property != null && property.CanWrite && property.CustomAttributes.FirstOrDefault().ConstructorArguments.Count > 2)
                    {
                        var pattern = attribute.ConstructorArguments[4].Value;
                        var value = values[(int)attribute.ConstructorArguments[2].Value];

                        if (pattern != null)
                        {
                            var type = (Type)attribute.ConstructorArguments[3].Value;
                            property.SetValue(log, Convert.ChangeType(Regex.Match(value, pattern.ToString()).Value, type));
                        }
                        else
                            property.SetValue(log, value);
                    }
                }
            }
            return log;
        }
    }
}