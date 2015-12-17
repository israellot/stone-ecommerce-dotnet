using System;
using System.Collections.ObjectModel;
using GatewayApiClient.DataContracts;
using GatewayApiClient.EnumTypes;
using GatewayApiClient.Utility;

namespace GatewayApiClient.ResourceClients.Interfaces {

    public interface ISaleResource : IBaseResource {

        #region Create

        /// <summary>
        /// Cria uma venda, contendo transações de boleto e/ou cartão de crédito
        /// </summary>
        /// <param name="createSaleRequest">Dados da venda</param>
        /// <returns></returns>
        HttpResponse<CreateSaleResponse> Create(CreateSaleRequest createSaleRequest);

        /// <summary>
        /// Cria uma venda com uma coleção de transações de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionCollection">Coleção de transações de cartão de crédito</param>
        /// <param name="orderReference">Identificação do pedido na loja</param>
        /// <returns></returns>
        HttpResponse<CreateSaleResponse> Create(Collection<CreditCardTransaction> creditCardTransactionCollection, string orderReference);

        /// <summary>
        /// Cria uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransaction">Dados da transação de cartão de crédito</param>
        /// <param name="orderReference">Identificação do pedido na loja</param>
        /// <returns></returns>
        HttpResponse<CreateSaleResponse> Create(CreditCardTransaction creditCardTransaction, string orderReference);

        /// <summary>
        /// Cria uma venda com uma coleção de transações de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionCollection">Coleção de transações de cartão de crédito</param>
        /// <returns></returns>
        HttpResponse<CreateSaleResponse> Create(Collection<CreditCardTransaction> creditCardTransactionCollection);

        /// <summary>
        /// Cria uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransaction">Dados da transação de cartão de crédito</param>
        /// <returns></returns>
        HttpResponse<CreateSaleResponse> Create(CreditCardTransaction creditCardTransaction);

        /// <summary>
        /// Cria uma venda com uma coleção de boletos
        /// </summary>
        /// <param name="boletoTransactionCollection">Coleção de boletos</param>
        /// <param name="orderReference">Identificação do pedido na loja</param>
        /// <returns></returns>
        HttpResponse<CreateSaleResponse> Create(Collection<BoletoTransaction> boletoTransactionCollection, string orderReference);

        /// <summary>
        /// Cria uma transação de boleto
        /// </summary>
        /// <param name="boletoTransaction">Dados da transação de boleto</param>
        /// <param name="orderReference">Identificação do pedido na loja</param>
        /// <returns></returns>
        HttpResponse<CreateSaleResponse> Create(BoletoTransaction boletoTransaction, string orderReference);

        /// <summary>
        /// Cria uma venda com uma coleção de boletos
        /// </summary>
        /// <param name="boletoTransactionCollection">Coleção de boletos</param>
        /// <returns></returns>
        HttpResponse<CreateSaleResponse> Create(Collection<BoletoTransaction> boletoTransactionCollection);

        /// <summary>
        /// Cria uma transação de boleto
        /// </summary>
        /// <param name="boletoTransaction">Dados da transação de boleto</param>
        /// <returns></returns>
        HttpResponse<CreateSaleResponse> Create(BoletoTransaction boletoTransaction);

        #endregion

        #region Manage

        /// <summary>
        /// Gerencia uam venda
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="manageSaleRequest">Dados da venda</param>
        /// <returns></returns>
        HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, ManageSaleRequest manageSaleRequest);

        /// <summary>
        /// Gerencia uma venda
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="orderKey">Chave do pedido</param>
        /// <returns></returns>
        HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, Guid orderKey);

        /// <summary>
        /// Gerencia uma coleção de transações de cartão de crédito.
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="orderKey">Chave do pedido</param>
        /// <param name="manageCreditCardTransactionCollection">Coleção de transações que serão gerenciadas</param>
        /// <returns></returns>
        HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, Guid orderKey, Collection<ManageCreditCardTransaction> manageCreditCardTransactionCollection);

        /// <summary>
        /// Gerencia uma transação de cartão de crédito específica
        /// </summary>
        /// <param name="manageOperation">Operação que deverá ser executada (captura ou cancelamento)</param>
        /// <param name="orderKey">Chave do pedido</param>
        /// <param name="manageCreditCardTransaction">Dados da transação que será gerenciada</param>
        /// <returns></returns>
        HttpResponse<ManageSaleResponse> Manage(ManageOperationEnum manageOperation, Guid orderKey, ManageCreditCardTransaction manageCreditCardTransaction);

        #endregion

        #region Retry

        /// <summary>
        /// Retenta as transações de cartão de crédito não autorizadas de uma venda
        /// </summary>
        /// <param name="retrySaleRequest">Dados da venda que terá as transações retentadas</param>
        /// <returns></returns>
        HttpResponse<RetrySaleResponse> Retry(RetrySaleRequest retrySaleRequest);

        /// <summary>
        /// Retenta as transações de cartão de crédito não autorizadas de uma venda
        /// </summary>
        /// <param name="orderKey">Chave do pedido</param>
        /// <returns></returns>
        HttpResponse<RetrySaleResponse> Retry(Guid orderKey);

        /// <summary>
        /// Retenta uma coleção de transações de cartão de crédito não autorizadas
        /// </summary>
        /// <param name="orderKey">Chave do pedido</param>
        /// <param name="retrySaleCreditCardTransactionCollection">Coleção de transações que serão retentadas</param>
        /// <returns></returns>
        HttpResponse<RetrySaleResponse> Retry(Guid orderKey, Collection<RetrySaleCreditCardTransaction> retrySaleCreditCardTransactionCollection);

        /// <summary>
        /// Retenta uma transação de cartão de crédito não autorizada
        /// </summary>
        /// <param name="orderKey">Chave do pedido</param>
        /// <param name="retrySaleCreditCardTransaction">Dados da transação que será retentada</param>
        /// <returns></returns>
        HttpResponse<RetrySaleResponse> Retry(Guid orderKey, RetrySaleCreditCardTransaction retrySaleCreditCardTransaction);

        #endregion

        #region Query

        /// <summary>
        /// Consulta uma venda
        /// </summary>
        /// <param name="orderKey">Chave da loja</param>
        /// <returns></returns>
        HttpResponse<QuerySaleResponse> QueryOrder(Guid orderKey);

        /// <summary>
        /// Consulta uma venda
        /// </summary>
        /// <param name="orderReference">Identificador do pedido no sistema da loja</param>
        /// <returns></returns>
        HttpResponse<QuerySaleResponse> QueryOrder(string orderReference);

        /// <summary>
        /// Consulta uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionKey">Chave da transação de cartão de crédito</param>
        /// <returns></returns>
        HttpResponse<QuerySaleResponse> QueryCreditCardTransaction(Guid creditCardTransactionKey);

        /// <summary>
        /// Consulta uma transação de cartão de crédito
        /// </summary>
        /// <param name="creditCardTransactionReference">Identificador da transação no sistema da loja</param>
        /// <returns></returns>
        HttpResponse<QuerySaleResponse> QueryCreditCardTransaction(string creditCardTransactionReference);

        /// <summary>
        /// Consulta uma transação de boleto
        /// </summary>
        /// <param name="boletoTransactionKey">Chave da transação de boleto</param>
        /// <returns></returns>
        HttpResponse<QuerySaleResponse> QueryBoletoTransaction(Guid boletoTransactionKey);

        /// <summary>
        /// Consulta uma transação de boleto
        /// </summary>
        /// <param name="boletoTransactionReference">Identificador da transação no sistema da loja</param>
        /// <returns></returns>
        HttpResponse<QuerySaleResponse> QueryBoletoTransaction(string boletoTransactionReference);

        #endregion
    }
}
