using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GasShipping.Model
{
    /// <summary>Ship Data Model</summary>
    public class Ship
    {
        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        [JsonPropertyName("ID")]
        public int Id { get; init; }
        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; init; }
        /// <summary>Gets or sets the location.</summary>
        /// <value>The location.</value>
        public Location Location { get; set; }
        /// <summary>Gets the total capacity.</summary>
        /// <value>The total capacity.</value>
        [JsonPropertyName("Total Capacity")]
        public double TotalCapacity { get; init; }
        /// <summary>Gets or sets the current capacity.</summary>
        /// <value>The current capacity.</value>
        [JsonPropertyName("Current Capacity")]
        public double CurrentCapacity { get; set; }

        public LinkedList<Customers>? Customers { get; set; }

        /// <summary>Initializes a new instance of the <see cref="Ship" /> class.
        /// Throws ArgumentNullException if param(s) are null.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="totalCapacity">The total capacity.</param>
        /// <param name="currentCapacity">The current capacity.</param>
        public Ship(int id, string name, Location location, double totalCapacity, double currentCapacity = 0)
        {
            //if (string.IsNullOrEmpty(name))
            //{
            //    throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            //}
            ArgumentNullException.ThrowIfNull(id, nameof(id));
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            //ArgumentNullException.ThrowIfNull(location, nameof(location));
            ArgumentNullException.ThrowIfNull(totalCapacity, nameof(totalCapacity));

            Id = id;
            Name = name;
            Location = location ?? new Location(0, 0); //?? throw new ArgumentNullException(nameof(location));
            TotalCapacity = totalCapacity;
            CurrentCapacity = currentCapacity;
            Customers = new LinkedList<Customers>();
        }
    }
}
