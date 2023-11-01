create database Ecommerce
go

use ecommerce
go


create Table Roles(
	ID_Rol int not null primary key CLUSTERED identity(1,1),
	TipoDeRol varchar(30) unique not null,
)
go


create table Usuarios(
	ID_Usuario int not null primary key CLUSTERED identity(1,1),
	NombreUsuario varchar(30) not null unique,
	Nombre varchar(30) not null,
	Apellido varchar(30) not null,
	Mail varchar(50) not null,
	Telefono varchar(50) not null,
	FechaNacimiento date check (FechaNacimiento<getdate()) not null,
	Clave int not null,
	ID_Rol int not null,
	Estado bit not null default 1,
	foreign key(ID_Rol) references Roles(ID_Rol)
)
go


create table Marcas(
	ID_Marca int not null primary key CLUSTERED identity(1,1),
	NombreMarca varchar(30) unique not null
)
go


create table Categorias(
	ID_Categoria int not null primary key CLUSTERED identity(1,1),
	NombreCategoria varchar(30) unique not null
)
go

create table Articulos(
	ID_Articulo int not null primary key CLUSTERED identity(1,1),
	NombreArticulo varchar(50) not null,
	Descripcion varchar(100) null,
	Precio money not null check(Precio>0),
	Stock int not null check(Stock>=0),
	Estado bit not null default 1,
	ID_Categoria int not null,
	ID_Marca int not null,
	foreign key(ID_Categoria) references Categorias(ID_Categoria),
	foreign key(ID_Marca) references Marcas(ID_Marca)
)
go


create table Imagenes(
	ID_Imagen int not null primary key CLUSTERED identity(1,1),
	Url_Imagen varchar(1500) not null,
	ID_Articulo int not null,
	foreign key(ID_Articulo) references Articulos(ID_Articulo)
)
go




--Se insertan valores a la tabla de Categorias

INSERT INTO Categorias (NombreCategoria)
VALUES('Remeras'),('Pantalones'),('Bermudas'),('Buzos'),('Chombas'),('Gorras'),('Jeans'),('Polleras');


--Se insertan valores a la tabla Marcas

INSERT INTO Marcas (NombreMarca)
VALUES('Nike'),('Adidas'),('Levis'),('Topper'),('Wrangler'),('Umbro'),('Puma'),('Reebok'),('Kappa');


create view vw_listarCategorias as
select * from Categorias
