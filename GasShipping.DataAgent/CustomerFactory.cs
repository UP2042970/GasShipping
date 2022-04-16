using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GasShipping.Model;

namespace GasShipping.DataAgent
{/// <summary>
///  this class is for creating a list of customers from a JSON string or create
///  a JSON from a list of customers
/// </summary>
    public class CustomerFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Customers> Customers { get; set; }
        private FileAgent _fileAgent;
        /// <summary>
        /// Cunstrctor for CustomerFactory
        /// </summary>
        /// <param name="customers">List&lt;Customers&gt;</param>
        public CustomerFactory(List<Customers> customers)
        {
            Customers = customers;
            _fileAgent = new FileAgent(Constants.CUSTOMER_FILE_NAME, Constants.PATH);
        }
        /// <summary>
        /// Cunstrctor for CustomerFactory
        /// </summary>
        public CustomerFactory()
        {
            Customers=new List<Customers>();
            _fileAgent = new FileAgent(Constants.CUSTOMER_FILE_NAME, Constants.PATH);
        }
        /// <summary>
        /// Cunstrctor for CustomerFactory
        /// </summary>
        /// <param name="fileAgent">FileAgent</param>
        public CustomerFactory(FileAgent fileAgent)
        {
            Customers = new List<Customers>();
            _fileAgent = fileAgent;
        }
        /// <summary>
        /// This method converts List of Customers to JSON string
        /// </summary>
        /// <returns>string</returns>
        public string SetCustomersToJSONString()
        {
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<List<Customers>>(Customers, opt);
        }/// <summary>
         /// This method converts List of Customers to JSON string
         /// </summary>
         /// <param name="customers">List&lt;Customers&gt;</param>
         /// <returns></returns>
        public string SetCustomersToJSONString(List<Customers> customers)
        {
            if (customers is null)
            {
                customers = Customers;
            }

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<List<Customers>>(customers, opt);
        }
        /// <summary>
        /// This method converts JSON string to List of Customers 
        /// </summary>
        /// <param name="JSONstring">string</param>
        /// <returns>List&lt;Customers&gt;</returns>
        public List<Customers> GetShipsFromJSONString(string JSONstring) => JsonSerializer.Deserialize<List<Customers>>(JSONstring);
        /// <summary>
        /// This method will add a customer to the List&lt;Customers&gt;
        /// </summary>
        /// <param name="customer">Customers</param>
        public void AddCustomer(Customers customer) => Customers.Add(customer);
        /// <summary>
        /// This method will remove the customer from the List&lt;Customers&gt;
        /// </summary>
        /// <param name="customer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RemoveCustomer(Customers customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            Customers.Remove(customer);
        }
        /// <summary>
        ///  This method will read a JSON file then will convert it to list of Customers
        /// </summary>
        /// <returns>List&lt;Customers&gt;</returns>
        public List<Customers> GetCustomersFromFile()
        {
            var jsonString = _fileAgent.ReadFile();
            Customers.Clear();
            Customers.AddRange(GetShipsFromJSONString(jsonString));
            return Customers;
        }
    }
}
