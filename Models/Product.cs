using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Value { get; private set; }

        public Product(string name, decimal value)
        {
            Id = Guid.NewGuid();
            Name = name;
            Value = value;
        } 

        public void Update(Product product)
        {
            Name = product.Name;
            Value = product.Value;
        }       
    }
}