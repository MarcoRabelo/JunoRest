# JunoRest
Integração completa (em desenvolvimento) com a API da Juno (https://juno.com.br/), desenvolvida em .Net C#, para a realização de cobranças via PIX, Picpay, cartão de crédito, boleto PIX, boleto convencional e movimentação de contas bancárias Juno.

- [Site oficial do Juno](https://juno.com.br/)
- [Documentação complementa do Juno](https://dev.juno.com.br/api/v2)

## Pré-requisitos
Será necessário obter os valores para as seguintes variáveis para execução dos exemplos abaixo:
- Menu > Integração > Criação de Credencial
string ClientId = "";
string ClientSecret = "";

- Menu > integração > token privado
string PrivateToken = ""; // token de recurso

### O que é possível fazer:
- Obter token de acesso (JWT);
- Verificar os saldos de uma conta Juno;
- Gerar cobrança por boleto;
- Gerar cobrança por cartão de crédito;
- Listar cobranças;
- Obter uma cobrança específica;
- Cancelar cobranças;

### Obtendo um token de acesso:
```
var auth = new JunoAuthorization(ClientId, ClientSecret);
var response = await auth.GenerateTokenAsync();
```

### Verificando o saldo na conta Juno:
```
var balance = new JunoBalance(tokenResponse.AccessToken, PrivateToken);
var balanceResponse = await balance.GetBalanceAsync();
```

### Obter lista de cobranças:
```
var charge = new JunoCharge(tokenResponse.AccessToken, PrivateToken);
var chargeResponse = await charge.GetCharges();
```

### Obter dados de uma cobrança específica:
```
var charge = new JunoCharge(tokenResponse.AccessToken, PrivateToken);
var chargeResponse = await charge.GetCharge("{ID_DA_COBRANCA}");
```

### Gerar cobrança (Boleto, Boleto PIX, Cartão de crédito):
```
var charge = new JunoCharge(tokenResponse.AccessToken, PrivateToken);
body = new ChargeRequest
{
    Charge = new Charge
    {
        Description = "Descrição da Cobrança",
        References = new List<string> { "Referencia para identificação da cobrança" },
        Amount = 22.45, //valor da cobrança
        Fine = 3, //multa
        Interest = "2.4", //juros
        DueDate = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), //data de vencimento
        MaxOverdueDays = 3, //dias máximo para boleto vencido
        PaymentAdvance = true //permitir adiantamento do pagamento
    },
    Billing = new Billing
    {
        Name = "Joao da Silva Almeida", //nome do destinatário para cobrança
        Document = "18860373700", //CPF
        Email = "joao.silva.almeida@gmail.com",
        Phone = "+5531995035656",
        BirthDate = "1982-11-19",
        Notify = true //envia um e-mail para o usuário com a informação do boleto gerado
    }
};
body.Charge.PaymentTypes = new List<string>
{
    PaymentType.BOLETO //Tipo de cobrança, que pode ser: Boleto, Boleto PIX e cartão de crédito
};

var chargeResponse = await charge.GenerateBillingBillAsync(body);

if (chargeResponse is BillingBillResponseSuccess)
{
    var success = chargeResponse as BillingBillResponseSuccess;
}
else if (chargeResponse is BillingBillResponseError)
{
    var error = chargeResponse as BillingBillResponseError;
}
```

### Cancelar cobrança
```
var charge = new JunoCharge(tokenResponse.AccessToken, PrivateToken);
var chargeResponse = await charge.CancelBillingBillAsync("{ID_DA_COBRANCA}");
```