using AuthenticateANDAuthorize.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticateANDAuthorize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(UserLoginModel userLogin)
        {
            if (userLogin.UserName != "admin" || userLogin.Password != "admin")
            {
                return BadRequest(new { message = "Hatalı kullanıcı adı veya şifre" });
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userLogin.UserName),
                new Claim(ClaimTypes.Role,"Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Eşsiz sır gibi saklayacağınız bir cümle"));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "softtech.com.tr",
                audience: "softtech.com.tr",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credential
                );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });





        }

    }
}
