using Microsoft.AspNetCore.Mvc;
using ThirdPartyFileHost.Interfaces;

namespace ThirdPartyFileHost.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly ILogger<FileController> _logger;

    public FileController(IFileService fileService, ILogger<FileController> logger)
    {
        this._fileService = fileService;
        _logger = logger;
    }

    [HttpGet(Name = "GetFile")]
    public async Task<ActionResult> Get(int fileId)
    {
        var fileBytes = await _fileService.GetFileById(fileId);

        return File(fileBytes, "text/plain", $"{fileId}.txt");
    }
}
