#  Payment Gateway API - .NET 10

Este projeto é uma Web API robusta para o processamento de pagamentos, construída com foco em **Clean Architecture** e **Princípios SOLID**. A aplicação simula o fluxo real de uma transação financeira, desde a recepção dos dados até a validação de regras de negócio complexas.

##  Tecnologias Utilizadas
* **.NET 10** (C#)
* **ASP.NET Core Web API**
* **Swagger (OpenAPI)** para documentação interativa
* **Injeção de Dependência** nativa
* **Padrão Repository** para persistência de dados

##  Arquitetura do Projeto
A solução foi dividida em camadas para garantir a separação de responsabilidades:
* **Domain:** Entidades de negócio e interfaces.
* **Application:** Serviços e DTOs (Data Transfer Objects).
* **Infrastructure:** Implementação de repositórios e dados.
* **API:** Controladores e configuração do pipeline de execução.

##  Funcionalidades principais
- [x] **Processamento Assíncrono:** Uso de `async/await` em toda a cadeia.
- [x] **Validação de Dados:** Filtros automáticos (ex: CVV obrigatório).
- [x] **Regras de Negócio:** Sistema de aprovação baseado em faixas de valor.
- [x] **Segurança:** Mascaramento de dados sensíveis (Cartão de Crédito).
- [x] **Histórico:** Endpoint GET para consulta de transações realizadas.

##  Como testar
1. Clone o repositório.
2. Execute o projeto via Visual Studio (IIS Express).
3. O Swagger abrirá automaticamente na raiz: `https://localhost:PORTA/`
