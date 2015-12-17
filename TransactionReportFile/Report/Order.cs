using System;

namespace GatewayApiClient.TransactionReportFile.Report {

    public class Order : IReportItem {

        public Guid MerchantKey { get; set; }

        public string MerchantName { get; set; }

        public Guid OrderKey { get; set; }

        public string OrderReference { get; set; }
    }
}
