using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApiIdentity.Dtos;
using WebApiIdentity.Identity;
using WebApiIdentity.JWT;

namespace WebApiIdentity.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TokensController : ControllerBase
  {
    // sistemdeki bir kayanağa erişim için login olmamız lazım

    private readonly UserManager<AppUser> userManager;
    private readonly RoleManager<AppRole> roleManager;
    private readonly IJwtTokenService jwtTokenService;

    public TokensController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IJwtTokenService jwtTokenService)
    {
      this.userManager = userManager;
      this.roleManager = roleManager;
      this.jwtTokenService = jwtTokenService;
    }

    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[HttpGet]
    //public IActionResult TestForAuthenticated()
    //{
    //  return Ok();
    //}


    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Admin")]
    [HttpGet]
    public IActionResult TestFromAdmin()
    {
      return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateToken([FromBody] LoginDto dto)
    {

      var user = await this.userManager.FindByEmailAsync(dto.Email);
      var isExist = await this.userManager.CheckPasswordAsync(user,dto.Password);
      var roles = await this.userManager.GetRolesAsync(user);

      if(isExist)
      {
        var userClaims = await this.userManager.GetClaimsAsync(user); // user claims
        //var roleNames = await this.userManager.GetRolesAsync(user);

        //var roleClaims = await this.roleManager.

        var identity = new ClaimsIdentity(new Claim[]
           {
                    new Claim("Email",user.Email),
                    new Claim(ClaimTypes.Role, roles[0]),
                    new Claim("UserId",user.Id)
           });

        identity.Claims.ToList().AddRange(userClaims);

        var token = this.jwtTokenService.CreateAccessToken(identity);

        return Ok(token);



      }

      return BadRequest();
    }
    

  }
}
