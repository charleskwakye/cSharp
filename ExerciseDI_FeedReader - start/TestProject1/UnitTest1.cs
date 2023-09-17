using ExerciseDI_FeedReader;
using Moq;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            [TestMethod]
            public void Test_IFeedReader_GetSingleFeed()
            {
                // Order retrieves its dependency via the constructor
                // We can mock it and change its behavior for this test
                var mediumSender = new Mock<IFeedReader>();
                // The following code simulates the execution of the Contact() method and returns a value that we choose
                mediumSender.Setup(e => e.GetSingleFeed());

                FeedService feedService = new FeedService(mediumSender.Object);

                // Test the price
                Assert.AreEqual(50.99, response.TotalPrice);
                // Test the response (contact message) we setup using the mock
                Assert.AreEqual("A test message for this wonderful test", response.ContactMessage);
            }
        }
    }
}