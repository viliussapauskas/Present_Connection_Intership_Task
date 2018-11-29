using System;
using System.Collections.Generic;
using System.Text;

namespace Intership_Task
{
    public class CountryList
    {
        public List<Country> data;


        public double returnExactRate(string name)
        {

            foreach (var country in data)
            {
                if (country.name == name)
                {
                    return country.rates;
                }
            }
            return -1;
        }

    }
}
