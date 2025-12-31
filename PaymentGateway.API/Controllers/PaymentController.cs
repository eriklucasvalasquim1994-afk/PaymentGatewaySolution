using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Application.Services;
using PaymentGateway.Application.DTOs;
using PaymentGateway.Domain.Interfaces; // 1. Precisamos disso para o Repositório

namespace PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        private readonly ITransactionRepository _repository; // 2. Declaramos o repositório aqui

        // 3. No "construtor", pedimos ao .NET para nos dar tanto o Service quanto o Repositório
        public PaymentController(PaymentService paymentService, ITransactionRepository repository)
        {
            _paymentService = paymentService;
            _repository = repository;
        }

        // --- AQUI É O SEU MÉTODO DE ENVIAR (POST) ---
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
        {
            var result = await _paymentService.ProcessAsync(request);

            if (result.Status == "Success")
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        // --- AQUI É ONDE VOCÊ INSERE O NOVO MÉTODO (GET) ---
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            // O Controller agora usa o _repository que adicionamos lá em cima
            var transactions = await _repository.GetAllAsync();
            return Ok(transactions);
        }
    } // Fim da Classe
}