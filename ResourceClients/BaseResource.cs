using System;
using System.Collections.Specialized;
using GatewayApiClient.ResourceClients.Interfaces;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients {

    public abstract class BaseResource : IBaseResource {

        private string _resourceName;
        public string ResourceName { get { return _resourceName; } }

        public Guid MerchantKey { get; set; }

        private string _hostUri;
        protected string HostUri { get { return _hostUri; } }

        private NameValueCollection _customHeader = null;

        internal HttpUtility HttpUtility { get; set; }

        protected BaseResource(Guid merchantKey, string resourceName, Uri hostUri, NameValueCollection customHeaders) {

            if (merchantKey == Guid.Empty) {
                merchantKey = ConfigurationUtility.GetConfigurationKey("MerchantKey");
            }

            this.HttpUtility = new HttpUtility();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            this.MerchantKey = merchantKey;
            if (hostUri != null) {
                this._hostUri = hostUri.ToString();
                this._hostUri = this._hostUri.Remove(this._hostUri.Length - 1);
            }
            else {
                this._hostUri = this.GetServiceUri();
            }
            this._resourceName = resourceName;

            this._customHeader = customHeaders;
        }

        private string GetServiceUri() {

            return ConfigurationUtility.GetConfigurationString("HostUri");
        }

        protected NameValueCollection GetHeaders() {

            NameValueCollection headers = new NameValueCollection();

            if (this._customHeader != null) {
                foreach (string headerName in this._customHeader) {
                    headers.Add(headerName, this._customHeader[headerName]);
                }
            }

            return headers;
        }
    }
}
