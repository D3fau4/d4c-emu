using d4c.HOS;
using Microsoft.AspNetCore.Mvc;

namespace d4c.Controllers;

[ApiController]
[Route("v1/")]
[Produces("application/json")]
public class SunController : ControllerBase
{
    [HttpGet("system_update_meta")]
    public ActionResult<SystemUpdateMeta> GetLastestUpdate(string device_id = "DEADCAFEBABEBEEF")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.Add("X-Content-Type-Options", "nosniff");
        HttpContext.Response.Headers.Add("X-Frame-Options", "DENY");
        HttpContext.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
        HttpContext.Response.Headers.Add("x-nintendo-akamai-reference-id", "0.7e251102.1650278892.589bfbdb");
        HttpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
        HttpContext.Response.Headers.Add("Connection", "keep-alive");
        /* nintendo Headers */

        if (!Horizon.ValidDeviceID(Convert.ToUInt64($"0x{device_id}", 16)))
            return StatusCode(StatusCodes.Status403Forbidden);

        foreach (var nca in Horizon.hos.ncafolder.Titles.Values.OrderBy(x => x.Id))
            if (nca.Id == 0x0100000000000816ul)
            {
                var meta = new SystemUpdateMeta
                {
                    timestamp = (int) DateTime.Now.ToBinary()
                };
                meta.system_update_metas.Add(new SystemUpdateMetas("0100000000000816", nca.Version.Version));

                return Ok(meta);
            }

        // Return last update
        return StatusCode(StatusCodes.Status404NotFound);
    }
}