using NUnit.Framework;

namespace UnitTestingTest
{
    public class FirstTest
    {
        [Test]
        public void Test1()
        {
            int result = 1 + 6;
            Assert.That(result, Is.EqualTo(5), "Error");
        }

        [Test]
        public void Test2()
        {
            int result = 1 + 6;
            Assert.That(result, Is.EqualTo(7), "Correct");
        }
    }
}