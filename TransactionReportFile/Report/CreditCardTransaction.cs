using System;

namespace GatewayApiClient.TransactionReportFile.Report {

    public class CreditCardTransaction : IReportItem {

        public Order Order { get; set; }

        public Guid TransactionKey { get; set; }

        public string TransactionKeyToAcquirer { get; set; }

        public string TransactionReference { get; set; }

        public string CreditCardBrand { get; set; }

        public string CreditCardNumber { get; set; }

        public int InstallmentCount { get; set; }

        public string AcquirerName { get; set; }

        public string Status { get; set; }

        public long AmountInCents { get; set; }

        public long IataAmountInCents { get; set; }

        public string AuthorizationCode { get; set; }

        public string TransactionIdentifier { get; set; }

        public string UniqueSequentialNumber { get; set; }

        public long AuthorizedAmountInCents { get; set; }

        public long CapturedAmountInCents { get; set; }

        public long VoidedAmountInCents { get; set; }

        public long RefundedAmountInCents { get; set; }

        public Nullable<DateTime> CapturedDate { get; set; }

        public Nullable<DateTime> AuthorizedDate { get; set; }

        public Nullable<DateTime> VoidedDate { get; set; }

        public Nullable<DateTime> LastProbeDate { get; set; }

        public string AcquirerAuthorizationReturnCode { get; set; }
    }
}
