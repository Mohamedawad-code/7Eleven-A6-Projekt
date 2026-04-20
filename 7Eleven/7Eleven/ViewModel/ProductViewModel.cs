using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _7Eleven.Model;

namespace _7Eleven.ViewModel
{
    public class ProductViewModel
    {
        private List<Product> _products;

        public Product CreateNewProduct(string Newname, int Newamount, DateTime NewtimeReceived, DateTime Newexpiringdate)
        {
            var NewProduct = new Product(Newname, Newamount, NewtimeReceived, Newexpiringdate);

            _products.Add(NewProduct);
            return NewProduct;
        }
    }
}
