using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Domain.Interfaces;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
    Task<Transaction> GetByIdAsync(Guid id);
    
    Task<IEnumerable<Transaction>> GetAllAsync();
}