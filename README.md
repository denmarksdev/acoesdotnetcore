# Ações DotNetCore
Aplicação para registro de compra e venda de ações em ASP.NET Core e Angular 2+. 

# Demo

- [Demo da aplicação](https://dotactions.azurewebsites.net/clientes)

#  Requerimentos

- [Visual Studio 2017+](https://visualstudio.microsoft.com/pt-br/vs/)
- [SqlServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) se não for utilizar o Sqlite

# Uso

1. Configurar a connection string em **appsettings.config** se for utilizar o **SqlServer**
1. Pode ser escolhido o banco de dados SqlServer ou Sqlite em **Startup.cs** no método **InicializaBaseDados**

# API JSON

Exemplos:

## Clientes
### GET https://localhost:44379/api/clientes
Retorna Todos os clientes
```
[
    {
        "nome": "Denis",
        "dataNascimento": "1983-10-27T00:00:00",
        "tipoPessoa": "F",
        "cnpjCpf": null,
        "id": 1
    },
    {
        "nome": "Mario",
        "dataNascimento": "1990-05-27T00:00:00",
        "tipoPessoa": "J",
        "cnpjCpf": null,
        "id": 2
    }
]
```
### GET https://localhost:44379/api/clientes/{idCliente}
Retorna um cliente
```
{
    "nome": "Denis",
    "dataNascimento": "1983-10-27T00:00:00",
    "tipoPessoa": "F",
    "cnpjCpf": null,
    "id": 4
}
```
### POST https://localhost:44379/api/clientes
BODY 
```
{
  "nome" : "Mario",
  "DataNascimento" :"1990/05/27",
  "TipoPessoa": "J"
  "CnpjCpf": "opcional"
 }
  
```

### PUT https://localhost:44379/api/clientes/{idCliente}
BODY 
```
{
  "id" : 1,
  "nome" : "Mario",
  "DataNascimento" :"1990/05/27",
  "TipoPessoa": "J"
  "CnpjCpf": "opcional"
 }
  
```

### DELETE https://localhost:44379/api/clientes/{idCliente}


## Ações
### GET https://localhost:44379/api/acoes
Retorna Todos as ações
```
[
    {
        "codigoDaAcao": "A2",
        "dataCotacao": "2019-08-02T00:00:00",
        "valor": 200,
        "id": 1
    },
    {
        "codigoDaAcao": "A2",
        "dataCotacao": "2019-09-02T00:00:00",
        "valor": 100,
        "id": 2
    },
    {
        "codigoDaAcao": "A5",
        "dataCotacao": "2019-08-02T00:00:00",
        "valor": 500,
        "id": 3
    }
]
```
### GET https://localhost:44379/api/acoes/{idAcao}
Retorna um ação
```
{
   "codigoDaAcao": "A2",
   "dataCotacao": "2019-09-02T00:00:00",
   "valor": 100,
   "id": 5
}
```
### POST https://localhost:44379/api/acoes
BODY 
```
{
   "codigoDaAcao": "A2",
   "dataCotacao": "2019-09-02T00:00:00",
   "valor": 100
}  
```

### PUT https://localhost:44379/api/clientes/{idAcao}
BODY 
```
{
   "codigoDaAcao": "A2",
   "dataCotacao": "2019-09-02T00:00:00",
   "valor": 100,
   "id": 5
}  
  
```

### DELETE https://localhost:44379/api/acoes/{idAcao}


## Ordem
### GET https://localhost:44379/api/ordens
Retorna Todos as ordens
```
[
    {
        "tipoOrdem": "V",
        "dataOrdem": "2019-09-02T00:00:00",
        "quantidadeAcoes": 2,
        "dataCompra": "2019-09-02T00:00:00",
        "valorOrdem": 200,
        "taxaCorretagem": 0.7,
        "impostoRenda": 0,
        "idCliente": 4,
        "codigoAcao": "A1",
        "id": 1
    },
    {
        "tipoOrdem": "V",
        "dataOrdem": "2019-09-02T00:00:00",
        "quantidadeAcoes": 2,
        "dataCompra": "2019-08-02T00:00:00",
        "valorOrdem": 200,
        "taxaCorretagem": 0.7,
        "impostoRenda": 0,
        "idCliente": 4,
        "codigoAcao": "A2",
        "id": 2
    },
    {
        "tipoOrdem": "V",
        "dataOrdem": "2019-09-02T00:00:00",
        "quantidadeAcoes": 2,
        "dataCompra": "2019-08-02T00:00:00",
        "valorOrdem": 200,
        "taxaCorretagem": 0.7,
        "impostoRenda": 0,
        "idCliente": 4,
        "codigoAcao": "A2",
        "id": 3
    }
]
```

### GET https://localhost:44379/api/ordens/{idOrdem}
Retorna um ordem
```
{
    "tipoOrdem": "V",
    "dataOrdem": "2019-09-02T00:00:00",
    "quantidadeAcoes": 2,
    "dataCompra": "2019-09-02T00:00:00",
    "valorOrdem": 200,
    "taxaCorretagem": 0.7,
    "impostoRenda": 0,
    "idCliente": 4,
     "codigoAcao": "A1",
     "id": 1
}
```
### POST https://localhost:44379/api/ordens
BODY 
```
{
   "tipoOrdem"  : "V",
   "dataOrdem"  : "2019/09/02",
   "dataCompra" : "2019/08/02",
   "quantidadeAcoes" : 2,
   "codigoAcao": "A2",
   "idCliente":4
}
```

# Screenshoots

## Clientes
![](https://github.com/denmarksdev/acoesdotnetcore/blob/master/docs/cliente.PNG?raw=true "Ações DotNet")

## Ações
![](https://github.com/denmarksdev/acoesdotnetcore/blob/master/docs/acoes.PNG?raw=true "Ações DotNet")

## Ordens
![](https://github.com/denmarksdev/acoesdotnetcore/blob/master/docs/ordens.PNG?raw=true "Ações DotNet")


