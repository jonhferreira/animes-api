# Usa a imagem oficial do .NET SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie os arquivos .csproj
COPY "./AnimesAPI.API/AnimesAPI.API.csproj" "AnimesAPI.API/"
COPY "./AnimesAPI.Infrastructure/AnimesAPI.Infrastructure.csproj" "AnimesAPI.Infrastructure/"
COPY "./AnimesAPI.Application/AnimesAPI.Application.csproj" "AnimesAPI.Application/"
COPY "./AnimesAPI.Domain/AnimesAPI.Domain.csproj" "AnimesAPI.Domain/"
COPY "./AnimesAPI.Test/AnimesAPI.Test.csproj" "AnimesAPI.Test/"

# Restaura as dependências
RUN dotnet restore "AnimesAPI.API/AnimesAPI.API.csproj"

# Copia todo o código fonte
COPY . .

# Compila a aplicação
WORKDIR "/src/AnimesAPI.API"
RUN dotnet build "AnimesAPI.API.csproj" -c Release -o /app/build

# Publique a aplicação
RUN dotnet publish "AnimesAPI.API.csproj" -c Release -o /app/publish


# Usa a imagem oficial do .NET para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os arquivos publicados da etapa de build
COPY --from=build /app/publish .

# Define a porta que a aplicação vai usar
EXPOSE 8080

# Define o comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "AnimesAPI.API.dll"]

