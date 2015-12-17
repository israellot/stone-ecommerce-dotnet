using System.IO;
using GatewayApiClient.TransactionReportFile.Report;

namespace GatewayApiClient.TransactionReportFile.Parsers {

    internal class TrailerParser : IReportItemParser {

        private TrailerParser() { }

        private static TrailerParser _instance = null;

        public static TrailerParser GetInstance() {

            if (TrailerParser._instance == null) {
                TrailerParser._instance = new TrailerParser();
            }

            return TrailerParser._instance;
        }

        public IReportItem Parse(string[] elements) {

            if (elements.Length < 5) {
                throw new InvalidDataException("The expected parameter count is 5");
            }

            Trailer trailer = new Trailer();

            trailer.OrderDataCount = int.Parse(elements[Constants.IDX_TRL_ORDER_DATA_COUNT]);
            trailer.CreditCardTransactionDataCount = int.Parse(elements[Constants.IDX_TRL_CREDIT_CARD_TRANSACTION_DATA_COUNT]);
            trailer.BoletoTransactionDataCount = int.Parse(elements[Constants.IDX_TRL_BOLETO_TRANSACTION_DATA_COUNT]);
            trailer.OnlineDebitTransactionDataCount = int.Parse(elements[Constants.IDX_TRL_ONLINE_DEBIT_TRANSACTION_DATA_COUNT]);

            return trailer;
        }
    }
}
