using System.Runtime.Serialization;

namespace GatewayApiClient.DataContracts.EnumTypes {

    /// <summary>
    /// Sexo
    /// </summary>
    [DataContract]
    public enum GenderEnum {
        
        /// <summary>
        /// Masculino
        /// </summary>
        [EnumMember]
        M = 1,

        /// <summary>
        /// Feminino
        /// </summary>
        [EnumMember]
        F = 2
    }
}