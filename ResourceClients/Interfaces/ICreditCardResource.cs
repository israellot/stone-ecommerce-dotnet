using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;
using System;

namespace GatewayApiClient.ResourceClients.Interfaces {

    public interface ICreditCardResource : IBaseResource {

        HttpResponse<GetInstantBuyDataResponse> GetInstantBuyData(Guid instantBuyKey);

        HttpResponse<GetInstantBuyDataResponse> GetInstantBuyDataWithBuyerKey(Guid buyerKey);
    }
}
