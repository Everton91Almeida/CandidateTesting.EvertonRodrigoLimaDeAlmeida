using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.BO;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service
{
    public interface ILogService<TLog> where TLog : LogBase
    {
        TLog Parse(string row);
        string GetFormat();
    }
}
