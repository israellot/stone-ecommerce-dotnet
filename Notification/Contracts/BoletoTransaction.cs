using System;
using System.Runtime.Serialization;
using GatewayApiClient.Notification.Contracts.Enum;

namespace GatewayApiClient.Notification.Contracts {

    [DataContract(Name = "BoletoTransaction", Namespace = "")]
    public class BoletoTransaction {
        [DataMember(Order = 0)]
        public long AmountInCents { get; set; }

        [DataMember(Order = 1)]
        public long AmountPaidInCents { get; set; }

        [DataMember(Order = 2)]
        public DateTime BoletoExpirationDate { get; set; }

        [DataMember(Order = 3)]
        public string NossoNumero { get; set; }

        [DataMember(Order = 4)]
        public DateTime StatusChangedDate { get; set; }

        [DataMember(Order = 5)]
        public Guid TransactionKey { get; set; }

        [DataMember(Order = 6)]
        public string TransactionReference { get; set; }

        [DataMember(Order = 7)]
        public BoletoTransactionStatusEnum PreviousBoletoTransactionStatus { get; set; }

        [DataMember(Order = 8)]
        public BoletoTransactionStatusEnum BoletoTransactionStatus { get; set; }
    }
}
