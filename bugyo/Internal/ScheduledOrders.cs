namespace bugyo.Internal;

public class ScheduledOrders
{
    public Orders orders = new();

    public struct Orders
    {
        public List<string> order;
    }
}