using _7Eleven.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _7Eleven.ViewModel
{
    public class ProductViewModel
    {
        private ObservableCollection<Product> _products = new ObservableCollection<Product>();
        private ProductRepository _repo = new ProductRepository();

        public string NewName { get; set; }
        public int NewAmount { get; set; }
        public DateTime NewTimeReceived { get; set; }
        public DateTime NewExpiringDate { get; set; }
        public Product SelectedProduct { get; set; }
       


        public ICommand CreateNewProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand EditProductCommand { get; }


        public void ExcuteCreateNewProduct()
        {
            CreateNewProduct(NewName, NewAmount, NewTimeReceived, NewExpiringDate);
        }

        public void ExcuteDeleteProduct()
        {
            if (SelectedProduct is null)
                return;

            DeleteProduct(SelectedProduct.ProductNO);
        }

        public void ExcuteEditProducts()
        {
            if (SelectedProduct is null)
                return;
            EditProducts(NewName, NewAmount, NewTimeReceived, NewExpiringDate, SelectedProduct.ProductNO);
        }


        public ProductViewModel()
        {
           CreateNewProductCommand = new RelayCommand(ExcuteCreateNewProduct);
           DeleteProductCommand = new RelayCommand(ExcuteDeleteProduct);
           EditProductCommand = new RelayCommand(ExcuteEditProducts);

            var result = _repo.GetAll();
            _products = new ObservableCollection<Product>(result);  



        }




        public Product CreateNewProduct(string Newname, int Newamount, DateTime NewtimeReceived, DateTime Newexpiringdate)
        {
            var NewProduct = new Product(Newname, Newamount, NewtimeReceived, Newexpiringdate);

            _products.Add(NewProduct);
            _repo.AddProduct(NewProduct);
            
            return NewProduct;
        }

        public void DeleteProduct(Guid productNO)
        {
            var product = _products.FirstOrDefault(p => p.ProductNO == productNO);
            if (product is null)
                throw new ArgumentException("Product doest exist");

            _repo.DeleteProduct(product.ProductNO);
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

            _repo.UpdateProduct(updatedProduct);
            return updatedProduct;
        }

        public ObservableCollection<Product> GetAllProducts()
        {
            var result = _repo.GetAll();
            _products = new ObservableCollection<Product>(result);
            return _products;
        }

        public Product GetByIdProduct(Guid productno)
        {
            var product = _repo.GetById(productno);
            if (product is null)
                throw new ArgumentException("Invalid");

            
            return product;
        }
    }
}
