using Microsoft.AspNetCore.Mvc;

namespace ctest.Controllers;

[ApiController]
public class CtestController : ControllerBase
{
    [HttpGet("/")]
    public ActionResult<string> GetCtest()
    {
        if (HttpContext.Request.Headers.UserAgent.Equals("NX NIFM/00"))
            return Ok("ok");
        return Forbid();
    }
}