using Microsoft.AspNetCore.Mvc;

namespace ctest.Controllers;

[ApiController]
public class CtestController : ControllerBase
{
    [HttpGet("/")]
    public ActionResult<string> GetCtest()
    {
        return Ok("ok");
    }
}