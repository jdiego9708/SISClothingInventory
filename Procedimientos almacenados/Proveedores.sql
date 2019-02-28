CREATE PROC sp_Insertar_proveedores
@Id_proveedor int output,
@Nombre_proveedor varchar(150),
@Telefono_proveedor varchar(50),
@Correo_electronico varchar(500)
AS
BEGIN TRY
BEGIN TRANSACTION Insertar_proveedor
BEGIN
DECLARE @Fecha_ingreso date = CONVERT(date,GETDATE())
INSERT INTO Proveedores
VALUES (@Fecha_ingreso, @Nombre_proveedor, @Telefono_proveedor, @Correo_electronico)
SET @Id_proveedor = SCOPE_IDENTITY()
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

CREATE PROC sp_Editar_proveedores
@Id_proveedor int,
@Nombre_proveedor varchar(150),
@Telefono_proveedor varchar(50),
@Correo_electronico varchar(500)
AS
BEGIN TRY
BEGIN TRANSACTION Editar_proveedor
BEGIN
UPDATE Proveedores
SET
Nombre_proveedor = @Nombre_proveedor,
Telefono_proveedor = @Telefono_proveedor,
Correo_electronico = @Correo_electronico
WHERE Id_proveedor = @Id_proveedor
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

CREATE PROC sp_Buscar_proveedores
@Tipo_busqueda varchar(50),
@Texto_busqueda varchar(50)
AS
BEGIN TRY
BEGIN
IF @Tipo_busqueda = 'COMPLETO'
	BEGIN
		SELECT TOP 500 * 
		FROM Proveedores
	END
ELSE IF @Tipo_busqueda = 'NOMBRE'
	BEGIN
		SELECT TOP 500 * 
		FROM Proveedores
		WHERE Nombre_proveedor like @Texto_busqueda + '%'
	END
ELSE IF @Tipo_busqueda = 'TELEFONO'
	BEGIN
		SELECT TOP 500 * 
		FROM Proveedores
		WHERE Telefono_proveedor like @Texto_busqueda
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