
# DarkLegacy REST API
API RESTful de consulta e cadastro de jogos.

Demonstração simples de utilização de CRUD usando API REST, consultas e validações, com duas tabelas com foreign key entre elas.

## Instalação e Execução
```bash
# Download do projeto
link: https://github.com/FMRavelli/jogos-api
# Build e Execução
cd jogos-api
dotnet run
./jogos-api

# API Endpoint : https://127.0.0.1:7125
```

## Estrutura
```
├── DarkLegacyAPI
│   ├── connected Services
│   ├── Dependências
│   ├── Properties
│		├── launchsettings.json
│		└── serviceDependencies.json
│	├── Controllers
│		└── JogosController.cs
│	├── Data
│		└── DarkLegacyContext.cs
│	├── Models
│		├── Generos.cs
│		└── Jogos.cs
│	├── ViewModel
│		├── GenerosViewModel.cs
│		└── JogosViewModel.cs
│	├── appsettings.json
│	└── Program.cs


```

## Configurar LocalDB


1 - No menu superior do Visual Studio, vá em *Exibir > Pesquisador de Objetos do SQL Server* para abrir o Explorer do SQL Server.

2 - No Explorer do SQL Server, clique com o botão direito em *(localdb)\\MSSQLLocalDB* e clique em *Nova Consulta...*, isso fará que abra uma nova tela para configurar o banco.

3 - Rode o script para criação do banco, tabelas e os inserts iniciais de dados, o script se encontra na raíz do projeto no arquivo *SQLConfig.sql.*

## API

#### /Generos
* `GET` : Consulta todos os Gêneros;
	* Envio:
	```
	Params:
	page (int) -> default = 1
	pageSize (int) -> default = 5
	mostrarInativos (bool) -> default = false
	```
	* Retorno
	```json
	[
	  {
	    "idGenero": int,
	    "dsGenero": "string"
	  }
	]
	
* `POST` : Cria um novo Gênero;
	* Envio
	```json
	[
	  {
	    "dsGenero": "string"
	  }
	]
	```
	* Retorno
	```
	Mensagem de validação.
* `PUT` : Atualiza as informações de um Gênero já existente;
 	* Envio
 	```
 	Params:
	Ativar (bool) => Default = false
 	```
	```json
	[
	  {
	    "idGenero": int,
	    "dsGenero": "string"
	  }
	]
	```
	* Retorno
	```
	Mensagem de validação.
* `DELETE` : Remove o Gênero da listagem.
	* Envio:
	```
	Params:
	idGenero (int)
	```
	* Retorno
	```
	Mensagem de validação.
	```
#### /Jogos
* `GET` : Consulta todos os Jogos;
* 	* Envio:
	```
	Params:
	page (int) -> default = 1
	pageSize (int) -> default = 5
	ordenarNota (bool) -> default = false
	mostrarInativos (bool) -> default = false
	```
	* Retorno
```json
[
  {
    "idJogo": int,
    "nmJogo": "string",
    "anoLancamento": int,
    "nota": int,
    "dsGenero": "string"
  }
]
```
* `POST` : Cria um novo Jogo;
	* Envio
	```json
	[
	  {
    "nmJogo": "string",
    "idGenero": int,
    "anoLancamento": int,
    "nota": int
	  }
	]
	```
	* Retorno
	```
	Mensagem de validação.
* `PUT` : Atualiza as informações de um Jogo já existente;
 	* Envio
 	```
 	Params:
	Ativar (bool) => Default = false
 	```
	```json
	[
	  {
	"idJogo": int
    "nmJogo": "string",
    "idGenero": int,
    "anoLancamento": int,
    "nota": int
	  }
	]
	```
	* Retorno
	```
	Mensagem de validação.
* `DELETE` : Remove o Jogo  da listagem.
* Envio:
	```
	Params:
	idJogo (int)
	```
	* Retorno
	```
	Mensagem de validação.
	```
#### /Generos/{idGenero}
* `GET` : Consulta um Gênero pelo id.
	 * Envio:
	```
	Params:
	idGenero (int)
	```	
	* Retorno
	```
	Mensagem de validação.
	```

#### /Jogos/{idJogo}
* `GET` : Consulta um Jogo pelo id.
	* Envio:
	```
	Params:
	idJogo (int)
	```
	* Retorno
	```
	Mensagem de validação.
	```
