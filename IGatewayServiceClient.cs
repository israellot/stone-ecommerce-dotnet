using GatewayApiClient.ResourceClients.Interfaces;

namespace GatewayApiClient {

    /// <summary>
    /// Cliente para acesso aos serviços do gateway.
    /// </summary>
    public interface IGatewayServiceClient {

        /// <summary>
        /// Recurso de cartão de crédito
        /// </summary>
        ICreditCardResource CreditCard { get; }

        /// <summary>
        /// Recurso buyer
        /// </summary>
        IBuyerResource Buyer { get; }

        /// <summary>
        /// Recurso de venda
        /// </summary>
        ISaleResource Sale { get; }
    }
}
