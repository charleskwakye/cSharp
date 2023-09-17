using Bank;

namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor_Balance0_Returns0()
        {
            //ARANGE
            Account account = new Account();
            //ACT
            double balance = account.Balance;
            //ASSERT
            Assert.AreEqual(0, balance, "HAHHAH Failure!!!!");
        }

        [TestMethod]
        public void Credit999OnBalance0_Returns999()
        {
            //ARANGE
            Account account = new Account();
            //ACT
            account.Credit(999);
            //ASSERT
            Assert.AreEqual(999, account.Balance, "HAHHAH Failure Again!!!!");
        }


        [TestMethod]
        public void Credit_NegativeAmount_ReturnsOutOfRangeException()
        {
            //ARANGE
            Account account = new Account();

            //ASSERT
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Credit(-200));
        }

        [TestMethod]
        public void Debit_500FromBalance500_Returns0()
        {
            //ARANGE
            Account account = new Account();
            //ACT
            account.Credit(500);
            account.Debit(500);
            //ASSERT
            Assert.AreEqual(0, account.Balance, "HAHHAH Failure Again and Again!!!!");
        }


        [TestMethod]
        public void Debit_AmountBiggerThanBalance_ThrowsBalanceInsufficientException()
        {
            //ARANGE
            Account account = new Account();
            //ACT
            account.Credit(200);

            //ASSERT
            Assert.ThrowsException<BalanceInsufficientException>(() => account.Debit(300));
        }
    }
}