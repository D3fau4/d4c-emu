using bugyo.Internal;
using Microsoft.AspNetCore.Mvc;

namespace bugyo.Controllers;

[ApiController]
[Produces("application/json")]
public class ShogunController : ControllerBase
{
    [HttpPost("shogun/v1/my/account")]
    public ActionResult<Account> GetAccount()
    {
        Account nnAccount = new Account();
        
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

        Account.ParentalControl parental = new Account.ParentalControl();
        parental.is_game_rating_restricted = false;
        parental.is_shopping_restricted = false;

        nnAccount.parental_control = parental;
        
        return Ok(nnAccount);
    }
    [HttpGet("shogun/v1/my/scheduled_orders")]
    public ActionResult<ScheduledOrders> GetScheduledorders()
    {
        ScheduledOrders nnSchedule = new ScheduledOrders();
        nnSchedule.orders.order = new List<string>();
        return Ok(nnSchedule);
    }
}