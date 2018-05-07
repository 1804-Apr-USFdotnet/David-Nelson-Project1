using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
//using RRObjects;
using LibraryLogic;
using DBEntity;

namespace GObjects
{

    public class nameList
    {
        public List<string> beginning = new List<string>(new string[] { "Yum", "Yummy ", "Edible-" });
        public List<string> ending = new List<string>(new string[] { "Yum", "Food ", "Steaks", "MEAT!", "Greens" });
        public List<string> first = new List<string>(new string[] { "Yobo", "Yumi", "Fred ", "Steve", "Meat", "Grodon", "James" });
        public List<string> last = new List<string>(new string[] { "Ysolda", "Jood ", "Steakson", "Meatingsmith!", "Green", "Apparently" });
    }

    public class ObjCollector<T> : ICollection
    {
        public ArrayList objCollect = new ArrayList();

        public void setList(ArrayList newArr)
        {
            objCollect = newArr;
        }

        public ArrayList getList()
        {

            return (ArrayList)objCollect.Clone();
        }

        public T this[int index]
        {
            get { return (T)objCollect[index]; }
        }
        public int Count
        {
            get { return objCollect.Count; }
        }

        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public IEnumerator GetEnumerator()
        {
            return objCollect.GetEnumerator();
        }

        public void Add(T newObj)
        {
            objCollect.Add(newObj);
        }

        public void CopyTo(Array array, int index)
        {
            objCollect.CopyTo(array, index);
        }
    }

    public class objSerializer<O>
    {
        public void SerializeCollection(string filename, ObjCollector<O> OCollection)
        {
            XmlSerializer xmlSerial = new XmlSerializer(typeof(ObjCollector<O>));
            TextWriter writer = new StreamWriter(filename);
            xmlSerial.Serialize(writer, OCollection);
        }

        public ObjCollector<O> DeserializeCollection(string filename, ObjCollector<O> OCollection)
        {
            XmlSerializer xmlSerial = new XmlSerializer(typeof(ObjCollector<O>));
            TextReader reader = new StreamReader(filename);
            OCollection = (ObjCollector < O >)xmlSerial.Deserialize(reader);
            return OCollection;
        }
    }

    ////Outdated Method that would populate the Review and Restaurant Lists, used for tests
    public class Superconstructor
    {

        public Superconstructor(ArrayList reviewArr, ArrayList restaurantsArr)
        {
            nameList Names = new nameList();
            Review tReview = new Review();
            Restaurant tRestaurant = new Restaurant();
            for (int i = 0; i < Names.beginning.Count; i++)
            {
                for (int o = 0; o < Names.ending.Count; o++)
                {
                    tRestaurant = new Restaurant();
                    tRestaurant.Name = (Names.beginning[i] + Names.ending[o]);
                    tRestaurant.Location = ("Nowhere");
                    tRestaurant.ID = restaurantsArr.Count;
                    restaurantsArr.Add(tRestaurant);
                }
            }

            for (int i = 0; i < Names.first.Count; i++)
            {
                for (int o = 0; o < Names.last.Count; o++)
                {
                    tReview = new Review();
                    tReview.Name = (Names.beginning[i] + Names.ending[o]);
                    tReview.RestaurantID = (i+(o*Names.last.Count))%restaurantsArr.Count;
                    tReview.Rating = (i + o) % 10 + 1;
                    tReview.ID = reviewArr.Count;
                    reviewArr.Add(tReview);
                }
            }
        }
    }

    public class Tester
    {
        string file1 = "ReviewXML.xml";
        string file2 = "RestaurantXML.xml";
        ObjCollector<Review> ReviewCollection = new ObjCollector<Review>();
        ObjCollector<Restaurant> RestaurantCollection = new ObjCollector<Restaurant>();
        objSerializer<Review> reviewSerializer = new objSerializer<Review>();
        objSerializer<Restaurant> restaurantSerializer = new objSerializer<Restaurant>();
        Library Library = new Library();
        DataAccess access = new DataAccess();
        public Tester ()
        {

            //reviewSerializer.DeserializeCollection("ReviewXML.xml", ReviewCollection);
            //restaurantSerializer.DeserializeCollection("RestaurantXML.xml", RestaurantCollection);

            RestaurantCollection.setList(access.getRestaurants());
            ReviewCollection.setList(access.getReviews());

            Console.WriteLine("*Top Three*");
            Library.TopThree(ReviewCollection.getList(), RestaurantCollection.getList());

            Console.WriteLine("*Display All (Name Sort)*");
            Library.DisplayAll(RestaurantCollection.getList(),1);

            Console.WriteLine("*Display All (ID Sort)*");
            Library.DisplayAll(RestaurantCollection.getList(), 1);

            Console.WriteLine("*Display Reviews (index 2)*");
            Library.DisplayReviews(ReviewCollection.getList(), RestaurantCollection[1]);

            Console.WriteLine("*Search for 'Nach'*");
            Library.SearchRestaurants(RestaurantCollection.getList(), "nach");

            Console.WriteLine("*Average rating of index 3*");
            Console.WriteLine(RestaurantCollection[2].Name + ": AvgRating: "
                + Library.AverageRating(ReviewCollection.getList(), RestaurantCollection[2]));

            Console.WriteLine("*Qutting Application*");
            Library.QuitApp();

            //reviewSerializer.SerializeCollection(file1, ReviewCollection);
            //restaurantSerializer.SerializeCollection(file2, RestaurantCollection);
        }



    }


}
