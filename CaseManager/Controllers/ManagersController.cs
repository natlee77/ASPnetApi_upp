using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaseManager.Data;
using CaseManager.Entities;
using Microsoft.AspNetCore.Authorization;
using LibraryProject.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using CaseManager.Filters;

namespace CaseManager.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]

    public class ManagersController : ControllerBase
    {
        private readonly SqlDbContext _context;
       
        public IConfiguration _configuration { get; }
        public ManagersController(SqlDbContext context,   IConfiguration configuration)
        {
            _context = context;          
            _configuration = configuration;
        }

         //[Authorize]
        [HttpGet]   // GET: api/Managers
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            return await _context.Managers.ToListAsync();
        }




        //string id  --from Url(query) , from body -from body mdl
        [AllowAnonymous]
        [ApiKeyAuth]
        [HttpPost("register")]                // POST: api/Managers
        public async Task<IActionResult> RegisterManager([FromBody] RegisterVM model)//ok
        {


            if (!_context.Managers.Any(user => user.Email == model.Email))
            {
                try
                {
                    var manager = new Manager()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email
                    };
                    manager.CreatePasswordHash(model.Password);
                    _context.Managers.Add(manager);
                    await _context.SaveChangesAsync();

                    return new OkResult();
                }
                catch (Exception ex) { return new BadRequestObjectResult(ex.Message); }
            }

            return new BadRequestResult();


          
        }





        [AllowAnonymous]
        [ApiKeyAuth]
        [HttpPost("login")]                // POST: api/Managers
        public async Task<IActionResult> Login([FromBody] LoginVM model)  //OK
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return new BadRequestObjectResult("Invalid Email or Password");//object result 

            try
            {
                //försöka hämta user from DB
                var manager = await _context.Managers.FirstOrDefaultAsync(manager => manager.Email == model.Email);


                if (manager == null)
                    return new BadRequestObjectResult("User Not Found");


                if (manager != null)
                {
                    if (!manager.ValidatePasswordHash(model.Password))
                        return new BadRequestObjectResult("Invalid Email or Password");
                    if (manager.ValidatePasswordHash(model.Password))
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var _secretKey = Encoding.UTF8.GetBytes(_configuration.GetSection("SecretKey").Value);//from appsettings section
                        var expiresDate = DateTime.Now.AddDays(1);



                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[] {
                                     new Claim("ManagerId", manager.Id.ToString()),
                                     new Claim("Expires", expiresDate.ToString())
                                }),
                            Expires = expiresDate,
                            SigningCredentials = new SigningCredentials(
                                new SymmetricSecurityKey(_secretKey),
                                SecurityAlgorithms.HmacSha512Signature)
                        };

                        var _accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
                        //spara i DB
                        //_context.SessionsTokens.Add(new SessionsToken { ManagerId = manager.Id, AccessToken = _accessToken });
                        //await _context.SaveChangesAsync();

                        //return new OkObjectResult(new  
                        //{
                        //    Id = manager.Id,
                        //    Email = manager.Email,
                        //    AccessToken = _accessToken
                        //});
                        return new OkObjectResult(_accessToken);
                    }
                }
            }
            catch (Exception ex) { return new BadRequestObjectResult(ex.Message); }

            return new BadRequestResult();

             
        }
         

    }
} 
 
 


