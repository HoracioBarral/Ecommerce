create database Ecommerce
go


use Ecommerce
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


create table StockPorTalles(
	ID_Registro int not null primary key CLUSTERED identity(1,1),
	Talle varchar(5) not null,
	Stock int not null check(Stock>=0),
	ID_Articulo int not null,
	foreign key(ID_Articulo) references Articulos(ID_Articulo),
	constraint UQ_talles_IDArticulo unique(ID_Articulo,Talle)
)
go


create table Imagenes(
	ID_Imagen int not null primary key CLUSTERED identity(1,1),
	Url_Imagen varchar(1500) not null,
	ID_Articulo int not null,
	foreign key(ID_Articulo) references Articulos(ID_Articulo),
	Estado bit not null Default 1
)
go


create table Pedidos(
	ID_Pedido int not null primary key CLUSTERED identity(1,1),
	--Cantidad int not null check(cantidad>0),
	--Talle varchar(5) not null,
	--ID_Articulo int not null,
	ID_Usuario int not null,
	Importe money not null check(importe>0),
	Fecha date not null check(Fecha<=getdate()) default getdate(),
	Estado int not null default 1 check(Estado>0 and Estado<6),
	--foreign key(ID_Articulo) references Articulos(ID_Articulo),
	foreign key(ID_Usuario) references Usuarios(ID_Usuario)
)
go


create table DetallePedidos(
	ID_Registro int not null primary key CLUSTERED identity(1,1),
	Cantidad int not null check(cantidad>0),
	Talle varchar(5) not null,
	ID_Articulo int not null,
	ID_Pedido int not null,
	Importe money not null check(importe>0),
	Estado bit not null default 1 check(Estado>=0 and Estado<=1),
	foreign key(ID_Articulo) references Articulos(ID_Articulo),
	foreign key(ID_Pedido) references Pedidos(ID_Pedido)
)
go


create table Carrousel(
	ID_Registro int not null primary key CLUSTERED identity(1,1),
	Texto1 varchar(100) null default 'Bienvenidos',
	Texto2 varchar(100) null default 'Aprovecha las Ofertas',
	Texto3 varchar(100) null default 'Tienda Grupo 30'
)
go


insert into Usuarios(NombreUsuario,Pass,ID_Rol,Estado) values('Administrador','Prueba2023',1,1) 


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
       ('Jeans clásicos', 'Jeans de mezclilla ',30000, 60, 7, 3),
       ('Gorra deportiva ', 'Gorra de béisbol Puma', 8000, 80, 6, 7),
       ('Buzo con capucha', 'Buzo cálido con capucha', 6000, 70, 4, 6);

INSERT INTO Imagenes (Url_Imagen, ID_Articulo)
VALUES ('https://nikearprod.vtexassets.com/arquivos/ids/699261-800-800?v=638229666028100000&width=800&height=800&aspect=true', 1),
		('https://nikearprod.vtexassets.com/arquivos/ids/699463-1200-1200?v=638229692034600000&width=1200&height=1200&aspect=true', 1),
       ('https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/c0b5234b4053469285dea83500d56eda_9366/Remera_3_Tiras_Blanco_CW1203_01_laydown.jpg', 2),
       ('https://levisarg.vtexassets.com/arquivos/ids/593707/272_6310356e0eb94.jpg?v=637976702233070000', 3),
       ('https://sporting.vtexassets.com/arquivos/ids/300847-1200-1200?width=1200&height=1200&aspect=true', 4),
       ('https://www.stockcenter.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dwd6185bf0/products/UBU11L187-1841/UBU11L187-1841-1.JPG', 5);


--Se insertan valores a la tabla Roles

insert into Roles values ('1'),('2')

go

CREATE PROCEDURE sp_ModificarArticulo
    @ID_Articulo INT,
    @NombreArticulo VARCHAR(50),
    @Descripcion VARCHAR(100),
    @Precio MONEY,
    @Stock INT,
    @ID_Categoria INT,
    @ID_Marca INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Articulos
        SET
            NombreArticulo = @NombreArticulo,
            Descripcion = @Descripcion,
            Precio = @Precio,
            Stock = @Stock,
            ID_Categoria = @ID_Categoria,
            ID_Marca = @ID_Marca
        WHERE
            ID_Articulo = @ID_Articulo;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK;

        -- Puedes agregar aquí código para manejar la excepción, por ejemplo:
        -- SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH;
END;

go


CREATE PROCEDURE sp_GuardarImagen
    @Url_Imagen VARCHAR(1500),
    @ID_Articulo INT
AS
BEGIN
    BEGIN TRY
        INSERT INTO Imagenes (Url_Imagen, ID_Articulo)
        VALUES (@Url_Imagen, @ID_Articulo);
    END TRY
    BEGIN CATCH
        -- Manejo de errores (puedes personalizar esto según tus necesidades)
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END

go

CREATE PROCEDURE sp_EliminarArticulo
    @ID_Articulo INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Articulos WHERE ID_Articulo = @ID_Articulo)
    BEGIN
        UPDATE Articulos SET Estado = 0 WHERE ID_Articulo = @ID_Articulo;
        PRINT 'Artículo eliminado correctamente.';
    END
    ELSE
    BEGIN
        PRINT 'El artículo no existe.';
    END
END;
go


CREATE PROCEDURE sp_ListarArticulos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        A.ID_Articulo,
        A.NombreArticulo,
        A.Descripcion,
        A.Estado,
        C.NombreCategoria AS Categoria,
        M.NombreMarca AS Marca,
        A.Precio,
        A.Stock,
        STRING_AGG(I.Url_Imagen, ';') AS Imagenes
    FROM
        Articulos A
        INNER JOIN Categorias C ON C.ID_Categoria = A.ID_Categoria
        INNER JOIN Marcas M ON M.ID_Marca = A.ID_Marca
        LEFT JOIN Imagenes I ON I.ID_Articulo = A.ID_Articulo
    GROUP BY
        A.ID_Articulo,
        A.NombreArticulo,
        A.Descripcion,
        A.Estado,
        C.NombreCategoria,
        M.NombreMarca,
        A.Precio,
        A.Stock;
END;