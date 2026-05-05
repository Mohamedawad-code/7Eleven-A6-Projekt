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

        public RegisterPaper CreateRegisterPaper(Product product, Category category, int amount, DateTime expiringDate, Coworker registeredBy, DateTime registerDate)
        {
            var newRegisterPaper = new RegisterPaper(product, category, amount, expiringDate, registeredBy, registerDate);

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

        public List<RegisterPaper> GetAllRegisterPapers()
        {
            return _registerpaper;
        }

        public RegisterPaper GetByIdRegisterPaper(Guid id)
        {
            var registerpaper = _registerpaper.FirstOrDefault(r => r.ID == id);
            if (registerpaper is null)
                throw new ArgumentException("Invalid");

            return registerpaper;
        }

        // Query methods for the table view
        public List<RegisterPaper> GetByCoworker(int coworkerId)
        {
            return _registerpaper.Where(r => r.RegisteredBy.Id == coworkerId).ToList();
        }

        public List<RegisterPaper> GetByProduct(string productName)
        {
            return _registerpaper.Where(r => r.Product.Name.Contains(productName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<RegisterPaper> GetByDateRange(DateTime start, DateTime end)
        {
            return _registerpaper.Where(r => r.RegisterDate >= start && r.RegisterDate <= end).ToList();
        }
    }
}
