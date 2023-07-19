# API-CRUD

Essa API foi desenvolvida para prova prática da empresa ServeLoja, a API é usada principalmente para fornecer uma interface padronizada para interagir com um banco de dados ou sistema de armazenamento de dados. Ela abstrai a complexidade do gerenciamento de dados e fornece métodos simples e bem definidos para executar as operações de CRUD.

## Tecnologias Utilizadas

* .NET 6
* Entity Framework
* MySQL

## Pré-requisitos

* [.NET 6 SDK](https://markdownlivepreview.com/).
* Laragon
* MySQL WorkBench
* Insomina

## Configuração

1. Clone o repositório:


git clone https://github.com/WellingtonStz/crud-api


2. Acesse o diretório do projeto:


cd seu-repositorio


3. Configure as variáveis de ambiente necessárias.

ex: 
Valor da Variavel: Server=localhost; Port=3306; DataBase=users; Uid=root; Pwd=;


4. Execute os seguintes comandos para restaurar as dependências e iniciar a API:

dotnet restore
dotnet run

5. Acesse a API em http://localhost:porta, onde "porta" é a porta configurada para a sua API.

## Funcionalidades

A API tem diversas funcionalidades, ela realizar um CRUD de operações básicas de criação, leitura, atualização e exclusão de registros entre outras funcionalidades.


Exemplo:

* `GET /api/Users/{id}`: Retornar um usuario cadastrado pelo Id.
* `DELETE /api/Users/{id}`: Deleta um usuario cadastrado pelo Id.
* `GET /api/Users`: Retornar todos os usuarios cadastrado no sistema.
* `POST /api/Users`: Cria um novo usuario.
* `PUT /api/Users`: Atualiza as informações do usuario cadastrado.

Enfim, ela simplifica o desenvolvimento, promove a padronização e oferece uma maneira eficiente e segura de manipular dados em um sistema.


## Banco de Dados

O Entity Framework é uma estrutura de mapeamento de objeto/relacional. Ele mapeia os objetos de domínio em seu código para entidades em um banco de dados relacional. Na maior parte do tempo, você não precisa se preocupar com a camada de banco de dados, pois o Entity Framework cuida dela para você. Seu código manipula os objetos e as alterações são persistentes em um banco de dados.

Exemplo:

A API utiliza o Entity Framework para se comunicar com o banco de dados. O banco de dados padrão é o Mysql. Para configurar o banco de dados:

1. Crie em seu sistema a variavel de conexão, como mostrado no exemplo anterior, logo acima.

2. Antes de executar as migrations para gerar o banco de dados, certifique-se de o Laragon está rodando, instanciando a porta 3306, do MySQL e a sua connctionString, está correta, após isso execute:


dotnet ef database update

Esse comando executará todas as migrations criadas e irá gerar toda parte do Banco de Dados.
