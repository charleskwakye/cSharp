using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaBike
{
    internal class Material
    {

        // Declare public properties for serial number and description
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        // Declare a constructor that takes serial number and description as parameters
        public Material(string serialNumber,string description) {
            SerialNumber = serialNumber;
            Description = description;
        }

        // Declare a method that returns a standard rental price of 100 Euros
        public virtual double ReturnRentalPrice() {
            return 100;
        }

    }
}
