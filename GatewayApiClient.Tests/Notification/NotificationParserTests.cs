using System;
using GatewayApiClient.Notification;
using GatewayApiClient.Notification.Contracts;
using GatewayApiClient.Notification.Contracts.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GatewayApiClient.Tests.Notification {

    [TestClass]
    public class NotificationParserTests {

        #region Full

        private readonly string fullNotification = @"<StatusNotification>
  <AmountInCents>8500</AmountInCents>
  <AmountPaidInCents>8500</AmountPaidInCents>
  <BoletoTransaction>
    <AmountInCents>1000</AmountInCents>
    <AmountPaidInCents>1000</AmountPaidInCents>
    <BoletoExpirationDate>2015-09-21T15:42:04.573</BoletoExpirationDate>
    <NossoNumero>0123456789</NossoNumero>
    <StatusChangedDate>2015-09-22T07:06:00.537</StatusChangedDate>
    <TransactionKey>F7C4B737-E8B5-4BAA-BB47-6ED2A1A1EE09</TransactionKey>
    <TransactionReference>6741137</TransactionReference>
    <PreviousBoletoTransactionStatus>Generated</PreviousBoletoTransactionStatus>
    <BoletoTransactionStatus>Paid</BoletoTransactionStatus>
  </BoletoTransaction>
  <CreditCardTransaction>
    <Acquirer>Simulator</Acquirer>
    <AmountInCents>500</AmountInCents>
    <AuthorizationCode>123456</AuthorizationCode>
    <AuthorizedAmountInCents>500</AuthorizedAmountInCents>
    <CapturedAmountInCents>500</CapturedAmountInCents>
    <CreditCardBrand>Mastercard</CreditCardBrand>
    <CustomStatus>String Content</CustomStatus>
    <RefundedAmountInCents>100</RefundedAmountInCents>
    <StatusChangedDate>2015-09-22T15:51:41.217</StatusChangedDate>
    <TransactionIdentifier>9876543210</TransactionIdentifier>
    <TransactionKey>4111D523-9A83-4BE3-94D2-160F1BC9C4BD</TransactionKey>
    <TransactionReference>91735820</TransactionReference>
    <UniqueSequentialNumber>63417982</UniqueSequentialNumber>
    <VoidedAmountInCents>100</VoidedAmountInCents>
    <PreviousCreditCardTransactionStatus>AuthorizedPendingCapture</PreviousCreditCardTransactionStatus>
    <CreditCardTransactionStatus>Captured</CreditCardTransactionStatus>
  </CreditCardTransaction>
  <MerchantKey>B1B1092C-8681-40C2-A734-500F22683D9B</MerchantKey>
  <OnlineDebitTransaction>
    <AmountInCents>7000</AmountInCents>
    <AmountPaidInCents>7000</AmountPaidInCents>
    <BankName>BancoDoBrasil</BankName>
    <BankPaymentDate>22092015</BankPaymentDate>
    <StatusChangedDate>2015-09-22T13:15:46.333</StatusChangedDate>
    <TransactionKey>751AE9F0-AF0B-4DE5-A483-2EFF2DE0FDF6</TransactionKey>
    <TransactionKeyToBank>00000000000012345</TransactionKeyToBank>
    <TransactionReference>656885531</TransactionReference>
    <PreviousOnlineDebitTransactionStatus>OpenedPendingPayment</PreviousOnlineDebitTransactionStatus>
    <OnlineDebitTransactionStatus>Paid</OnlineDebitTransactionStatus>
  </OnlineDebitTransaction>
  <OrderKey>1025FCB5-41D8-43B5-82FE-398F61E83879</OrderKey>
  <OrderReference>9623472</OrderReference>
  <OrderStatus>Paid</OrderStatus>
</StatusNotification>";

        #endregion

        #region CreditCard

        private readonly string creditCardNotification = @"<StatusNotification>
  <AmountInCents>500</AmountInCents>
  <AmountPaidInCents>500</AmountPaidInCents>
  <BoletoTransaction />
  <CreditCardTransaction>
    <Acquirer>Simulator</Acquirer>
    <AmountInCents>500</AmountInCents>
    <AuthorizationCode>123456</AuthorizationCode>
    <AuthorizedAmountInCents>500</AuthorizedAmountInCents>
    <CapturedAmountInCents>500</CapturedAmountInCents>
    <CreditCardBrand>Mastercard</CreditCardBrand>
    <CustomStatus />
    <RefundedAmountInCents />
    <StatusChangedDate>2015-09-22T15:51:41.217</StatusChangedDate>
    <TransactionIdentifier>9876543210</TransactionIdentifier>
    <TransactionKey>4111D523-9A83-4BE3-94D2-160F1BC9C4BD</TransactionKey>
    <TransactionReference>91735820</TransactionReference>
    <UniqueSequentialNumber>63417982</UniqueSequentialNumber>
    <VoidedAmountInCents />
    <PreviousCreditCardTransactionStatus>AuthorizedPendingCapture</PreviousCreditCardTransactionStatus>
    <CreditCardTransactionStatus>Captured</CreditCardTransactionStatus>
  </CreditCardTransaction>
  <MerchantKey>B1B1092C-8681-40C2-A734-500F22683D9B</MerchantKey>
  <OrderKey>18471F05-9F6D-4497-9C24-D60D5BBB6BBE</OrderKey>
  <OrderReference>64a85875</OrderReference>
  <OrderStatus>Paid</OrderStatus>
</StatusNotification>";

        #endregion

        #region Boleto

        private readonly string boletoNotification = @"<StatusNotification>
  <AmountInCents>1000</AmountInCents>
  <AmountPaidInCents>1000</AmountPaidInCents>
  <BoletoTransaction>
    <AmountInCents>1000</AmountInCents>
    <AmountPaidInCents>1000</AmountPaidInCents>
    <BoletoExpirationDate>2015-09-21T15:42:04.573</BoletoExpirationDate>
    <NossoNumero>0123456789</NossoNumero>
    <StatusChangedDate>2015-09-22T07:06:00.537</StatusChangedDate>
    <TransactionKey>F7C4B737-E8B5-4BAA-BB47-6ED2A1A1EE09</TransactionKey>
    <TransactionReference>6741137</TransactionReference>
    <PreviousBoletoTransactionStatus>Generated</PreviousBoletoTransactionStatus>
    <BoletoTransactionStatus>Paid</BoletoTransactionStatus>
  </BoletoTransaction>
  <CreditCardTransaction />
  <MerchantKey>B1B1092C-8681-40C2-A734-500F22683D9B</MerchantKey>
  <OrderKey>60365605-1D43-487D-AE4C-8B7DC5BAA213</OrderKey>
  <OrderReference>9657412</OrderReference>
  <OrderStatus>Paid</OrderStatus>
</StatusNotification>";

        #endregion

        #region OnlineDebit

        private readonly string onlineDebitNotification = @"<StatusNotification>
  <AmountInCents>7000</AmountInCents>
  <AmountPaidInCents>7000</AmountPaidInCents>
  <BoletoTransaction />
  <CreditCardTransaction />
  <MerchantKey>B1B1092C-8681-40C2-A734-500F22683D9B</MerchantKey>
  <OnlineDebitTransaction>
    <AmountInCents>7000</AmountInCents>
    <AmountPaidInCents>7000</AmountPaidInCents>
    <BankName>BancoDoBrasil</BankName>
    <BankPaymentDate>22092015</BankPaymentDate>
    <StatusChangedDate>2015-09-22T13:15:46.333</StatusChangedDate>
    <TransactionKey>751AE9F0-AF0B-4DE5-A483-2EFF2DE0FDF6</TransactionKey>
    <TransactionKeyToBank>00000000000012345</TransactionKeyToBank>
    <TransactionReference>656885531</TransactionReference>
    <PreviousOnlineDebitTransactionStatus>OpenedPendingPayment</PreviousOnlineDebitTransactionStatus>
    <OnlineDebitTransactionStatus>Paid</OnlineDebitTransactionStatus>
  </OnlineDebitTransaction>
  <OrderKey>1025FCB5-41D8-43B5-82FE-398F61E83879</OrderKey>
  <OrderReference>9623472</OrderReference>
  <OrderStatus>Paid</OrderStatus>
</StatusNotification>";

        #endregion

       [TestMethod]
        public void ParseNotification_CreditCard_Test() {

            NotificationParser notificationParser = new NotificationParser();

            StatusNotification statusNotification = null;

            statusNotification = notificationParser.ParseNotification(this.creditCardNotification);

            Assert.AreEqual(500, statusNotification.AmountInCents);
            Assert.AreEqual(500, statusNotification.AmountPaidInCents);
            Assert.IsNotNull(statusNotification.CreditCardTransaction);
            Assert.IsNull(statusNotification.OnlineDebitTransaction);
            Assert.AreEqual(Guid.Parse("B1B1092C-8681-40C2-A734-500F22683D9B"), statusNotification.MerchantKey);
            Assert.AreEqual(Guid.Parse("18471F05-9F6D-4497-9C24-D60D5BBB6BBE"), statusNotification.OrderKey);
            Assert.AreEqual("64a85875", statusNotification.OrderReference);
            Assert.AreEqual(OrderStatusEnum.Paid, statusNotification.OrderStatus);

            // CreditCardTransaction
            CreditCardTransaction creditCardTransaction = statusNotification.CreditCardTransaction;
            Assert.AreEqual("Simulator", creditCardTransaction.Acquirer);
            Assert.AreEqual(500, creditCardTransaction.AmountInCents);
            Assert.AreEqual("123456", creditCardTransaction.AuthorizationCode);
            Assert.AreEqual(500, creditCardTransaction.AuthorizedAmountInCents);
            Assert.AreEqual(500, creditCardTransaction.CapturedAmountInCents);
            Assert.AreEqual("Mastercard", creditCardTransaction.CreditCardBrand);
            Assert.IsTrue(string.IsNullOrEmpty(creditCardTransaction.CustomStatus));
            Assert.IsNull(creditCardTransaction.RefundedAmountInCents);
            Assert.AreEqual(this.ParseDateTime("2015-09-22T15:51:41.217"), creditCardTransaction.StatusChangedDate);
            Assert.AreEqual("9876543210", creditCardTransaction.TransactionIdentifier);
            Assert.AreEqual(Guid.Parse("4111D523-9A83-4BE3-94D2-160F1BC9C4BD"), creditCardTransaction.TransactionKey);
            Assert.AreEqual("91735820", creditCardTransaction.TransactionReference);
            Assert.AreEqual("63417982", creditCardTransaction.UniqueSequentialNumber);
            Assert.IsNull(creditCardTransaction.VoidedAmountInCents);
            Assert.AreEqual(CreditCardTransactionStatusEnum.AuthorizedPendingCapture, creditCardTransaction.PreviousCreditCardTransactionStatus);
            Assert.AreEqual(CreditCardTransactionStatusEnum.Captured, creditCardTransaction.CreditCardTransactionStatus);
        }

        [TestMethod]
        public void ParseNotification_Boleto_Test() {
            NotificationParser notificationParser = new NotificationParser();

            var statusNotification = notificationParser.ParseNotification(boletoNotification);

            Assert.AreEqual(1000, statusNotification.AmountInCents);
            Assert.AreEqual(1000, statusNotification.AmountPaidInCents);
            Assert.IsNotNull(statusNotification.BoletoTransaction);
            Assert.IsNull(statusNotification.OnlineDebitTransaction);
            Assert.AreEqual(Guid.Parse("B1B1092C-8681-40C2-A734-500F22683D9B"), statusNotification.MerchantKey);
            Assert.AreEqual(Guid.Parse("60365605-1D43-487D-AE4C-8B7DC5BAA213"), statusNotification.OrderKey);
            Assert.AreEqual("9657412", statusNotification.OrderReference);
            Assert.AreEqual(OrderStatusEnum.Paid, statusNotification.OrderStatus);

            // BoletoTransaction
            Assert.AreEqual(1000, statusNotification.BoletoTransaction.AmountInCents);
            Assert.AreEqual(1000, statusNotification.BoletoTransaction.AmountPaidInCents);
            Assert.AreEqual(ParseDateTime("2015-09-21T15:42:04.573"), statusNotification.BoletoTransaction.BoletoExpirationDate);
            Assert.AreEqual("0123456789", statusNotification.BoletoTransaction.NossoNumero);
            Assert.AreEqual(ParseDateTime("2015-09-22T07:06:00.537"), statusNotification.BoletoTransaction.StatusChangedDate);
            Assert.AreEqual(Guid.Parse("F7C4B737-E8B5-4BAA-BB47-6ED2A1A1EE09"), statusNotification.BoletoTransaction.TransactionKey);
            Assert.AreEqual("6741137", statusNotification.BoletoTransaction.TransactionReference);
            Assert.AreEqual(BoletoTransactionStatusEnum.Generated, statusNotification.BoletoTransaction.PreviousBoletoTransactionStatus);
            Assert.AreEqual(BoletoTransactionStatusEnum.Paid, statusNotification.BoletoTransaction.BoletoTransactionStatus);
        }

        [TestMethod]
        public void ParseNotification_OnlineDebit_Test() {
            NotificationParser notificationParser = new NotificationParser();

            var statusNotification = notificationParser.ParseNotification(onlineDebitNotification);

            Assert.AreEqual(7000, statusNotification.AmountInCents);
            Assert.AreEqual(7000, statusNotification.AmountPaidInCents);
            Assert.IsNotNull(statusNotification.OnlineDebitTransaction);
            Assert.AreEqual(Guid.Parse("B1B1092C-8681-40C2-A734-500F22683D9B"), statusNotification.MerchantKey);
            Assert.AreEqual(Guid.Parse("1025FCB5-41D8-43B5-82FE-398F61E83879"), statusNotification.OrderKey);
            Assert.AreEqual("9623472", statusNotification.OrderReference);
            Assert.AreEqual(OrderStatusEnum.Paid, statusNotification.OrderStatus);

            // OnlineDebitTransaction
            Assert.AreEqual(7000, statusNotification.OnlineDebitTransaction.AmountInCents);
            Assert.AreEqual(7000, statusNotification.OnlineDebitTransaction.AmountPaidInCents);
            Assert.AreEqual("BancoDoBrasil", statusNotification.OnlineDebitTransaction.BankName);
            Assert.AreEqual("22092015", statusNotification.OnlineDebitTransaction.BankPaymentDate);
            Assert.AreEqual(ParseDateTime("2015-09-22T13:15:46.333"), statusNotification.OnlineDebitTransaction.StatusChangedDate);
            Assert.AreEqual(Guid.Parse("751AE9F0-AF0B-4DE5-A483-2EFF2DE0FDF6"), statusNotification.OnlineDebitTransaction.TransactionKey);
            Assert.AreEqual("00000000000012345", statusNotification.OnlineDebitTransaction.TransactionKeyToBank);
            Assert.AreEqual("656885531", statusNotification.OnlineDebitTransaction.TransactionReference);
            Assert.AreEqual(OnlineDebitTransactionStatusEnum.OpenedPendingPayment, statusNotification.OnlineDebitTransaction.PreviousOnlineDebitTransactionStatus);
            Assert.AreEqual(OnlineDebitTransactionStatusEnum.Paid, statusNotification.OnlineDebitTransaction.OnlineDebitTransactionStatus);
        }

        [TestMethod]
        public void ParseNotification_AllFields_Test() {
            NotificationParser notificationParser = new NotificationParser();

            var statusNotification = notificationParser.ParseNotification(fullNotification);

            Assert.AreEqual(8500, statusNotification.AmountInCents);
            Assert.AreEqual(8500, statusNotification.AmountPaidInCents);
            Assert.IsNotNull(statusNotification.OnlineDebitTransaction);
            Assert.IsNotNull(statusNotification.CreditCardTransaction);
            Assert.IsNotNull(statusNotification.BoletoTransaction);
            Assert.AreEqual(Guid.Parse("B1B1092C-8681-40C2-A734-500F22683D9B"), statusNotification.MerchantKey);
            Assert.AreEqual(Guid.Parse("1025FCB5-41D8-43B5-82FE-398F61E83879"), statusNotification.OrderKey);
            Assert.AreEqual("9623472", statusNotification.OrderReference);
            Assert.AreEqual(OrderStatusEnum.Paid, statusNotification.OrderStatus);

            // BoletoTransaction
            Assert.AreEqual(1000, statusNotification.BoletoTransaction.AmountInCents);
            Assert.AreEqual(1000, statusNotification.BoletoTransaction.AmountPaidInCents);
            Assert.AreEqual(ParseDateTime("2015-09-21T15:42:04.573"), statusNotification.BoletoTransaction.BoletoExpirationDate);
            Assert.AreEqual("0123456789", statusNotification.BoletoTransaction.NossoNumero);
            Assert.AreEqual(ParseDateTime("2015-09-22T07:06:00.537"), statusNotification.BoletoTransaction.StatusChangedDate);
            Assert.AreEqual(Guid.Parse("F7C4B737-E8B5-4BAA-BB47-6ED2A1A1EE09"), statusNotification.BoletoTransaction.TransactionKey);
            Assert.AreEqual("6741137", statusNotification.BoletoTransaction.TransactionReference);
            Assert.AreEqual(BoletoTransactionStatusEnum.Generated, statusNotification.BoletoTransaction.PreviousBoletoTransactionStatus);
            Assert.AreEqual(BoletoTransactionStatusEnum.Paid, statusNotification.BoletoTransaction.BoletoTransactionStatus);

            // CreditCardTransaction
            CreditCardTransaction creditCardTransaction = statusNotification.CreditCardTransaction;
            Assert.AreEqual("Simulator", creditCardTransaction.Acquirer);
            Assert.AreEqual(500, creditCardTransaction.AmountInCents);
            Assert.AreEqual("123456", creditCardTransaction.AuthorizationCode);
            Assert.AreEqual(500, creditCardTransaction.AuthorizedAmountInCents);
            Assert.AreEqual(500, creditCardTransaction.CapturedAmountInCents);
            Assert.AreEqual("Mastercard", creditCardTransaction.CreditCardBrand);
            Assert.AreEqual("String Content", creditCardTransaction.CustomStatus);
            Assert.AreEqual(100, creditCardTransaction.RefundedAmountInCents);
            Assert.AreEqual(this.ParseDateTime("2015-09-22T15:51:41.217"), creditCardTransaction.StatusChangedDate);
            Assert.AreEqual("9876543210", creditCardTransaction.TransactionIdentifier);
            Assert.AreEqual(Guid.Parse("4111D523-9A83-4BE3-94D2-160F1BC9C4BD"), creditCardTransaction.TransactionKey);
            Assert.AreEqual("91735820", creditCardTransaction.TransactionReference);
            Assert.AreEqual("63417982", creditCardTransaction.UniqueSequentialNumber);
            Assert.AreEqual(100, creditCardTransaction.VoidedAmountInCents);
            Assert.AreEqual(CreditCardTransactionStatusEnum.AuthorizedPendingCapture, creditCardTransaction.PreviousCreditCardTransactionStatus);
            Assert.AreEqual(CreditCardTransactionStatusEnum.Captured, creditCardTransaction.CreditCardTransactionStatus);

            // OnlineDebitTransaction
            Assert.AreEqual(7000, statusNotification.OnlineDebitTransaction.AmountInCents);
            Assert.AreEqual(7000, statusNotification.OnlineDebitTransaction.AmountPaidInCents);
            Assert.AreEqual("BancoDoBrasil", statusNotification.OnlineDebitTransaction.BankName);
            Assert.AreEqual("22092015", statusNotification.OnlineDebitTransaction.BankPaymentDate);
            Assert.AreEqual(ParseDateTime("2015-09-22T13:15:46.333"), statusNotification.OnlineDebitTransaction.StatusChangedDate);
            Assert.AreEqual(Guid.Parse("751AE9F0-AF0B-4DE5-A483-2EFF2DE0FDF6"), statusNotification.OnlineDebitTransaction.TransactionKey);
            Assert.AreEqual("00000000000012345", statusNotification.OnlineDebitTransaction.TransactionKeyToBank);
            Assert.AreEqual("656885531", statusNotification.OnlineDebitTransaction.TransactionReference);
            Assert.AreEqual(OnlineDebitTransactionStatusEnum.OpenedPendingPayment, statusNotification.OnlineDebitTransaction.PreviousOnlineDebitTransactionStatus);
            Assert.AreEqual(OnlineDebitTransactionStatusEnum.Paid, statusNotification.OnlineDebitTransaction.OnlineDebitTransactionStatus);
        }

        private DateTime ParseDateTime(string dateTime) {

            return DateTime.ParseExact(dateTime, "yyyy-MM-ddTHH:mm:ss.fff", null);
        }
    }
}
