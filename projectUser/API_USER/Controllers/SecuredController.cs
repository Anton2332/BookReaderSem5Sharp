using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_USER.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SecuredController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSecuredData()
    {
        return Ok("This Secured Data is available only for Authenticated Users.");
    }
}