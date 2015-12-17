namespace GatewayApiClient.TransactionReportFile {

    internal static class Constants {

        // Date/Time Formats.
        public const string DATE_FORMAT = "yyyyMMdd";
        public const string HDR_DATE_TIME_FORMAT = "yyyyMMdd HH:mm:ss";
        public const string CCT_DATE_TIME_FORMAT = "yyyy-MM-ddTHH:mm:ss";
        public const string BT_DATE_TIME_FORMAT = "M/d/yyyy h:mm:ss tt";
        public const string ODT_DATE_TIME_FORMAT = "M/d/yyyy h:mm:ss tt";

        // Header Index Constants
        public const int IDX_HDR_TRANSACTION_PROCESSED_DATE = 1;
        public const int IDX_HDR_REPORT_FILE_CREATE_DATE = 2;
        public const int IDX_HDR_VERSION = 3;

        // Trailer Index Constants
        public const int IDX_TRL_ORDER_DATA_COUNT = 1;
        public const int IDX_TRL_CREDIT_CARD_TRANSACTION_DATA_COUNT = 2;
        public const int IDX_TRL_BOLETO_TRANSACTION_DATA_COUNT = 3;
        public const int IDX_TRL_ONLINE_DEBIT_TRANSACTION_DATA_COUNT = 4;

        // Credit Card Index Constants
        public const int IDX_CCT_ORDER_ORDER_KEY = 1;
        public const int IDX_CCT_ORDER_ORDER_REFERENCE = 2;
        public const int IDX_CCT_ORDER_MERCHANT_KEY = 3;
        public const int IDX_CCT_ORDER_MERCHANT_NAME = 4;
        public const int IDX_CCT_TRANSACTION_KEY = 5;
        public const int IDX_CCT_TRANSACTION_KEY_TO_ACQUIRER = 6;
        public const int IDX_CCT_TRANSACTION_REFERENCE = 7;
        public const int IDX_CCT_CREDIT_CARD_BRAND = 8;
        public const int IDX_CCT_CREDIT_CARD_NUMBER = 9;
        public const int IDX_CCT_INSTALLMENT_COUNT = 10;
        public const int IDX_CCT_ACQUIRER_NAME = 11;
        public const int IDX_CCT_STATUS = 12;
        public const int IDX_CCT_AMOUNT_IN_CENTS = 13;
        public const int IDX_CCT_IATA_AMOUNT_IN_CENTS = 14;
        public const int IDX_CCT_AUTHORIZATION_CODE = 15;
        public const int IDX_CCT_TRANSACTION_IDENTIFIER = 16;
        public const int IDX_CCT_UNIQUE_SEQUENTIAL_NUMBER = 17;
        public const int IDX_CCT_AUTHORIZED_AMOUNT_IN_CENTS = 18;
        public const int IDX_CCT_CAPTURED_AMOUNT_IN_CENTS = 19;
        public const int IDX_CCT_VOIDED_AMOUNT_IN_CENTS = 20;
        public const int IDX_CCT_REFUNDED_AMOUNT_IN_CENTS = 21;
        public const int IDX_CCT_ACQUIRER_AUTHORIZATION_RETURN_CODE = 22;
        public const int IDX_CCT_AUTHORIZED_DATE = 23;
        public const int IDX_CCT_CAPTURED_DATE = 24;
        public const int IDX_CCT_VOIDED_DATE = 25;
        public const int IDX_CCT_LAST_PROBE_DATE = 26;

        // Boleto Index Constants
        public const int IDX_BT_ORDER_ORDER_KEY = 1;
        public const int IDX_BT_ORDER_ORDER_REFERENCE = 2;
        public const int IDX_BT_ORDER_MERCHANT_KEY = 3;
        public const int IDX_BT_ORDER_MERCHANT_NAME = 4;
        public const int IDX_BT_TRANSACTION_KEY = 5;
        public const int IDX_BT_TRANSACTION_REFERENCE = 6;
        public const int IDX_BT_STATUS = 7;
        public const int IDX_BT_NOSSO_NUMERO = 8;
        public const int IDX_BT_BANK_NUMBER = 9;
        public const int IDX_BT_AGENCY = 10;
        public const int IDX_BT_ACCOUNT = 11;
        public const int IDX_BT_BARCODE = 12;
        public const int IDX_BT_EXPIRATION_DATE = 13;
        public const int IDX_BT_AMOUNT_IN_CENTS = 14;
        public const int IDX_BT_AMOUNT_PAID_IN_CENTS = 15;
        public const int IDX_BT_PAYMENT_DATE = 16;
        public const int IDX_BT_CREDIT_DATE = 17;

        // Online Debit Index Constants
        public const int IDX_ODT_ORDER_ORDER_KEY = 1;
        public const int IDX_ODT_ORDER_ORDER_REFERENCE = 2;
        public const int IDX_ODT_ORDER_MERCHANT_KEY = 3;
        public const int IDX_ODT_ORDER_MERCHANT_NAME = 4;
        public const int IDX_ODT_TRANSACTION_KEY = 5;
        public const int IDX_ODT_TRANSACTION_REFERENCE = 6;
        public const int IDX_ODT_BANK = 7;
        public const int IDX_ODT_STATUS = 8;
        public const int IDX_ODT_AMOUNT_IN_CENTS = 9;
        public const int IDX_ODT_AMOUNT_PAID_IN_CENTS = 10;
        public const int IDX_ODT_PAYMENT_DATE = 11;
        public const int IDX_ODT_BANK_RETURN_CODE = 12;
        public const int IDX_ODT_BANK_PAYMENT_DATE = 13;
        public const int IDX_ODT_SIGNATURE = 14;
        public const int IDX_ODT_TRANSACTION_KEY_TO_BANK = 15;
    }
}
