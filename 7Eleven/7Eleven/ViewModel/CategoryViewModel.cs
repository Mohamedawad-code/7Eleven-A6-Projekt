using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _7Eleven.Model;

namespace _7Eleven.ViewModel
{
    public class CategoryViewModel
    {
        private List<Category> _categories = new List<Category>();

        public Category AddCategory(string Newfoodname, FoodCategory Newfoodtype)
        {
            var NewCategory = new Category(Newfoodname, Newfoodtype);
            if (NewCategory is null)
                throw new ArgumentException("Category doesnt exist");

            _categories.Add(NewCategory);
            return NewCategory;
        }

        public void DeleteCategory(string foodname)
        {
            var category = _categories.FirstOrDefault(c => c.FoodName == foodname);
            if (category is null)
                throw new ArgumentException("Category doesnt exist");

            _categories.Remove(category);
        }

        public Category EditCategory(string Updatedfoodname, FoodCategory Updatedfoodtype, string foodname)
        {
            var UpdatedCategory = _categories.FirstOrDefault(u => u.FoodName == foodname);
            if (UpdatedCategory is null)
                throw new ArgumentException("Category doesnt exist");

            UpdatedCategory.FoodName = Updatedfoodname;
            UpdatedCategory.FoodType = Updatedfoodtype;

            return UpdatedCategory;

        }

    }
}
