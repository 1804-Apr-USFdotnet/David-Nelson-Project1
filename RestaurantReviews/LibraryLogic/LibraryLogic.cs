using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntity;


namespace LibraryLogic
{
    public class Library
    {
        private DataAccess Context;
        //Obsolete Code
        //List<Review> reviews = new List<Review>();
        //List<Restaurant> restaurants = new List<Restaurant>();

        //Library(int reviewers, int inputrestaurants)
        //{
        //    for (int i = 0; i < reviewers; i++)
        //    {
        //        reviews.Add(new Review());
        //    }

        //    for (int i = 0; i < inputrestaurants; i++)
        //    {
        //        restaurants.Add(new Restaurant());
        //    }

        public Library()
        {
            Context = new DataAccess();
        }

        public List<Review> ReturnReview()
        {
            return Context.getReviewsList();
        }

        public ArrayList ReturnRestaurant()
        {
            return Context.getRestaurants();
        }


        public double AverageRating(ArrayList reviews, Restaurant b)
        {
            //Console.WriteLine("Average for #" + b.ID);
            int qauntity = 0;
            double sum = 0;
            double average;
            foreach (Review element in reviews)
            {
                //Console.Write("Review for #" + element.RestaurantID);
                if (b.ID == element.RestaurantID)
                {
                    //Console.Write(element.Rating + " + ");
                    sum += (int)element.Rating;
                    qauntity++;
                }
            }
            //if (qauntity == 0)
            //    Console.Write("= Sum: " + sum + "/ Qauntity: " + qauntity + "= Div by Zero \n");
            //else
            //    Console.Write("= Sum: " + sum + "/ Qauntity: " + qauntity + "= Avg: " + sum / qauntity + "\n");
            if (qauntity == 0)
                return 0;
            average = sum / qauntity;

            return average;
        }

        public ArrayList TopThree(ArrayList reviewList, ArrayList restaurantList)
        { // top what restrants
            int topX = 3, sum;
            double[] tempaverage = new double[restaurantList.Count];
            int[] highest = new int[topX];
            ArrayList restList = new ArrayList();

            if (topX > restaurantList.Count)
                topX = restaurantList.Count;

            //Sums and averages every restaurants individial ratings in a Double Array with corresponding index
            for (int i = 0; i < restaurantList.Count; i++)
            {
                sum = 0;
                tempaverage[i] = 0;
                foreach (var segment in reviewList)
                {
                    if (((Review)segment).RestaurantID == ((Restaurant)restaurantList[i]).ID)
                    {
                        sum += (int)((Review)segment).Rating;
                        tempaverage[i]++;
                    }
                }
                tempaverage[i] = sum / tempaverage[i];
            }

            for (int i = 0; i < topX; i++)
            {
                highest[i] = 0;
                for (int o = 0; o < tempaverage.Count(); o++)
                {
                    if (tempaverage[o] > tempaverage[highest[i]])
                    {
                        highest[i] = o;
                    }
                }

                restList.Add(restaurantList[highest[i]]);
                tempaverage[highest[i]] = -1;
            }
            return restList;
        }

        public void DisplayAll(ArrayList restaurant, int sort)
        {
            if (sort == 1)
                restaurant = Namesort(restaurant);

            Console.WriteLine("-------------------------------");
            Console.WriteLine("ID | Name | Location ");
            Console.WriteLine("-------------------------------");

            foreach (Restaurant element in restaurant)
            {
                Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", element.ID, element.Name, element.Location));
            }
            Console.WriteLine("-------------------------------");
        }

        //Displays all reviews of a restaurant
        public void DisplayReviews(ArrayList reviews, Restaurant restaurant)
        {
            Console.WriteLine("ID | Name | Restaurant Name | Rating | Text ");
            foreach (Review element in reviews)
            {
                if (element.RestaurantID == restaurant.ID)
                {
                    Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-5}",
                        element.ID, element.Name, element.RestaurantID, element.Rating, element.Text));
                }
            }
        }

        internal ArrayList Namesort(ArrayList restaurant)
        {
            ArrayList temp = new ArrayList();
            int lowest;
            while (restaurant.Count > 0)
            {
                lowest = 0;
                for (int i = 0; i < restaurant.Count; i++)
                {
                    if (0 > (((Restaurant)restaurant[i]).Name.CompareTo(((Restaurant)restaurant[lowest]).Name)))
                        lowest = i;
                }
                temp.Add(restaurant[lowest]);
                restaurant.RemoveAt(lowest);
            }
            return temp;
        }

        //Search Restaurants (By partial name), display all matching results
        public ArrayList SearchRestaurants(ArrayList restaurant, string target)
        {
            string compare;
            int found = 0;
            ArrayList match = new ArrayList();
            foreach (Restaurant element in restaurant)
            {
                compare = element.Name.ToUpper();
                if (compare.Contains(target.ToUpper()))
                {
                    found++;
                    match.Add(element);
                }
            }
            return match;
        }

        //Quits application
        public void QuitApp()
        {
            Console.ReadKey();
            System.Environment.Exit(0);
        }


    }
}

