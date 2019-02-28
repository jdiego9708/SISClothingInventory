CREATE PROC sp_Insertar_articulo
@Id_articulo int output,
@Id_tipo_articulo int,
@Nombre_articulo varchar(500),
@Id_proveedor int,
@Cantidad int,
@Tipo_detalle varchar(50),
@Descripcion_detalle varchar(100),
@Precio_articulo int,
@Imagen varchar(1000)
AS
BEGIN TRY
BEGIN TRANSACTION Insertar_articulo
BEGIN
INSERT INTO Articulos
VALUES (@Id_tipo_articulo, @Nombre_articulo, @Id_proveedor, @Cantidad, @Tipo_detalle,
@Descripcion_detalle, @Precio_articulo, @Imagen)
SET @Id_articulo = SCOPE_IDENTITY()
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

CREATE PROC sp_Editar_articulo
@Id_articulo int,
@Id_tipo_articulo int,
@Nombre_articulo varchar(500),
@Id_proveedor int,
@Cantidad int,
@Tipo_detalle varchar(50),
@Descripcion_detalle varchar(100),
@Precio_articulo int,
@Imagen varchar(1000)
AS
BEGIN TRY
BEGIN TRANSACTION Editar_articulo
BEGIN
UPDATE Articulos
SET
Id_tipo_articulo = @Id_tipo_articulo,
Nombre_articulo = @Nombre_articulo,
Id_proveedor = @Id_proveedor,
Cantidad = @Cantidad,
Tipo_detalle = @Tipo_detalle,
Descripcion_detalle = @Descripcion_detalle,
Precio_articulo = @Precio_articulo,
Imagen = @Imagen
WHERE Id_articulo = @Id_articulo
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

CREATE PROC sp_Buscar_articulos
@Tipo_busqueda varchar(50),
@Texto_busqueda varchar(50)
AS
BEGIN TRY

BEGIN
IF @Tipo_busqueda = 'COMPLETO'
	BEGIN
		SELECT TOP 1000 *
		FROM Articulos ar 
		INNER JOIN Tipo_articulos tp ON 
		ar.Id_tipo_articulo = tp.Id_tipo_articulo
		INNER JOIN Proveedores pr ON
		ar.Id_proveedor = pr.Id_proveedor
	END
ELSE IF @Tipo_busqueda = 'NOMBRE'
	BEGIN
		SELECT TOP 500 *
		FROM Articulos ar 
		INNER JOIN Tipo_articulos tp ON 
		ar.Id_tipo_articulo = tp.Id_tipo_articulo
		INNER JOIN Proveedores pr ON
		ar.Id_proveedor = pr.Id_proveedor
		WHERE ar.Nombre_articulo like @Texto_busqueda + '%'
	END
ELSE IF @Tipo_busqueda = 'TIPO ARTICULO'
	BEGIN
		SELECT TOP 500 *
		FROM Articulos ar 
		INNER JOIN Tipo_articulos tp ON 
		ar.Id_tipo_articulo = tp.Id_tipo_articulo
		INNER JOIN Proveedores pr ON
		ar.Id_proveedor = pr.Id_proveedor
		WHERE ar.Id_tipo_articulo = @Texto_busqueda
	END
ELSE IF @Tipo_busqueda = 'ID PROVEEDOR'
	BEGIN
		SELECT TOP 500 *
		FROM Articulos ar 
		INNER JOIN Tipo_articulos tp ON 
		ar.Id_tipo_articulo = tp.Id_tipo_articulo
		INNER JOIN Proveedores pr ON
		ar.Id_proveedor = pr.Id_proveedor
		WHERE ar.Id_proveedor = @Texto_busqueda
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

