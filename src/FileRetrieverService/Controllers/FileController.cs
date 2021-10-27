using FileRetrieverService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileRetrieverService.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly ILogger<FileController> _logger;
    private readonly IFileService _fileService;

    public FileController(IFileService fileService, ILogger<FileController> logger)
    {
        this._fileService = fileService;
        _logger = logger;
    }

    [HttpPost(Name = "GetFiles")]
    public async Task<ActionResult> Get([FromBody] GetFilesRequest getFilesRequest)
    {
        var zipBytes = await _fileService.GetFilesAsSingleZip(getFilesRequest.FileIds);

        return File(zipBytes, "application/zip", "files.zip");
    }
}
