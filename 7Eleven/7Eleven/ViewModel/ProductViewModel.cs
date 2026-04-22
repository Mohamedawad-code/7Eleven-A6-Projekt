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
        private List<Product> _products = new List<Product>();

        public Product CreateNewProduct(string Newname, int Newamount, DateTime NewtimeReceived, DateTime Newexpiringdate)
        {
            var NewProduct = new Product(Newname, Newamount, NewtimeReceived, Newexpiringdate);

            _products.Add(NewProduct);
            return NewProduct;
        }

        public void DeleteProduct(Guid productNO)
        {
            var product = _products.FirstOrDefault(p => p.ProductNO == productNO);
            if (product is null)
                throw new ArgumentException("Product doest exist");

            _products.Remove(product);

        }

        public Product EditProducts(string Updatedname, int Updatedamount, DateTime UpdatedtimeReceived, DateTime Updatedexpiringdate, Guid productNO)
        {
            var updatedProduct = _products.FirstOrDefault(p => p.ProductNO == productNO);
            if (updatedProduct is null)
                throw new ArgumentException("Product doesnt exist");

            updatedProduct.Name = Updatedname;
            updatedProduct.Amount = Updatedamount;
            updatedProduct.TimeReceived = UpdatedtimeReceived;
            updatedProduct.ExpiringDate = Updatedexpiringdate;

            return updatedProduct;
        }
    }
}
