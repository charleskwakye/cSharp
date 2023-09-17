using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaBike
{
    internal class BikeRental
    {
        public readonly List<Bike> RentedBikes = new() { };
        //public List <Bike>? OverviewRentals { get; set; }

         

        


        public void RegisterRent(Bike bike ) { 
            bool exist = false;

            foreach(Bike item in RentedBikes)
            {
                if(item.SerialNumber == bike.SerialNumber)
                {
                    exist = true;
                    Trace.WriteLine("Bike is already in list");
                }
                
            }
            if(!exist)
            {
                RentedBikes.Add(bike);
            }
        }

        public void DeregisterRent(Bike bike)
        {
            RentedBikes.Remove(bike);
        }
    }
}
