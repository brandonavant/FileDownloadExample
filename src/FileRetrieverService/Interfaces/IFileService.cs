namespace FileRetrieverService.Interfaces
{
    public interface IFileService
    {
         Task<byte[]> GetFilesAsSingleZip(int[] fileIds);
    }
}