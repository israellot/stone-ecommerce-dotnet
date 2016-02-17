using System;
using System.Collections.Specialized;
using GatewayApiClient.DataContracts;
using GatewayApiClient.EnumTypes;
using GatewayApiClient.ResourceClients.Interfaces;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients {
    public class BuyerResource : BaseResource, IBuyerResource {
        public BuyerResource(Guid merchantKey, Uri hostUri, NameValueCollection customHeaders) : base(merchantKey, "/Buyer", hostUri, customHeaders) { }

        public HttpResponse<GetBuyerData> GetBuyer(Guid buyerKey) {
            string actionName = string.Format("/{0}", buyerKey.ToString());

            HttpVerbEnum httpVerb = HttpVerbEnum.Get;

            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            return this.HttpUtility.SubmitRequest<GetBuyerData>(string.Concat(this.HostUri, this.ResourceName, actionName), httpVerb, HttpContentTypeEnum.Json, headers);
        }

        public HttpResponse<CreateBuyerResponse> CreateBuyer(CreateBuyerRequest createBuyerRequest) {
            HttpVerbEnum httpVerb = HttpVerbEnum.Post;

            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            return
                this.HttpUtility.SubmitRequest<CreateBuyerRequest, CreateBuyerResponse>(createBuyerRequest,
                    string.Concat(this.HostUri, this.ResourceName), httpVerb, HttpContentTypeEnum.Json, headers);
        }
    }
}