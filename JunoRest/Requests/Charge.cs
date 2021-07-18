using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JunoRest.Requests
{
    public class Charge
    {
        /// <summary>
        /// Chave Pix aleatória associada a conta digital referenciada em X-Resource-Token (Obrigatória para o tipo de pagamento BOLETO_PIX).
        /// </summary>
        [JsonProperty("pixKey")]
        public Guid? PixKey { get; set; }

        /// <summary>
        /// Nesse campo deverá ser inserido informações referentes a produtos, serviços e afins relacionados a essa cobrança.
        /// Máximo de 400 caracteres.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Lista de references atrelada a cada cobrança gerada.
        /// O número de itens deve ser igual ao número de parcelas.
        /// </summary>
        [JsonProperty("references")]
        public List<string> References { get; set; }

        /// <summary>
        /// Valor total da transação.
        /// Requer uso do parâmetro installments.
        /// Se utilizado, não deverá ser utilizado amount.
        /// </summary>
        [JsonProperty("totalAmount")]
        public double? TotalAmount { get; set; }

        /// <summary>
        /// Valor total da parcela.
        /// O valor será aplicado para cada parcela.
        /// Se utilizado, não deverá ser utilizado totalAmount.
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Multa para pagamento após o vencimento.
        /// Recebe valores de 0.00 a 20.00.
        /// Só é efetivo se maxOverdueDays for maior que zero.
        /// Não disponível para BOLETO_PIX.
        /// </summary>
        [JsonProperty("fine")]
        public int Fine { get; set; }

        /// <summary>
        /// Valor do Juros de Mora
        /// </summary>
        [JsonProperty("interest")]
        public string Interest { get; set; }

        /// <summary>
        /// Valor absoluto de desconto.
        /// Não disponível para BOLETO_PIX.
        /// </summary>
        [JsonProperty("discountAmount")]
        public double? DiscountAmount { get; set; }

        /// <summary>
        /// Número de dias de desconto.
        /// Não disponível para BOLETO_PIX.
        /// </summary>
        [JsonProperty("discountDays")]
        public int? DiscountDays { get; set; }

        /// <summary>
        /// Tipos de pagamento
        /// </summary>
        [JsonProperty("paymentTypes")]
        public List<string> PaymentTypes { get; set; }

        /// <summary>
        /// Data de Vencimento no formato "yyyy-MM-dd"
        /// </summary>
        [JsonProperty("dueDate")]
        public string DueDate { get; set; }

        /// <summary>
        /// Parcelas
        /// </summary>
        [JsonProperty("installments")]
        public int? Installments { get; set; }

        /// <summary>
        /// Número de dias permitido para pagamento após o vencimento.
        /// Não disponível para BOLETO_PIX.
        /// </summary>
        [JsonProperty("maxOverdueDays")]
        public int MaxOverdueDays { get; set; }

        /// <summary>
        /// Permitir adiantamento de pagamento
        /// </summary>
        /// <remarks>
        /// Antecipações consistem no recebimento adiantado de uma transação, seja ela parcelada ou não.
        /// Disponível apenas para cartão de crédito, com a Juno você pode decidir se deseja ou não fazer esse 
        /// adiantamento de maneira flexível via API com o paymentAdvance. O serviço inclui taxas.
        /// </remarks>
        /// <see cref="https://junocx.zendesk.com/hc/pt-br/articles/360041256631-Posso-pedir-antecipa%C3%A7%C3%A3o-do-pagamento-para-cobran%C3%A7as-parceladas-"/>
        [JsonProperty("paymentAdvance")]
        public bool PaymentAdvance { get; set; }

        /// <summary>
        /// Define o esquema de taxas alternativo para uma cobrança específica.
        /// Para cobranças criadas com o objeto split, a taxa da emissão fica a cargo da conta que recebe true no chargeFee.
        /// </summary>
        [JsonProperty("feeSchemaToken")]
        public string FeeSchemaToken { get; set; }
    }
}
