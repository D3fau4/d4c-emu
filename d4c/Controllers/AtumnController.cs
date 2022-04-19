using d4c.HOS;
using Microsoft.AspNetCore.Mvc;

namespace d4c.Controllers;

[ApiController]
public class AtumnController : ControllerBase
{
    #region NCA0

    [HttpHead("t/s/{contentid}/{version}")]
    [ETagFilter(200)]
    public IActionResult GetSystemUpdateNca0(string contentid = "0100000000000816", string version = "940572692",
        string device_id = "DEADCAFEBABEBEEF")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.Add("x-nintendo-akamai-reference-id", "0.7e251102.1650278892.589bfbdb");
        /* nintendo Headers */

        if (!Horizon.ValidDeviceID(Convert.ToUInt64($"0x{device_id}", 16)))
            return StatusCode(StatusCodes.Status403Forbidden);

        foreach (var nca in Horizon.hos.ncafolder._Titles.OrderBy(x => x.Id))
            if (nca.Id.Equals(Convert.ToUInt64($"0x{contentid}", 16)) &&
                nca.Version.Version.Equals(Convert.ToUInt32($"{version}")))
            {
                HttpContext.Response.Headers.Add("X-Nintendo-Content-ID", nca.MetaNca.NcaId);
                HttpContext.Response.Headers.Add("X-Nintendo-Content-Hash",
                    Horizon.SHA256CheckSum(Path.Combine(Horizon.hos.NcaFolderPath, nca.MetaNca.Filename)));
                return File(System.IO.File.ReadAllBytes(Path.Combine(Horizon.hos.NcaFolderPath, nca.MetaNca.Filename)),
                    "application/octet-stream");
            }

        return NotFound("");
    }

    [HttpHead("t/a/{contentid}/{version}")]
    [ETagFilter(200)]
    public ActionResult<HttpContent> GetMetaNca0(string contentid = "0100000000000816", string version = "940572692",
        string device_id = "DEADCAFEBABEBEEF")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.ContentType = "application/octet-stream";
        HttpContext.Response.Headers.Add("x-nintendo-akamai-reference-id", "0.7e251102.1650278892.589bfbdb");
        /* nintendo Headers */

        if (!Horizon.ValidDeviceID(Convert.ToUInt64($"0x{device_id}", 16)))
            return StatusCode(StatusCodes.Status403Forbidden);

        foreach (var nca in Horizon.hos.ncafolder._Titles.OrderBy(x => x.Version.Version))
        {
            if (nca.Id.Equals(Convert.ToUInt64($"0x{contentid}", 16)) &&
                nca.Version.Version.Equals(Convert.ToUInt32($"{version}")))
            {
                HttpContext.Response.Headers.Add("X-Nintendo-Content-ID", nca.MetaNca.NcaId);
                HttpContext.Response.Headers.Add("X-Nintendo-Content-Hash",
                    Horizon.SHA256CheckSum(Path.Combine(Horizon.hos.NcaFolderPath, nca.MetaNca.Filename)));
                return File(System.IO.File.ReadAllBytes(Path.Combine(Horizon.hos.NcaFolderPath, nca.MetaNca.Filename)),
                    "application/octet-stream");
            }
        }

        return NotFound();
    }

    [HttpHead("t/c/{contentid}/{version}")]
    [ETagFilter(200)]
    public ActionResult<HttpContent> GetProgramNca0(string contentid = "0100000000000816", string version = "940572692",
        string device_id = "DEADCAFEBABEBEEF")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.ContentType = "application/octet-stream";
        HttpContext.Response.Headers.Add("x-nintendo-akamai-reference-id", "0.7e251102.1650278892.589bfbdb");
        /* nintendo Headers */

        if (!Horizon.ValidDeviceID(Convert.ToUInt64($"0x{device_id}", 16)))
            return StatusCode(StatusCodes.Status403Forbidden);

        foreach (var nca in Horizon.hos.ncafolder._Titles.OrderBy(x => x.Id))
            if (nca.Id.Equals(Convert.ToUInt64($"0x{contentid}", 16)) &&
                nca.Version.Version.Equals(Convert.ToUInt32($"{version}")))
            {
                HttpContext.Response.Headers.Add("X-Nintendo-Content-ID", nca.MainNca.NcaId);
                HttpContext.Response.Headers.Add("X-Nintendo-Content-Hash",
                    Horizon.SHA256CheckSum(Path.Combine(Horizon.hos.NcaFolderPath, nca.MainNca.Filename)));
                return File(System.IO.File.ReadAllBytes(Path.Combine(Horizon.hos.NcaFolderPath, nca.MainNca.Filename)),
                    "application/octet-stream");
            }

        return NotFound();
    }

    #endregion

    #region NCA

    [HttpGet("c/s/{NcaId}")]
    [ETagFilter(200)]
    public IActionResult GetSystemUpdateNca(string NcaId = "eef23e6017719c46c6f8bbecdd53da77")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.Add("x-nintendo-akamai-reference-id", "0.7e251102.1650278892.589bfbdb");
        /* nintendo Headers */

        foreach (var nca in Horizon.hos.ncafolder.Ncas.Values)
            if (nca.NcaId.ToLower().Equals(NcaId))
            {
                HttpContext.Response.Headers.Add("X-Nintendo-Content-ID", nca.NcaId);
                HttpContext.Response.Headers.Add("X-Nintendo-Content-Hash",
                    Horizon.SHA256CheckSum(Path.Combine(Horizon.hos.NcaFolderPath, nca.Filename)));
                return File(System.IO.File.ReadAllBytes(Path.Combine(Horizon.hos.NcaFolderPath, nca.Filename)),
                    "application/octet-stream");
            }

        return NotFound();
    }

    [HttpGet("c/a/{NcaId}")]
    [ETagFilter(200)]
    public IActionResult GetMetaNca(string NcaId = "eef23e6017719c46c6f8bbecdd53da77")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.Add("x-nintendo-akamai-reference-id", "0.7e251102.1650278892.589bfbdb");
        /* nintendo Headers */

        foreach (var nca in Horizon.hos.ncafolder.Ncas.Values)
            if (nca.NcaId.ToLower().Equals(NcaId))
            {
                HttpContext.Response.Headers.Add("X-Nintendo-Content-ID", nca.NcaId);
                HttpContext.Response.Headers.Add("X-Nintendo-Content-Hash",
                    Horizon.SHA256CheckSum(Path.Combine(Horizon.hos.NcaFolderPath, nca.Filename)));
                return File(System.IO.File.ReadAllBytes(Path.Combine(Horizon.hos.NcaFolderPath, nca.Filename)),
                    "application/octet-stream");
            }

        return NotFound();
    }

    [HttpGet("c/c/{NcaId}")]
    [ETagFilter(200)]
    public IActionResult GetProgramNca(string NcaId = "eef23e6017719c46c6f8bbecdd53da77")
    {
        /* nintendo Headers */
        HttpContext.Response.Headers.Add("x-nintendo-akamai-reference-id", "0.7e251102.1650278892.589bfbdb");
        foreach (var nca in Horizon.hos.ncafolder.Ncas.Values)
            if (nca.NcaId.ToLower().Equals(NcaId))
            {
                HttpContext.Response.Headers.Add("X-Nintendo-Content-ID", nca.NcaId);
                HttpContext.Response.Headers.Add("X-Nintendo-Content-Hash",
                    Horizon.SHA256CheckSum(Path.Combine(Horizon.hos.NcaFolderPath, nca.Filename)));
                return File(System.IO.File.ReadAllBytes(Path.Combine(Horizon.hos.NcaFolderPath, nca.Filename)),
                    "application/octet-stream");
            }

        return NotFound();
    }

    #endregion
}