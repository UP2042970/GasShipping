using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GasShipping.Model;

namespace GasShipping.DataAgent
{
    public class CustomerFactory
    {
        public List<Customers> Customers { get; set; }
        private FileAgent _fileAgent;

        public CustomerFactory(List<Customers> customers)
        {
            Customers = customers;
            _fileAgent = new FileAgent(Constants.CUSTOMER_FILE_NAME, Constants.PATH);
        }
        public CustomerFactory()
        {
            Customers=new List<Customers>();
            _fileAgent = new FileAgent(Constants.CUSTOMER_FILE_NAME, Constants.PATH);
        }

        public string SetCustomersToJSONString()
        {
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<List<Customers>>(Customers, opt);
        }
        public string SetCustomersToJSONString(List<Customers> customers)
        {
            if (customers is null)
            {
                customers = Customers;
            }

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<List<Customers>>(customers, opt);
        }
        public List<Customers> GetShipsFromJSONString(string JSONstring) => JsonSerializer.Deserialize<List<Customers>>(JSONstring);
        public void AddCustomers(Customers customers) => Customers.Add(customers);
        public void RemoveCustomers(Customers customers)
        {
            if (customers is null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            Customers.Remove(customers);
        }
        public List<Customers> GetCustomersFromFile()
        {
            var jsonString = _fileAgent.ReadFile();
            Customers.Clear();
            Customers.AddRange(GetShipsFromJSONString(jsonString));
            return Customers;
        }
    }
}
