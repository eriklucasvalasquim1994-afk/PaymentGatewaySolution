using PaymentGateway.Application.Services;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração dos Serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Suas injeções de dependência
builder.Services.AddSingleton<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<PaymentService>();

var app = builder.Build();

// 2. Configuração do Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment Gateway V1");
    c.RoutePrefix = string.Empty; // Isso faz a página abrir direto no localhost:5000
});

app.MapControllers();

// 3. Inicialização (Corrigido: apenas um comando de execução)
app.Run();