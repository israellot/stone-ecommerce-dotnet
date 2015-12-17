using System;
using System.Collections.Specialized;
using GatewayApiClient.DataContracts;
using GatewayApiClient.EnumTypes;
using GatewayApiClient.ResourceClients.Interfaces;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients {

    public class CreditCardResource : BaseResource, ICreditCardResource {

        public CreditCardResource(Guid merchantKey, Uri hostUri, NameValueCollection customHeaders) : base(merchantKey, "/CreditCard", hostUri, customHeaders) { }

        public HttpResponse<GetInstantBuyDataResponse> GetInstantBuyData(Guid instantBuyKey) {
            return this.GetInstantBuyDataImplementation(instantBuyKey, string.Empty);
        }

        public HttpResponse<GetInstantBuyDataResponse> GetInstantBuyDataWithBuyerKey(Guid buyerKey) {
            return this.GetInstantBuyDataImplementation(buyerKey, "BuyerKey");
        }

        private HttpResponse<GetInstantBuyDataResponse> GetInstantBuyDataImplementation(Guid key, string identifierName) {

            if (string.IsNullOrWhiteSpace(identifierName) == false) { identifierName = string.Concat("/", identifierName); }

            string actionName = string.Format("/{0}{1}", key.ToString(), identifierName);

            HttpVerbEnum httpVerb = HttpVerbEnum.Get;

            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            return this.HttpUtility.SubmitRequest<GetInstantBuyDataResponse>(string.Concat(this.HostUri, this.ResourceName, actionName), httpVerb, HttpContentTypeEnum.Json, headers);
        }
    }
}
