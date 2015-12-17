using System;

namespace GatewayApiClient.TransactionReportFile.Report {

    public class BoletoTransaction : IReportItem {

        public Order Order { get; set; }

        public Guid TransactionKey { get; set; }

        public string TransactionReference { get; set; }

        public string Status { get; set; }

        public string NossoNumero { get; set; }

        public string BankNumber { get; set; }

        public string Agency { get; set; }

        public string Account { get; set; }

        public string BarCode { get; set; }

        public DateTime ExpirationDate { get; set; }

        public long AmountInCents { get; set; }

        public long AmountPaidInCents { get; set; }

        public Nullable<DateTime> PaymentDate { get; set; }

        public Nullable<DateTime> CreditDate { get; set; }
    }
}
