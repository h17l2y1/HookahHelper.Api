using HookahHelper.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;

public class DropBoxFilesController : ControllerBase
{
    private readonly ILogger<DropBoxFilesController> _logger;
    private IDropBoxFilesService _dropBoxFilesService;

    public DropBoxFilesController(ILogger<DropBoxFilesController> logger, IDropBoxFilesService DropBoxFilesService)
    {
        _logger = logger;
        _dropBoxFilesService = DropBoxFilesService;
    }

    [HttpGet]
    [Route(@"~/GetDocument")]
    public async Task<FileResult> GetDocumentAsync(string filename)
    {
        try
        {
            string _fileExtension = Path.GetExtension(filename);

            byte[] fileContent = await _dropBoxFilesService.GetFile(filename);


            if (_fileExtension.ToLower() == ".pdf")
            {
                return File(fileContent, System.Net.Mime.MediaTypeNames.Application.Pdf, filename);
            }
            else
            {
                return File(fileContent, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public class FileUploadModel
    {
        public string FileName { get; set; }
        public IFormFile File { get; set; }
    }


    [HttpPost]
    [Route(@"~/SaveDocument")]
    public async Task<ActionResult> SaveUploadedDocumentAsync([FromForm] FileUploadModel uploadedFile)
    {
        using (var reader = new StreamReader(uploadedFile.File.OpenReadStream()))
        {
            var bytes = default(byte[]);
            using (var memstream = new MemoryStream())
            {
                reader.BaseStream.CopyTo(memstream);
                bytes = memstream.ToArray();
            }

            await _dropBoxFilesService.WriteFile(uploadedFile.File.FileName, bytes);
        }

        return Ok(new {status = true, message = "File Uploaded Successfully"});
    }
}