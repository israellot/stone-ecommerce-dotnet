using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using GatewayApiClient.EnumTypes;
using GatewayApiClient.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GatewayApiClient.Tests {
    [TestClass]
    public class GatewayServiceClientTests : BaseTests {

        #region EndPoint
        private readonly Uri _endpoint = new Uri("https://transaction.stone.com.br");
        #endregion

        #region Variables
        private readonly CreateSaleRequest _createCreditCardSaleRequest = new CreateSaleRequest {
            CreditCardTransactionCollection = new Collection<CreditCardTransaction>
            {
                new CreditCardTransaction
                {
                    CreditCard = new CreditCard
                    {
                        CreditCardNumber = "4111111111111111",
                        CreditCardBrand = CreditCardBrandEnum.Visa,
                        ExpMonth = 10,
                        ExpYear = 2018,
                        SecurityCode = "123",
                        HolderName = "LUKE SKYWALKER"
                    },
                    AmountInCents = 100,
                    Options = new CreditCardTransactionOptions{PaymentMethodCode = 1}
                }
            }
        };

        private readonly CreateSaleRequest _createBoletoSaleRequest = new CreateSaleRequest {
            BoletoTransactionCollection = new Collection<BoletoTransaction>
            {
                new BoletoTransaction
                {
                    AmountInCents = 100,
                    BankNumber = "237"
                }
            }
        };

        private readonly CreditCardTransaction _createSingleCreditCardTransaction = new CreditCardTransaction {
            CreditCard = new CreditCard {
                CreditCardNumber = "4111111111111111",
                CreditCardBrand = CreditCardBrandEnum.Visa,
                ExpMonth = 10,
                ExpYear = 2018,
                SecurityCode = "123",
                HolderName = "LUKE SKYWALKER"
            },
            AmountInCents = 100,
            Options = new CreditCardTransactionOptions { PaymentMethodCode = 1 }
        };

        private readonly CreateBuyerRequest _createBuyer = new CreateBuyerRequest {
            Birthdate = new DateTime(1994, 9, 26, 10, 35, 12),
            BuyerCategory = BuyerCategoryEnum.Normal,
            BuyerReference = "DotNet Buyer",
            CreateDateInMerchant = DateTime.UtcNow.AddDays(-5),
            DocumentNumber = "12345678901",
            DocumentType = DocumentTypeEnum.CPF,
            Email = "dotnet@developer.com",
            EmailType = EmailTypeEnum.Personal,
            FacebookId = "developer.net",
            Gender = GenderEnum.M,
            HomePhone = "2125247689",
            LastBuyerUpdateInMerchant = DateTime.UtcNow.AddDays(-2),
            MobilePhone = "21989685642",
            Name = "Dotnet Developer",
            PersonType = PersonTypeEnum.Person,
            TwitterId = "@developer.net",
            WorkPhone = "21965647826",
            AddressCollection = new Collection<BuyerAddress> { new BuyerAddress
                {
                    AddressType = AddressTypeEnum.Residential,
                    City = "Rio de Janeiro",
                    Complement = "Aeroporto",
                    Country = "Brazil",
                    District = "Centro",
                    Number = "123",
                    State = "RJ",
                    Street = "Av. General Justo",
                    ZipCode = "20270230"
                }}
        };

        private readonly CreateInstantBuyDataRequest _createInstantBuyDataRequest = new CreateInstantBuyDataRequest {
            BillingAddress = new BillingAddress {
                Number = "123",
                State = "RJ",
                City = "Rio de Janeiro",
                Street = "Av. General Justo",
                ZipCode = "20270230",
                Country = "Brazil",
                Complement = "Ao lado do Aeroporto",
                District = "Centro"
            },
            CreditCardBrand = CreditCardBrandEnum.Visa,
            CreditCardNumber = "4111111111111111",
            ExpMonth = 12,
            ExpYear = 2022,
            HolderName = "Ozzy Osbourne",
            IsOneDollarAuthEnabled = false,
            SecurityCode = "123"
        };
        #endregion


        [TestMethod]
        public void ItShouldCreateCreditCardSale() {
            // Cria o client que enviará a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Autoriza a transação de cartão de crédito e recebe a resposta do gateway.
            HttpResponse<CreateSaleResponse> httpResponse = serviceClient.Sale.Create(this._createCreditCardSaleRequest);

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.HttpStatusCode);
        }

        [TestMethod]
        public void ItShouldCreateCreditCardSaleWithOrderReference() {
            // Cria o client que enviará a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Identificação do pedido na loja.
            string orderReference = Guid.NewGuid().ToString("n");

            // Autoriza a transação de cartão de crédito e recebe a resposta do gateway.
            HttpResponse<CreateSaleResponse> httpResponse = serviceClient.Sale.Create(this._createSingleCreditCardTransaction, orderReference);

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.HttpStatusCode);
            Assert.AreEqual(orderReference, httpResponse.Response.OrderResult.OrderReference);
        }

        [TestMethod]
        public void ItShouldCreateCreditCardSaleUsingConfiguredMerchantKey() {
            // Cria o client que enviará a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Autoriza a transação de cartão de crédito e recebe a resposta do gateway.
            HttpResponse<CreateSaleResponse> httpResponse = serviceClient.Sale.Create(this._createCreditCardSaleRequest);

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.HttpStatusCode);
        }

        [TestMethod]
        public void ItShouldCreateBoletoSale() {
            // Cria o client que enviará a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            HttpResponse<CreateSaleResponse> httpResponse = serviceClient.Sale.Create(_createBoletoSaleRequest);

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.HttpStatusCode);
        }

        [TestMethod]
        public void ItShouldCancelATransaction() {
            // Cria o cliente para cancelar a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Cria transação de cartão de crédito para ser cancelada
            HttpResponse<CreateSaleResponse> saleResponse = serviceClient.Sale.Create(this._createCreditCardSaleRequest);

            Assert.AreEqual(saleResponse.HttpStatusCode, HttpStatusCode.Created);

            Guid orderKey = saleResponse.Response.OrderResult.OrderKey;

            // Cancela a transação de cartão de crédito e recebe a resposta do gateway.
            HttpResponse<ManageSaleResponse> httpResponse = serviceClient.Sale.Manage(ManageOperationEnum.Cancel, orderKey);

            Assert.AreEqual(httpResponse.HttpStatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void ItShouldCaptureATransaction() {
            // Cria o cliente para Capturar a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Cria transação de cartão de crédito para ser capturada
            HttpResponse<CreateSaleResponse> saleResponse = serviceClient.Sale.Create(this._createCreditCardSaleRequest);

            Assert.AreEqual(saleResponse.HttpStatusCode, HttpStatusCode.Created);

            Guid orderKey = saleResponse.Response.OrderResult.OrderKey;

            // Captura a transação de cartão de crédito e recebe a resposta do gateway.
            HttpResponse<ManageSaleResponse> httpResponse = serviceClient.Sale.Manage(ManageOperationEnum.Capture, orderKey);

            Assert.AreEqual(httpResponse.HttpStatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void ItShouldRetryATransaction() {
            // Cria o cliente para retentar a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Cria transação de cartão de crédito para ser retentada
            HttpResponse<CreateSaleResponse> saleResponse = serviceClient.Sale.Create(this._createCreditCardSaleRequest);

            Assert.AreEqual(saleResponse.HttpStatusCode, HttpStatusCode.Created);

            Guid orderKey = saleResponse.Response.OrderResult.OrderKey;

            // Retenta a transação de cartão de crédito e recebe a resposta do gateway.
            HttpResponse<RetrySaleResponse> httpResponse = serviceClient.Sale.Retry(orderKey);

            Assert.AreEqual(httpResponse.HttpStatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void ItShouldDoQueryMethod() {
            // Cria o cliente para consultar o pedido.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Cria transação de cartão de crédito para ser consultada
            HttpResponse<CreateSaleResponse> saleResponse = serviceClient.Sale.Create(this._createCreditCardSaleRequest);

            Assert.AreEqual(saleResponse.HttpStatusCode, HttpStatusCode.Created);

            Guid orderKey = saleResponse.Response.OrderResult.OrderKey;

            // Consulta o pedido no gateway.
            HttpResponse<QuerySaleResponse> httpResponse = serviceClient.Sale.QueryOrder(orderKey);

            Assert.AreEqual(httpResponse.HttpStatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void ItShouldCreateSaleWithAllFields() {
            CreateSaleRequest saleRequest = new CreateSaleRequest();

            // Dados da transação de cartão de crédito.
            saleRequest.CreditCardTransactionCollection = new Collection<CreditCardTransaction>() {
                new CreditCardTransaction() {
                    AmountInCents = 100,
                    CreditCardOperation = CreditCardOperationEnum.AuthAndCapture,
                    CreditCard = new CreditCard() {
                        CreditCardBrand = CreditCardBrandEnum.Visa,
                        CreditCardNumber = "4111111111111111",
                        ExpMonth = 10,
                        ExpYear = 2018,
                        HolderName = "Somebody",
                        SecurityCode = "123"
                    },
                    // Opcional.  
                    Options = new CreditCardTransactionOptions() {
                        // Indica que a transação é de simulação.
                        PaymentMethodCode = 1
                    }
                }
            };

            // Dados do comprador.
            saleRequest.Buyer = new Buyer() {
                DocumentNumber = "11111111111",
                DocumentType = DocumentTypeEnum.CPF,
                Email = "Somebody@example.com",
                EmailType = EmailTypeEnum.Personal,
                Gender = GenderEnum.M,
                HomePhone = "(21) 12345678",
                Name = "Somebody",
                PersonType = PersonTypeEnum.Person,
                AddressCollection = new Collection<BuyerAddress>() {
                    new BuyerAddress() {
                        AddressType = AddressTypeEnum.Residential,
                        City = "Rio de Janeiro",
                        Complement = "10º floor",
                        Country = CountryEnum.Brazil.ToString(),
                        District = "Centro",
                        Number = "199",
                        State = "RJ",
                        Street = "Rua da Quitanda",
                        ZipCode = "20091005"
                    }
                }
            };

            // Dados do carrinho de compras.
            saleRequest.ShoppingCartCollection = new Collection<ShoppingCart>() {
                new ShoppingCart() {
                    FreightCostInCents = 0,
                    ShoppingCartItemCollection = new Collection<ShoppingCartItem>() {
                        new ShoppingCartItem() {
                            Description = "Teclado Padrão",
                            ItemReference = "#1234",
                            Name = "Teclado",
                            Quantity = 3,
                            TotalCostInCents = 60,
                            UnitCostInCents = 20
                        }
                    }
                }
            };

            // Indica que o pedido usará anti fraude.
            saleRequest.Options.IsAntiFraudEnabled = true;

            // Cria o cliente que enviará a transação para o gateway.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Autoriza a transação de cartão de crédito e recebe a resposta do gateway.
            HttpResponse<CreateSaleResponse> httpResponse = serviceClient.Sale.Create(saleRequest);

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.HttpStatusCode);
        }

        [TestMethod]
        public void ItShouldConsultInstantBuyKey() {
            // Cria o cliente para retentar a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Cria transação de cartão de crédito para ser retentada
            HttpResponse<CreateSaleResponse> saleResponse = serviceClient.Sale.Create(this._createCreditCardSaleRequest);

            Assert.AreEqual(saleResponse.HttpStatusCode, HttpStatusCode.Created);

            var instantBuyKey = saleResponse.Response.CreditCardTransactionResultCollection.Select(x => x.CreditCard.InstantBuyKey);

            // Obtém os dados do cartão de crédito no gateway.
            HttpResponse<GetInstantBuyDataResponse> httpResponse = serviceClient.CreditCard.GetInstantBuyData(instantBuyKey.FirstOrDefault());

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.HttpStatusCode);
        }

        [TestMethod]
        public void ItShouldConsultCreditCardWithInstantBuyKey() {
            // Cria o cliente para retentar a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Cria transação de cartão de crédito para ser retentada
            HttpResponse<CreateSaleResponse> saleResponse = serviceClient.Sale.Create(this._createCreditCardSaleRequest);

            Assert.AreEqual(saleResponse.HttpStatusCode, HttpStatusCode.Created);

            var instantBuyKey = saleResponse.Response.CreditCardTransactionResultCollection.Select(x => x.CreditCard.InstantBuyKey);

            // Obtém os dados do cartão de crédito no gateway.
            HttpResponse<GetInstantBuyDataResponse> httpResponse = serviceClient.CreditCard.GetCreditCard(instantBuyKey.FirstOrDefault());

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.HttpStatusCode);
        }

        [TestMethod]
        public void ItShouldConsultWithBuyerKey() {

            Buyer buyer = new Buyer {
                Name = "Anakin Skywalker",
                Birthdate = new DateTime(1994, 9, 26),
                DocumentNumber = "12345678901",
                DocumentType = DocumentTypeEnum.CPF,
                PersonType = PersonTypeEnum.Person,
                Gender = GenderEnum.M
            };

            _createCreditCardSaleRequest.Buyer = buyer;

            // Cria o cliente para retentar a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Cria transação de cartão de crédito para ser retentada
            HttpResponse<CreateSaleResponse> saleResponse = serviceClient.Sale.Create(this._createCreditCardSaleRequest);

            Assert.AreEqual(saleResponse.HttpStatusCode, HttpStatusCode.Created);

            var buyerKey = saleResponse.Response.BuyerKey;

            // Obtém os dados do cartão de crédito no gateway.
            HttpResponse<GetInstantBuyDataResponse> httpResponse = serviceClient.CreditCard.GetInstantBuyDataWithBuyerKey(buyerKey);

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.HttpStatusCode);
        }

        [TestMethod]
        public void ItShouldConsultCreditCardWithBuyerKey() {
            Buyer buyer = new Buyer {
                Name = "Anakin Skywalker",
                Birthdate = new DateTime(1994, 9, 26),
                DocumentNumber = "12345678901",
                DocumentType = DocumentTypeEnum.CPF,
                PersonType = PersonTypeEnum.Person,
                Gender = GenderEnum.M
            };

            _createCreditCardSaleRequest.Buyer = buyer;

            // Cria o cliente para retentar a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Cria transação de cartão de crédito para ser retentada
            HttpResponse<CreateSaleResponse> saleResponse = serviceClient.Sale.Create(this._createCreditCardSaleRequest);

            Assert.AreEqual(saleResponse.HttpStatusCode, HttpStatusCode.Created);

            var buyerKey = saleResponse.Response.BuyerKey;

            // Obtém os dados do cartão de crédito no gateway.
            HttpResponse<GetInstantBuyDataResponse> httpResponse = serviceClient.CreditCard.GetCreditCardWithBuyerKey(buyerKey);

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.HttpStatusCode);
        }

        [TestMethod]
        public void ItShouldCreateACreditCard() {
            // Cria o cliente para retentar a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Obtém a resposta da criação do cartão
            var response = serviceClient.CreditCard.CreateCreditCard(this._createInstantBuyDataRequest);

            // Verifica se a resposta foi bem sucedida
            Assert.IsTrue(response.Response.Success);
        }

        [TestMethod]
        public void ItShouldDeleteCreditCard() {
            // Cria o cliente para retentar a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Obtém o instantbuykey para deletar o cartão
            Guid instantBuyKey = serviceClient.CreditCard.CreateCreditCard(this._createInstantBuyDataRequest).Response.InstantBuyKey;

            var response = serviceClient.CreditCard.DeleteCreditCard(instantBuyKey);

            // Verifica se a resposta foi bem sucedida
            Assert.IsTrue(response.Response.Success);
        }

        [TestMethod]
        public void ItShouldUpdateCreditCard() {
            // Cria o cliente para retentar a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Obtém o instantbuykey para atualizar o cartão
            Guid instantBuyKey = serviceClient.CreditCard.CreateCreditCard(this._createInstantBuyDataRequest).Response.InstantBuyKey;

            // Cria um buyer para usar o buyerkey e atualizar o cartão
            UpdateInstantBuyDataRequest updateInstantBuyDataRequest = new UpdateInstantBuyDataRequest {
                BuyerKey = serviceClient.Buyer.CreateBuyer(this._createBuyer).Response.BuyerKey
            };

            // Atualiza o cartão
            var response = serviceClient.CreditCard.UpdateCreditCard(updateInstantBuyDataRequest, instantBuyKey);

            // Varifica se a operação foi bem sucedida
            Assert.IsTrue(response.Response.Success);
        }

        [TestMethod]
        public void ItShouldCreateATransactionWithInstantBuyKey() {
            // Cria o cliente para retentar a transação.
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Cria transação de cartão de crédito para ser retentada
            HttpResponse<CreateSaleResponse> saleResponse = serviceClient.Sale.Create(this._createCreditCardSaleRequest);

            Assert.AreEqual(saleResponse.HttpStatusCode, HttpStatusCode.Created);

            var instantBuyKey = saleResponse.Response.CreditCardTransactionResultCollection.Select(x => x.CreditCard.InstantBuyKey);

            // Cria requisição com instant buy key
            CreateSaleRequest createSale = new CreateSaleRequest {
                CreditCardTransactionCollection = new Collection<CreditCardTransaction>
                {
                    new CreditCardTransaction
                    {
                        AmountInCents = 10000,
                        CreditCard = new CreditCard
                        {
                            InstantBuyKey = instantBuyKey.FirstOrDefault()
                        }
                    }
                }
            };

            // Faz a requisição
            HttpResponse<CreateSaleResponse> httpResponse = serviceClient.Sale.Create(createSale);

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.HttpStatusCode);
        }

        [TestMethod]
        public void ItShouldCreateBuyer() {
            // Cria o cliente para criar um buyer
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Faz a chamada do método
            var response = serviceClient.Buyer.CreateBuyer(this._createBuyer);

            // Verifica se recebeu a resposta com sucesso
            Assert.IsTrue(response.Response.Success);
        }

        [TestMethod]
        public void ItShouldGetBuyer() {
            // Cria o cliente para buscar um buyer
            IGatewayServiceClient serviceClient = this.GetGatewayServiceClient();

            // Cria um buyer e pega sua chave
            Guid buyerKey = serviceClient.Buyer.CreateBuyer(this._createBuyer).Response.BuyerKey;

            // Faz a chamada do método de buscar o buyer
            var response = serviceClient.Buyer.GetBuyer(buyerKey);

            // Verifica se recebeu a resposta com sucesso
            Assert.IsTrue(response.Response.Success);
        }

        private IGatewayServiceClient GetGatewayServiceClient() {

            return new GatewayServiceClient(MerchantKey, _endpoint);
        }
    }
}
