using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ObjectsNameSpace;

namespace GenericObjects
{
    public class nameList
    {
        public List<string> beginning = new List<string>(new string[] { "Yum", "Yummy ", "Edible-" });
        public List<string> ending = new List<string>(new string[] { "Yum", "Food ", "Steaks", "MEAT!", "Greens" });
        public List<string> first = new List<string>(new string[] { "Yumi", "Fred ", "Steve", "Meat", "Grodon", "James" });
        public List<string> last = new List<string>(new string[] { "Ysolda", "Jood ", "Steakson", "Meatingsmith!", "Green", "Apparently" });
    }


    public class ObjCollector<T> : ICollection
    {
        private ArrayList objCollect = new ArrayList();

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
        public void SerializeCollection(string filename)
        {
            ObjCollector<O> OCollection = new ObjCollector<O>();
            XmlSerializer xmlSerial = new XmlSerializer(typeof(ObjCollector<O>));
            TextWriter writer = new StreamWriter(filename);
            xmlSerial.Serialize(writer, OCollection);
        }
    }

    public class Superconstructor
    {     

        public Superconstructor(ref ObjCollector<Review> reviewCollection, ref ObjCollector<Restaurant> resterauntsCollection)
            {
            nameList Names = new nameList();
            Review tReview = new Review();
            Restaurant tRestaurant = new Restaurant();
            for(int i = 0; i < Names.beginning.Count; i++)
            {
                for (int o = 0; o < Names.ending.Count; o++)
                {
                    tRestaurant = new Restaurant((Names.beginning[i] + Names.ending[o]), "Texas");
                    resterauntsCollection.Add(tRestaurant);
                }
            }

            for (int i = 0; i < Names.first.Count; i++)
            {
                for (int o = 0; o < Names.last.Count; o++)
                {
                    tReview = new Review("To do", resterauntsCollection[(i+o)%(Names.beginning.Count
                        +Names.ending.Count)].IDnumber, i+o, (Names.first[i] + Names.last[o]));
                    reviewCollection.Add(tReview);
                }
            }

            }
    }

    public class Tester
    {
        string file1 = "ReviewXML.xml";
        string file2 = "RestaurantXML.xml";
        objSerializer<Review> reviewSerializer = new objSerializer<Review>();
        objSerializer<Restaurant> restaurantSerializer = new objSerializer<Restaurant>();

        //reviewSerializer.SerializeCollection(file1);
        //restaurantSerializer.SerializeCollection(file2);
    }
}
