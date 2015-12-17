using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using GatewayApiClient.DataContracts;
using GatewayApiClient.EnumTypes;
using GatewayApiClient.ResourceClients.Interfaces;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients {

    public class SaleResource : BaseResource, ISaleResource {

        public SaleResource(Guid merchantKey, Uri hostUri, NameValueCollection customHeaders) : base(merchantKey, "/Sale", hostUri, customHeaders) { }

        #region Create

        /// <summary>
        /// Cria uma venda, contendo transações de boleto e/ou cartão de crédito
        /// </summary>
        /// <param name="createSaleRequest">Dados da venda</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(CreateSaleRequest createSaleRequest) {

            // Configura MerchantKey e o header
            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            // Envia requisição
            return this.HttpUtility.SubmitRequest<CreateSaleRequest, CreateSaleResponse>(createSaleRequest,
                string.Concat(this.HostUri, this.ResourceName), HttpVerbEnum.Post, HttpContentTypeEnum.Json, headers);
        }

        /// <summary>
        /// Cria uma venda com uma coleção de transações de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionCollection">Coleção de transações de cartão de crédito</param>
        /// <param name="orderReference">Identificação do pedido na loja</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(Collection<CreditCardTransaction> creditCardTransactionCollection, string orderReference) {

            CreateSaleRequest createSaleRequest = new CreateSaleRequest();
            createSaleRequest.CreditCardTransactionCollection = creditCardTransactionCollection;
            // Se não for informado o comprador nem o carrinho de compras não será possível utilizar o serviço de anti fraude.
            createSaleRequest.Options = new SaleOptions() { IsAntiFraudEnabled = false };
            if (string.IsNullOrWhiteSpace(orderReference) == false) {
                createSaleRequest.Order = new Order() {
                    OrderReference = orderReference
                };
            }

            return this.Create(createSaleRequest);
        }

        /// <summary>
        /// Cria uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransaction">Dados da transação de cartão de crédito</param>
        /// <param name="orderReference">Identificação do pedido na loja</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(CreditCardTransaction creditCardTransaction, string orderReference) {

            Collection<CreditCardTransaction> creditCardTransactionCollection = new Collection<CreditCardTransaction>();
            creditCardTransactionCollection.Add(creditCardTransaction);

            return this.Create(creditCardTransactionCollection, orderReference);
        }

        /// <summary>
        /// Cria uma venda com uma coleção de transações de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionCollection">Coleção de transações de cartão de crédito</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(Collection<CreditCardTransaction> creditCardTransactionCollection) {

            return this.Create(creditCardTransactionCollection, null);
        }

        /// <summary>
        /// Cria uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransaction">Dados da transação de cartão de crédito</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(CreditCardTransaction creditCardTransaction) {

            return this.Create(creditCardTransaction, null);
        }

        /// /// <summary>
        /// Cria uma venda com uma coleção de boletos
        /// </summary>
        /// <param name="boletoTransactionCollection">Coleção de boletos</param>
        /// <param name="orderReference">Identificação do pedido na loja</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(Collection<BoletoTransaction> boletoTransactionCollection, string orderReference) {

            CreateSaleRequest createSaleRequest = new CreateSaleRequest();
            createSaleRequest.BoletoTransactionCollection = boletoTransactionCollection;
            // Se não for informado o comprador nem o carrinho de compras não será possível utilizar o serviço de anti fraude.
            createSaleRequest.Options = new SaleOptions() { IsAntiFraudEnabled = false };
            if (string.IsNullOrWhiteSpace(orderReference) == false) {
                createSaleRequest.Order = new Order() {
                    OrderReference = orderReference
                };
            }

            return this.Create(createSaleRequest);
        }

        /// <summary>
        /// Cria uma transação de boleto
        /// </summary>
        /// <param name="boletoTransaction">Dados da transação de boleto</param>
        /// <param name="orderReference">Identificação do pedido na loja</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(BoletoTransaction boletoTransaction, string orderReference) {

            Collection<BoletoTransaction> boletoTransactionCollection = new Collection<BoletoTransaction>();
            boletoTransactionCollection.Add(boletoTransaction);

            return this.Create(boletoTransactionCollection, orderReference);
        }
        
        /// /// <summary>
        /// Cria uma venda com uma coleção de boletos
        /// </summary>
        /// <param name="boletoTransactionCollection">Coleção de boletos</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(Collection<BoletoTransaction> boletoTransactionCollection) {

            return this.Create(boletoTransactionCollection, null);
        }

        /// <summary>
        /// Cria uma transação de boleto
        /// </summary>
        /// <param name="boletoTransaction">Dados da transação de boleto</param>
        /// <returns></returns>
        public HttpResponse<CreateSaleResponse> Create(BoletoTransaction boletoTransaction) {

            return this.Create(boletoTransaction, null);
        }

        #endregion

        #region Manage

        /// <summary>
        /// Gerencia uam venda
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="manageSaleRequest">Dados da venda</param>
        /// <returns></returns>
        public HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, ManageSaleRequest manageSaleRequest) {

            // Configura o action que será utilizado
            string actionName = manageOperation.ToString();

            // Configura MerchantKey e o header
            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            // Envia requisição
            return this.HttpUtility.SubmitRequest<ManageSaleRequest, ManageSaleResponse>(manageSaleRequest,
                string.Concat(this.HostUri, this.ResourceName, "/", actionName), HttpVerbEnum.Post, HttpContentTypeEnum.Json, headers);
        }

        /// <summary>
        /// Gerencia uma venda
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="orderKey">Chave do pedido</param>
        /// <returns></returns>
        public HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, Guid orderKey) {

            ManageSaleRequest manageSaleRequest = new ManageSaleRequest();
            manageSaleRequest.OrderKey = orderKey;

            return this.Manage(manageOperation, manageSaleRequest);
        }


        /// <summary>
        /// Gerencia uma coleção de transações de cartão de crédito.
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="orderKey">Chave do pedido</param>
        /// <param name="manageCreditCardTransactionCollection">Coleção de transações que serão gerenciadas</param>
        /// <returns></returns>
        public HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, Guid orderKey, Collection<ManageCreditCardTransaction> manageCreditCardTransactionCollection) {

            ManageSaleRequest manageSaleRequest = new ManageSaleRequest();
            manageSaleRequest.OrderKey = orderKey;
            manageSaleRequest.CreditCardTransactionCollection = manageCreditCardTransactionCollection;

            return this.Manage(manageOperation, manageSaleRequest);
        }

        /// <summary>
        /// Gerencia uma transação de cartão de crédito específica
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="orderKey">Chave do pedido</param>
        /// <param name="manageCreditCardTransaction">Dados da transação que será gerenciada</param>
        /// <returns></returns>
        public HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, Guid orderKey, ManageCreditCardTransaction manageCreditCardTransaction) {

            Collection<ManageCreditCardTransaction> manageCreditCardTransactionCollection = new Collection<ManageCreditCardTransaction>();
            manageCreditCardTransactionCollection.Add(manageCreditCardTransaction);

            return this.Manage(manageOperation, orderKey, manageCreditCardTransactionCollection);
        }

        #endregion

        #region Retry

        public HttpResponse<RetrySaleResponse> Retry(RetrySaleRequest retrySaleRequest) {

            // Configura MerchantKey e o header
            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            // Envia requisição
            return this.HttpUtility.SubmitRequest<RetrySaleRequest, RetrySaleResponse>(retrySaleRequest,
                string.Concat(this.HostUri, this.ResourceName, "/Retry"), HttpVerbEnum.Post, HttpContentTypeEnum.Json, headers);
        }

        public HttpResponse<RetrySaleResponse> Retry(Guid orderKey) {

            RetrySaleRequest retrySaleRequest = new RetrySaleRequest();
            retrySaleRequest.OrderKey = orderKey;

            return this.Retry(retrySaleRequest);
        }

        public HttpResponse<RetrySaleResponse> Retry(Guid orderKey, Collection<RetrySaleCreditCardTransaction> retrySaleCreditCardTransactionCollection) {

            RetrySaleRequest retrySaleRequest = new RetrySaleRequest();
            retrySaleRequest.OrderKey = orderKey;
            retrySaleRequest.RetrySaleCreditCardTransactionCollection = retrySaleCreditCardTransactionCollection;

            return this.Retry(retrySaleRequest);
        }

        public HttpResponse<RetrySaleResponse> Retry(Guid orderKey, RetrySaleCreditCardTransaction retrySaleCreditCardTransaction) {

            Collection<RetrySaleCreditCardTransaction> retrySaleCreditCardTransactionCollection = new Collection<RetrySaleCreditCardTransaction>();
            retrySaleCreditCardTransactionCollection.Add(retrySaleCreditCardTransaction);

            return this.Retry(orderKey, retrySaleCreditCardTransactionCollection);
        }

        #endregion

        #region Query

        /// <summary>
        /// Consulta uma venda
        /// </summary>
        /// <param name="orderKey">Chave da loja</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryOrder(Guid orderKey) {
            return this.QueryImplementation("OrderKey", orderKey.ToString());
        }

        /// <summary>
        /// Consulta uma venda
        /// </summary>
        /// <param name="orderReference">Identificador do pedido no sistema da loja</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryOrder(string orderReference) {
            return this.QueryImplementation("OrderReference", orderReference);
        }

        /// <summary>
        /// Consulta uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionKey">Chave da transação de cartão de crédito</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryCreditCardTransaction(Guid creditCardTransactionKey) {
            return this.QueryImplementation("CreditCardTransactionKey", creditCardTransactionKey.ToString());
        }

        /// <summary>
        /// Consulta uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionReference">Identificador da transação no sistema da loja</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryCreditCardTransaction(string creditCardTransactionReference) {
            return this.QueryImplementation("CreditCardTransactionReference", creditCardTransactionReference);
        }

        /// <summary>
        /// Consulta uma transação de boleto
        /// </summary>
        /// <param name="boletoTransactionKey">Chave da transação de boleto</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryBoletoTransaction(Guid boletoTransactionKey) {
            return this.QueryImplementation("BoletoTransactionKey", boletoTransactionKey.ToString());
        }

        /// <summary>
        /// Consulta uma transação de boleto
        /// </summary>
        /// <param name="boletoTransactionReference">Identificador da transação no sistema da loja</param>
        /// <returns></returns>
        public HttpResponse<QuerySaleResponse> QueryBoletoTransaction(string boletoTransactionReference) {
            return this.QueryImplementation("BoletoTransactionReference", boletoTransactionReference);
        }

        /// <summary>
        /// Implementação da chamada do método Query
        /// </summary>
        /// <param name="identifierName">Nome do identificador utilizado para realizar a consulta</param>
        /// <param name="value">Identificador utilizado para realizar a consulta</param>
        /// <returns></returns>
        private HttpResponse<QuerySaleResponse> QueryImplementation(string identifierName, string value) {

            string actionName = string.Format("/Query/{0}={1}", identifierName, value);

            HttpVerbEnum httpVerb = HttpVerbEnum.Get;

            NameValueCollection headers = this.GetHeaders();
            headers.Add("MerchantKey", this.MerchantKey.ToString());

            return this.HttpUtility.SubmitRequest<QuerySaleResponse>(string.Concat(this.HostUri, this.ResourceName, actionName), httpVerb, HttpContentTypeEnum.Json, headers);
        }

        #endregion
    }
}
