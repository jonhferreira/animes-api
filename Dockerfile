# Usa a imagem oficial do .NET SDK para compilar a aplica��o
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie os arquivos .csproj
COPY "./AnimesAPI.API/AnimesAPI.API.csproj" "AnimesAPI.API/"
COPY "./AnimesAPI.Infrastructure/AnimesAPI.Infrastructure.csproj" "AnimesAPI.Infrastructure/"
COPY "./AnimesAPI.Application/AnimesAPI.Application.csproj" "AnimesAPI.Application/"
COPY "./AnimesAPI.Domain/AnimesAPI.Domain.csproj" "AnimesAPI.Domain/"
COPY "./AnimesAPI.Test/AnimesAPI.Test.csproj" "AnimesAPI.Test/"

# Restaura as depend�ncias
RUN dotnet restore "AnimesAPI.API/AnimesAPI.API.csproj"

# Copia todo o c�digo fonte
COPY . .

#Instala a tool dotnet ef
RUN dotnet tool install --global dotnet-ef

# Adiciona o dotnet-ef ao PATH
ENV PATH="$PATH:/root/.dotnet/tools"

# Compila a aplica��o
WORKDIR "/src/AnimesAPI.API"
RUN dotnet build "AnimesAPI.API.csproj" -c Release -o /app/build

# Publique a aplica��o
RUN dotnet publish "AnimesAPI.API.csproj" -c Release -o /app/publish

#RUN dotnet ef database update --project ../AnimesAPI.Infrastructure/AnimesAPI.Infrastructure.csproj

# Usa a imagem oficial do .NET para rodar a aplica��o
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os arquivos publicados da etapa de build
COPY --from=build /app/publish .

# Define a porta que a aplica��o vai usar
EXPOSE 8080

# Define o comando de inicializa��o da aplica��o
ENTRYPOINT ["dotnet", "AnimesAPI.API.dll"]

