using FileRetrieverService.Interfaces;

namespace FileRetrieverService.Services
{
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;

        public FileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://thirdpartyfilehost/file"); // Note: You must have the Docker container running for ThirdPartyFileHost.
        }

        public Task<byte[]> GetFilesAsSingleZip(int[] fileIds)
        {

        }
    }
}