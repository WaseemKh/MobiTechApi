using System;

using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MobiTech.Data;
using MobiTech.Models;
using MobiTech.DataView;
using AutoMapper;
using System.Security.Policy;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Authorization;

namespace MobiTech.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly MobiDbContext _db;
        private UserManager<SysUsers> _userManager;
        private SignInManager<SysUsers> _signinManager;
        private IMapper _mapper;
        private readonly ApplicationSettings _appSettings;
        private IPasswordHasher<SysUsers> passwordHasher;
        public AuthenticateController(MobiDbContext context, UserManager<SysUsers> userManager, SignInManager<SysUsers> signinManager, IOptions<ApplicationSettings> appSettings , IPasswordHasher<SysUsers> passwordHash)
        {
            _db = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _appSettings = appSettings.Value;
            passwordHasher = passwordHash;
        }
        // GET: api/NewUser
        //[Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] SignModel model)
        {
            model.Role = "Employee";
            var sysUsers = new SysUsers()
            {
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                FullName = model.FullName,
                
            };

            try
            {
                var resault = await _userManager.CreateAsync(sysUsers, model.PasswordHash);
                await _userManager.AddToRoleAsync(sysUsers, model.Role);
                return Ok(resault);
            }
            catch (Exception ex)
            {
                throw ex;

            }



        }


        //[Authorize(Roles = "Manager")]
        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser([FromBody] EditeUserVw model)
        {
            
            var user = _userManager.FindByIdAsync(model.Id).Result;

            if (user == null)
            {

                return NotFound();
            }
            else
            {
                user.UserName = model.UserName;
                user.FullName = model.FullName;
                user.PhoneNumber= model.PhoneNumber;
                user.PasswordHash = passwordHasher.HashPassword(user, model.PasswordHash);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                  return Ok(Getusers());
                }
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
                return Ok(model);
            }
 

        }






        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
           
            var user = await _userManager.FindByNameAsync(model.UserName);
          
              
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {

                    Subject = new ClaimsIdentity(new Claim[]
                     {
                   // new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                   // new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                   new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                     }),
                    Expires = DateTime.Now.AddHours(3),
                    //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)

                };


                //  var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecureKeySecureKey"));

                // var token = new JwtSecurityToken(
                //       issuer: "http://dotnetdetail.net",
                //      audience: "http://dotnetdetail.net",
                // expires: DateTime.Now.AddHours(3),
                // claims: authClaims,
                //signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                //  );
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
                //  {
                //   token = new JwtSecurityTokenHandler().WriteToken(token),
                //   expiration = token.ValidTo,

                // });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }

        [HttpGet("GetUser")]
        //Authorize(Roles = "Manager")]


        public async Task<ActionResult<IEnumerable<SysUsers>>> Getusers()
        {
            //var userId = _db.UserRoles.Select(x => x.UserId).ToListAsync();
            var users = _db.SysUsers ;
            //   var Data = _mapper.Map<IEnumerable<SysUsers>>(users);
            //    var data = await _db.Users.Select(x => new SignModelVw
            //    {
            //      UserName=  x.UserName,

            //        FullName=   x.FullName,
            //        //Password =   x.Password,
            //        //role = _db.Roles.Select(x => x.Name).FirstOrDefault()

            //    }).ToListAsync();
            return users;
        }
        [HttpGet("{Id}")]
        //[Authorize(Roles = "Manager")]

        public async Task<ActionResult<SysUsersVw>> GetuserById(string Id)
    {


            var user = _db.SysUsers.Select(x => new SysUsersVw
            {
                Id = x.Id,
                UserName = x.UserName,
                PhoneNumber = x.PhoneNumber,
                FullName = x.FullName,
            
            }).SingleOrDefault(x => x.Id == Id);
            return user;
    }
    }
 




    }
