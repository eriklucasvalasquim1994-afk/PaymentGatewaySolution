using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces;

namespace PaymentGateway.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    // Esta é a lista que guarda as transações na memória do PC
    private readonly List<Transaction> _transactions = new List<Transaction>();

    public async Task AddAsync(Transaction transaction)
    {
        _transactions.Add(transaction);
        await Task.CompletedTask;
    }

    public async Task<Transaction> GetByIdAsync(Guid id)
    {
        var transaction = _transactions.FirstOrDefault(t => t.Id == id);
        return await Task.FromResult(transaction);
    }

    // --- ADICIONE ESTE MÉTODO ABAIXO PARA SUMIR O ERRO ---
    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        // Ele simplesmente devolve a lista de transações lá do topo
        return await Task.FromResult(_transactions);
    }
}