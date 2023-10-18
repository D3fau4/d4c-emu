namespace bugyo.Internal.Prices;

public class RegularPrice
{
    public int Id { get; set; }
    public string FormattedValue { get; set; }
    public string Currency { get; set; }
    public string RawValue { get; set; }
}

public class GoldPoint
{
    public string BasicGiftRate { get; set; }
    public string BasicGiftGp { get; set; }
    public List<object> ExtraGoldPoints { get; set; }
    public string ConsumeGp { get; set; }
    public string GiftGp { get; set; }
    public string GiftRate { get; set; }
}

public class Price
{
    public RegularPrice RegularPrice { get; set; }
    public bool NoGiftGoldPoint { get; set; }
    public GoldPoint GoldPoint { get; set; }
    public bool IsDownloadReady { get; set; }
    public string SettlementDate { get; set; }
    public int? DiscountPrice { get; set; }
    public string StartDatetime { get; set; }
    public string EndDatetime { get; set; }
    public bool StatExclusionFlag { get; set; }
}

public class Content_item
{
    public int Id { get; set; }
    public string ContentType { get; set; }
    public bool IsOwned { get; set; }
    public bool IsSelfOwned { get; set; }
    public bool IsScheduledOrdered { get; set; }
}

public class PickupItem
{
    public int Id { get; set; }
    public string SalesStatus { get; set; }
    public bool IsSoldOndevice { get; set; }
    public Price Price { get; set; }
    public List<Content_item> Contents { get; set; }
    public bool IsOwned { get; set; }
    public bool IsSelfOwned { get; set; }
}