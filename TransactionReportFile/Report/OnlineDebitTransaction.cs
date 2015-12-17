using System;

namespace GatewayApiClient.TransactionReportFile.Report {

    public class OnlineDebitTransaction : IReportItem {

        public Order Order { get; set; }

        public Guid TransactionKey { get; set; }

        public string TransactionReference { get; set; }

        public string Bank { get; set; }

        public string Status { get; set; }

        public long AmountInCents { get; set; }

        public string TransactionKeyToBank { get; set; }

        public Nullable<long> AmountPaidInCents { get; set; }

        public string Signature { get; set; }

        public Nullable<DateTime> PaymentDate { get; set; }

        public string BankReturnCode { get; set; }

        public string BankPaymentDate { get; set; }
    }
}
