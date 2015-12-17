using System;
using System.Runtime.Serialization;
using GatewayApiClient.DataContracts.EnumTypes;

namespace GatewayApiClient.DataContracts {

    [DataContract(Name = "BoletoTransactionOptions", Namespace = "")]
    public class BoletoTransactionOptions {

        /// <summary>
        /// Total de dias para expirar o boleto
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Nullable<int> DaysToAddInBoletoExpirationDate { get; set; }

        /// <summary>
        /// Url para notificação da transação
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string NotificationUrl { get; set; }

        /// <summary>
        /// Indica se a transação vai precisar ser notificada
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Nullable<bool> IsNotificationEnabled { get; set; }

        #region CurrencyIso

        /// <summary>
        /// Moeda. Opções: BRL, EUR, USD, ARS, BOB, CLP, COP, UYU, MXN, PYG
        /// </summary>
        [DataMember(Name = "CurrencyIso", EmitDefaultValue = false)]
        private string CurrencyIsoField {
            get {
                if (this.CurrencyIso == null) { return null; }
                return this.CurrencyIso.ToString();
            }
            set {
                if (value == null) {
                    this.CurrencyIso = null;
                }
                else {
                    this.CurrencyIso = (CurrencyIsoEnum)Enum.Parse(typeof(CurrencyIsoEnum), value);
                }
            }
        }

        /// <summary>
        /// Moeda. Opções: BRL, EUR, USD, ARS, BOB, CLP, COP, UYU, MXN, PYG
        /// </summary>
        public Nullable<CurrencyIsoEnum> CurrencyIso { get; set; }

        #endregion
    }
}