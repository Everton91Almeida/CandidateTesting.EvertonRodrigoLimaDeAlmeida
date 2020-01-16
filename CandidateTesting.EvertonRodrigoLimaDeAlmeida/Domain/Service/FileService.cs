using CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Interface.Service;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Domain.Service
{
    public class FileService : IFileService
    {
        public async Task<string> GetString(string url)
        {
            try
            {
                return (await new HttpClient().GetStringAsync(url))?.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while accessing service '{url}'.", ex);
            }
        }
        public void SaveAsFile(string path, string content)
        {
            try
            {
                File.WriteAllText(path, content);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while saving text as file.", ex);
            }
        }
    }
}