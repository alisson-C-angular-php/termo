# 🧾 Sistema de Gestão de Termos de Aceite

Este projeto tem como objetivo gerenciar termos de aceite e consentimentos de usuários, incluindo controle de versões, itens aceitos individualmente e histórico de alterações. A aplicação foi desenvolvida com .NET, utilizando Dapper para acesso rápido ao banco de dados e Entity Framework para versionamento do schema.

## 🚀 Tecnologias Utilizadas

- ASP.NET Core
- Dapper
- SQL Server
- Entity Framework Core (Migrations)
- Docker

## 📦 Estrutura do Banco de Dados

As principais tabelas criadas na migration inicial são:

- `tb_cad_usuario`: Cadastro de usuários.
- `tb_cad_termo`: Termos de aceite com controle de versão.
- `tb_cad_termo_item`: Itens contidos dentro de cada termo.
- `tb_cad_termo_item_aceite`: Registro de aceite por item e usuário.
- `tb_cad_termo_item_aceite_usuario_historico`: Histórico de todas as interações.

## 🐳 Como subir o banco com Docker

### 1. Subir o container com o SQL Server:

```bash
docker compose up
```

Isso iniciará o serviço do SQL Server com as configurações definidas no docker-compose.yml.


### 2. Executar o script de inicialização:

```bash
docker run -it --rm -v ${PWD}/init:/scripts mcr.microsoft.com/mssql-tools \
/opt/mssql-tools/bin/sqlcmd -S host.docker.internal,1433 -U sa -P 'YourStrong!Passw0rd' \
-i /scripts/init.sql
```


Esse comando executa o script init.sql que sobe o banco e com dotnet ef migrations add CriarTabelaUsuarios
voce cria o banco.

📂 Organização do Projeto
<strong> Migrations/ </strong> – Arquivos de versionamento do banco de dados.


<strong> Repositories/ </strong> – Acesso ao banco usando Dapper.

<strong> Entities/ </strong>– Classes que representam as tabelas.

init/init.sql – Script inicial de criação das tabelas.

✅ Funcionalidades Implementadas
- Cadastro de novos termos com seus respectivos itens.

- Registro de aceite de itens por usuário.

- Histórico completo das decisões dos usuários.

- Listagem de termos aceitos.

📌 Requisitos
- Docker + Docker Compose

- .NET SDK 6.0 ou superior

- Git

📫 Contato
Caso queira contribuir ou tirar dúvidas, fique à vontade para abrir uma issue ou me chamar no LinkedIn.

