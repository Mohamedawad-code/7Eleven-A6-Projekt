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
        public Product Product { get; set; }
        public Category Category { get; set; }
        public int Amount { get; set; }
        public DateTime ExpiringDate { get; set; }
        public Coworker RegisteredBy { get; set; }
        public DateTime RegisterDate { get; set; }

        public RegisterPaper(Product product, Category category, int amount, DateTime expiringDate, Coworker registeredBy, DateTime registerDate)
        {
            Product = product;
            Category = category;
            Amount = amount;
            ExpiringDate = expiringDate;
            RegisteredBy = registeredBy;
            RegisterDate = registerDate;
        }
    }
}
