using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class ReviewModel
    {
        public string Name { get; set; }
        public int Rating { get; set; } = 0;
        public string text { get; set; } = "ToBe";
        public int RestaurantID {get; set; }
        public int ID { get; set; }
    }
}