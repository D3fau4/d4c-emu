namespace bugyo.Internal;

public class Account
{
    public ulong shop_account_id { get; set; }
    public string na_id { get; set; }
    public string screen_name { get; set; }
    public string gender { get; set; }
    public string country { get; set; }
    public string language { get; set; }
    public string timezone { get; set; }
    public string birthday { get; set; }
    public int age { get; set; }
    public string payment { get; set; }
    public bool analytics_opted_in { get; set; }
    public bool shop_analytics_opted_in { get; set; }
    public bool ecash_integrated { get; set; }
    public bool nnid_linked { get; set; }

    public struct ParentalControl
    {
        public bool is_shopping_restricted { get; set; }
        public bool is_game_rating_restricted { get; set; }
    }
    public ParentalControl parental_control { get; set; }
}