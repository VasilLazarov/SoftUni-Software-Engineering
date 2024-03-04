namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        //Valid cases
        [TestCase(new int[] {})]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstructorShouldInitializeData_WithCorrectlyCount(int[] data)
        {
            //Arrange
            
            //Act
            Database db = new Database(data);

            //Assert
            int expectedCount = data.Length;
            int actualCount = db.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void Test_ConstructorShouldThrowException_WhenInputArrayIsWithAbove116Elements(int[] data)
        {
           Assert.Throws<InvalidOperationException>(() =>
           {
               Database db = new Database(data);
           }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstructorShouldAddElements_IntroDataField(int[] data)
        {
            Database db = new Database(data);

            int[] expectedData = data;
            int[] actualData = db.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }


        [Test]
        public void Test_AddingElementsShouldIncreaseCount()
        {
            int expectedCount = 5;
        
            for (int i = 1; i <= expectedCount; i++)
            {
                database.Add(i);
            }

            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_AddingElementsShouldAddThemToTheDataField()
        {
            int[] expectedData = new int[5];

            for (int i = 1; i <= 5; i++)
            {
                database.Add(i);
                expectedData[i - 1] = i;
            }

            int[] actualData = database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }


        [Test]
        public void Test_AddingElementsShouldThrowException_WhenAddingMoreThan16Elements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i <= 17; i++)
                {
                    database.Add(i);
                }
            }, "Array's capacity must be exactly 16 integers!");
        }


        [Test]
        public void Test_RemovingElementsShouldDecreaseCount()
        {
            int initialCount = 5;

            for (int i = 1; i <= initialCount; i++)
            {
                database.Add(i);
            }
            int removeCount = 2;
            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }
            int expectedCount = initialCount - removeCount;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }


        [Test]
        public void Test_RemovingElementsShouldRemoveThemFromTheDataField()
        {
            int initialCount = 5;

            for (int i = 1; i <= initialCount; i++)
            {
                database.Add(i);
            }
            int removeCount = 2;
            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }
            int[] expectedData = new int[] { 1, 2, 3 };
            int[] actualData = database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }


        [Test]
        public void Test_RemovingElementsShouldThrowException_WhenThereAreNoElementsInDataField()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                    database.Remove();

            }, "The collection is empty!");
        }


        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_FetchShouldReturnSameCollectionAsFieldData(int[] data)
        {
            Database db = new Database(data);

            int[] expectedData = data;
            int[] actualData = db.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}
