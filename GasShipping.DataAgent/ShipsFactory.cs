using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GasShipping.Model;

namespace GasShipping.DataAgent
{
    public class ShipsFactory
    {
        public List<Ship> Ships { get; set; }
        public ShipsFactory(List<Ship> ships)
        {
            Ships = ships;
        }

        public ShipsFactory()
        {
            Ships = new List<Ship>();
        }

       

        public string GetShips()
        {
            var opt=new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<List<Ship>>(Ships, opt);
        }
        public void AddShip(Ship ship) => Ships.Add(ship);

        public void RemoveShip(Ship ship)
        {
            if (ship is null)
            {
                throw new ArgumentNullException(nameof(ship));
            }

            Ships.Remove(ship);
        }
    }

}
