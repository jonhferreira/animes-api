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
   git clone https://github.com/seu-usuario/nome-do-repositorio.git
   cd nome-do-repositorio

2. **Suba os Containers**:
O projeto inclui um arquivo `docker-compose.yml` que configura a API e o banco de dados SQL Server. Para subir os containers, execute o seguinte comando:
   ```bash
   docker-compose up --build

## Acessando a API

Após os containers estarem em execução, a API estará disponível localmente pelo [link](http://localhost:5000)

## Acessando o Banco de Dados
  O SQL Server estará disponível na porta 1433. Você pode conectar ao banco de dados usando as seguintes credenciais:
  - **User: as
  - **Pass: animeSenha123
  - **Banco de Dados: animesdb

### Observação
Durante a execução dos containers, foi identificado um problema na comunicação entre a API e o banco de dados, que não pode ser solucionado no prazo determinado.
Individualmente a Aplicação e o banco de dados funcionam corretamente porém a comunicação não se apresenta correta. Por conta disso é indicado a **execução local da API**

## Executando a API localmente
Esses passos devem ser realizado após pelo menos o banco de dados está em execução no container, como apresentado anteriormente.

1. **Defina a string de conexão como variável de ambiente do sistema**
   ```bash
   Server=localhost,1433;Database=animesdb;User ID=sa;Password=animeSenha123;TrustServerCertificate=True;

2. **No Visual Studio acesse**  **Ferramentas->Gerenciador de Pacotes do Nuget->Console de Gerenciador de Pacotes** e digite
Ou utilizando a string de conexão
   ```bash
   update-database
Com isso as migrations serão executadas e seu banco estará pronto para os testes

3. **Acessando a documentação da API**
A documentação Swagger da Api estará disponível no [link](http://localhost:5000/swagger)	





