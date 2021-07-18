using JunoRest.Enums;
using JunoRest.Requests;
using JunoRest.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JunoRest.Test
{
    /// <summary>
    /// Testes para efetuar e listar cobranças na Juno
    /// </summary>
    public class JunoChargeTest : JunoApiCredentials
    {
        /// <summary>
        /// Testa a obtenção uma lista de cobranças.
        /// </summary>
        [Fact]
        public async Task GetChargesTestAsync()
        {
            var auth = new JunoAuthorization(ClientId, ClientSecret, null, SandboxAuthBaseUrl);
            var tokenResponse = await auth.GenerateTokenAsync();

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.AccessToken);
            Assert.NotEmpty(tokenResponse.AccessToken);

            var charge = new JunoCharge(tokenResponse.AccessToken, PrivateToken, null);
            var chargeResponse = await charge.GetChargesAsync();

            Assert.NotNull(chargeResponse);
        }

        /// <summary>
        /// Testa a obtenção uma cobrança específica.
        /// </summary>
        [Fact]
        public async Task GetChargeTestAsync()
        {
            var auth = new JunoAuthorization(ClientId, ClientSecret, null, SandboxAuthBaseUrl);
            var tokenResponse = await auth.GenerateTokenAsync();

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.AccessToken);
            Assert.NotEmpty(tokenResponse.AccessToken);

            var charge = new JunoCharge(tokenResponse.AccessToken, PrivateToken, null);

            var charges = await charge.GetChargesAsync();
            Assert.NotNull(charges);

            var chargeResponse = await charge.GetChargeAsync(charges.Embedded.Charges[0].Id);
            Assert.NotNull(chargeResponse);
        }

        /// <summary>
        /// Testa a geração de uma cobrança por boleto
        /// </summary>
        [Fact]
        public async Task GenerateBillingBillTestAsync()
        {
            var auth = new JunoAuthorization(ClientId, ClientSecret, null, SandboxAuthBaseUrl);
            var tokenResponse = await auth.GenerateTokenAsync();

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.AccessToken);
            Assert.NotEmpty(tokenResponse.AccessToken);

            JunoCharge charge;
            ChargeRequest body;
            GetChargeBody(tokenResponse, out charge, out body, PaymentType.BOLETO);

            var chargeResponse = await charge.GenerateBillingBillAsync(body);

            if (chargeResponse is BillingBillResponseSuccess)
            {
                Assert.NotNull(((BillingBillResponseSuccess)chargeResponse).Embedded);
            }
            else if (chargeResponse is BillingBillResponseError)
            {
                Assert.NotNull(((BillingBillResponseError)chargeResponse).Error);
                Assert.NotEmpty(((BillingBillResponseError)chargeResponse).Error);
            }
        }

        /// <summary>
        /// Testa a geração de uma cobrança por cartão de crédito.
        /// </summary>
        [Fact]
        public async Task GenerateCreditCardChargeTestAsync()
        {
            var auth = new JunoAuthorization(ClientId, ClientSecret, null, SandboxAuthBaseUrl);
            var tokenResponse = await auth.GenerateTokenAsync();

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.AccessToken);
            Assert.NotEmpty(tokenResponse.AccessToken);

            JunoCharge charge;
            ChargeRequest body;
            GetChargeBody(tokenResponse, out charge, out body, PaymentType.CREDIT_CARD);

            var chargeResponse = await charge.GenerateBillingBillAsync(body);

            Assert.NotNull(chargeResponse);
            if (chargeResponse is BillingBillResponseSuccess)
            {
                Assert.NotNull(((BillingBillResponseSuccess)chargeResponse).Embedded);
            }
            else if (chargeResponse is BillingBillResponseError)
            {
                Assert.NotNull(((BillingBillResponseError)chargeResponse).Error);
                Assert.NotEmpty(((BillingBillResponseError)chargeResponse).Error);

                //Mostrar as mensagens de erro que retornaram da API.
                Assert.True(chargeResponse is BillingBillResponseSuccess, string.Join(',', ((BillingBillResponseError)chargeResponse).Details.Select(a => a.Message)));
            }
        }

        /// <summary>
        /// Testa o cancelamento de uma cobrança.
        /// </summary>
        [Fact]
        public async Task CancelBillingBillTestAsync()
        {
            var auth = new JunoAuthorization(ClientId, ClientSecret, null, SandboxAuthBaseUrl);
            var tokenResponse = await auth.GenerateTokenAsync();

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.AccessToken);
            Assert.NotEmpty(tokenResponse.AccessToken);

            var charge = new JunoCharge(tokenResponse.AccessToken, PrivateToken, null);

            var charges = await charge.GetChargesAsync();
            Assert.NotNull(charges);

            var chargeResponse = await charge.CancelBillingBillAsync(charges.Embedded.Charges.Where(a => a.Status == "ACTIVE").FirstOrDefault().Id);

            Assert.True(chargeResponse);
        }

        private static void GetChargeBody(TokenResponse tokenResponse, out JunoCharge charge, out ChargeRequest body, PaymentType paymentType)
        {
            charge = new JunoCharge(tokenResponse.AccessToken, PrivateToken, null);
            body = new ChargeRequest
            {
                Charge = new Charge
                {
                    Description = "Cobrança Test - XUnit",
                    References = new List<string> { "Uma simples referencia para teste 2 - XUnit" },
                    Amount = 22.45,
                    Fine = 3,
                    Interest = "2.4",
                    DueDate = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),
                    MaxOverdueDays = 3,
                    PaymentAdvance = true
                },
                Billing = new Billing
                {
                    Name = "Joao da Silva Almeida",
                    Document = "72592359346",
                    Email = "joao.silva.almeida@gmail.com",
                    Phone = "+5581732141290",
                    BirthDate = "1968-03-21",
                    Notify = true
                }
            };
            body.Charge.PaymentTypes = new List<string>
            {
                Enum.GetName(typeof(PaymentType), paymentType)
            };
        }
    }
}
