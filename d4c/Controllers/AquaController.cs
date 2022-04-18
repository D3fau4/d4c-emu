using Microsoft.AspNetCore.Mvc;

namespace d4c.Controllers;

[ApiController]
[Produces("application/json")]
public class AquaController : ControllerBase
{
    [HttpGet]
    [Route("required_system_update_meta")]
    public ActionResult<string> GetLastestMandatoryUpdate(string device_id = "DEADCAFEBABEBEEF")
    {
        if (device_id.Length < 16)
            return  StatusCode(StatusCodes.Status403Forbidden);
        return Ok($"Hello from aqua");
    }
}