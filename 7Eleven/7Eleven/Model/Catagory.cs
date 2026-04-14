using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Eleven.Model
{
    public class Catagory
    {
        public string FoodName { get; set; }
        public FoodCategory FoodType { get; set; }

        public Catagory (string foodname, FoodCategory foodtype)
        {
            FoodName = foodname;
            FoodType = foodtype;

        }

       
    }

    public enum FoodCategory
    {
        Bread,
        Dessert,
        Sandwhiches,
        Pastry,
        FriedFood,

    }
}
