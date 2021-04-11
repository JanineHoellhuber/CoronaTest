using CoronaTest.Core.Contracts;
using CoronaTest.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Test.Web.Controllers
{
    /// <summary>
    /// API-Controller für die Autorisierung
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IList<AuthUser> _authUsers;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        public AuthController(IConfiguration config, IUnitOfWork unitOfWork)
        {
            _config = config;
            _unitOfWork = unitOfWork;
            _authUsers = new List<AuthUser>
            {
                new AuthUser{Email = "admin@htl.at", Password=AuthUtils.GenerateHashedPassword("12345"),
                UserRole="Admin"},
                 new AuthUser{Email = "user@htl.at", Password=AuthUtils.GenerateHashedPassword("5678"),
                UserRole="User"},
                  new AuthUser{Email = "norole@htl.at", Password=AuthUtils.GenerateHashedPassword("7890")
               },
            };


          }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost()]
        [AllowAnonymous]
        public IActionResult Login([FromBody] AuthUser model)
        {
            var authUser = _authUsers.SingleOrDefault(u => u.Email == model.Email);
            if(authUser == null)
            {
                return Unauthorized();

            }
            if(!AuthUtils.VerifyPassword(model.Password, authUser.Password))
            {
                return Unauthorized();
            }
            var tokenString = GenerateJwtToken(authUser);
            IActionResult response = Ok(new 
            {
                auth_token = tokenString,
                userMail = authUser.Email,
            });

            return response;

        }

        /// <summary>
        /// Registrierung eines Benutzers
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> Register(/*string email, string passowrd*/[FromBody] AuthUser model)
        {
            var authUser = _authUsers.SingleOrDefault(u => u.Email == model.Email);
            if (authUser != null)
            {
                return BadRequest(new
                {
                    Status = "Error",
                    Message = "User already exists!"
                
                });

            }
            string hashText = AuthUtils.GenerateHashedPassword(model.Password);
            authUser = new AuthUser
            {
                Email = model.Email,
                Password = hashText,
                UserRole = "User"
            };



            try
            {
                await _unitOfWork.UserRepository.AddAsync(authUser);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(authUser);

        }



        /// <summary>
        /// JWT erzeugen. Minimale Claim-Infos: Email und Rolle
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>Token mit Claims</returns>
        private string GenerateJwtToken(AuthUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var authClaims = new List<Claim>();
            authClaims.Add(new Claim(ClaimTypes.Email, userInfo.Email));
            authClaims.Add(new Claim(ClaimTypes.Country, "Austria"));
            if (!string.IsNullOrEmpty(userInfo.UserRole))
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userInfo.UserRole));
            }

            var token = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Audience"],
              claims: authClaims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
