using System;
using System.Globalization;
using System.IO;
using GatewayApiClient.TransactionReportFile.Report;

namespace GatewayApiClient.TransactionReportFile.Parsers {

    internal class OnlineDebitTransactionParser : IReportItemParser {

        private OnlineDebitTransactionParser() { }

        private static OnlineDebitTransactionParser _instance = null;

        public static OnlineDebitTransactionParser GetInstance() {

            if (OnlineDebitTransactionParser._instance == null) {
                OnlineDebitTransactionParser._instance = new OnlineDebitTransactionParser();
            }

            return OnlineDebitTransactionParser._instance;
        }

        public IReportItem Parse(string[] elements) {

            if (elements.Length < 16) {
                throw new InvalidDataException("The expected parameter count is 16");
            }

            OnlineDebitTransaction onlineDebitTransaction = new OnlineDebitTransaction();

            onlineDebitTransaction.Order = new Order();
            onlineDebitTransaction.Order.OrderKey = Guid.Parse(elements[Constants.IDX_ODT_ORDER_ORDER_KEY]);
            onlineDebitTransaction.Order.OrderReference = elements[Constants.IDX_ODT_ORDER_ORDER_REFERENCE];
            onlineDebitTransaction.Order.MerchantKey = Guid.Parse(elements[Constants.IDX_ODT_ORDER_MERCHANT_KEY]);
            onlineDebitTransaction.Order.MerchantName = elements[Constants.IDX_ODT_ORDER_MERCHANT_NAME];

            onlineDebitTransaction.TransactionKey = Guid.Parse(elements[Constants.IDX_ODT_TRANSACTION_KEY]);
            onlineDebitTransaction.TransactionReference = elements[Constants.IDX_ODT_TRANSACTION_REFERENCE];
            onlineDebitTransaction.Bank = elements[Constants.IDX_ODT_BANK];
            onlineDebitTransaction.Status = elements[Constants.IDX_ODT_STATUS];
            onlineDebitTransaction.AmountInCents = long.Parse(elements[Constants.IDX_ODT_AMOUNT_IN_CENTS]);
            onlineDebitTransaction.AmountPaidInCents = string.IsNullOrWhiteSpace(elements[Constants.IDX_ODT_AMOUNT_PAID_IN_CENTS]) == false ? long.Parse(elements[Constants.IDX_ODT_AMOUNT_PAID_IN_CENTS]) : 0;
            onlineDebitTransaction.PaymentDate = string.IsNullOrWhiteSpace(elements[Constants.IDX_ODT_PAYMENT_DATE]) == false ? DateTime.ParseExact(elements[Constants.IDX_ODT_PAYMENT_DATE], Constants.ODT_DATE_TIME_FORMAT, CultureInfo.InvariantCulture) : (DateTime?)null;
            onlineDebitTransaction.BankReturnCode = elements[Constants.IDX_ODT_BANK_RETURN_CODE];
            onlineDebitTransaction.BankPaymentDate = elements[Constants.IDX_ODT_BANK_PAYMENT_DATE];
            onlineDebitTransaction.Signature = elements[Constants.IDX_ODT_SIGNATURE];
            onlineDebitTransaction.TransactionKeyToBank = elements[Constants.IDX_ODT_TRANSACTION_KEY_TO_BANK];

            return onlineDebitTransaction;
        }
    }
}
