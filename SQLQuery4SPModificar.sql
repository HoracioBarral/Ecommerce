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