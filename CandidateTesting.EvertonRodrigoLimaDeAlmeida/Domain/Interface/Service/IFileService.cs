using System.Collections.Generic;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service
{
    public interface IFileService
    {
        IEnumerable<string> GetFromStorage(string path);
    }
}
