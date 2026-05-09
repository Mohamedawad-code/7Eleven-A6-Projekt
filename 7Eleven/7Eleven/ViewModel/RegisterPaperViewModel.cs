using _7Eleven.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace _7Eleven.ViewModel
{
    public class RegisterPaperViewModel
    {
        private ObservableCollection<RegisterPaper> _registerpaper = new ObservableCollection<RegisterPaper>();
        private RegisterPaperRepository _repo = new RegisterPaperRepository();


        // Input properties for RegisterPaper
        public Product SelectedProduct { get; set; }
        public Category SelectedCategory { get; set; }
        public Coworker SelectedCoworker { get; set; }
        public int NewAmount { get; set; }
        public DateTime NewExpiringDate { get; set; }
        public DateTime NewRegisterDate { get; set; }
        public RegisterPaper SelectedRegisterPaper { get; set; }

        public ICommand CreateRegisterPaperCommand { get; }
        public ICommand DeleteRegisterPaperCommand { get; }

        public void ExcuteCreateRegisterPaper() // WPF cant call methods with parameters, so we do dis
        {
            CreateRegisterPaper(SelectedProduct,
               SelectedCategory,
               NewAmount,
               NewExpiringDate,
               SelectedCoworker,
               NewRegisterDate);
        }

        public void ExcuteDeleteRegisterPaper()
        {
            if (SelectedRegisterPaper is null)
                return;

            DeleteRegisterPaper(SelectedRegisterPaper.ID);
        }

        public RegisterPaperViewModel()
        {
            CreateRegisterPaperCommand = new RelayCommand(ExcuteCreateRegisterPaper);
            DeleteRegisterPaperCommand = new RelayCommand(ExcuteDeleteRegisterPaper);

            var result = _repo.GetAll();
            _registerpaper = new ObservableCollection<RegisterPaper>(result);
           

        }

        

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