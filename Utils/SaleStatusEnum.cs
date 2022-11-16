using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace tech_test_payment_api.Utils
{
    public enum SaleStatusEnum
    {
        [Description("Aguardando pagamento")]
        awaitingPayment,
        [Description("Pagamento aprovado")]
        paymentAccept,
        [Description("Enviado para transportadora")]
        sentToCarrier,
        [Description("Entregue")]
        delivered,
        [Description("Cancelada")]
        canceled
    }
}