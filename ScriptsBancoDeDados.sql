Create Database CRUD_MVC_TDD;

use CRUD_MVC_TDD;

CREATE TABLE [dbo].[Estabelecimento]
(
	id int IDENTITY(1,1) NOT NULL,
	nome varchar (50) NOT NULL,
	nomeFantasia varchar (50) null,
	cnpj varchar (18) not null,
	email varchar (30) NULL,
	telefone varchar(14) NULL,
 	categoriaId int NOT NULL,
	status bit not null,
	Primary Key (id),
	FOREIGN KEY(categoriaId) REFERENCES [dbo].[CategoriaEstabelecimento] ([id])
)

Create Table [dbo].[CategoriaEstabelecimento]
(
    id int IDENTITY(1,1) NOT NULL,
	nome varchar (30) NOT NULL,
	Primary Key (id),
)

insert into CategoriaEstabelecimento values ('SuperMercado');
insert into CategoriaEstabelecimento values ('Restaurante');
insert into CategoriaEstabelecimento values ('Borracharia');
insert into CategoriaEstabelecimento values ('Posto');
insert into CategoriaEstabelecimento values ('Oficina');

