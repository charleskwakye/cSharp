using DI_Pattern_Good;

Order order = new Order(new EmailSender());
order.ContactCustomer(1, "Your shipment will be delivered tomorrow at 4pm.");
Order secondOrder = new Order(new TelSender());
secondOrder.ContactCustomer(1, "Your shipment will be delivered tomorrow at 5pm");
Console.WriteLine("Press any key");
Console.ReadKey();