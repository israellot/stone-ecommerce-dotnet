using System.Runtime.Serialization;

namespace GatewayApiClient.Notification.Contracts.Enum {

    public enum OnlineDebitTransactionStatusEnum {

        /// <summary>
        /// Criado
        /// </summary>
        [EnumMember]
        Created = 1,

        /// <summary>
        /// Aberto e pendente de pagamento
        /// </summary>
        [EnumMember]
        OpenedPendingPayment = 2,

        /// <summary>
        /// Não pago
        /// </summary>
        [EnumMember]
        NotPaid = 3,

        /// <summary>
        /// Pago
        /// </summary>
        [EnumMember]
        Paid = 4,

        /// <summary>
        /// Pago a menor
        /// </summary>
        [EnumMember]
        UnderPaid = 5,

        /// <summary>
        /// Pago a maior
        /// </summary>
        [EnumMember]
        OverPaid = 6,

        /// <summary>
        /// Não encontrado
        /// </summary>
        [EnumMember]
        NotFound = 7,

        /// <summary>
        /// Com erro
        /// </summary>
        [EnumMember]
        WithError = 99
    }
}
