# Etapa 1: Build da aplicação
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /app

# Copia os arquivos do projeto para o diretório /app
COPY . ./

# Restaura as dependências
RUN dotnet restore

# Compila o projeto
RUN dotnet build -c Release -o /app/out

# Publica a aplicação
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Imagem final
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS base

WORKDIR /app

# Copia os arquivos da etapa de build para a etapa final
COPY --from=build /app/publish .

# Exponha a porta que a API vai escutar
EXPOSE 80

# Configuração do ambiente de produção
ENV ASPNETCORE_ENVIRONMENT=Production

# Etapa 3: Executando o comando para aplicar as migrations
CMD ["sh", "-c", "dotnet AnimesAPI.API.dll && dotnet ef database update"]
