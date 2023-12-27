using Job.Application.Dto;
using Job.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongViecController : ControllerBase
    {
        private readonly ICongViecService _congViecService;
        private readonly IWebHostEnvironment environment;
        public CongViecController(ICongViecService congViecService, IWebHostEnvironment environment)
        {
            _congViecService = congViecService;
            this.environment = environment;
        }
        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile formFile, string jobcode)
        {
            APIResponse response = new APIResponse();
            List<string> Imageurl = new List<string>();
            string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string Filepath = GetFilepath(jobcode);
                if (!System.IO.Directory.Exists(Filepath))
                {
                    System.IO.Directory.CreateDirectory(Filepath);
                }
                string imagepath = Filepath + "\\" + jobcode + ".png";
                if (System.IO.File.Exists(imagepath))
                {
                    System.IO.File.Delete(imagepath);
                }
                using (FileStream stream = System.IO.File.Create(imagepath))
                {
                    await formFile.CopyToAsync(stream);
                    response.ResponseCode = 200;
                    response.Result = "pass";
                    string _Imageurl = hosturl + "/Upload/job/" + jobcode + "/" + jobcode + ".png";
                    Imageurl.Add(_Imageurl);
                }
            }
            catch (Exception ex)
            {
                response.Errormessage = ex.Message;
            }
            return Ok(Imageurl);
        }
        [HttpGet("GetImage")]
        public async Task<IActionResult> GetImage(string jobcode)
        {
            string Imageurl = string.Empty;
            string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string Filepath = GetFilepath(jobcode);
                string imagepath = Filepath + "\\" + jobcode + ".png";
                if (System.IO.File.Exists(imagepath))
                {
                    Imageurl = hosturl + "/Upload/job/" + jobcode + "/" + jobcode + ".png";
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
            }
            return Ok(Imageurl);
        }
        [NonAction]
        private string GetFilepath(string jobcode)
        {
            return this.environment.WebRootPath + "\\Upload\\job\\" + jobcode;
        }
        [HttpGet("download")]
        public async Task<IActionResult> download(string jobcode)
        {
            try
            {
                string Filepath = GetFilepath(jobcode);
                string imagepath = Filepath + "\\" + jobcode + ".png";
                if (System.IO.File.Exists(imagepath))
                {
                    MemoryStream stream = new MemoryStream();
                    using (FileStream fileStream = new FileStream(imagepath, FileMode.Open))
                    {
                        await fileStream.CopyToAsync(stream);
                    }
                    stream.Position = 0;
                    return File(stream, "image/png", jobcode + ".png");
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
            return Ok(_congViecService.GetAll());
        }
        [HttpGet("GetLastJob")]
        public IActionResult GetLastJob()
        {
            var jobs = _congViecService.GetAll();
            return Ok(jobs[jobs.Count - 1]);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var congViec = _congViecService.Get(id);
            if(congViec == null)
            {
                return NotFound();
            }
            return Ok(congViec);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post(CongViecDto congViec)
        {
            if (_congViecService.Add(congViec))
            {
                return CreatedAtAction("GetLastJob", new { id = congViec.ID }, congViec);
            }
            return Ok("Loại công việc đã tồn tại");
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(CongViecDto congViec)
        {
            if (_congViecService.Update(congViec))
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_congViecService.Delete(id))
            {
                return NoContent();
            }
            return NotFound("Không thể xóa vì loại công việc không tồn tại");
        }
    }
}
