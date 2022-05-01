using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace GasShipping.DataAgent
{
    /// <summary>This class holds all the constants for this project</summary>
    public static class Constants
    {
        ///// <summary>costumer c50 file name constant</summary>
        //public const string CUSTOMER_FILE_NAME_C50 = "c50_customers.json";
        ///// <summary>The c75 customer file name</summary>
        //public const string CUSTOMER_FILE_NAME_C75 = "c75_customers.json";
        ///// <summary>The c100 customer file name</summary>
        //public const string CUSTOMER_FILE_NAME_C100 = "c100_customers.json";
        ///// <summary>ships c50 file name constant</summary>
        //public const string SHIPS_FILE_NAME_C50 = "c50_ships.json";
        ///// <summary>ships c75 file name constant</summary>
        //public const string SHIPS_FILE_NAME_C75 = "c75_ships.json";
        ///// <summary>ships c100 file name constant</summary>
        //public const string SHIPS_FILE_NAME_C100 = "c100_ships.json";
        ///// <summary>directory path  constant</summary>
        //public const string PATH = @"C:\Users\binma\source\repos\GasShipping\Datasets\JsonFormat\";
        // Environment.CurrentDirectory;//Directory.GetCurrentDirectory();


        /// <summary>costumer c50 file name constant</summary>
        public static  string CUSTOMER_FILE_NAME_C50 = ConfigurationManager.AppSettings.Get("C50Cust").ToString();
        /// <summary>The c75 customer file name</summary>
        public static string CUSTOMER_FILE_NAME_C75 =  ConfigurationManager.AppSettings.Get("C75Cust").ToString();
        /// <summary>The c100 customer file name</summary>
        public static string CUSTOMER_FILE_NAME_C100 = ConfigurationManager.AppSettings.Get("C100Cust").ToString();
        /// <summary>ships c50 file name constant</summary>
        public static string SHIPS_FILE_NAME_C50 = ConfigurationManager.AppSettings.Get("C50Ship").ToString();
        /// <summary>ships c75 file name constant</summary>
        public static string SHIPS_FILE_NAME_C75 = ConfigurationManager.AppSettings.Get("C75Ship").ToString();
        /// <summary>ships c100 file name constant</summary>
        public static string SHIPS_FILE_NAME_C100 = ConfigurationManager.AppSettings.Get("C100Ship").ToString();
        /// <summary>directory path  constant</summary>
        public static string PATH = ConfigurationManager.AppSettings.Get("PATH").ToString();



    }
}
