using Job.Application.Dto;
using Job.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Job.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaTuyenDungController : ControllerBase
    {
        private readonly INhaTuyenDungService _nhaTuyenDungService;
        private readonly IConfiguration _configuration;
        public NhaTuyenDungController(INhaTuyenDungService nhaTuyenDungService, IConfiguration configuration)
        {
            _nhaTuyenDungService = nhaTuyenDungService;
            _configuration = configuration;
        }
        [HttpPost("login")]
        public IActionResult Login(string account, string password)
        {
            //Lay user trong database
            var user = _nhaTuyenDungService.GetAll().FirstOrDefault(x => x.UserName == account && x.PassWord == password);
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
                    new Claim(ClaimTypes.MobilePhone, "0862202887"),
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
            return Ok(_nhaTuyenDungService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var nhaTuyenDung = _nhaTuyenDungService.Get(id);
            if(nhaTuyenDung == null)
            {
                return NotFound();
            }
            return Ok(nhaTuyenDung);
        }
        [HttpPost]
        public IActionResult Post(NhaTuyenDungDto nhaTuyenDung)
        {
            if (_nhaTuyenDungService.Add(nhaTuyenDung))
            {
                return NoContent();
            }
            return Ok("Đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult Put(NhaTuyenDungDto nhaTuyenDung)
        {
            if (_nhaTuyenDungService.Update(nhaTuyenDung))
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_nhaTuyenDungService.Delete(id))
            {
                return NoContent();
            }
            return NotFound("Không thể xóa vì không tồn tại");
        }
    }
}
