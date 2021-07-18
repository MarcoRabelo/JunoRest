namespace JunoRest.Enums
{
    /// <summary>
    /// Tipos de pagamento permitidos BOLETO, BOLETO_PIX e CREDIT_CARD.
    /// Para checkout transparente, deve receber obrigatoriamente o tipo CREDIT_CARD.
    /// 
    /// Arranjos de tipos de pagamentos permitidos:
    /// BOLETO
    /// BOLETO_PIX
    /// CREDIT_CARD
    /// BOLETO, CREDIT_CARD
    /// BOLETO_PIX, CREDIT_CARD
    /// 
    /// Arranjos de tipos de pagamentos NÃO permitidos:
    /// BOLETO, BOLETO_PIX
    /// </summary>
    public enum PaymentType
    {
        BOLETO = 1,
        BOLETO_PIX = 2,
        CREDIT_CARD = 3
    }
}
