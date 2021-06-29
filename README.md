# Como criar um projeto novo com C# e serverless

## Instalação do dotnet core compatível:

https://docs.microsoft.com/pt-br/dotnet/core/install/linux-ubuntu#1804-

```bash
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update

# Este é compatível
sudo apt-get install -y dotnet-sdk-3.1
# Este é o último
sudo apt-get install -y dotnet-sdk-5.0
```

Adicionar a pasta local do dotnet no PATH:

```bash
export PATH=${PATH}:$HOME/.dotnet/tools
```

## Instalar o serverless

```bash
npm i -g serverless
```

##  Criar um projeto do serverless com suporte a C# e instalar o plugin para execução offline

```bash
serverless create --template aws-csharp
./build.sh
```

4) Adicionar o endpoint de exemplo

```yaml
#    The following are a few example events you can configure
#    NOTE: Please make sure to change your handler code to work with those events
#    Check the event documentation for details
    events:
      - httpApi:
          path: /users/create
          method: post
```
Nota: Cuidado com tabulação!!!

## Compilar o projeto
```bash
./build.sh
```

## Instalar as coisas do API gateway
```bash
dotnet add package Amazon.Lambda.APIGatewayEvents
```

## Instalar a entity-framework e do suporte ao MySQL

https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
```bash
dotnet tool install --global dotnet-ef
dotnet add package MySql.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
```
7) Adicionar os modelos no código (conteúdo de models) e criar a migração
Nota: deve-se ter uma instância do MariaDB em execução e acessível.

```bash
docker run -p 3306:3306 --name mariadb --rm -d -eMARIADB_ROOT_PASSWORD=root mariadb
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Faça um teste!

```bash
./build.sh
serverless invoke local --function CreateUser --path ./invoke-request.json
```

## Tudo de uma vez

```bash
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update

sudo apt-get install -y dotnet-sdk-3.1
export PATH=${PATH}:$HOME/.dotnet/tools

npm i -g serverless
dotnet add package Amazon.Lambda.APIGatewayEvents

./build.sh

# Adicione código neste momento!!

dotnet tool install --global dotnet-ef
dotnet add package MySql.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design

docker run -p 3306:3306 --name mariadb --rm -d -eMARIADB_ROOT_PASSWORD=root mariadb

dotnet ef migrations add InitialUserCreate
dotnet ef database update

```