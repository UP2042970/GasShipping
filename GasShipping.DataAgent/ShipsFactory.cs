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
        private FileAgent _fileAgent; 
        public ShipsFactory(List<Ship> ships)
        {
            Ships = ships;
            _fileAgent = new FileAgent(Constants.SHIPS_FILE_NAME, Constants.PATH);
        }

        public ShipsFactory()
        {
            Ships = new List<Ship>();
            _fileAgent = new FileAgent(Constants.SHIPS_FILE_NAME, Constants.PATH);
        }

       

        public string SetShipsToJSONString()
        {
            var opt=new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<List<Ship>>(Ships, opt);
        }
        public string SetShipsToJSONString(List<Ship> ships)
        {
            if (ships is null)
            {
                ships = Ships;
            }

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<List<Ship>>(ships, opt);
        }
        public List<Ship> GetShipsFromJSONString(string JSONstring) => JsonSerializer.Deserialize<List<Ship>>(JSONstring);
        public void AddShip(Ship ship ) => Ships.Add(ship);

        public void RemoveShip(Ship ship)
        {
            if (ship is null)
            {
                throw new ArgumentNullException(nameof(ship));
            }

            Ships.Remove(ship);
        }
        public List<Ship> GetShipsFromFile()
        {
            var jsonString=_fileAgent.ReadFile();
            Ships.Clear();
            Ships.AddRange(GetShipsFromJSONString(jsonString));
            return Ships;
        }
    }

}
