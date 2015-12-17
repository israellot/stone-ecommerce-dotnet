namespace GatewayApiClient.TransactionReportFile.Report {

    public class Trailer : IReportItem {

        public int OrderDataCount { get; set; }

        public int BoletoTransactionDataCount { get; set; }

        public int CreditCardTransactionDataCount { get; set; }

        public int OnlineDebitTransactionDataCount { get; set; }
    }
}
