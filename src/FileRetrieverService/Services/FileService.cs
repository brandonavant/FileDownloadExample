using System.IO.Compression;
using FileRetrieverService.Interfaces;

namespace FileRetrieverService.Services
{
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;

        public FileService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            // Note: You must have the Docker container running for ThirdPartyFileHost.
            // If you wish to access this from outside of the docker-compose network,
            // use http://localhost:5000/file instead.
            _httpClient.BaseAddress = new Uri("http://third-party-file-host-api"); 
        }

        public async Task<byte[]> GetFilesAsSingleZip(int[] fileIds)
        {
            using (var zipFileMemoryStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(zipFileMemoryStream, ZipArchiveMode.Create))
                {
                    foreach (var fileId in fileIds)
                    {
                        ZipArchiveEntry zipArchiveEntry;

                        var downloadedFileMemoryStream = new MemoryStream();
                        var httpResponse = await _httpClient.GetAsync($"/File?fileId={fileId}");

                        zipArchiveEntry = zipArchive.CreateEntry($"{fileId}.txt");
                        using (var zipArchiveEntryStream = zipArchiveEntry.Open())
                        {
                            await httpResponse.Content.CopyToAsync(zipArchiveEntryStream);
                        }
                    }
                }

                return zipFileMemoryStream.ToArray();
            }
        }
    }
}