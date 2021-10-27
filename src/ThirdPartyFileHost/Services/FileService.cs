using ThirdPartyFileHost.Interfaces;

namespace ThirdPartyFileHost.Services
{
    public class FileService : IFileService
    {
        public Task<byte[]> GetFileById(int fileId)
        {
            return File.ReadAllBytesAsync($"Files//{fileId}.txt");
        }
    }
}