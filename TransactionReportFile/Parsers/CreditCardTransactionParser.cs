using System;
using System.IO;
using GatewayApiClient.TransactionReportFile.Report;

namespace GatewayApiClient.TransactionReportFile.Parsers {

    internal class CreditCardTransactionParser : IReportItemParser {

        private CreditCardTransactionParser() { }

        private static CreditCardTransactionParser _instance = null;

        public static CreditCardTransactionParser GetInstance() {

            if (CreditCardTransactionParser._instance == null) {
                CreditCardTransactionParser._instance = new CreditCardTransactionParser();
            }

            return CreditCardTransactionParser._instance;
        }

        public IReportItem Parse(string[] elements) {

            if (elements.Length < 27) {
                throw new InvalidDataException("The expected parameter count is 27");
            }

            CreditCardTransaction creditCardTransaction = new CreditCardTransaction();

            creditCardTransaction.Order = new Order();
            creditCardTransaction.Order.OrderKey = Guid.Parse(elements[Constants.IDX_CCT_ORDER_ORDER_KEY]);
            creditCardTransaction.Order.OrderReference = elements[Constants.IDX_CCT_ORDER_ORDER_REFERENCE];
            creditCardTransaction.Order.MerchantKey = Guid.Parse(elements[Constants.IDX_CCT_ORDER_MERCHANT_KEY]);
            creditCardTransaction.Order.MerchantName = elements[Constants.IDX_CCT_ORDER_MERCHANT_NAME];

            creditCardTransaction.TransactionKey = Guid.Parse(elements[Constants.IDX_CCT_TRANSACTION_KEY]);
            creditCardTransaction.TransactionKeyToAcquirer = elements[Constants.IDX_CCT_TRANSACTION_KEY_TO_ACQUIRER];
            creditCardTransaction.TransactionReference = elements[Constants.IDX_CCT_TRANSACTION_REFERENCE];
            creditCardTransaction.CreditCardBrand = elements[Constants.IDX_CCT_CREDIT_CARD_BRAND];
            creditCardTransaction.CreditCardNumber = elements[Constants.IDX_CCT_CREDIT_CARD_NUMBER];
            creditCardTransaction.InstallmentCount = string.IsNullOrWhiteSpace(elements[Constants.IDX_CCT_INSTALLMENT_COUNT]) == false ? int.Parse(elements[Constants.IDX_CCT_INSTALLMENT_COUNT]) : 0;
            creditCardTransaction.AcquirerName = elements[Constants.IDX_CCT_ACQUIRER_NAME];
            creditCardTransaction.Status = elements[Constants.IDX_CCT_STATUS];
            creditCardTransaction.AmountInCents = string.IsNullOrWhiteSpace(elements[Constants.IDX_CCT_AMOUNT_IN_CENTS]) == false ? int.Parse(elements[Constants.IDX_CCT_AMOUNT_IN_CENTS]) : 0;
            creditCardTransaction.IataAmountInCents = string.IsNullOrWhiteSpace(elements[Constants.IDX_CCT_IATA_AMOUNT_IN_CENTS]) == false ? int.Parse(elements[Constants.IDX_CCT_IATA_AMOUNT_IN_CENTS]) : 0;
            creditCardTransaction.AuthorizationCode = elements[Constants.IDX_CCT_AUTHORIZATION_CODE];
            creditCardTransaction.TransactionIdentifier = elements[Constants.IDX_CCT_TRANSACTION_IDENTIFIER];
            creditCardTransaction.UniqueSequentialNumber = elements[Constants.IDX_CCT_UNIQUE_SEQUENTIAL_NUMBER];
            creditCardTransaction.AuthorizedAmountInCents = string.IsNullOrWhiteSpace(elements[Constants.IDX_CCT_AUTHORIZED_AMOUNT_IN_CENTS]) == false ? long.Parse(elements[Constants.IDX_CCT_AUTHORIZED_AMOUNT_IN_CENTS]) : 0;
            creditCardTransaction.CapturedAmountInCents = string.IsNullOrWhiteSpace(elements[Constants.IDX_CCT_CAPTURED_AMOUNT_IN_CENTS]) == false ? long.Parse(elements[Constants.IDX_CCT_CAPTURED_AMOUNT_IN_CENTS]) : 0;
            creditCardTransaction.VoidedAmountInCents = string.IsNullOrWhiteSpace(elements[Constants.IDX_CCT_VOIDED_AMOUNT_IN_CENTS]) == false ? long.Parse(elements[Constants.IDX_CCT_VOIDED_AMOUNT_IN_CENTS]) : 0;
            creditCardTransaction.RefundedAmountInCents = string.IsNullOrWhiteSpace(elements[Constants.IDX_CCT_REFUNDED_AMOUNT_IN_CENTS]) == false ? long.Parse(elements[Constants.IDX_CCT_REFUNDED_AMOUNT_IN_CENTS]) : 0;
            creditCardTransaction.AcquirerAuthorizationReturnCode = elements[Constants.IDX_CCT_ACQUIRER_AUTHORIZATION_RETURN_CODE];
            creditCardTransaction.AuthorizedDate = string.IsNullOrWhiteSpace(elements[Constants.IDX_CCT_AUTHORIZED_DATE]) == false ? DateTime.ParseExact(elements[Constants.IDX_CCT_AUTHORIZED_DATE], Constants.CCT_DATE_TIME_FORMAT, null) : (DateTime?)null;
            creditCardTransaction.CapturedDate = string.IsNullOrWhiteSpace(elements[Constants.IDX_CCT_CAPTURED_DATE]) == false ? DateTime.ParseExact(elements[Constants.IDX_CCT_CAPTURED_DATE], Constants.CCT_DATE_TIME_FORMAT, null) : (DateTime?)null;
            creditCardTransaction.VoidedDate = string.IsNullOrWhiteSpace(elements[Constants.IDX_CCT_VOIDED_DATE]) == false ? DateTime.ParseExact(elements[Constants.IDX_CCT_VOIDED_DATE], Constants.CCT_DATE_TIME_FORMAT, null) : (DateTime?)null;
            creditCardTransaction.LastProbeDate = string.IsNullOrWhiteSpace(elements[Constants.IDX_CCT_LAST_PROBE_DATE]) == false ? DateTime.ParseExact(elements[Constants.IDX_CCT_LAST_PROBE_DATE], Constants.CCT_DATE_TIME_FORMAT, null) : (DateTime?)null;

            return creditCardTransaction;
        }
    }
}
