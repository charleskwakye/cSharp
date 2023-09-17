using Kata;
namespace KataTest
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void Add_Empty_Equals0()
        {
            //ARRANGE
            StringCalculator stringcalculator = new StringCalculator();
            //ACT
            int result = stringcalculator.add("");
            //ASSERT
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_SingleNumber_ReturnsSingleNumber()
        {
            //ARRANGE
            StringCalculator stringcalculator = new StringCalculator();
            //ACT
            int result = stringcalculator.add("1,2,3,1005");
            //ASSERT
            Assert.AreEqual(6, result);
        }
    }
}