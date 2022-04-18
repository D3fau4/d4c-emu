using d4c.HOS;
using Microsoft.AspNetCore.Mvc;

namespace d4c.Controllers;

[ApiController]
[Produces("application/json")]
public class AquaController : ControllerBase
{
    [HttpGet("required_system_update_meta")]
    [ETagFilter(200)]
    public ActionResult<required_system_update_meta> GetLastestMandatoryUpdate(string device_id = "DEADCAFEBABEBEEF")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.Add("Connection", "keep-alive");
        /* nintendo Headers */

        if (!Horizon.ValidDeviceID(Convert.ToUInt64($"0x{device_id}", 16)))
            return StatusCode(StatusCodes.Status403Forbidden);

        foreach (var nca in Horizon.hos.ncafolder.Titles.Values.OrderBy(x => x.Id))
        {
            if (nca.Id == 0x0100000000000816ul)
            {
                var meta = new required_system_update_meta
                {
                    contents_delivery_required_title_id = "0100000000000816",
                    contents_delivery_required_title_version = nca.Version.Version
                };

                return Ok(meta);
            }
        }

        // Return last update
        return StatusCode(StatusCodes.Status404NotFound);
    }
}