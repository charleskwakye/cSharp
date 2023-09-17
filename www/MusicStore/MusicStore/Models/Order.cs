namespace MusicStore.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
