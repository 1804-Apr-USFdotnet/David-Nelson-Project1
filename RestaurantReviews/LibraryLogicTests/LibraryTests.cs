using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntity;
using GObjects;
using System.Collections;
using System.IO;

namespace LibraryLogic.Tests
{
    [TestClass()]
    public class LibraryTests
    {
        [TestMethod()]
        public void LibraryTest()
        {
            Library library = new Library();
            Assert.IsNotNull(library);
        }

        [TestMethod()]
        public void AverageRatingTest()
        {
            Library test = new Library();
            int numReviews = 17;
            Restaurant testRest = new Restaurant();
            Review testRev = new Review();
            ArrayList reviewArr = new ArrayList();
            double expected = 0, actual;
            testRest.ID = 2;

            //Console.Write("Expected: ");
            for (int i = 0; i < numReviews; i++)
            {
                testRev = new Review();
                testRev.Rating = (i % 10) + 1;
                testRev.RestaurantID = (i % 5) + 1;
                reviewArr.Add(testRev);
                if (testRev.RestaurantID == testRest.ID)
                {
                    //Console.Write(testRev.Rating + " + ");
                    expected += ((double)testRev.Rating);
                }
            }
            //Console.Write("\n\n");
            expected /= 4;

            actual = test.AverageRating(reviewArr, testRest);
            Console.WriteLine("Expected: " + expected + ", Actual: " + actual);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AverageRatingTestEmpty()
        {
            Library test = new Library();
            Restaurant testRest = new Restaurant();
            Review testRev = new Review();
            ArrayList reviewArr = new ArrayList();
            double expected = 0, actual;
            testRest.ID = 2;

            actual = test.AverageRating(reviewArr, testRest);

            Assert.AreEqual(expected, actual);

        }




        [TestMethod()]
        public void TopThreeTest()
        {
            Library test = new Library();
            ArrayList revArr = new ArrayList(), restArr = new ArrayList(), actual = new ArrayList();
            Review tempRev = new Review();
            Restaurant tempRest = new Restaurant();
            int numRev = 17, numRest = 5, high = 0;
            double[] highest = new double[numRest];



            for (int i = 0; i < numRest; i++)
            {
                tempRest.ID = i + 1;
                tempRest.Name = "Test#" + i + 1;
                tempRest.Location = "Area#" + i + 1;
                restArr.Add(tempRest);
            }

            for (int i = 0; i < numRev; i++)
            {
                tempRev.Rating = (i + 1) % 10;
                tempRev.RestaurantID = (i + 1) % numRest;
                revArr.Add(tempRev);
            }

            for (int i = 0; i < restArr.Count; i++)
            {
                highest[i] = test.AverageRating(revArr, ((Restaurant)restArr[i]));
            }
            for (int o = 0; o < 3; o++)
            {
                for (int i = 0; i < restArr.Count; i++)
                {
                    if (highest[high] < highest[i])
                        high = i;
                }
                actual.Add(restArr[high]);
                highest[high] = -1;
            }

            restArr = test.TopThree(revArr, restArr);
            if (restArr.Count != 3)
                Assert.Fail();
            for (int i = 0; i < 3; i++)
            {
                if (((Restaurant)restArr[i]).ID != ((Restaurant)actual[i]).ID)
                    Assert.Fail();
            }
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void DisplayAllTest()
        {
            Library test = new Library();
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            ArrayList restArr = new ArrayList();
            Restaurant tempRest = new Restaurant();
            for (int i = 0; i < 10; i++)
            {
                tempRest.ID = i + 1;
                tempRest.Name = "Test#" + (i + 1);
                tempRest.Location = "Area#" + (i + 1);
                restArr.Add(tempRest);
            }

            test.DisplayAll(restArr, 0);
            Assert.IsNotNull(stringWriter);
        }

        [TestMethod()]
        public void DisplayReviewsTest()
        {
            Library test = new Library();
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            ArrayList restArr = new ArrayList();
            ArrayList revArr = new ArrayList();
            Restaurant tempRest = new Restaurant();
            Review tempRev = new Review();
            for (int i = 0; i < 10; i++)
            {
                tempRest.ID = i + 1;
                tempRest.Name = "Test#" + (i + 1);
                tempRest.Location = "Area#" + (i + 1);
                restArr.Add(tempRest);
            }
            for (int i = 0; i < 17; i++)
            {
                tempRev.Rating = (i + 1) % 10;
                tempRev.RestaurantID = (i + 1) % 10;
                revArr.Add(tempRev);
            }
            
            test.DisplayReviews(revArr,((Restaurant)restArr[5]));
            Assert.IsNotNull(stringWriter);
        }

        [TestMethod()]
        public void SearchRestaurantsTest()
        {
            Library test = new Library();
            ArrayList restArr = new ArrayList(), expected = new ArrayList();
            Restaurant tempRest = new Restaurant();

            for (int i = 0; i < 10; i++)
            {
                tempRest = new Restaurant();
                tempRest.ID = i + 1;
                tempRest.Name = "Test#" + (i + 1);
                tempRest.Location = "Area#" +( i + 1);
                restArr.Add(tempRest);
            }
            Console.WriteLine("Test#" + (9 + 1));
            expected.Add(tempRest);
            restArr = test.SearchRestaurants(restArr, "0");

            Assert.AreEqual(expected.Count, restArr.Count);
        }

        [TestMethod()]
        public void QuitAppTest()
        {
            Library library = new Library();
            //library.QuitApp();
            Assert.IsNotNull(library);
        }
    }
}