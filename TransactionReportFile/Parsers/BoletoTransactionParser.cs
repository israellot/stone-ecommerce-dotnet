using System;
using System.Globalization;
using System.IO;
using GatewayApiClient.TransactionReportFile.Report;

namespace GatewayApiClient.TransactionReportFile.Parsers {

    internal class BoletoTransactionParser : IReportItemParser {

        private BoletoTransactionParser() { }

        private static BoletoTransactionParser _instance = null;

        public static BoletoTransactionParser GetInstance() {

            if (BoletoTransactionParser._instance == null) {
                BoletoTransactionParser._instance = new BoletoTransactionParser();
            }

            return BoletoTransactionParser._instance;
        }

        public IReportItem Parse(string[] elements) {

            if (elements.Length < 18) {
                throw new InvalidDataException("The expected parameter count is 18");
            }

            BoletoTransaction boletoTransaction = new BoletoTransaction();

            boletoTransaction.Order = new Order();
            boletoTransaction.Order.OrderKey = Guid.Parse(elements[Constants.IDX_BT_ORDER_ORDER_KEY]);
            boletoTransaction.Order.OrderReference = elements[Constants.IDX_BT_ORDER_ORDER_REFERENCE];
            boletoTransaction.Order.MerchantKey = Guid.Parse(elements[Constants.IDX_BT_ORDER_MERCHANT_KEY]);
            boletoTransaction.Order.MerchantName = elements[Constants.IDX_BT_ORDER_MERCHANT_NAME];

            boletoTransaction.TransactionKey = Guid.Parse(elements[Constants.IDX_BT_TRANSACTION_KEY]);
            boletoTransaction.TransactionReference = elements[Constants.IDX_BT_TRANSACTION_REFERENCE];
            boletoTransaction.Status = elements[Constants.IDX_BT_STATUS];
            boletoTransaction.NossoNumero = elements[Constants.IDX_BT_NOSSO_NUMERO];
            boletoTransaction.BankNumber = elements[Constants.IDX_BT_BANK_NUMBER];
            boletoTransaction.Agency = elements[Constants.IDX_BT_AGENCY];
            boletoTransaction.Account = elements[Constants.IDX_BT_ACCOUNT];
            boletoTransaction.BarCode = elements[Constants.IDX_BT_BARCODE];
            boletoTransaction.ExpirationDate = DateTime.ParseExact(elements[Constants.IDX_BT_EXPIRATION_DATE], Constants.BT_DATE_TIME_FORMAT, CultureInfo.InvariantCulture);
            boletoTransaction.AmountInCents = long.Parse(elements[Constants.IDX_BT_AMOUNT_IN_CENTS]);
            boletoTransaction.AmountPaidInCents = string.IsNullOrWhiteSpace(elements[Constants.IDX_BT_AMOUNT_PAID_IN_CENTS]) == false ? long.Parse(elements[Constants.IDX_BT_AMOUNT_PAID_IN_CENTS]) : 0;
            boletoTransaction.PaymentDate = string.IsNullOrWhiteSpace(elements[Constants.IDX_BT_PAYMENT_DATE]) == false ? DateTime.ParseExact(elements[Constants.IDX_BT_PAYMENT_DATE], Constants.BT_DATE_TIME_FORMAT, CultureInfo.InvariantCulture) : (DateTime?)null;
            boletoTransaction.CreditDate = string.IsNullOrWhiteSpace(elements[Constants.IDX_BT_CREDIT_DATE]) == false ? DateTime.ParseExact(elements[Constants.IDX_BT_CREDIT_DATE], Constants.BT_DATE_TIME_FORMAT, CultureInfo.InvariantCulture) : (DateTime?)null;

            return boletoTransaction;
        }
    }
}
