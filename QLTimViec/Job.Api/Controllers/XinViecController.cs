using Job.Application.Dto;
using Job.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace Job.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XinViecController : ControllerBase
    {
        private readonly IXinViecService _xinViecService;
        private readonly IWebHostEnvironment environment;
        public XinViecController(IXinViecService xinViecService, IWebHostEnvironment environment)
        {
            _xinViecService = xinViecService;
            this.environment = environment;
        }
        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile formFile, string cvcode)
        {
            APIResponse response = new APIResponse();
            List<string> Fileurl = new List<string>();
            string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string Filepath = GetFilepath(cvcode);
                if (!System.IO.Directory.Exists(Filepath))
                {
                    System.IO.Directory.CreateDirectory(Filepath);
                }
                string filepath = Filepath + "\\" + cvcode + ".docx";
                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
                using (FileStream stream = System.IO.File.Create(filepath))
                {
                    await formFile.CopyToAsync(stream);
                    response.ResponseCode = 200;
                    response.Result = "pass";
                    string _Fileurl = hosturl + "/Upload/cv/" + cvcode + "/" + cvcode + ".docx";
                    Fileurl.Add(_Fileurl);
                }
            }
            catch (Exception ex)
            {
                response.Errormessage = ex.Message;
            }
            return Ok(response);
        }
        [HttpGet("GetFile")]
        public async Task<IActionResult> GetFile(string cvcode)
        {
            string Fileurl = string.Empty;
            string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string Filepath = GetFilepath(cvcode);
                string filepath = Filepath + "\\" + cvcode + ".docx";
                if (System.IO.File.Exists(filepath))
                {
                    Fileurl = hosturl + "/Upload/cv/" + cvcode + "/" + cvcode + ".docx";
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
            }
            return Ok(Fileurl);
        }
        [NonAction]
        public string GetFilepath(string cvcode)
        {
            return this.environment.WebRootPath + "\\Upload\\cv\\" + cvcode;
        }
        [HttpGet("download")]
        public async Task<IActionResult> download(string cvcode)
        {
            try
            {
                string Filepath = GetFilepath(cvcode);
                string filepath = Filepath + "\\" + cvcode + ".docx";
                if (System.IO.File.Exists(filepath))
                {
                    MemoryStream stream = new MemoryStream();
                    using (FileStream fileStream = new FileStream(filepath, FileMode.Open))
                    {
                        await fileStream.CopyToAsync(stream);
                    }
                    stream.Position = 0;
                    return File(stream, "file/docx", cvcode + ".docx");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_xinViecService.GetAll());
        }
        [HttpGet("GetLastApply")]
        public IActionResult GetLastApply()
        {
            var applys = _xinViecService.GetAll();
            return Ok(applys[applys.Count - 1]);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var xinViec = _xinViecService.Get(id);
            if(xinViec == null)
            {
                return NotFound();
            }
            return Ok(xinViec);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post(XinViecDto xinViec)
        {
            if (_xinViecService.Add(xinViec))
            {
                return NoContent();
            }
            return Ok("Đã tồn tại");
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(XinViecDto xinViec)
        {
            if (_xinViecService.Update(xinViec))
            {
                return NoContent();
            }
            return NotFound();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_xinViecService.Delete(id))
            {
                return NoContent();
            }
            return NotFound("Không thể xóa vì đã tồn tại");
        }
    }
}
