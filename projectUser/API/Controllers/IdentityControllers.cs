using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class IdentityControllers : ControllerBase
{
    [HttpGet("Get")]
    public ActionResult<string> GetCurrentUser()
    {
        return Ok("1");
    }
}