using Job.Application.Dto;
using Job.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Job.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UngVienController : ControllerBase
    {
        private readonly IUngViecService _ungViecService;
        private readonly IConfiguration _configuration;
        public UngVienController(IUngViecService ungViecService, IConfiguration configuration)
        {
            _ungViecService = ungViecService;
            _configuration = configuration;
        }
        [HttpPost("login")]
        public IActionResult Login(string account, string password)
        {
            //Lay user trong database
            var user = _ungViecService.GetAll().FirstOrDefault(x => x.UserName == account && x.PassWord == password);
            //Neu ton tai user thi tao token
            if (user != null)
            {
                //Ma hoa khoa bi mat
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                //Ky vao khoa bi mat da ma hoa
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                //Tao claims chua thong tin bo sung
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Name, account),
                    new Claim(ClaimTypes.MobilePhone, "0988675142"),
                };
                //Tao token voi cac thong so khop voi cau hinh trong file appsettings de validate
                var token = new JwtSecurityToken
                (
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredential,
                    claims: claims
                );
                //Sinh ra chuoi token voi cac thong o tren
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    user
                });
            }
            return Unauthorized();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ungViecService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ungVien = _ungViecService.Get(id);
            if(ungVien == null)
            {
                return NotFound();
            }
            return Ok(ungVien);
        }
        [HttpPost]
        public IActionResult Post(UngVienDto ungVien)
        {
            if (_ungViecService.Add(ungVien))
            {
                return NoContent();
            }
            return Ok("Đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult Put(UngVienDto ungVien)
        {
            if (_ungViecService.Update(ungVien))
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_ungViecService.Delete(id))
            {
                return NoContent();
            }
            return NotFound("không thể xóa vì không tồn tại");
        }
    }
}
