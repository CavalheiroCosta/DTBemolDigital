# DTBemolDigital

------------

Neste projeto viso apresentar duas situações:
+ Protótipo de documentação arquitetural de um onmichannel na notação C4
	+ Referência [C4 Model Documentação](https://c4model.com/ "C4 Model Documentação")
+ Implementação de uma API "CustomerApi" com as seguintes implementações
	+ Endpoint de Busca de endereços ao passar um cep (Busca de dados em [ViaCep](https://viacep.com.br/ "ViaCep"))
	+ Endpoin de cadastro de cliente Pessoa Fisica e Pessoa Juridica

**Sobre a execução do projeto**

Pode executar o projeto por linha de comando através de
``` dotnet run --project Customer.Api ```

Também há opções locais de execução através dos perfis:
+ http ou https
+ IIS Express
+ Docker

**Sobre a interface de utilização**

No projeto há a disposição um JSON referente a uma collection de postman e o projeto também contém swagger configurado.
+ Arquivo  [DTBemolDigital Collection](https://github.com/CavalheiroCosta/DTBemolDigital/blob/main/DTBemolDigital.postman_collection.json "DTBemolDigital Collection")

------------
### Sobre a API
No projeto consta a "CustomerApi" que foi desenvolvida utilizando [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/community/ "Visual Studio 2022") em .NET 7 e utilizando Swagger para documentação parcial de api.

**Sobre as features**

Foram implementados três features:
+ Busca de dados endereços utilizando o Cep `api/Customer/Address/{Cep}` recebendo o valor do Cep pela rota.
+ Cadastro de clientes pessoa fisica através de `api/Customer/Person` recebendo json pelo body.
```JSON
{
  "name": "string",
  "birthDate": "2023-02-19T23:39:29.855Z",
  "cpf": "string",
  "email": "string",
  "deliveryAddress": {
   	"cep": "string",
   	"identifier": "string",
   	"number": "string",
   	"complement": "string",
    	"reference": "string"
  	}
}
```
+ Cadastro de clientes pessoa Juridica através de `api/Customer/Company` recebendo json pelo body.
```JSON
{
  "name": "string",
  "corporateName": "string",
  "cnpj": "string",
  "email": "string",
  "deliveryAddress": {
    	"cep": "string",
    	"identifier": "string",
    	"number": "string",
    	"complement": "string",
    	"reference": "string"
  	}
}
```

------------


### Documentação C4
Três diagramas foram desenvolvidos em notação c4, com uma visão parcial de uma arquitetura omnichannel.
+ Para o desenvolvimento dos diagramas foi utilizado o [visual studio code](https://code.visualstudio.com/ "visual studio code") e [plant uml](https://plantuml.com/ "plant uml") com [biblioteca c4](https://github.com/plantuml-stdlib/C4-PlantUML "biblioteca c4").

##### Diagrama de contexto
![Context](https://github.com/CavalheiroCosta/DTBemolDigital/blob/main/out/Documentation/C4ContextDiagram/C4ContextDiagram.png "Context")

##### Diagrama de container
![Container](https://github.com/CavalheiroCosta/DTBemolDigital/blob/main/out/Documentation/C4ContainerDiagram/C4ContainerDiagram.png "Container")

##### Diagrama de componentes
![component](https://github.com/CavalheiroCosta/DTBemolDigital/blob/main/out/Documentation/C4ComponentDiagram/C4ComponentDiagram.png "component")


------------
