using System.Runtime.Serialization;

namespace GatewayApiClient.Notification.Contracts.Enum {

    public enum OrderStatusEnum {

        /// <summary>
        /// Aberto
        /// </summary>
        [EnumMember]
        Opened = 1,

        /// <summary>
        /// Fechado
        /// </summary>
        [EnumMember]
        Closed = 2,

        /// <summary>
        /// Pago
        /// </summary>
        [EnumMember]
        Paid = 3,

        /// <summary>
        /// Pago a maior
        /// </summary>
        [EnumMember]
        Overpaid = 4,

        /// <summary>
        /// Cancelado
        /// </summary>
        [EnumMember]
        Canceled = 5,

        /// <summary>
        /// Pago parcialmente
        /// </summary>
        [EnumMember]
        PartialPaid = 6,

        /// <summary>
        /// Com erro
        /// </summary>
        [EnumMember]
        WithError = 7
    }
}
