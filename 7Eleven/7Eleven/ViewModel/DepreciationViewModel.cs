using _7Eleven.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _7Eleven.ViewModel
{
    public class DepreciationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Depreciation> _depreciation = new ObservableCollection<Depreciation>();
        private DepreciationRepository _repo = new DepreciationRepository();
        public ObservableCollection<Depreciation> Depreciations
        {
            get => _depreciation;
            set
            {
                _depreciation = value;
                OnPropertyChanged(nameof(Depreciations));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        public DateTime NewDate { get; set; }
        public Product SelectedProductDep { get; set; }
        public Depreciation SelectedDepreciation { get; set; }


        public ICommand CreateDepreciationCommand { get; }
        public ICommand DeleteDepreciationCommand { get; }
        public ICommand EditDepreciationCommand { get; }


        public void ExcuteCreateDepreciation()
        {
            CreateDepreciation(NewDate, SelectedProductDep);
        }

        public void ExcuteDeleteDepreciation()
        {
            if (SelectedDepreciation is null)
                return;
            DeleteDepreciation(SelectedDepreciation.ID);
        }

        public void ExcuteEditDepreciation()
        {
            if (SelectedDepreciation is null)
                return;
            EditDepreciation(NewDate, SelectedProductDep, SelectedDepreciation.ID);
        }


        public DepreciationViewModel()
        {
            CreateDepreciationCommand = new RelayCommand(ExcuteCreateDepreciation);
            DeleteDepreciationCommand = new RelayCommand(ExcuteDeleteDepreciation);
            EditDepreciationCommand = new RelayCommand(ExcuteEditDepreciation);

            var result = _repo.GetAll();
            Depreciations = new ObservableCollection<Depreciation>(result);



        }




        public Depreciation CreateDepreciation(DateTime newDate, Product newProductdep)
        {
            var newDepreciation = new Depreciation(newDate, newProductdep);

            _depreciation.Add(newDepreciation);
            _repo.AddDepreciation(newDepreciation);
            return newDepreciation;
        }

        public void DeleteDepreciation(Guid id)
        {
            var depreciation = _depreciation.FirstOrDefault(d => d.ID == id);
            if (depreciation is null)
                throw new ArgumentException("Invalid or doesnt exist");

            _repo.DeleteDepreciation(depreciation.ID);
            _depreciation.Remove(depreciation);
        }

        public Depreciation EditDepreciation(DateTime updatedDate, Product updatedProductdep, Guid id)
        {
            var updatedDepreciation = _depreciation.FirstOrDefault(d => d.ID == id);
            if (updatedDepreciation is null)
                throw new ArgumentException("Invalid");

        
            updatedDepreciation.ProductDep = updatedProductdep;
            updatedDepreciation.Date = updatedDate;

            _repo.UpdateDepreciation(updatedDepreciation);

            return updatedDepreciation;
        }

        public ObservableCollection<Depreciation> GetAll()
        {
            var  result = _repo.GetAll();
            Depreciations = new ObservableCollection<Depreciation>(result);
            return Depreciations;
        }

        public Depreciation GetByIdDepreciation(Guid id)
        {
            var depreciation = _repo.GetById(id);
            if (depreciation is null)
                throw new ArgumentException("Doesnt exist");

            return depreciation;
        }
    }
}
