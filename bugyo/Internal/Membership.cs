namespace bugyo.Internal;

public class Course
{
    public string course_id { get; set; }
}

public class Courses
{
    public Course individual { get; set; }
    public Course family { get; set; }
    public Course ex_individual { get; set; }
    public Course ex_family { get; set; }
}

public class MembershipContent
{
    public long id { get; set; }
    public bool classic_game { get; set; }
    public bool membership_required { get; set; }
    public string classic_game_type { get; set; }
    public string image_url { get; set; }
}

public class ExMembershipContent
{
    public long id { get; set; }
    public bool membership_required { get; set; }
    public bool ex_membership_free { get; set; }
    public string classic_game_type { get; set; }
}

public class DlTerm
{
    public DateTime start { get; set; }
    public DateTime end { get; set; }
}

public class PlayTerm
{
    public DateTime start { get; set; }
    public DateTime end { get; set; }
}

public class PromotionContent
{
    public long id { get; set; }
    public DlTerm dl_term { get; set; }
    public PlayTerm play_term { get; set; }
    public Dictionary<string, object> promotion { get; set; }
    public string promotion_type { get; set; }
    public bool is_feature_limited { get; set; }
    public string required_membership_type { get; set; }
}

public class Membership
{
    public Courses courses { get; set; }
    public List<MembershipContent> membership_contents { get; set; }
    public List<ExMembershipContent> ex_membership_contents { get; set; }
    public List<PromotionContent> promotion_contents { get; set; }
}