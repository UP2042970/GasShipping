using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GasShipping.Model;

namespace GasShipping.DataAgent
{
    /// <summary>  This class is for creating a list of customers from a JSON string or create
    ///  a JSON from a list of customers</summary>
    public class CustomerFactory
    {

        /// <summary>Gets or sets the List&lt;Customers&gt; customers.</summary>
        /// <value>The customers.</value>
        public List<Customers> Customers { get; set; }
        /// <summary>The file agent</summary>
        private FileAgent _fileAgent;

        /// <summary>Initializes a new instance of the <see cref="CustomerFactory" /> class.</summary>
        /// <param name="customers">The customers.</param>
        public CustomerFactory(List<Customers> customers)
        {
            Customers = customers;
            _fileAgent = new FileAgent(Constants.CUSTOMER_FILE_NAME_C50, Constants.PATH);
        }

        /// <summary>Initializes a new instance of the <see cref="CustomerFactory" /> class.</summary>
        public CustomerFactory()
        {
            Customers=new List<Customers>();
            _fileAgent = new FileAgent(Constants.CUSTOMER_FILE_NAME_C50, Constants.PATH);
        }

        /// <summary>Initializes a new instance of the <see cref="CustomerFactory" /> class.</summary>
        /// <param name="fileAgent">The file agent.</param>
        public CustomerFactory(FileAgent fileAgent)
        {
            Customers = new List<Customers>();
            _fileAgent = fileAgent;
        }
        /// <summary>This method converts List of Customers to JSON string</summary>
        /// <returns>string</returns>
        public string SetCustomersToJSONString()
        {
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<List<Customers>>(Customers, opt);
        }

        /// <summary>This method converts List of Customers to JSON string</summary>
        /// <param name="customers">The list of customers.</param>
        /// <returns>JSON string</returns>
        public string SetCustomersToJSONString(List<Customers> customers)
        {
            if (customers is null)
            {
                customers = Customers;
            }

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize<List<Customers>>(customers, opt);
        }

        /// <summary>This method converts JSON string to List of Customers</summary>
        /// <param name="JSONstring">The JSON string.</param>
        /// <returns>List of Customers</returns>
        public List<Customers> GetShipsFromJSONString(string JSONstring) => JsonSerializer.Deserialize<List<Customers>>(JSONstring);
        /// <summary>This method will add a customer to the List&lt;Customers&gt;</summary>
        /// <param name="customer">Customers</param>
        public void AddCustomer(Customers customer) => Customers.Add(customer);
        /// <summary>This method will remove the customer from the List&lt;Customers&gt;</summary>
        /// <param name="customer"></param>
        /// <exception cref="ArgumentNullException"> if the customer is null</exception>
        public void RemoveCustomer(Customers customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            Customers.Remove(customer);
        }
        /// <summary>This method will read a JSON file then will convert it to list of Customers</summary>
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
