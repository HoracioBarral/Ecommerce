CREATE PROCEDURE sp_EliminarArticulo
    @ID_Articulo INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Articulos WHERE ID_Articulo = @ID_Articulo)
    BEGIN
        DELETE FROM Articulos WHERE ID_Articulo = @ID_Articulo;
        PRINT 'Art�culo eliminado correctamente.';
    END
    ELSE
    BEGIN
        PRINT 'El art�culo no existe.';
    END
END;