# Desafio Técnico — Target Sistemas

Solução desenvolvida para o desafio técnico da vaga de **Desenvolvedor Junior** da Target Sistemas.

O projeto contém três exercícios desenvolvidos em **C#**, utilizando **.NET 10** e aplicações do tipo **Console**.

## 📋 Exercícios

### 1. Comissão

Sistema responsável por processar um arquivo JSON contendo vendas realizadas por diferentes vendedores e calcular as respectivas comissões.

#### Regras

* Vendas abaixo de **R$ 100,00**: sem comissão
* Vendas abaixo de **R$ 500,00**: comissão de **1%**
* Vendas a partir de **R$ 500,00**: comissão de **5%**

O resultado apresenta um resumo agrupado por vendedor, contendo:

* Nome do vendedor
* Quantidade de vendas
* Total de comissão

#### Principais recursos utilizados

* Leitura de arquivo JSON
* Desserialização com `System.Text.Json`
* LINQ
* `GroupBy`
* `decimal` para valores monetários
* Separação da regra de negócio em classe própria

---

### 2. Estoque

Sistema de controle de movimentações de estoque baseado nos produtos fornecidos no arquivo JSON.

O sistema possui um menu interativo que permite realizar operações de entrada e saída de produtos.

#### Funcionalidades

* Adicionar produtos ao estoque
* Remover produtos do estoque
* Cadastrar um novo produto
* Consultar produtos em estoque
* Exibir o estoque atualizado após uma movimentação
* Registrar histórico das movimentações
* Identificar cada movimentação com um número único
* Registrar data e hora da movimentação
* Validar entradas numéricas
* Impedir saída superior à quantidade disponível em estoque

#### Histórico de movimentações

Cada movimentação registra:

* ID da movimentação
* Código do produto
* Descrição
* Tipo da movimentação (`ENTRADA` ou `SAÍDA`)
* Quantidade movimentada
* Data e hora

O histórico é mantido em memória durante a execução da aplicação.

---

### 3. Calculadora de Juros

Sistema responsável por calcular juros simples de acordo com a quantidade de dias de atraso de uma conta.

#### Regra

A taxa definida pelo exercício é de **2,5% ao dia**.

O sistema recebe:

* Valor inicial da conta
* Data de vencimento

A partir desses dados, calcula:

* Quantidade de dias de atraso
* Taxa de juros
* Valor dos juros
* Valor final da conta

A data de vencimento não pode ser posterior à data atual.

---

## 🛠️ Tecnologias utilizadas

* **C#**
* **.NET 10**
* **Console Application**
* **System.Text.Json**
* **LINQ**
* **DateTime**

## 📁 Estrutura

Cada exercício foi desenvolvido como um projeto independente.

```text
/
├── Comissão/
│   ├── Program.cs
│   ├── Model.cs
│   ├── SolucaoMetodo.cs
│   └── comissao.json
│
├── Estoque/
│   ├── Program.cs
│   ├── Model.cs
│   ├── MovimentacaoEstoque.cs
│   └── estoque.json
│
├── Calcular Juros/
│   ├── Program.cs
│   ├── Model.cs
│   └── CalculadoraJuros.cs
│
└── README.md
```

> A estrutura acima representa a organização lógica dos projetos. Os nomes dos arquivos podem variar conforme a organização atual do repositório.

## ▶️ Como executar

### Pré-requisitos

Ter instalado o **.NET 10 SDK**.

Para verificar a versão instalada:

```bash
dotnet --version
```

### Executando um exercício

Entre na pasta do exercício desejado e execute:

```bash
dotnet run
```

Por exemplo:

```bash
cd Comissão
dotnet run
```

Os exercícios de **Comissão** e **Estoque** utilizam arquivos JSON como fonte de dados, que devem permanecer disponíveis junto ao projeto.

## 💡 Decisões de implementação

Busquei manter as soluções simples e compatíveis com o escopo de uma aplicação Console, evitando adicionar complexidade arquitetural que não fosse necessária para os requisitos apresentados.

Entre as principais decisões estão:

* Utilização de `decimal` para cálculos financeiros.
* Separação das regras de negócio em classes e métodos específicos.
* Utilização de LINQ para agrupamento e processamento das vendas.
* Validação de entradas numéricas com `TryParse`.
* Registro das movimentações de estoque com identificador único.
* Uso de `DateTime` para cálculo do período de atraso e registro das movimentações.
* Organização dos dados através de classes de modelo.

## 🎯 Objetivo

O objetivo deste projeto é demonstrar a capacidade de:

* Interpretar requisitos;
* Desenvolver soluções em C#;
* Organizar código de forma clara;
* Aplicar regras de negócio;
* Trabalhar com arquivos JSON;
* Realizar validações de entrada;
* Utilizar recursos da linguagem e do .NET;
* Pensar em cenários de erro e regras de negócio.

---

**Desafio Técnico — Target Sistemas**

Desenvolvido por **Ronei Cruz**
