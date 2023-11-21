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