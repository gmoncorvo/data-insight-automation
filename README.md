# Data Insight Automation

Projeto full stack desenvolvido com o objetivo de simular um sistema real de coleta, processamento e visualização de dados.

## 🚀 Tecnologias utilizadas

- .NET Web API (C#)
- SQL Server
- Python (para automação de dados)
- React (frontend - em desenvolvimento)
- Entity Framework Core
- Git e GitHub

## 📌 Descrição

Este projeto realiza a coleta automática de dados (ex: preços de criptomoedas), armazena essas informações em um banco de dados relacional e disponibiliza os dados através de uma API.

## ⚙️ Funcionalidades atuais

- API REST desenvolvida com .NET
- Integração com SQL Server via Entity Framework Core
- Estrutura organizada em camadas (Service e Repository)
- DTOs para controle de entrada e saída de dados
- Validação de dados no backend
- Tratamento global de erros com middleware
- Respostas padronizadas para toda a API
- Endpoint GET para listagem de dados
- Endpoint GET com filtro por ativo
- Endpoint POST para inserção de dados

## 📈 Próximos passos

- Implementar paginação nos endpoints
- Melhorar validações com abordagem mais robusta
- Criar integração com coleta automática de dados (Python)
- Desenvolver frontend em React para visualização

## 🧠 Objetivo

Este projeto foi desenvolvido com foco em aprendizado prático e construção de um portfólio sólido na área de desenvolvimento de software.

## 🧱 Arquitetura

O projeto segue uma arquitetura em camadas:

- API (Endpoints)
- Service (Regras de negócio)
- Repository (Acesso ao banco de dados)
- DTOs (Controle de entrada e saída)
- Middleware (Tratamento global de erros)

Essa organização permite maior escalabilidade, manutenção e clareza no fluxo da aplicação.