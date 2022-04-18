using Microsoft.AspNetCore.Mvc;

namespace d4c.Controllers;

[ApiController]
[Produces("application/json")]
public class AquaController : ControllerBase
{
    [HttpGet]
    [ETagFilter(200)]
    [Route("required_system_update_meta")]
    public ActionResult<string> GetLastestMandatoryUpdate(string device_id = "DEADCAFEBABEBEEF")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.Add("Connection", "keep-alive");
        /* nintendo Headers */
        
        if (device_id.Length != 16)
            return  StatusCode(StatusCodes.Status403Forbidden);
        return Ok("{\"contents_delivery_required_title_id\":\"0100000000000816\",\"contents_delivery_required_title_version\":873463968}");
    }
}