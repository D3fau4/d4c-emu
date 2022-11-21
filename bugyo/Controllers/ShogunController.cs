using bugyo.Internal;
using Microsoft.AspNetCore.Mvc;

namespace bugyo.Controllers;

[ApiController]
[Produces("application/json")]
[Route("shogun/")]
public class ShogunController : ControllerBase
{
    #region /my/

    [HttpPost("v1/my/account")]
    public ActionResult<Account> GetAccount(int shop_id, string redirect_url = "nintendo://shop.nx.sys", string country = "EN", string lang = "en")
    {
        var nnAccount = new Account();

        nnAccount.shop_account_id = 0000000000;
        nnAccount.na_id = "ffffffffffffffff";
        nnAccount.screen_name = "ll•••@z••••";
        nnAccount.gender = "male";
        nnAccount.country = "SK";
        nnAccount.language = "en-US";
        nnAccount.timezone = "Europe/London";
        nnAccount.birthday = "1998-04-04";
        nnAccount.age = 23;
        nnAccount.payment = "balance";
        nnAccount.analytics_opted_in = true;
        nnAccount.shop_analytics_opted_in = true;
        nnAccount.ecash_integrated = false;
        nnAccount.nnid_linked = false;

        var parental = new Account.ParentalControl();
        parental.is_game_rating_restricted = false;
        parental.is_shopping_restricted = false;

        nnAccount.parental_control = parental;

        return Ok(nnAccount);
    }

    [HttpGet("v1/my/scheduled_orders")]
    public ActionResult<ScheduledOrders> GetScheduledorders()
    {
        var nnSchedule = new ScheduledOrders();
        nnSchedule.orders.order = new List<string>();
        return Ok(nnSchedule);
    }

    [HttpPost("v1/my/tickets/rights")]
    public ActionResult<string> GetTickets()
    {
        return Ok("[]");
    }

    #endregion

    #region /country/
    
    [HttpGet("v1/country")]
    public ActionResult<Country> GetCountryConfig(int shop_id, string lang, string country)
    {
        var nnCountry = new Country();
        nnCountry.id = 105;
        return Ok(nnCountry);
    }

    #endregion
}