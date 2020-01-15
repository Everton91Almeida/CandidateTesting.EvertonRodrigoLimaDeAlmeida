using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Atributte;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO
{
    public class LogBase
    {
        [Log("provider", 0)]
        public string Provider { get; set; }
    }
}
