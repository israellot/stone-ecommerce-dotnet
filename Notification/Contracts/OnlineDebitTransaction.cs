using System;
using System.Runtime.Serialization;
using GatewayApiClient.Notification.Contracts.Enum;

namespace GatewayApiClient.Notification.Contracts {

    [DataContract(Name = "OnlineDebitTransaction", Namespace = "")]
    public class OnlineDebitTransaction {
        [DataMember(Order = 0)]
        public long AmountInCents { get; set; }

        [DataMember(Order = 1)]
        public long AmountPaidInCents { get; set; }

        [DataMember(Order = 2)]
        public string BankName { get; set; }

        [DataMember(Order = 3)]
        public string BankPaymentDate { get; set; }

        [DataMember(Order = 4)]
        public DateTime StatusChangedDate { get; set; }

        [DataMember(Order = 5)]
        public Guid TransactionKey { get; set; }

        [DataMember(Order = 6)]
        public string TransactionKeyToBank { get; set; }
        
        [DataMember(Order = 7)]
        public string TransactionReference { get; set; }

        [DataMember(Order = 8)]
        public OnlineDebitTransactionStatusEnum PreviousOnlineDebitTransactionStatus { get; set; }

        [DataMember(Order = 9)]
        public OnlineDebitTransactionStatusEnum OnlineDebitTransactionStatus { get; set; }
    }
}
