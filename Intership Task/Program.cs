using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Intership_Task
{
    public class Program
    {
        const string COUNTRIES_DATA = @"..\\..\\..\\Data\\countries.json";
        const string CUSTOMERS_DATA_JSON = @"..\\..\\..\\Data\\customers.json";
        const string VENDORS_DATA_JSON = @"..\\..\\..\\Data\\vendors.json";
        const string OUTPUT_INVOICE = @"..\\..\\..\\Invoice.txt";
        const string ORDERS_DATA_JSON = @"..\\..\\..\\Data\\orders.json";

        static CountryList countryList;
        static PartnerList customerList;
        static PartnerList vendorsList;
        static OrderList ordersList;

        static Partner customer;
        static Partner vendor;
        static Order order;
        static void Main(string[] args)
        {
            new Program().ProgramBegin();
        }
        public CountryList getListForTest()
        {
            return countryList;
        }

        void DataManager()
        {
            string countriesContent = File.ReadAllText(COUNTRIES_DATA);
            string customersContent = File.ReadAllText(CUSTOMERS_DATA_JSON);
            string vendorsContent = File.ReadAllText(VENDORS_DATA_JSON);
            string ordersContent = File.ReadAllText(ORDERS_DATA_JSON);

            countryList = (CountryList)JsonConvert.DeserializeObject(countriesContent, typeof(CountryList));
            customerList = (PartnerList)JsonConvert.DeserializeObject(customersContent, typeof(PartnerList));
            vendorsList = (PartnerList)JsonConvert.DeserializeObject(vendorsContent, typeof(PartnerList));
            ordersList = (OrderList)JsonConvert.DeserializeObject(ordersContent, typeof(OrderList));
            // Changing data with array value
            customer = customerList.data[2];
            vendor = vendorsList.data[2];
            order = ordersList.data[2];

            order.getfullOrder(customer, vendor);
        }

        void PrintData()
        {
            if (File.Exists(OUTPUT_INVOICE))
                File.Delete(OUTPUT_INVOICE);
            if (order.ReturnRateVAT() >= 0)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(OUTPUT_INVOICE))
                {
                    file.WriteLine("        SASKAITA FAKTURA");
                    file.WriteLine();
                    file.WriteLine("        Kliento duomenys");
                    file.WriteLine(customer.ToString());
                    file.WriteLine();
                    file.WriteLine("        Pardavėjo duomenys");
                    file.WriteLine(vendor.ToString());
                    file.WriteLine();
                    file.WriteLine("        Sutarties duomenys");
                    file.WriteLine(order.ToString());
                }
                Console.Write("Date writing is completed >> Invoice.txt");
                Console.WriteLine("You can change data in data's folder and select other examples at DataManager method");
            }
            else Console.WriteLine("Tokios valstybės duomenu faile nėra arba įvedėte klaidingą pavadinimą.Patikrinkite pirkėjo ir gamintojo duomenis");
        }

        void ProgramBegin()
        {
            DataManager();
            order.addRateVAT(returnRates(vendor, customer));
            PrintData();
        }
        public bool doesCountryExist(CountryList countryList, Partner partner)
        {
            foreach (var country in countryList.data)
            {

                if (country.name == partner.country)
                {
                    partner.isInEurope = country.isInEurope;
                    return true;
                }
            }
            return false;
        }
        public double returnRates(Partner Vendor, Partner Customer)
        {

            if (doesCountryExist(countryList, vendor) &&
                doesCountryExist(countryList, customer))
            {
                if (!Vendor.isVATPayer)
                {
                    return 0;
                }
                else if (isFromSameCountry(Vendor, Customer))
                {
                    return (countryList.returnExactRate(Vendor.country));
                }
                else
                {
                    if (!Customer.isInEurope)
                    {
                        return 0;
                    }
                    else if (Customer.isInEurope && !Customer.isVATPayer)
                    {

                        return (countryList.returnExactRate(Customer.country));
                    }
                    else if (Customer.isInEurope && Customer.isVATPayer)
                    {
                        return 0;
                    }
                    return 0;
                }
            }
            else return -1;
        }

        public bool isFromSameCountry(Partner Vendor, Partner Customer)
        {
            if (Vendor.country == Customer.country)
            {
                return true;
            }
            else return false;
        }
    }
}