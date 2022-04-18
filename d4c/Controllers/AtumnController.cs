using System.IO;
using System.Net;
using LibHac.Common;
using LibHac.Tools.FsSystem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Horizon = d4c.HOS.Horizon;

namespace d4c.Controllers;

[ApiController]
[Route("t/")]
public class AtumnController : ControllerBase
{
    [HttpHead("s/{contentid:long}/{version:long}")]
    [ETagFilter(200)]
    public IActionResult GetMetaNca0(string contentid = "0100000000000816", string version = "940572692", string device_id = "DEADCAFEBABEBEEF")
    {
        /* nintendo Headers */
        //HttpContext.Response.ContentType = "application/octet-stream";
        HttpContext.Response.Headers.Add("x-nintendo-akamai-reference-id","0.7e251102.1650278892.589bfbdb");
        /* nintendo Headers */
        
        /*if (!Horizon.ValidDeviceID(Convert.ToUInt64($"0x{device_id}",16)))
            return  StatusCode(StatusCodes.Status403Forbidden);*/
        foreach (var nca in Horizon.hos.ncafolder.Titles.Values.OrderBy(x => x.Id))
        {
            if (nca.Id == Convert.ToUInt64($"0x{contentid}",16))
            {
                HttpContext.Response.Headers.Add("X-Nintendo-Content-ID", nca.MetaNca.NcaId);
                HttpContext.Response.Headers.Add("X-Nintendo-Content-Hash", Horizon.SHA256CheckSum(Path.Combine(Horizon.hos.NcaFolderPath, nca.MetaNca.Filename)));
                return File(System.IO.File.ReadAllBytes(Path.Combine(Horizon.hos.NcaFolderPath, nca.MetaNca.Filename)), "application/octet-stream");
            }
            continue;
        }

        return NotFound();
    }
    
    [HttpHead("a/{contentid:long}/{version:long}")]
    [ETagFilter(200)]
    public ActionResult<HttpContent> GetProgramNca0(string contentid = "0100000000000816", string version = "940572692", string device_id = "DEADCAFEBABEBEEFul")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.ContentType = "application/octet-stream";
        HttpContext.Response.Headers.Add("x-nintendo-akamai-reference-id","0.7e251102.1650278892.589bfbdb");
        /* nintendo Headers */
        
        /*if (!Horizon.ValidDeviceID(Convert.ToUInt64($"0x{device_id}",16)))
            return  StatusCode(StatusCodes.Status403Forbidden);*/
        
        return Ok();
    }
}