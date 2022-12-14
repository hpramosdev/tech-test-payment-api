using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Utils;

namespace tech_test_payment_api.Models
{
     public class Sale
    {
        public Guid Id { get; private set; }
        public Guid SellerId { get; set; }
        public DateTime Date { get; private set; }        
        public SaleStatusEnum Status { get; private set; }

        public Seller Seller { get; set; }
        public List<SaleItems> Items { get; set; }

        public Sale(Guid sellerId, DateTime date)
        {
            Items = new List<SaleItems>();

            Id = Guid.NewGuid();
            SellerId = sellerId;
            Date = date;
            Status = SaleStatusEnum.awaitingPayment;
        }        

        public void UpdateSaleStatus(SaleStatusEnum saleStatusEnum)
        {
            if (saleStatusEnum == SaleStatusEnum.paymentAccept && Status == SaleStatusEnum.awaitingPayment)
                Status = saleStatusEnum;

            if (saleStatusEnum == SaleStatusEnum.canceled && Status == SaleStatusEnum.awaitingPayment)
                Status = saleStatusEnum;

            if (saleStatusEnum == SaleStatusEnum.sentToCarrier && Status == SaleStatusEnum.paymentAccept)
                Status = saleStatusEnum;

            if (saleStatusEnum == SaleStatusEnum.canceled && Status == SaleStatusEnum.paymentAccept)
                Status = saleStatusEnum;

            if (saleStatusEnum == SaleStatusEnum.delivered && Status == SaleStatusEnum.sentToCarrier)
                Status = saleStatusEnum;
        }
    }
}