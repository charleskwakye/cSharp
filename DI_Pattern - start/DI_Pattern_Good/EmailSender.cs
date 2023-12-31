﻿namespace DI_Pattern_Good
{
    public class EmailSender : IContact
    {
        public string Contact(int customerId, string message)
        {
            // Code to send mail
            string contactMessage = $"Mail sent to customer with id = {customerId} : {message}";
            Console.WriteLine(contactMessage);
            return contactMessage;
        }
    }
}
