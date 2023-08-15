<h1 align="center"> Tech Challenge - Grupo 31 - Fase 2</h1>
<h3 align="center">Desenvolvimento do projeto WebNews.</h3>

## 📚 Sobre o projeto

O projeto tem como objetivo criar uma Web API para a gestão de notícias de um portl de comunicação, gravando as informações em uma base de dados SQL Server.
O projeto está sendo desenvolvido em grupo, com o objetivo de compartilhar conhecimentos e experiências e atender os requisitos avaliativos do Tech Challenge FIAP do curso postech ARQUITETURA DE SISTEMAS .NET COM AZURE na fase 2.

## 📝 Conteúdo

- [Sobre o projeto](#-sobre-o-projeto)

## Configuração do ambiente

### 📋 Pré-requisitos

- [.NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Sql Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

### 🎲 Banco de dados
A configuração do banco de dados é feita através do arquivo appsettings.json, que fica na raiz do projeto WebNews.API. 
O arquivo já está configurado para o banco de dados **Sql Server** local, mas caso queira utilizar outro banco de dados, basta alterar a string de conexão. Você pode configurar também
a váriavel `newsDB_local` e `newsDB_local_identity` que pode conter o endereço do banco remoto, no caso deste projeto ele será publicado no Azure. Importante configurar também a flag `enable_connection_local_db` 
para habilitar a troca do banco apontando para nuvem ou para o servidor local.

```json
 "ConnectionStrings": {
    "newsDB_local": "Server=(localdb)\\mssqllocaldb;Database=NewsDB;Integrated Security=SSPI;Persist Security Info=False;",
    "newsDB_local_identity": "Server=(localdb)\\mssqllocaldb;Database=NewsDBIdentity;Integrated Security=SSPI;Persist Security Info=False;",
    "newsDB_remote": "",
    "newsDB_remote_identity": ""
  }
```

## 🚀 Como executar o projeto

```bash
# Clone este repositório
$ git clone https://github.com/andreleaos/LojaGames](https://github.com/bessax/WebNews.git

# Acesse a pasta do projeto no terminal o projeto Web /cmd
$ cd ./temp/WebNews/WebNews.API [Executar o projeto Web]

# Execute a aplicação em modo de desenvolvimento
$ dotnet run

# O servidor inciará localmente na porta:7073 - acesse https://localhost:7073
```

## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/) - Linguagem
- [.NET](https://docs.microsoft.com/pt-br/dotnet/) - Framework
- [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet/apis) - Asp.NET Core WebAPI
- [ADO.NET](https://learn.microsoft.com/en-us/ef/core/) - EntityFramework Core
- [Swagger](https://swagger.io/) - Documentação da API

## ✒️ Colaborador(as/es)

- **Fernando Augusto Ribeiro Alves** - _Desenvolvedor_  - [Faralves](https://github.com/faralves)
- **André Leão da Silva** - _Desenvolvedor_ - [andreleaos](https://github.com/andreleaos)
- **André Bessa da Silva** - _Desenvolvedor_  - [bessax](https://github.com/bessax)
- **Liandro Freire dos Anjos** - _Desenvolvedor_  - [liandro](oliverliandro@gmail.com)
- **Diogo da Franca Rodrigues** - _Desenvolvedor_  - [diogo](diogo_f.rodrigues@hotmail.com)

