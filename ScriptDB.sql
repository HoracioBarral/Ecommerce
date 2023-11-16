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
	Nombre varchar(30) null,
	Apellido varchar(30) null,
	Mail varchar(50) null,
	Telefono varchar(50) null,
	FechaNacimiento date check (FechaNacimiento<getdate()) null,
	Pass varchar(50) not null,
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
go

--Se insertan valores a la tabla Marcas

INSERT INTO Marcas (NombreMarca)
VALUES('Nike'),('Adidas'),('Levis'),('Topper'),('Wrangler'),('Umbro'),('Puma'),('Reebok'),('Kappa');
go

--Se crea la vista para que traiga todas las categorias

create view vw_listarCategorias as
select * from Categorias
go


--Se crea el procedimiento almacenado para que a partir de un IDArticulo traiga todas las imagenes de dicho articulo

create procedure sp_verImagenes(@idArticulo int) as
begin
	declare @cantidad int
	begin try
		select @cantidad=COUNT(Url_Imagen) from Imagenes
		if(@cantidad<0) begin
			raiserror('El articulo no tiene imagenes',16,1)
		end
		else begin
			select Url_Imagen from Imagenes where ID_Articulo=@idArticulo
		end
	end try
	begin catch
		raiserror('No hay imagenes',16,1)
	end catch
end

go


--Se insertan datos a las tablas Categorias, Articulos e Imagenes

INSERT INTO Categorias (NombreCategoria)
VALUES('Zapatillas')
INSERT INTO Articulos (NombreArticulo, Descripcion, Precio, Stock, ID_Categoria, ID_Marca)
VALUES ('Zapatillas deportivas', 'Zapatillas para correr Nike', 25000, 50, 9, 1),
       ('Camiseta deportiva', 'Camiseta para entrenamiento Adidas', 10000, 100, 8, 2),
       ('Jeans cl�sicos', 'Jeans de mezclilla ',30000, 60, 7, 3),
       ('Gorra deportiva ', 'Gorra de b�isbol Puma', 8000, 80, 6, 7),
       ('Buzo con capucha', 'Buzo c�lido con capucha', 6000, 70, 4, 6);

INSERT INTO Imagenes (Url_Imagen, ID_Articulo)
VALUES ('https://nikearprod.vtexassets.com/arquivos/ids/699261-800-800?v=638229666028100000&width=800&height=800&aspect=true', 1),
		('https://nikearprod.vtexassets.com/arquivos/ids/699463-1200-1200?v=638229692034600000&width=1200&height=1200&aspect=true', 1),
       ('https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/c0b5234b4053469285dea83500d56eda_9366/Remera_3_Tiras_Blanco_CW1203_01_laydown.jpg', 2),
       ('https://levisarg.vtexassets.com/arquivos/ids/593707/272_6310356e0eb94.jpg?v=637976702233070000', 3),
       ('https://sporting.vtexassets.com/arquivos/ids/300847-1200-1200?width=1200&height=1200&aspect=true', 4),
       ('https://www.stockcenter.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwd6185bf0/products/UBU11L187-1841/UBU11L187-1841-1.JPG', 5);


--Se insertan valores a la tabla Roles

insert into Roles values ('1'),('2')
