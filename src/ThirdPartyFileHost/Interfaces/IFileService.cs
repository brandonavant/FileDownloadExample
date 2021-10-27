namespace ThirdPartyFileHost.Interfaces
{
    public interface IFileService
    {
        Task<byte[]> GetFileById(int fileId);
    }
}