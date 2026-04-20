using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Eleven.Model
{
    public class RegisterPaper
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        private Coworker RegisteredBy { get; set; }
        private  List<Category> _categories { get; set; }
        private List<Depreciation> _depreciations { get; set; }
        private List<Product> _products { get; set; }
        public DateTime Date { get; set; }

        
        public RegisterPaper (Coworker registeredby
            , List<Category> categories
            , List<Depreciation> depreciations
            , List<Product> products
            , DateTime date)
        {
            RegisteredBy = registeredby;
            _categories = categories;
            _depreciations = depreciations;
            _products = products;
            Date = date;
        }

    }
}
