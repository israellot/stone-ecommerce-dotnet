using System;
using System.Collections.Generic;
using System.IO;

namespace GatewayApiClient.TransactionReportFile.Report {

    public class TransactionReport {

        public Header Header { get; set; }

        public Trailer Trailer { get; set; }

        public IList<BoletoTransaction> BoletoTransactionCollection { get; set; }

        public IList<CreditCardTransaction> CreditCardTransactionCollection { get; set; }

        public IList<OnlineDebitTransaction> OnlineDebitTransactionCollection { get; set; }

        public TransactionReport() {
            this.BoletoTransactionCollection = new List<BoletoTransaction>();
            this.CreditCardTransactionCollection = new List<CreditCardTransaction>();
            this.OnlineDebitTransactionCollection = new List<OnlineDebitTransaction>();
        }

        internal void Add(IReportItem item) {

            if (item == null) { throw new ArgumentNullException("item"); }

            if (item is CreditCardTransaction) {
                this.CreditCardTransactionCollection.Add(item as CreditCardTransaction);
            }
            else if (item is BoletoTransaction) {
                this.BoletoTransactionCollection.Add(item as BoletoTransaction);
            }
            else if (item is OnlineDebitTransaction) {
                this.OnlineDebitTransactionCollection.Add(item as OnlineDebitTransaction);
            }
            else if (item is Header) {
                this.Header = item as Header;
            }
            else if (item is Trailer) {
                this.Trailer = item as Trailer;
            }
            else {
                throw new InvalidDataException("Unrecognized data type: " + item.GetType().Name);
            }
        }
    }
}
