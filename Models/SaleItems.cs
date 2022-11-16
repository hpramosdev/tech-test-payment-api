using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class SaleItems
    {
        public Guid Id { get; private set; }
        public Guid SaleId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }

        public Sale Sale { get; private set; }
        public Product Produtcx { get; private set; }

        public SaleItems(Guid saleId, Guid productId, int quantity, decimal value)
        {
            Id = Guid.NewGuid();
            SaleId = saleId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
        }
    }
}