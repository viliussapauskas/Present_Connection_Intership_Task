using System;
using System.Collections.Generic;
using System.Text;

namespace Intership_Task
{
    public class Partner
    {
        public string name { get; set; }
        public bool isVATPayer { get; set; }
        public bool isInEurope { get; set; }
        public string country { get; set; }
        public string address { get; set; }


        public Partner(string name, bool isVATPayer, bool isInEurope, string country, string address)
        {
            this.name = name;
            this.isVATPayer = isVATPayer;
            this.isInEurope = isInEurope;
            this.country = country;
            this.address = address;
        }


        public override string ToString()
        {
            return String.Format("|*Pavadinimas: {0,-25} | \n|*Valstybė: {1,-28} |\n|*Adresas: {2,-30}|\n", this.name, this.country, this.address).ToString();
        }
    }
}
