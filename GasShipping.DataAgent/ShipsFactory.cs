using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GasShipping.Model;

namespace GasShipping.DataAgent
{/// <summary>
/// This class will be responsible for creating ships from the file agent
/// 
/// </summary>
    public class ShipsFactory
    {
        /// <summary>
        ///  list of ship objects
        /// </summary>
        public List<Ship> Ships { get; set; }
        /// <summary>
        /// FileAgent object
        /// </summary>
        private FileAgent _fileAgent;

        /// <summary>
        /// Cunstrctor for ShipsFactory 
        /// </summary>
        /// <param name="ships">List&lt;Ship&gt;</param>
        public ShipsFactory(List<Ship> ships)
        {
            Ships = ships;
            _fileAgent = new FileAgent(Constants.SHIPS_FILE_NAME_C50, Constants.PATH);
        }
        /// <summary>
        /// Cunstrctor for ShipsFactory 
        /// </summary>
        public ShipsFactory()
        {
            Ships = new List<Ship>();
            _fileAgent = new FileAgent(Constants.SHIPS_FILE_NAME_C50, Constants.PATH);
        }
        /// <summary>
        /// Cunstrctor for ShipsFactory 
        /// </summary>
        /// <param name="fileAgent">FileAgent</param>
        public ShipsFactory(FileAgent fileAgent)
        {
            Ships = new List<Ship>();
            _fileAgent = fileAgent;
        }

        /// <summary>
        /// This method converts List of ships to JSON string
        /// </summary>
        /// <returns>JSON string</returns>
        public string SetShipsToJSONString()
        {
            var opt=new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<List<Ship>>(Ships, opt);
        }
        /// <summary>
        /// This method converts List of ships to JSON string
        /// </summary>
        /// <param name="ships">List&lt;Ship&gt;</param>
        /// <returns>JSON string</returns>
        public string SetShipsToJSONString(List<Ship> ships)
        {
            if (ships is null)
            {
                ships = Ships;
            }

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<List<Ship>>(ships, opt);
        }
        /// <summary>
        /// This method converts JSON string to List of ships 
        /// </summary>
        /// <param name="JSONstring">string</param>
        /// <returns>List&lt;Ship&gt;</returns>
        public List<Ship> GetShipsFromJSONString(string JSONstring) => JsonSerializer.Deserialize<List<Ship>>(JSONstring);
        /// <summary>
        /// This method will add a ship to the List&lt;Ship&gt;
        /// </summary>
        /// <param name="ship">Ship</param>
        public void AddShip(Ship ship ) => Ships.Add(ship);
        /// <summary>
        /// This method will remove the ship from the List&lt;Ship&gt;
        /// </summary>
        /// <param name="ship">Ship</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RemoveShip(Ship ship)
        {
            if (ship is null)
            {
                throw new ArgumentNullException(nameof(ship));
            }

            Ships.Remove(ship);
        }
        /// <summary>
        /// This method will read a JSON file then will convert it to list of ships
        /// </summary>
        /// <returns>List&lt;Ship&gt;</returns>
        public List<Ship> GetShipsFromFile()
        {
            var jsonString=_fileAgent.ReadFile();
            Ships.Clear();
            Ships.AddRange(GetShipsFromJSONString(jsonString));
            return Ships;
        }
    }

}
