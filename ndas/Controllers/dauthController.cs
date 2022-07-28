using Microsoft.AspNetCore.Mvc;
using ndas.Internal;

namespace ndas.Controllers;

[ApiController]
[Produces("application/json")]
[Route("v7/")]
public class dauthController : ControllerBase
{
    [HttpPost("challenge/")]
    public ActionResult<ChallengeMessage> GetChallenge(string key_generation = "14")
    {
        var message = new ChallengeMessage();
        message.challenge = "InNjA125bIEZ8K6QpXi4yplEPNCgrYP77X7Zz9SItYY=";
        message.data = "mXj_1s484owezGnLYRhD6w==";
        return Ok(message);
    }

    [HttpPost("device_auth_token/")]
    public ActionResult<DeviceAuthTokenMessage> GetDeviceAuthToken(
        string challenge = "InNjA125bIEZ8K6QpXi4yplEPNCgrYP77X7Zz9SItYY",
        string client_id = "", bool ist = false, string key_generation = "14",
        string system_version = "", string mac = "")

    {
        var message = new DeviceAuthTokenMessage();
        message.expires_in = 86400;
        message.device_auth_token = "PIPOPIPO";
        return Ok(message);
    }
}