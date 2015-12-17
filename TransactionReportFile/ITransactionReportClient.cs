using System;
using System.Net;
using GatewayApiClient.Utility;

namespace GatewayApiClient.TransactionReportFile {

    public interface ITransactionReportClient {

        HttpResponse DownloadReport(DateTime fileDate);

        HttpStatusCode DownloadReportToFile(DateTime fileDate, string fileName);
    }
}