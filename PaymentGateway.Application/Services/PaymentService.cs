using PaymentGateway.Application.DTOs; // Para encontrar o PaymentRequest
using PaymentGateway.Domain.Entities;   // Para encontrar a Transaction
using PaymentGateway.Domain.Interfaces; // Para encontrar o ITransactionRepository

namespace PaymentGateway.Application.Services;

public class PaymentService
{
    private readonly ITransactionRepository _repository;

    public PaymentService (ITransactionRepository repository)


    {  
        _repository = repository;
    }

    public async Task<PaymentResponse> ProcessAsync(PaymentRequest request)
    {
        // Criar a entidade 
        var transaction = new Transaction(request.Amount, request.Currency, request.CardNumber);

        //Executa a lógica 
        if (request.Amount > 1000)
            transaction.RejectPayment();
        else
            transaction.ConfirmPayment();

        await _repository.AddAsync(transaction);

        //Retorna a resposta 
        return new PaymentResponse(

            transaction.Id,
            transaction.Status.ToString(),
            transaction.Status == TransactionStatus.Success ? "Sucesso" : "Valor muito alto"

        );

    }
}