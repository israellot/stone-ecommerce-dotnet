using System;
using System.Runtime.Serialization;
using GatewayApiClient.Notification.Contracts.Enum;

namespace GatewayApiClient.Notification.Contracts {

    [DataContract(Name = "StatusNotification", Namespace = "")]
    public class StatusNotification {
        [DataMember(Order = 0)]
        public long AmountInCents { get; set; }

        [DataMember(Order = 1)]
        public long AmountPaidInCents { get; set; }

        [DataMember(Order = 2)]
        public BoletoTransaction BoletoTransaction { get; set; }

        [DataMember(Order = 3)]
        public CreditCardTransaction CreditCardTransaction { get; set; }

        [DataMember(Order = 4)]
        public Guid MerchantKey { get; set; }

        [DataMember(Order = 5)]
        public OnlineDebitTransaction OnlineDebitTransaction { get; set; }

        [DataMember(Order = 6)]
        public Guid OrderKey { get; set; }

        [DataMember(Order = 7)]
        public string OrderReference { get; set; }

        [DataMember(Order = 8)]
        public OrderStatusEnum OrderStatus { get; set; }
    }
}
