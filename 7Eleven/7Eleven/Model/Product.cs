using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Eleven.Model
{
    public class Product
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public Guid ProductNO { get; set; } = Guid.NewGuid();
        public DateTime TimeReceived { get; set; }
        public DateTime ExpiringDate { get; set; }


        public Product (string name, int amount, DateTime timeReceived, DateTime expiringdate)
        {
            Name = name;
            Amount = amount;
            TimeReceived = timeReceived;
            ExpiringDate = expiringdate;

        }

    }
}
