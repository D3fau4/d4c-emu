using Microsoft.AspNetCore.Mvc;

namespace ndas.Controllers;

[ApiController]
[Produces("application/json")]
[Route("v1/")]
public class aauthController : ControllerBase
{
    [HttpGet("time/")]
    public ActionResult<string> GetTime()
    {
        return Ok($"{(int)DateTime.Now.ToBinary()}\n{Request.HttpContext.Connection.RemoteIpAddress}");
    }
}