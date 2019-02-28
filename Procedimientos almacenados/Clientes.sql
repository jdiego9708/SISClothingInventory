CREATE PROC sp_Insertar_cliente
@Id_cliente int output,
@Nombre_cliente varchar(200),
@Telefono_empleado varchar(50),
@Correo_electronico varchar(500)
AS
BEGIN TRY
BEGIN TRANSACTION Insertar_cliente
BEGIN
DECLARE @Fecha_ingreso date = CONVERT(date,GETDATE())
INSERT INTO Clientes
VALUES (@Fecha_ingreso, @Nombre_cliente, @Telefono_empleado, @Correo_electronico)
SET @Id_cliente = SCOPE_IDENTITY()
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

CREATE PROC sp_Editar_cliente
@Id_cliente int,
@Nombre_cliente varchar(200),
@Telefono_empleado varchar(50),
@Correo_electronico varchar(500)
AS
BEGIN TRY
BEGIN TRANSACTION Editar_cliente
BEGIN
UPDATE Clientes
SET
Nombre_cliente = @Nombre_cliente,
Telefono_empleado = @Telefono_empleado,
Correo_electronico = @Correo_electronico
WHERE Id_cliente = @Id_cliente
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

CREATE PROC sp_Buscar_cliente
@Tipo_busqueda varchar(50),
@Texto_busqueda varchar(50)
AS
BEGIN TRY
BEGIN
IF @Tipo_busqueda = 'COMPLETO'
	BEGIN
		SELECT TOP 1000 *
		FROM Clientes
	END
ELSE IF @Tipo_busqueda = 'NOMBRE'
	BEGIN
		SELECT TOP 500 *
		FROM Clientes
		WHERE Nombre_cliente like @Texto_busqueda + '%'
	END
ELSE IF @Tipo_busqueda = 'TELEFONO'
	BEGIN
		SELECT TOP 500 *
		FROM Clientes
		WHERE Telefono_empleado like @Texto_busqueda
	END
ELSE IF @Tipo_busqueda = 'CORREO ELECTRONICO'
	BEGIN
		SELECT TOP 500 *
		FROM Clientes
		WHERE Correo_electronico like + '%' + @Texto_busqueda + '%'
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

