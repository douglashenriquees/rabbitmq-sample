## Criando o Projeto

* ```dotnet new sln --name solution_name```
* ```dotnet new console -o project_name```
* ```dotnet sln solution_name.sln add ./project_name/project_name.csproj```
* ```dotnet new gitignore```
* ```cd project_name```
* ```dotnet add package RabbitMQ.Client```

## Executando o Projeto

* ```dotnet run --project project_name```

## Executando o Container do RabbitMQ

* ```docker run -d -p 15672:15672 rabbitmq:3-management```