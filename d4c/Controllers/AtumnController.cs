using System.ComponentModel;
using LibHac;
using Microsoft.AspNetCore.Mvc;
using Horizon = d4c.HOS.Horizon;

namespace d4c.Controllers;

[ApiController]
[Route("t/")]
public class AtumnController : ControllerBase
{
    [HttpHead("s/{contentid:long}/{version:long}")]
    [ETagFilter(200)]
    public ActionResult<HttpContent> GetMetaNca0(string contentid = "0100000000000816", string version = "940572692", string device_id = "DEADCAFEBABEBEEF")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.ContentType = "application/octet-stream";
        /* nintendo Headers */
        
        if (!Horizon.ValidDeviceID((ulong)Convert.ToInt64(device_id)))
            return  StatusCode(StatusCodes.Status403Forbidden);
        
        return Ok();
    }
    
    [HttpHead("a/{contentid:long}/{version:long}")]
    [ETagFilter(200)]
    public ActionResult<HttpContent> GetProgramNca0(string contentid = "0100000000000816", string version = "940572692", string device_id = "DEADCAFEBABEBEEFul")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.ContentType = "application/octet-stream";
        /* nintendo Headers */
        
        if (!Horizon.ValidDeviceID(Convert.ToUInt64($"0x{device_id}",16)))
            return  StatusCode(StatusCodes.Status403Forbidden);
        
        return Ok();
    }
}