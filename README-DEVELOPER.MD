Projeto de Sistema teste ambevTech
Este projeto é uma implementação do teste ambevTech. Ele utiliza .NET e algumas boas práticas de desenvolvimento, como CQRS, DDD e validação com FluentValidation. Ele faz uso de containers Docker para facilitar a execução e a configuração de ambiente.

Tecnologias Utilizadas
C#
.NET Core 8.0
Automapper
Arquitetura CQRS (Command Query Responsibility Segregation)
DDD (Domain-Driven Design)
Entity Framework Core
FluentValidation
Docker
Como Executar o Projeto
Pré-requisitos
Docker: Certifique-se de ter o Docker instalado em sua máquina para rodar os containers.
MongoDB: A aplicação depende de uma collection chamada Carts no MongoDB. Garanta que o MongoDB esteja configurado corretamente.
Visual Studio: Para rodar o banco de dados e interagir com o projeto.
Passos para Execução
Configuração Inicial

Na raiz do projeto, há um arquivo docker-compose.yml. Este arquivo configura os containers necessários para a aplicação, incluindo o banco de dados e a Web API.

Rodar os Containers Docker

No terminal, na pasta raiz do projeto, execute o comando:

bash
Copiar
Editar
docker-compose up
Esse comando irá iniciar os containers definidos no docker-compose.yml. Se você precisar alterar algo na configuração do Docker, edite o arquivo Dockerfile dentro da pasta WebApi.

Banco de Dados

Antes de rodar o projeto, certifique-se de que a collection Carts exista no MongoDB. Caso contrário, crie a collection manualmente ou configure o MongoDB para criar automaticamente.

Atualizar Banco de Dados

Após os containers estarem em execução, abra o Console do Gerenciador de Pacotes do Visual Studio e execute o comando abaixo para criar o banco de dados e as tabelas necessárias:

update-database
Isso irá garantir que o banco de dados seja inicializado com as tabelas definidas através do Entity Framework Core.

Funcionalidades Implementadas
Foram implementadas todas as features descritas no documento .doc, incluindo:

Carts: Gerenciamento de carrinhos de compras.
Users: Cadastro e gerenciamento de usuários.
Auth: Sistema de autenticação de usuários.
Products: Gerenciamento de produtos.
Sale: Processamento de vendas e transações.
Estrutura do Projeto
A arquitetura segue os princípios de CQRS e DDD.

Na pasta Adapter teremos a pasta Driven (onde estão localizados os projetos ORM do Postgres e do Mongo) e a pasta Drivers(Onde está localizada a API com as features)
Na pasta Core, temos a application, onde estão os Handles, commands e results de cada feature e a Domain, onde temos os repositories, entidades, enums, arquivos em comum e etc

