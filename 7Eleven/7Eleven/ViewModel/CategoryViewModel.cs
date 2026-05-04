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
        private CategoryRepository _repo = new CategoryRepository();

        public Category AddCategory(string Newfoodname, FoodCategory Newfoodtype)
        {
            var NewCategory = new Category(Newfoodname, Newfoodtype);
            if (NewCategory is null)
                throw new ArgumentException("Category doesnt exist");

            _repo.AddCategory(NewCategory);
            _categories.Add(NewCategory);
            return NewCategory;
        }

        public void DeleteCategory(Guid id)
        {
            var category = _categories.FirstOrDefault(c => c.ID == id);
            if (category is null)
                throw new ArgumentException("Category doesnt exist");
            _repo.DeleteCategory(category.ID);
            _categories.Remove(category);
        }

        public Category EditCategory(string Updatedfoodname, FoodCategory Updatedfoodtype, Guid id)
        {
            var UpdatedCategory = _categories.FirstOrDefault(u => u.ID == id);
            if (UpdatedCategory is null)
                throw new ArgumentException("Category doesnt exist");

            UpdatedCategory.FoodName = Updatedfoodname;
            UpdatedCategory.FoodType = Updatedfoodtype;

            _repo.UpdateCategory(UpdatedCategory);


            return UpdatedCategory;

        }

        public List<Category> GetAllCategories()
        {

            _categories = _repo.GetAll();
            return _categories;
        }

        public Category GetByidCategory(Guid id)
        {
            var category = _repo.GetById(id);
            if (category is null)
                throw new ArgumentException("Category doesnt exist");

            return category;
        }
    }
}
 