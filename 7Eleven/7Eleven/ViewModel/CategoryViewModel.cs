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

        public void DeleteCategory(Guid id)
        {
            var category = _categories.FirstOrDefault(c => c.ID == id);
            if (category is null)
                throw new ArgumentException("Category doesnt exist");

            _categories.Remove(category);
        }

        public Category EditCategory(string Updatedfoodname, FoodCategory Updatedfoodtype, Guid id)
        {
            var UpdatedCategory = _categories.FirstOrDefault(u => u.ID == id);
            if (UpdatedCategory is null)
                throw new ArgumentException("Category doesnt exist");

            UpdatedCategory.FoodName = Updatedfoodname;
            UpdatedCategory.FoodType = Updatedfoodtype;

            return UpdatedCategory;

        }

        public List<Category> GetAllCategories()
        {
            return _categories;
        }

        public Category GetByidCategory(Guid id)
        {
            var category = _categories.FirstOrDefault(c => c.ID == id);
            return category;
        }
    }
}
