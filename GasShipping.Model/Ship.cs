using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasShipping.Model
{
    public class Ship
    {

        public int Id { get; init; }
        public string Name { get; init; }
        public Location Location { get; set; }
        public double TotalCapacity { get; init; }
        public double CurrentCapacity { get; set; }

        public Ship(int id, string name, Location location, double totalCapacity, double currentCapacity=0)
        {
            //if (string.IsNullOrEmpty(name))
            //{
            //    throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            //}
            ArgumentNullException.ThrowIfNull(id, nameof(id));
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            ArgumentNullException.ThrowIfNull(location, nameof(location));
            ArgumentNullException.ThrowIfNull(totalCapacity, nameof(totalCapacity));

            Id = id;
            Name = name;
            Location = location; //?? throw new ArgumentNullException(nameof(location));
            TotalCapacity = totalCapacity;
            CurrentCapacity = currentCapacity;
        }
    }
}
