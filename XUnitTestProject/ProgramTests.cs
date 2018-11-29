using Intership_Task;
using NUnit.Framework;

namespace ProgramTest
{

    [TestFixture]
    class ProgramTests
    {

        [Test]
        public void isFromSameCountry()
        {
            Program program = new Program();
            Partner vendor = new Partner("Vilius", true, true, "Lithuania", "adresas");
            Partner customer = new Partner("Vilius", true, true, "Lithuania", "adresas");
            Assert.AreEqual(true, program.isFromSameCountry(vendor, customer));
            customer.country = "USA";
            Assert.AreEqual(false, program.isFromSameCountry(vendor, customer));
        }
        [Test]
        public void doesCountryExist()
        {


        }
    }
}
