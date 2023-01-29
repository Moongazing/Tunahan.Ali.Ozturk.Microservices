using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TAO.IdentityServer.Dtos;
using TAO.IdentityServer.Models;
using static IdentityServer4.IdentityServerConstants;

namespace TAO.IdentityServer.Controllers
{
  
  [Authorize(LocalApi.PolicyName)]
  [Route("api/[controller]/{action}")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserManager<ApplicationUser> _userManager;
    public UserController(UserManager<ApplicationUser> userManager)
    {
      _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignupDto singupDto)
    {
      var user = new ApplicationUser
      {
        UserName = singupDto.UserName,
        Email = singupDto.Email,
        City = singupDto.City,
    
      };
      var result = await _userManager.CreateAsync(user, singupDto.Password);

      if(!result.Succeeded)
      {
        return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x=>x.Description).ToList(),400));
      }
      return NoContent();
    }
  }
}
