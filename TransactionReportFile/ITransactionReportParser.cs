using System.IO;
using GatewayApiClient.TransactionReportFile.Report;

namespace GatewayApiClient.TransactionReportFile {

    public interface ITransactionReportParser {

        TransactionReport ParseFile(string filename);

        TransactionReport ParseStream(Stream stream);

        TransactionReport ParseString(string reportContent);
    }
}