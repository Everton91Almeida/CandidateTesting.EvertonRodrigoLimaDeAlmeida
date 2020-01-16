using System.Threading.Tasks;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service
{
    public interface IFileService
    {
        Task<string> GetString(string url);
        void SaveAsFile(string path, string content);
    }
}