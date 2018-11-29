using Intership_Task;
using NUnit.Framework;

namespace Intership_task.tests
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void returnCostWithVAT()
        {

            Order order = new Order("Puslapis", 200);
            Assert.AreEqual(200, order.returnCostWithVAT());
            order.rate_VAT = 21;
            Assert.AreEqual(242, order.returnCostWithVAT());

        }
        [Test]
        public void CalculateVAT()
        {
            Order order = new Order("Puslapis", 200);
            Assert.AreEqual(0, order.CalculateVAT());
        }
    }

}
