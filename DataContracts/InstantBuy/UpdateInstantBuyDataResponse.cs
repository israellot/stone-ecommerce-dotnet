using System.Runtime.Serialization;

namespace GatewayApiClient.DataContracts {

    [DataContract(Namespace = "")]
    public class UpdateInstantBuyDataResponse : BaseResponse {

        /// <summary>
        /// Indicador de sucesso
        /// </summary>
        [DataMember]
        public bool Success { get; set; }
    }
}
