Stone .NET Integration library.
====================

.NET library for integration with Stone payment web services.

## NuGet
  PM> Install-Package Stone.Gateway.Client

## Getting started

Add this to your App.config or Web.config file.
```xml
<appSettings>
    <add key="GatewayService.MerchantKey" value="85328786-8BA6-420F-9948-5352F5A183EB" />
    <add key="GatewayService.HostUri" value="https://transaction.stone.com.br" />
</appSettings>
```

Code:
```c#
// Creates the credit card transaction.
var transaction = new CreditCardTransaction() {
    AmountInCents = 100,
    CreditCard = new CreditCard() {
        CreditCardNumber = "4111111111111111",
        CreditCardBrand = CreditCardBrandEnum.Visa,
        ExpMonth = 10,
        ExpYear = 2018,
        SecurityCode = "123",
        HolderName = "Smith"
    }
};

try {

    // Creates the client that will send the transaction.
    var serviceClient = new GatewayServiceClient();

    // Authorizes the credit card transaction and returns the gateway response.
    var httpResponse = serviceClient.Sale.Create(transaction);

    // API response code
    Console.WriteLine("Status: {0}", httpResponse.HttpStatusCode);

    var createSaleResponse = httpResponse.Response;
    if (httpResponse.HttpStatusCode == HttpStatusCode.Created) {
        foreach (var creditCardTransaction in createSaleResponse.CreditCardTransactionResultCollection) {
            Console.WriteLine(creditCardTransaction.AcquirerMessage);
        }
    }
    else {
        if (createSaleResponse.ErrorReport != null) {
            foreach (ErrorItem errorItem in createSaleResponse.ErrorReport.ErrorItemCollection) {
                Console.WriteLine("Error {0}: {1}", errorItem.ErrorCode, errorItem.Description);
            }
        }
    }
}
catch (Exception ex) {
    Console.WriteLine(ex.Message);
}

Console.ReadKey();
            
```

## Simulator rules by amount

### Authorization

* `<= $ 1.050,00 -> Authorized`
* `>= $ 1.050,01 && < $ 1.051,71 -> Timeout`
* `>= $ 1.500,00 -> Not Authorized`
 
### Capture

* `<= $ 1.050,00 -> Captured`
* `>= $ 1.050,01 -> Not Captured`
 
### Cancellation

* `<= $ 1.050,00 -> Cancelled`
* `>= $ 1.050,01 -> Not Cancelled`
 
### Refund
* `<= $ 1.050,00 -> Refunded`
* `>= $ 1.050,01 -> Not Refunded`

## Documentation

  https://github.com/stone-pagamentos/stone-ecommerce-dotnet/wiki/
  
## Other examples

* [Capture](https://github.com/stone-pagamentos/stone-ecommerce-dotnet/wiki/Capture-method)
* [Cancel](https://github.com/stone-pagamentos/stone-ecommerce-dotnet/wiki/Cancel-method)

## License

See the LICENSE file.
