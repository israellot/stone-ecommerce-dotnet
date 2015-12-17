using System.Runtime.Serialization;

namespace GatewayApiClient.DataContracts.EnumTypes {

    /// <summary>
    /// Categoria do comprador
    /// </summary>
    [DataContract]
    public enum BuyerCategoryEnum {

        /// <summary>
        /// Normal
        /// </summary>
        [DataMember]
        Normal = 1,

        /// <summary>
        /// Plus
        /// </summary>
        [DataMember]
        Plus = 1,
    }
}