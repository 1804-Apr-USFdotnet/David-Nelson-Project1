using System;
using System.Collections.Generic;
using ObjectsNameSpace;

namespace Library
{
    public class Library
    {
        //Obsolete Code
        List<Review> reviews = new List<Review>();
        List<Restaurant> restaurants = new List<Restaurant>();

        Library(int reviewers, int inputrestaurants)
        {
            for (int i = 0; i < reviewers; i++)
            {
                reviews.Add(new Review());
            }

            for (int i = 0; i < inputrestaurants; i++)
            {
                restaurants.Add(new Restaurant());
            }

        }

    public double AverageRating(List<Review> a, Restaurant b)
        {
            int qauntity = 0;
            double average = 0;
            foreach (Review element in a)
            {
                if (b.Name == element.restaurantID)
                {
                    average += element.rating;
                    qauntity++;
                }
            }
            return average / qauntity;
        }

        public void TopThree(List<Review> a, List<Restaurant> b)
        { // top what restrants
            int topX = 3;
            double tempaverage;
            List<double> top = new List<double>();
            List<string> topname = new List<string>();
            foreach (Restaurant element in b)
            {
                //finds the average rating of the restaurant
                tempaverage = AverageRating(a, element);
                //checks if there are already 3 ratings
                if (top.Count == topX)
                {
                    if (tempaverage < top[0])
                        continue;
                    //checks if the current restaurant is higher rated than the top three
                    for (int i = topX; i > 0; i--)
                    {

                        if (tempaverage > top[i - 1])
                        {
                            top[i - 1] = tempaverage;
                            topname[i - 1] = element.Name;
                            break;
                        }
                    }
                }
                else
                {
                    top.Add(tempaverage);
                    topname.Add(element.Name);
                }
            }
            for (int i = 0; i < topX; i++)
            {
                Console.WriteLine($"#{i} {topname[i]}: {top[i]}");
            }

        }

        public void DisplayAll(Restaurant[] restaurant)
        {

            foreach (Restaurant element in restaurant)
                Console.WriteLine($"");
        }

        public void DisplayReviews(Restaurant[] restaurant)
        {

        }
        public void SearchRestaurants(Restaurant restaurant)
        {

        }
        public void QuitApp()
        {

        }


    }
}
