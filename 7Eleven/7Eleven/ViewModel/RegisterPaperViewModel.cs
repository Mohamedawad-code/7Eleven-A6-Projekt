using _7Eleven.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace _7Eleven.ViewModel
{
    public class RegisterPaperViewModel
    {
        private ObservableCollection<RegisterPaper> _registerpaper = new ObservableCollection<RegisterPaper>();
        private RegisterPaperRepository _repo = new RegisterPaperRepository();

        public RegisterPaper CreateRegisterPaper(Product Newproduct, Category Newcategory, int Newamount, DateTime NewexpiringDate, Coworker NewregisteredBy, DateTime NewregisterDate)
        {
            var newRegisterPaper = new RegisterPaper(Newproduct, Newcategory, Newamount, NewexpiringDate, NewregisteredBy, NewregisterDate);

            _repo.AddRegisterPaper(newRegisterPaper);  
            _registerpaper.Add(newRegisterPaper);       

            return newRegisterPaper;
        }

        public void DeleteRegisterPaper(Guid id)
        {
            var registerPaper = _registerpaper.FirstOrDefault(r => r.ID == id);
            if (registerPaper is null)
                throw new ArgumentException("RegisterPaper does not exist");

            _repo.DeleteRegisterPaper(registerPaper.ID); 
            _registerpaper.Remove(registerPaper);          
        }

        public ObservableCollection<RegisterPaper> GetAllRegisterPapers()
        {
            var result = _repo.GetAll();
            _registerpaper = new ObservableCollection<RegisterPaper>(result);
            return _registerpaper;
        }

        public RegisterPaper GetByIdRegisterPaper(Guid id)
        {
            var registerpaper = _repo.GetById(id);  
            if (registerpaper is null)
                throw new ArgumentException("Invalid");

            return registerpaper;
        }

     
    }
}