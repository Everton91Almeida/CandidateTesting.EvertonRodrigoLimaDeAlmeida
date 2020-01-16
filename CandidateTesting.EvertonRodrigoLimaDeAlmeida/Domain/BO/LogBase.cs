using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Atributte;
using System.Linq;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO
{
    public class LogBase
    {
        [Log("provider", 0)]
        public string Provider { get; set; }

        public override string ToString()
        {
            var values = GetType().GetProperties()
                .OrderBy(p => p.CustomAttributes.Select(c => (int)c.ConstructorArguments[1].Value).FirstOrDefault())
                .Select(p => p.GetValue(this)).ToArray();

            return string.Join(' ', values).Trim();
        }
    }
}
