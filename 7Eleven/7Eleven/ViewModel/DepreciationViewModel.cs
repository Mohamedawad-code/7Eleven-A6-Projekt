using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _7Eleven.Model;

namespace _7Eleven.ViewModel
{
    public class DepreciationViewModel
    {
        private List<Depreciation> _depreciation = new List<Depreciation>();

        public Depreciation CreateDepreciation(DateTime newDate, Product newProductdep)
        {
            var newDepreciation = new Depreciation(newDate, newProductdep);

            _depreciation.Add(newDepreciation);
            return newDepreciation;
        }

        public void DeleteDepreciation(Guid id)
        {
            var depreciation = _depreciation.FirstOrDefault(d => d.ID == id);
            if (depreciation is null)
                throw new ArgumentException("Invalid or doesnt exist");

            _depreciation.Remove(depreciation);
        }

        public Depreciation EditDepreciation(DateTime updatedDate, Product updatedProductdep, Guid id)
        {
            var updatedDepreciation = _depreciation.FirstOrDefault(d => d.ID == id);
            if (updatedDepreciation is null)
                throw new ArgumentException("Invalid");

        
            updatedDepreciation.ProductDep = updatedProductdep;
            updatedDepreciation.Date = updatedDate;

            return updatedDepreciation;
        }

        public List<Depreciation> GetAll()
        {
            return _depreciation;
        }

        public Depreciation GetByIdDepreciation(Guid id)
        {
            var depreciation = _depreciation.FirstOrDefault(d => d.ID == id);
            if (depreciation is null)
                throw new ArgumentException("Doesnt exist");

            return depreciation;
        }
    }
}
