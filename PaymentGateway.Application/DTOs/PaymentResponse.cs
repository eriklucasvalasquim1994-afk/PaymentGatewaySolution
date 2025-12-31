
namespace PaymentGateway.Application.DTOs;

public record PaymentResponse(

    Guid Id,
    string Status,
    string Message
    );
