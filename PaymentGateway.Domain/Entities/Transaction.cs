using System.Net.NetworkInformation;

namespace PaymentGateway.Domain.Entities;

public enum TransactionStatus { Pending, Success, Failed }

public class Transaction
{
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }
    public string Currency {  get; private set; }
    public string CardNumberMasked { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public TransactionStatus Status { get; private set; }

    public Transaction (decimal amount, string currency,string cardNumber)
    {
        Id = Guid.NewGuid ();
        Amount = amount;
        Currency = currency;
        CreatedAt = DateTime.UtcNow;
        Status = TransactionStatus.Pending;


        //Proteção para mascarar o número do cartão
        CardNumberMasked = cardNumber.Length >= 4
            ? $"**** **** **** {cardNumber.Substring(cardNumber.Length - 4)}"
            : "****";
    }

    public void ConfirmPayment() => Status = TransactionStatus.Success;
    public void RejectPayment() => Status = TransactionStatus.Failed;
}


  
