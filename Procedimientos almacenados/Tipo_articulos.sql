CREATE PROC sp_Insertar_tipo_articulo
@Id_tipo_articulo int output,
@Nombre_tipo varchar(200),
@Descripcion varchar(500)
AS
BEGIN TRY
BEGIN TRANSACTION Insertar_tipo_articulo
BEGIN
INSERT INTO Tipo_articulos
VALUES (@Nombre_tipo, @Descripcion)
SET @Id_tipo_articulo = SCOPE_IDENTITY()
END
COMMIT
RETURN 1
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0
DECLARE @Mensaje_error NVARCHAR(4000) = ERROR_MESSAGE();
DECLARE @Mensaje_severidad INT = ERROR_SEVERITY();
DECLARE @Estado_error INT = ERROR_STATE();
DECLARE @Numero_error INT = ERROR_NUMBER();
DECLARE @Error_procedure varchar(500) = ERROR_PROCEDURE();
DECLARE @Error_line INT = Error_line();
RAISERROR (@Mensaje_error,
           @Mensaje_severidad,
           @Estado_error,
		   @Numero_error,
		   @Error_procedure,
		   @Error_line
           ); 
ROLLBACK
RETURN -1
END CATCH
GO

CREATE PROC sp_Editar_tipo_articulo
@Id_tipo_articulo int,
@Nombre_tipo varchar(200),
@Descripcion varchar(500)
AS
BEGIN TRY
BEGIN TRANSACTION Editar_tipo_articulo
BEGIN
UPDATE Tipo_articulos
SET
Nombre_tipo = @Nombre_tipo,
Descripcion = @Descripcion
WHERE Id_tipo_articulo = @Id_tipo_articulo
END
COMMIT
RETURN 1
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0
DECLARE @Mensaje_error NVARCHAR(4000) = ERROR_MESSAGE();
DECLARE @Mensaje_severidad INT = ERROR_SEVERITY();
DECLARE @Estado_error INT = ERROR_STATE();
DECLARE @Numero_error INT = ERROR_NUMBER();
DECLARE @Error_procedure varchar(500) = ERROR_PROCEDURE();
DECLARE @Error_line INT = Error_line();
RAISERROR (@Mensaje_error,
           @Mensaje_severidad,
           @Estado_error,
		   @Numero_error,
		   @Error_procedure,
		   @Error_line
           ); 
ROLLBACK
RETURN -1
END CATCH
GO

CREATE PROC sp_Buscar_tipo_articulos
@Tipo_busqueda varchar(50),
@Texto_busqueda varchar(50)
AS
BEGIN TRY
BEGIN
IF @Tipo_busqueda = 'COMPLETO'
	BEGIN
		SELECT * 
		FROM Tipo_articulos
	END
ELSE IF @Tipo_busqueda = 'NOMBRE'
	BEGIN
		SELECT * 
		FROM Tipo_articulos
		WHERE Nombre_tipo like @Texto_busqueda + '%'
	END
END
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0
DECLARE @Mensaje_error NVARCHAR(4000) = ERROR_MESSAGE();
DECLARE @Mensaje_severidad INT = ERROR_SEVERITY();
DECLARE @Estado_error INT = ERROR_STATE();
DECLARE @Numero_error INT = ERROR_NUMBER();
DECLARE @Error_procedure varchar(500) = ERROR_PROCEDURE();
DECLARE @Error_line INT = Error_line();
RAISERROR (@Mensaje_error,
           @Mensaje_severidad,
           @Estado_error,
		   @Numero_error,
		   @Error_procedure,
		   @Error_line
           ); 
END CATCH
GO
