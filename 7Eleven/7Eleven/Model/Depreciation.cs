using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Eleven.Model
{
    public class Depreciation
    {
        public DateTime Date { get; set; }
        public Guid ID { get; set; } = Guid.NewGuid();
        public Product ProductDep { get; set; }


        public Depreciation(DateTime date, Product productdep)
        {
            Date = date;
            ProductDep = productdep;

        }

    }
}
