using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;
using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Service
{
    public class LogService<T> : ILogService<T> where T : LogBase
    {
        private struct LogData
        {
            public int position;
            public string name;
        }

        public string GetFormat()
        {
            var logData = new List<LogData>();
            foreach (var property in typeof(T).GetProperties())
            {
                foreach (var attribute in property.CustomAttributes)
                {
                    var prop = typeof(T).GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);
                    if (prop != null && prop.CanWrite)
                    {
                        logData.Add(new LogData()
                        {
                            name = prop.CustomAttributes.FirstOrDefault().ConstructorArguments[0].Value.ToString(),
                            position = (int)prop.CustomAttributes.FirstOrDefault().ConstructorArguments[1].Value,
                        });
                    }
                }
            }

            return String.Join(' ', logData.OrderBy(l => l.position).Select(l => l.name).ToArray()).Trim();
        }

        public T Parse(string row)
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            var values = row.Split('|');
            foreach (var property in typeof(T).GetProperties())
            {
                foreach (var attribute in property.CustomAttributes)
                {
                    var prop = typeof(T).GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);
                    if (prop != null && prop.CanWrite && prop.CustomAttributes.FirstOrDefault().ConstructorArguments.Count > 2)
                    {
                        var pattern = attribute.ConstructorArguments[4].Value;
                        var value = values[(int)attribute.ConstructorArguments[2].Value];

                        if (pattern != null)
                        {
                            var type = (Type)attribute.ConstructorArguments[3].Value;
                            prop.SetValue(obj, Convert.ChangeType(Regex.Match(value, pattern.ToString()).Value, type));
                        }
                        else
                            prop.SetValue(obj, value);
                    }
                }
            }
            return obj;
        }
    }
}