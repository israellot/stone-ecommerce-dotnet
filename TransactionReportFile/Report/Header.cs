using System;

namespace GatewayApiClient.TransactionReportFile.Report {

    public class Header : IReportItem {

        public DateTime TransactionProcessedDate { get; set; }

        public DateTime ReportFileCreateDate { get; set; }

        public string Version { get; set; }
    }
}
