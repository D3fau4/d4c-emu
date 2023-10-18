namespace bugyo.Internal;

public class RatingInfo
{
    public RatingSystem RatingSystem { get; set; }
    public Rating Rating { get; set; }
    public List<ContentDescriptor> ContentDescriptors { get; set; }
}

public class Rating
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string ImageUrl { get; set; }
    public string SvgImageUrl { get; set; }
    public bool Provisional { get; set; }
}

public class RatingSystem
{
    public int Id { get; set; }
    public string Name { get; set; }
}