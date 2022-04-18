using Microsoft.AspNetCore.Mvc;

namespace d4c.Controllers;

[ApiController]
[Route("v1/")]
[Produces("application/json")]
public class SunController : ControllerBase
{
    [HttpGet]
    [Route("system_update_meta")]
    public ActionResult<string> GetLastestUpdate(string device_id = "DEADCAFEBABEBEEF")
    {
        if (device_id.Length < 16)
            return  StatusCode(StatusCodes.Status403Forbidden);
        return Ok($"{device_id}");
    }
}