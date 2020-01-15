using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service;
using System.Collections.Generic;
using System.IO;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Service
{
    public class FileService : IFileService
    {
        public IEnumerable<string> GetFromStorage(string path)
        {
            using (var file = new StreamReader(path))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(ln))
                        yield return ln;
                }
            }
        }
    }
}