![Logo Dapper](https://github.com/thiagoubiratan/CrudDapperMVC/blob/master/Dapper.logo.png)

# Crud Dapper ORM com MVC
CRUD básico com Dapper utilizando MVC5 e SqlServer.

# Mas o que é Dapper?
O Dapper é um Micro ORM (Object Relational Mapping) voltado para o desenvolvimento .NET, onde seu principal objetivo é melhorar o desempenho das consultas ao banco de dados. Ele não conta com toda a gama de um ORM mais facilita muito o desenvolvimento de aplicações com melhor desempenho.

# Como o Dapper funciona?
O Dapper trabalha com o conceito de Extension methods, onde ele implementa um método de extensão da classe de conexão do banco, onde ao fazer a consulta ao banco de dados o mesmo vai fazer o mapeamento do retorno do Data Reader para o Modelo de dados.

### Tecnologias Usadas
* MVC 5.2.7
* Target Framework net48
* Dapper 2.0.35
* DataTables 1.10.15
* Toastr 2.1.1
* Boostrap 4.5.2

### Script para criação do banco de dados

```
CREATE DATABASE UserRegisterDB

USE UserRegisterDB

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS	WHERE table_name = 'Client')
BEGIN
	CREATE TABLE Client (
		Id INT NOT NULL IDENTITY,
		Name VARCHAR(250) NOT NULL,
		CPF VARCHAR(11) NOT NULL,
		Email VARCHAR(200) NOT NULL,
		Phone VARCHAR(11) NOT NULL,
		Active BIT NOT NULL,
		DateRegister DATETIME NOT NULL DEFAULT GETDATE(),
		ZipCode VARCHAR(8) NOT NULL,
		Street VARCHAR(180) NOT NULL,
		Number INT NOT NULL,
		AddressComplement VARCHAR(180) NULL,
		City VARCHAR(180) NOT NULL,
		Neighborhood VARCHAR(80) NOT NULL,
		State VARCHAR(2) NOT NULL
	)
END;
```
