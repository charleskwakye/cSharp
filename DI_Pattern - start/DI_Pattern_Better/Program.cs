using DI_Pattern_Better;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider serviceProvider;

var services = new ServiceCollection();
// Register interfaces using factory that returns implementation
services.AddSingleton<IContact, EmailSender>();
serviceProvider = services.BuildServiceProvider(true);

Order order = new Order(serviceProvider.GetService<IContact>());
order.ContactCustomer(1, "Finally shipped");

Console.WriteLine("Press any key");
Console.ReadKey();