namespace DI_Pattern_Good
{
    public class Order
    {
        IContact sender;
        public Order(IContact Sender)
        {
            sender = Sender;
        }

        // Contact customer when order is shipped
        public string ContactCustomer(int customerId, string message)
        {
            return sender.Contact(customerId, message);
        }
    }
}
