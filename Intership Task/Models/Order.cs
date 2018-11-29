using System;
using System.Collections.Generic;
using System.Text;

namespace Intership_Task
{
    public class Order
    {
        Partner customer { get; set; }
        Partner vendor { get; set; }
        public string item { get; set; }
        double cost { get; set; }
        public double rate_VAT { get; set; }

        public Order(string item, double cost)
        {
            this.customer = null;
            this.vendor = null;
            this.rate_VAT = 0;
            this.item = item;
            this.cost = cost;
        }

        public void getfullOrder(Partner customer, Partner vendor)
        {
            this.customer = customer;
            this.vendor = vendor;
        }

        public double ReturnRateVAT()
        {
            return this.rate_VAT;
        }
        public double returnCostWithVAT()
        {
            return this.cost + this.CalculateVAT();
        }
        public double returnCostWithoutVAT()
        {
            return this.cost;
        }
        public void addRateVAT(double rate)
        {
            this.rate_VAT = rate;
        }
        public double CalculateVAT()
        {
            if (this.rate_VAT == 0)
            {
                return 0;
            }
            else if (this.rate_VAT > 0)
            {
                return (this.cost * this.rate_VAT / 100);
            }
            else return 0;
        }


        public override string ToString()
        {
            return String.Format("|Prekės pavadinimas: {0,-19} |\n" +
                                 "|Kaina be PVM: {1,-25} |\n" +
                                 "|PVM Tarifas (%): {2,-23}|\n" +
                                 "|PVM suma: {3,-30}|\n" +
                                 "|Kaina su PVM mokęsčiu: {4,-17}|\n", this.item, this.cost, this.ReturnRateVAT(), this.CalculateVAT(), this.returnCostWithVAT()).ToString();
        }
    }
}
