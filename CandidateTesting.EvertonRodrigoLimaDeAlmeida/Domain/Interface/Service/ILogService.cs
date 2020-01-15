using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service
{
    public interface ILogService<T> where T : LogBase
    {
        T Parse(string row);
        string GetFormat();
    }
}
