using System;
using GatewayApiClient.DataContracts;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients.Interfaces {
    public interface IBuyerResource {
        HttpResponse<GetBuyerData> GetBuyer(Guid buyerKey);

        HttpResponse<CreateBuyerResponse> CreateBuyer(CreateBuyerRequest createBuyerRequest);
    }
}