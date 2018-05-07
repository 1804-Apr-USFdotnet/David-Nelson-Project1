using System;

namespace ObjectsNameSpace
{

    public abstract class Object
    {
        protected const int digits = 5;//Set # of digits that the ID# Contain
        public string Name { get; set; }//Name of Reviewer or Restaurant
        public String IDnumber { get; set; }// Unique Identifier
    }

    public class Restaurant : Object
    {
        static int tracker = 0;//Ensures all Restaurants have a Unique Id#
        public string Location { get; set; }// Location of building
        public Restaurant() { }
        public Restaurant(string name, string location)
        {
            this.Name = name;
            IDnumber = tracker.ToString();
            while (digits > IDnumber.Length)
                IDnumber = "0" + IDnumber;
            tracker++;
        }

    }

    public class Review : Object
    {
        static int tracker = 0;//Ensures all Reviews have a Unique Id#
        public Review() { }
        public Review(string text, string restaurantID, double rating, string name)
        {
            this.text = text;
            this.restaurantID = restaurantID;
            this.rating = rating;
            this.Name = name;
            IDnumber = tracker.ToString();
            while (digits > IDnumber.Length)
                IDnumber = "0" + IDnumber;
            tracker++;

        }
        public string text { get; set; }// Body of Review
        public string restaurantID { get; set; }//RestaurantId #
        public double rating { get; set; }// Rating of Restaurant given by reviewer
    }


}
