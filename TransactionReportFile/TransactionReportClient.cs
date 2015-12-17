using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using GatewayApiClient.Utility;

namespace GatewayApiClient.TransactionReportFile {

    public class TransactionReportClient : ITransactionReportClient {

        private Guid MerchantKey { get; set; }

        private Uri HostUri { get; set; }

        private HttpUtility HttpUtility = null;

        public TransactionReportClient(Guid merchantKey, Uri hostUri) {

            if (merchantKey == Guid.Empty) {
                merchantKey = ConfigurationUtility.GetConfigurationKey("MerchantKey");
            }
            this.MerchantKey = merchantKey;

            if (hostUri == null) { throw new ArgumentNullException("hostUri"); }
            this.HostUri = hostUri;

            this.HttpUtility = new HttpUtility();
        }

        public HttpResponse DownloadReport(DateTime fileDate) {

            // MerchantKey header
            NameValueCollection header = new NameValueCollection();
            header.Add("MerchantKey", this.MerchantKey.ToString());

            // Defines the resource.
            string resource = "/TransactionReportFile/GetStream?fileDate=" + fileDate.ToString("yyyyMMdd");

            // Sends the request.
            HttpResponse httpResponse = this.HttpUtility.SendHttpWebRequest(null, HttpVerbEnum.Get, null, null, new Uri(this.HostUri, resource).ToString(), header);

            return httpResponse;
        }

        public HttpStatusCode DownloadReportToFile(DateTime fileDate, string fileName) {

            // Downloads the file.
            HttpResponse httpResponse = this.DownloadReport(fileDate);

            if (httpResponse.HttpStatusCode == HttpStatusCode.OK) {

                // Saves the file.
                File.WriteAllText(fileName, httpResponse.RawResponse, Encoding.UTF8);
            }

            return httpResponse.HttpStatusCode;
        }
    }
}
