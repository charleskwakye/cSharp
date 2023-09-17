using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaBike
{
    internal class Bike : Material
    {

        // Declare a private field to store the code
        private int code;

        // Declare a public property to get the code
        public int Code {
            get { return code;} 
         }



        // Declare a constructor that takes serial number and description as parameters and calls the base constructor
        public Bike(string serialNumber, string description):base(serialNumber,description) { 
        Random rnd = new Random();
            code = rnd.Next(100,1000);
        }

        public override double ReturnRentalPrice()
        {
            return base.ReturnRentalPrice() + (base.ReturnRentalPrice() * 0.2);
        }

        public override string ToString()
        {
            return $"Serial Number: {SerialNumber} Description: {Description} Code: {Code}" ;
        }
    }
}
