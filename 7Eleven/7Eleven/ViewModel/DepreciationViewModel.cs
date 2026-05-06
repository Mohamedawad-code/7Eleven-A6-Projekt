using _7Eleven.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Eleven.ViewModel
{
    public class DepreciationViewModel
    {
        private ObservableCollection<Depreciation> _depreciation = new ObservableCollection<Depreciation>();
        private DepreciationRepository _repo = new DepreciationRepository();

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
            _depreciation = new ObservableCollection<Depreciation>(result);
            return _depreciation;
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
