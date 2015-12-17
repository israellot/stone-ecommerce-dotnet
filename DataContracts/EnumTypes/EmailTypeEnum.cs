using System.Runtime.Serialization;

namespace GatewayApiClient.DataContracts.EnumTypes {

    /// <summary>
    /// Tipo de e-mail
    /// </summary>
    [DataContract]
    public enum EmailTypeEnum {

        /// <summary>
        /// Comercial
        /// </summary>
        [EnumMember]
        Comercial = 1,

        /// <summary>
        /// Pessoal
        /// </summary>
        [EnumMember]
        Personal = 2
    }
}