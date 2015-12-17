using GatewayApiClient.TransactionReportFile.Report;

namespace GatewayApiClient.TransactionReportFile.Parsers {

    internal interface IReportItemParser {

        IReportItem Parse(string[] elements);
    }
}
