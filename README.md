# 🤲 PROJETO AMPARE WEB ❤️ - BACKEND

![Banner Projeto Ampare](/docs/figuras/banner-readme.png)

### 🎓 Curso Sistemas para a Internet - PUC-MG

### Eixo 4 - Projeto: Desenvolvimento de Aplicações Distribuídas - Turma 01 - 2024/1

### 👁️‍🗨️ Visão do Produto

Para voluntários, que desejam encontrar, de maneira prática, projetos de ajuda humanitária urgentes na região, e ONGs, que desejam encontrar, de maneira prática e urgente, voluntários na região. O Projeto Ampare é uma aplicação web elaborada em ambiente acadêmico que objetiva a criação de uma plataforma de ajuda humanitária com o intuito de conectar voluntários e ONGs que necessitem de auxílio em atividades, causas e ações sociais urgentes. A plataforma fornecerá o acesso intuitivo dos voluntários à causas que necessitem de ajuda urgente, compartilhando informações e conectando-os diretamente às ONGs. Diferentemente de outras aplicações do mesmo segmento, nosso projeto busca apresentar uma conexão mais prática e rápida entre os voluntários e ONGs, pois tem como foco principal causas urgentes e de devida importância.

### 🧠 Integrantes

<ul>
<li>Angélica Almeida - [@angelicasa](https://github.com/angelicasa)
<li>Matheus Soares de Sales - [@matheus-9](https://github.com/matheus-9)
<li>Maria Michele de Freitas - [@mmichelefreitas](https://github.com/mmichelefreitas)
<li>Nicolas F. Petrachin Wulk - [@nickwulk](https://github.com/nickwulk)
<li>Raquel Bomjardim Ferreira - [@bomjardimraquel](https://github.com/bomjardimraquel)
<ul>

### Como rodar este projeto

- O projeto está dividido em 2 aplicações: Front-end e Back-end
- Pré-requisitos:
  - NodeJS deve estar instalado.
  - .NET CLI e Entity Framework Tools devem estar instalados.
  - Docker deve estar instalado.

## Inicie o banco de dados através do docker compose

- Navegue até a pasta src/ampare.api
- Execute o comando:
  docker compose up -d
- Rode as migrations utilizando o seguinte comando:
  dotnet ef database update

## Inicie a API

- Navegue até a pasta src/ampare.api
- Execute os seguintes comando:
  dotnet build
  dotnet watch

## Inicie a Aplicação Web

- Navegue até a pasta src/ampare-webapp
- Instale as dependências:
  npm install
- Inicie o projeto:
  npm run dev

### 🖊️ Orientador

Prof. Luiz Alberto Ferreira Gomes

## 📝 Instruções de utilização

Assim que a primeira versão do sistema estiver disponível, deverá complementar com as instruções de utilização. Descreva como instalar eventuais dependências e como executar a aplicação.

## Etapa 1: Requisitos do produto

- [Problemas e dores atuais](docs/01-problemas.md)
- [Expectativas com o produto](docs/02-expectativas.md)
- [Personas do produto](docs/03-personas.md)
- [Entendendo as funcionalidades](docs/04-funcionalidades.md), [Priorização](docs/04-priorizacao.md), [Restrições](docs/04-restricoes.md)
- [Especificação das APIs](docs/05-apis.md)
- [Roteiro de implementação](docs/roteiro-de-implementacao.md)

### Etapa 2: Integração de APIs com banco de dados e serviços externos

- [Trade-off de requisitos não funcionais](docs/tradeoffs.md)
- [Diagrama de Contexto](docs/diagrama-de-contexto.md)
- [Roteiro de implementação](docs/roteiro-de-implementacao.md)

### Etapa 3: Arquitetura da aplicação em nuvem

- [Diagrama de Contêiner](docs/diagrama-de-conteiner.md)
- [Roteiro de implementação](docs/roteiro-de-implementacao.md)

### Etapa 4: Testes e implantação da aplicação em nuvem

- [Roteiro de testes](docs/roteiro-de-teste-e-deploy.md)
- [Roteiro de implementação](docs/roteiro-de-implementacao.md)

### Etapa 5: Entrega e apresentação do produto

- [Roteiro para entrega e apresentação](docs/roteiro-de-entrega-e-apresentacao.md)
