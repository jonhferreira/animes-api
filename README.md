# Projeto de API REST para Consulta de Animes

Este projeto consiste em uma **API REST** que retorna dados sobre animes, como títulos, descrições e diretor. A API foi desenvolvida utilizando as seguintes tecnologias:

- **.NET 8**: Framework moderno e de alto desempenho para desenvolvimento de aplicações.
- **SQL Server**: Banco de dados relacional para armazenamento de dados.
- **Entity Framework Core**: ORM para mapeamento objeto-relacional e gerenciamento de migrações.
- **MediatR**: Biblioteca para implementação do padrão Mediator, facilitando a separação de responsabilidades.
- **xUnit**: Framework para testes unitários, garantindo a qualidade do código.
- **Docker**: Containerização da aplicação e do banco de dados para facilitar a execução em diferentes ambientes.

---

## Como Executar o Projeto

### Pré-requisitos
Antes de executar o projeto, certifique-se de ter instalado em sua máquina:
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (opcional, para execução local da API)

---

### Executando a API e o Banco de Dados com Docker Compose

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/jonhferreira/animes-api.git
   cd animes-api

2. **Suba os Containers**:
   
   O projeto inclui um arquivo `docker-compose.yml` que configura a API e o banco de dados SQL Server. Para subir os containers, execute o seguinte comando:
   ```bash
   docker-compose up --build

## Acessando a API

Após os containers estarem em execução, a API estará disponível localmente pelo [link](http://localhost:5000)

## Acessando a documentação da API

A documentação Swagger da Api estará disponível no [link](http://localhost:5000/swagger)	





