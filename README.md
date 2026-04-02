# Data Insight Automation

Projeto full stack desenvolvido com o objetivo de simular um sistema real de coleta, processamento e visualização de dados.

## 🧠 Objetivo

Este projeto foi desenvolvido com foco em aprendizado prático e construção de um portfólio sólido na área de desenvolvimento de software.

## 📌 Descrição

Este projeto consiste no desenvolvimento de uma API REST utilizando .NET, com foco em simular um sistema real de coleta, processamento e disponibilização de dados.

A aplicação evolui de uma API estruturada para um sistema integrado, sendo capaz de consumir dados de uma fonte externa e armazená-los automaticamente no banco de dados.

Além do backend, foi implementado um script em Python responsável por coletar dados de uma API pública e enviá-los para o sistema, simulando um fluxo real de ingestão de dados.

O projeto segue boas práticas de desenvolvimento, incluindo arquitetura em camadas, validação de dados, tratamento global de erros, padronização de respostas e controle de volume de dados com paginação.

O objetivo principal é aprofundar o conhecimento em engenharia de software, construindo um sistema evolutivo que se aproxima cada vez mais de aplicações reais utilizadas no mercado.

## 🚀 Tecnologias utilizadas

- .NET Web API (C#)
- SQL Server
- Python (para automação de dados)
- React (frontend - em desenvolvimento)
- Entity Framework Core
- Git e GitHub

## ⚙️ Funcionalidades atuais

- API REST desenvolvida com .NET
- Integração com SQL Server via Entity Framework Core
- Arquitetura em camadas (Service e Repository)
- DTOs para controle de entrada e saída de dados
- Validação de dados no backend
- Validação de parâmetros de consulta
- Tratamento global de erros com middleware
- Respostas padronizadas para toda a API
- Paginação e metadados de paginação
- Filtros por faixa de preço
- Ordenação de resultados
- Combinação de múltiplos parâmetros
- Integração com API externa (CoinGecko)
- Script em Python para ingestão automática de dados
- Suporte a múltiplas moedas

## 📈 Próximos passos

- Automatizar execução do script Python (agendamento)
- Implementar logging estruturado
- Criar frontend em React para visualização dos dados
- Adicionar autenticação e segurança

## 🧱 Arquitetura

O projeto é dividido em múltiplas camadas e componentes:

- API (Endpoints): responsável pela comunicação HTTP
- Service: contém as regras de negócio
- Repository: acesso ao banco de dados
- DTOs: controle de entrada e saída
- Middleware: tratamento global de erros
- Script Python: responsável pela ingestão de dados externos

Essa arquitetura permite escalabilidade, manutenção e evolução contínua do sistema.

## 🔄 Fluxo de dados

O sistema segue o seguinte fluxo:

API externa (CoinGecko) → Script em Python → API .NET → Banco de dados

Esse fluxo simula um pipeline de ingestão de dados, onde informações são coletadas automaticamente, processadas e armazenadas para posterior consulta.

## 🔄 Padrão de resposta da API

Todas as respostas seguem um formato padronizado:

```json
{
  "success": true,
  "data": {},
  "message": null,
  "pagination": {}
}