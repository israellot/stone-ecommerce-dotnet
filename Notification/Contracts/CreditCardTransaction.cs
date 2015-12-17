using System;
using System.Runtime.Serialization;
using GatewayApiClient.Notification.Contracts.Enum;

namespace GatewayApiClient.Notification.Contracts {

    [DataContract(Name = "CreditCardTransaction", Namespace = "")]
    public class CreditCardTransaction {

        [DataMember(Order = 0)]
        public string Acquirer { get; set; }

        [DataMember(Order = 1)]
        public long AmountInCents { get; set; }

        [DataMember(Order = 2)]
        public string AuthorizationCode { get; set; }

        [DataMember(Name = "AuthorizedAmountInCents", Order = 3)]
        private string AuthorizedAmountInCentsField {
            get {
                if (this.AuthorizedAmountInCents == null) { return null; }
                return this.AuthorizedAmountInCents.ToString();
            }
            set {
                if (string.IsNullOrEmpty(value)) {
                    this.AuthorizedAmountInCents = null;
                }
                else {
                    this.AuthorizedAmountInCents = (long)long.Parse(value);
                }
            }
        }

        [IgnoreDataMember]
        public Nullable<long> AuthorizedAmountInCents { get; set; }

        [DataMember(Name = "CapturedAmountInCents", Order = 4)]
        private string CapturedAmountInCentsField {
            get {
                if (this.CapturedAmountInCents == null) { return null; }
                return this.CapturedAmountInCents.ToString();
            }
            set {
                if (string.IsNullOrEmpty(value)) {
                    this.CapturedAmountInCents = null;
                }
                else {
                    this.CapturedAmountInCents = (long)long.Parse(value);
                }
            }
        }

        [IgnoreDataMember]
        public Nullable<long> CapturedAmountInCents { get; set; }

        [DataMember(Order = 5)]
        public string CreditCardBrand { get; set; }

        [DataMember(Order = 6)]
        public string CustomStatus { get; set; }

        [DataMember(Name = "RefundedAmountInCents", Order = 7)]
        private string RefundedAmountInCentsField {
            get {
                if (this.RefundedAmountInCents == null) {
                    return null;
                }
                return this.RefundedAmountInCents.ToString();
            }
            set {
                if (string.IsNullOrEmpty(value)) {
                    this.RefundedAmountInCents = null;
                }
                else {
                    this.RefundedAmountInCents = (long)long.Parse(value);
                }
            }
        }

        [IgnoreDataMember]
        public Nullable<long> RefundedAmountInCents { get; set; }

        [DataMember(Order = 8)]
        public DateTime StatusChangedDate { get; set; }

        [DataMember(Order = 9)]
        public string TransactionIdentifier { get; set; }

        [DataMember(Order = 10)]
        public Guid TransactionKey { get; set; }

        [DataMember(Order = 11)]
        public string TransactionReference { get; set; }

        [DataMember(Order = 12)]
        public string UniqueSequentialNumber { get; set; }

        [DataMember(Name = "VoidedAmountInCents", Order = 13)]
        private string VoidedAmountInCentsField {
            get {
                if (this.VoidedAmountInCents == null) { return null; }
                return this.VoidedAmountInCents.ToString();
            }
            set {
                if (string.IsNullOrEmpty(value)) {
                    this.VoidedAmountInCents = null;
                }
                else {
                    this.VoidedAmountInCents = (long)long.Parse(value);
                }
            }
        }

        [IgnoreDataMember]
        public Nullable<long> VoidedAmountInCents { get; set; }

        [DataMember(Name = "PreviousCreditCardTransactionStatus", Order = 14)]
        private string PreviousCreditCardTransactionStatusField {
            get { return this.PreviousCreditCardTransactionStatus.ToString(); }
            set {
                this.PreviousCreditCardTransactionStatus =
                    (CreditCardTransactionStatusEnum)System.Enum.Parse(typeof(CreditCardTransactionStatusEnum), value);
            }
        }

        [IgnoreDataMember]
        public CreditCardTransactionStatusEnum PreviousCreditCardTransactionStatus { get; set; }

        [DataMember(Name = "CreditCardTransactionStatus", Order = 15)]
        private string CreditCardTransactionStatusField {
            get { return this.CreditCardTransactionStatus.ToString(); }
            set {
                this.CreditCardTransactionStatus =
                    (CreditCardTransactionStatusEnum)System.Enum.Parse(typeof(CreditCardTransactionStatusEnum), value);
            }
        }

        [IgnoreDataMember]
        public CreditCardTransactionStatusEnum CreditCardTransactionStatus { get; set; }
    }
}
