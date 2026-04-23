using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _7Eleven.Model;

namespace _7Eleven.ViewModel
{
    public class RegisterPaperViewModel
    {
        private List<RegisterPaper> _registerpaper = new List<RegisterPaper>();

        public RegisterPaper CreateRegisterPaper(Coworker Newregisteredby
            , List<Category> newCategories
            , List<Depreciation> newDepreciations
            , List<Product> newProducts
            , DateTime newDate)
        {
            var newRegisterPaper = new RegisterPaper(Newregisteredby
            , newCategories
            , newDepreciations
            , newProducts
            , newDate);

            _registerpaper.Add(newRegisterPaper);

            return newRegisterPaper;

        }

        public void DeleteRegisterPaper(Guid id)
        {
            var registerPaper = _registerpaper.FirstOrDefault(r => r.ID == id);
            if (registerPaper is null)
                throw new ArgumentException("register_paper is null");

            _registerpaper.Remove(registerPaper);
        }

      
        public List<RegisterPaper> GetAllregisterPapers()
        {
            return _registerpaper;
        }


    }
}
