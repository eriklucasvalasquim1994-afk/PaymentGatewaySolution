namespace PaymentGateway.Application.DTOs;

public record PaymentRequest(

    decimal Amount,
    string Currency,
    string CardNumber,
    string CVV

    );
