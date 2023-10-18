namespace bugyo.Internal;

public class Content
{
    public int Id { get; set; }
    public string FormalName { get; set; }
    public string HeroBannerUrl { get; set; }
    public List<Screenshot> Screenshots { get; set; }
    public string ReleaseDateOnEshop { get; set; }
    public string PublicStatus { get; set; }
    public bool IsNew { get; set; }
    public bool MembershipRequired { get; set; }
    public List<string> Tags { get; set; }
    public RatingInfo RatingInfo { get; set; }
    public bool ExMembershipFree { get; set; }
    public bool IsSpecialTrial { get; set; }
    public string ContentType { get; set; }
}