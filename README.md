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

Este projeto consiste no desenvolvimento de uma API REST utilizando .NET, com foco em simular um sistema real de coleta, armazenamento e disponibilização de dados.

A aplicação foi construída com uma arquitetura em camadas, seguindo boas práticas de desenvolvimento backend, incluindo validação de dados, tratamento global de erros, padronização de respostas e controle de volume de dados através de paginação.

O objetivo principal é aprofundar o conhecimento em engenharia de software, construindo um sistema evolutivo e estruturado desde a base até aspectos mais avançados de qualidade e escalabilidade.

## ⚙️ Funcionalidades atuais

- API REST desenvolvida com .NET
- Integração com SQL Server via Entity Framework Core
- Arquitetura em camadas (Service e Repository)
- DTOs para controle de entrada e saída de dados
- Validação de dados no backend
- Tratamento global de erros com middleware
- Respostas padronizadas para toda a API
- Paginação para controle de volume de dados
- Metadados de paginação nas respostas
- Endpoint GET para listagem de dados
- Endpoint GET com filtro por ativo
- Endpoint POST para inserção de dados

## 📈 Próximos passos

- Implementar ordenação de dados
- Melhorar validações com abordagem mais robusta
- Criar integração com coleta automática de dados (Python)
- Desenvolver frontend em React para visualização

## 🧠 Objetivo

Este projeto foi desenvolvido com foco em aprendizado prático e construção de um portfólio sólido na área de desenvolvimento de software.

## 🧱 Arquitetura

O projeto segue uma arquitetura em camadas, com separação clara de responsabilidades:

- API (Endpoints): responsável pela comunicação HTTP
- Service: contém as regras de negócio da aplicação
- Repository: responsável pelo acesso ao banco de dados
- DTOs: controlam entrada e saída de dados da API
- Middleware: tratamento global de erros

Essa estrutura facilita a manutenção, escalabilidade e evolução do sistema.

## 🔄 Padrão de resposta da API

Todas as respostas seguem um formato padronizado:

```json
{
  "success": true,
  "data": {},
  "message": null,
  "pagination": {}
}