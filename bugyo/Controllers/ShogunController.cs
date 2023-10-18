using bugyo.Internal;
using bugyo.Internal.Prices;
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
    public ActionResult<ScheduledOrders> GetScheduledorders(int shop_id, string lang)
    {
        var nnSchedule = new ScheduledOrders();
        nnSchedule.orders.order = new List<string>();
        return Ok(nnSchedule);
    }

    [HttpPost("v1/my/tickets/rights")]
    public ActionResult<string[]> GetTickets(int shop_id)
    {
        return Ok(new string[0]);
    }

    [HttpGet("v1/my/devices")]
    public ActionResult<string[]> getDevices(int shop_id, string lang, int device_type_id)
    {
        var devices = new string[] { "aaaaaaaaaaaa" };
        return Ok(devices);
    }
    #endregion

    #region /country/
    
    [HttpGet("v1/country")]
    public ActionResult<Country> GetCountryConfig(int shop_id, string lang, string country)
    {
        var nnCountry = new Country
        {
            id = 105,
            name = "Spain",
            iso_code = "ES",
            group_id = 9,
            region_code = "EUR",
            timezone = "Europe/Madrid",
            currency = "EUR",
            prepaid_card_available = true,
            credit_card_available = true,
            paypal_available = true,
            tax_excluded_country = false,
            mutable_tax_location_country = false,
            coupon_available = false,
            my_coupon_available = true,
            legal_payment_message_required = false,
            replenish_amounts = new[] { "10", "20", "60", "130" },
            eshop_available = true,
            redeem_only = false,
            max_cash_raw = "250",
            default_language_code = "es",
            default_language = new Country.defaultLanguage
            {
                id = 302,
                code = "es"
            },
            available_language_codes = new []{ new Country.defaultLanguage() { id = 302, code = "es"} },
            default_timezone = "+02:00",
            language_selectable = false,
            tax_free_country = false,
            jcb_security_code_available = false,
            max_cash = new Country.Currency
            {
                formatted_value = "250,00 €",
                currency = "EUR",
                raw_value = "250"
            },
            gp_exchange_rate = "0.01",
            gp_gift_rate = "0.05",
            minimum_currency_unit = "0.01"
        };

        return Ok(nnCountry);
    }

    [HttpGet("v1/country/membership")]
    public ActionResult<Membership> GetMembership(int shop_id, string lang, string country)
    {
        var membership = new Membership
            {
                courses = new Courses
                {
                    individual = new Course { course_id = "7fb703910f7e823d" },
                    family = new Course { course_id = "c3df9efd3d821bc7" },
                    ex_individual = new Course { course_id = "d97067bbfb3cf1d0" },
                    ex_family = new Course { course_id = "71de90a1cf1ae628" }
                },
                membership_contents = new List<MembershipContent>
                {
                    new MembershipContent { id = 70010000018532, classic_game = false, membership_required = false },
                    new MembershipContent { id = 70010000032160, classic_game = false, membership_required = false },
                    new MembershipContent { id = 70010000023210, classic_game = true, classic_game_type = "basic", membership_required = false },
                    new MembershipContent { id = 70010000013627, classic_game = true, classic_game_type = "basic", membership_required = false },
                    new MembershipContent { id = 70050000019994, membership_required = true },
                    new MembershipContent { id = 70050000021157, membership_required = true },
                    new MembershipContent { id = 70090000005548, membership_required = true, image_url = "/i/c08da815ed18d85c01940fa10ad33a53076f5bffade111b66d5dde53c8ec9bf9.jpg" }
                },
                ex_membership_contents = new List<ExMembershipContent>
                {
                    new ExMembershipContent { id = 70070000013750, membership_required = false, ex_membership_free = true },
                    new ExMembershipContent { id = 70010000046984, classic_game_type = "ex", membership_required = false, ex_membership_free = false },
                    new ExMembershipContent { id = 70050000030743, membership_required = false, ex_membership_free = true },
                    new ExMembershipContent { id = 70010000046989, classic_game_type = "ex", membership_required = false, ex_membership_free = false }
                },
                promotion_contents = new List<PromotionContent>
                {
                    new PromotionContent
                    {
                        id = 70010000009166,
                        dl_term = new DlTerm { start = DateTime.Parse("2022-04-19T10:00:00+02:00"), end = DateTime.Parse("2022-04-26T23:59:59+02:00") },
                        play_term = new PlayTerm { start = DateTime.Parse("2022-04-20T10:00:00+02:00"), end = DateTime.Parse("2022-04-26T23:59:59+02:00") },
                        promotion = new Dictionary<string, object>(),
                        promotion_type = "game_trials",
                        is_feature_limited = false,
                        required_membership_type = "membership"
                    }
                }
            };

        return Ok(membership);
    }
    
    #endregion

    #region /v2/

    [HttpGet("v2/pickup_shelves")]
    public ActionResult<PickupShelf[]> getpickup_shelves(int shop_id, string lang, string country)
    {
        return Ok(new PickupShelf[5]);
    }

    #endregion

    #region /v1/

    [HttpGet("v1/prices")]
    public ActionResult<PickupItem[]> getPrices(int shop_id, string lang, string ids)
    {
        return Ok(new PickupItem[ids.Length]);
    }
    
    #endregion
    
    [HttpGet("ashigaru-assets/environment.json")]
    public ActionResult<string> getEnvironmentJSON()
    {
        return Ok("{\n\t\"name\": \"lp1\",\n\t\"nasHostname\": \"accounts.nintendo.com\",\n\t\"nasParam\": {\n\t\t\"client_id\": \"e56201e414c97a10\",\n\t\t\"state\": \"STATESTATE\"\n\t}\n}");
    }
}