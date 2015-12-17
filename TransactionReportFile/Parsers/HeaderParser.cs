using System;
using System.IO;
using GatewayApiClient.TransactionReportFile.Report;

namespace GatewayApiClient.TransactionReportFile.Parsers {

    internal class HeaderParser : IReportItemParser {

        private HeaderParser() { }

        private static HeaderParser _instance = null;

        public static HeaderParser GetInstance() {

            if (HeaderParser._instance == null) {
                HeaderParser._instance = new HeaderParser();
            }

            return HeaderParser._instance;
        }

        public IReportItem Parse(string[] elements) {

            if (elements.Length < 4) {
                throw new InvalidDataException("The expected parameter count is 4");
            }

            Header header = new Header();

            header.TransactionProcessedDate = DateTime.ParseExact(elements[Constants.IDX_HDR_TRANSACTION_PROCESSED_DATE], Constants.DATE_FORMAT, null);
            header.ReportFileCreateDate = DateTime.ParseExact(elements[Constants.IDX_HDR_REPORT_FILE_CREATE_DATE], Constants.HDR_DATE_TIME_FORMAT, null);
            header.Version = elements[Constants.IDX_HDR_VERSION];

            return header;
        }
    }
}
