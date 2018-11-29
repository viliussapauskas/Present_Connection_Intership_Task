using System;
using System.Collections.Generic;
using System.Text;

namespace Intership_Task
{
    public class Country
    {
        public string name { get; set; }
        public double rates { get; set; }
        public bool isInEurope { get; set; }

        public Country(string name, double rates)
        {
            this.name = name;
            this.rates = rates;
        }
    }
}
