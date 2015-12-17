using GatewayApiClient.TransactionReportFile.Parsers;

namespace GatewayApiClient.TransactionReportFile.Factory {

    internal static class ParserFactory {

        internal static IReportItemParser GetParser(string lineIdentification) {

            switch (lineIdentification) {
                case "01":
                    return HeaderParser.GetInstance();
                case "20":
                    return CreditCardTransactionParser.GetInstance();
                case "30":
                    return BoletoTransactionParser.GetInstance();
                case "40":
                    return OnlineDebitTransactionParser.GetInstance();
                case "99":
                    return TrailerParser.GetInstance();
                default:
                    return null;
            }
        }
    }
}
