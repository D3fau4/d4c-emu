namespace bugyo.Internal;

public class PickupShelf
{
    public int ShelfId { get; set; }
    public string Type { get; set; }
    public List<Content> Contents { get; set; }
    public string Reason { get; set; }
}