namespace bugyo.Internal;

public class Country
{
    public int id { get; set; }
    public string name { get; set; }
    public string iso_code { get; set; }
    public int group_id { get; set; }
    public string timezone { get; set; }
    public string currency { get; set; }
    public bool prepaid_card_available { get; set; } = true;
    public bool credit_card_available { get; set; } = false;
    public bool paypal_available { get; set; } = false;
    public bool tax_excluded_country { get; set; } = false;
    public bool mutable_tax_location_country { get; set; } = false;
    public bool coupon_available { get; set; } = false;
    public bool my_coupon_available { get; set; } = true;
    public bool legal_payment_message_required { get; set; } = true;
    public string[] replenish_amounts { get; set; }
    public bool eshop_available { get; set; } = true;
    public bool redeem_only { get; set; } = false;
    public string max_cash_raw { get; set; }= "250";
    public string region_code { get; set; }
    public string default_language_code { get; set; }
    public defaultLanguage default_language { get; set; }
    public defaultLanguage[] available_language_codes { get; set; }
    public string default_timezone { get; set; } = "+02:00";
    public bool language_selectable { get; set; } = false;
    public bool tax_free_country { get; set; } = false;
    public bool jcb_security_code_available { get; set; } = false;
    public Currency max_cash { get; set; }
    public string gp_exchange_rate { get; set; }
    public string gp_gift_rate { get; set; }
    public string minimum_currency_unit { get; set; }
    
    public struct defaultLanguage
    {
        public int id;
        public string code;
    }
    
    public struct Currency
    {
        public string formatted_value;
        public string currency;
        public string raw_value;
    }
    
    public struct PriceFormat
    {
        public string positive_prefix;
        public string positive_suffix;
        public string negative_prefix;
        public string negative_suffix;
        public CurrencyFormats formats;
    }
    
    public struct CurrencyFormats
    {
        public int pattern_id;
        public Formats[] formats;
    }
    
    public struct Formats
    {
        public string format;
        public string digit;
    }
}