using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    internal class Product
    {

        public string ItemId { get; set; }

        public string ItemDescription { get; set; }

        public double Price { get; set; }

        private List<string> Locations;

        public int Amount { get; set; }


        public Product(string itemId, string itemDescription, double price)
        {
            ItemId = itemId;
            ItemDescription = itemDescription;
            Price = price;
            Locations = new List<string>();
        }

        public List<string> GetLocations()
        {
            return Locations;
        }
        
        public void SetLocations(List<string> locations)
        {
            Locations = locations;
        }

        public void AddLocation(string Location)
        {
            Locations.Add(Location);
        }

        public void RemoveLocation(string Location)
        {
            try
            {
                for(int i = 0; i < Locations.Count; i++)
                    if(Locations[i] == Location)
                        Locations.RemoveAt(i);

            } catch (IndexOutOfRangeException e)
            {
                Trace.WriteLine(e);
            }
        }

        public void AddAmount(int Amount)
        {
            this.Amount += Amount;
        }


        public void RemoveAmount(int Amount)
        {
            this.Amount -= Amount;
        }

	}
}
