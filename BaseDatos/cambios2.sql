IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_criterio_lst')
   DROP PROCEDURE [clase].sp_criterio_lst
GO

CREATE PROC clase.sp_criterio_lst 
	@area_id int,
	@colegio_id int
AS
BEGIN
	SELECT c.colegio_id,c.area_id,c.criterio_id,c.criterio
	FROM dbo.criterio c
	WHERE c.colegio_id = @colegio_id AND c.area_id = @area_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_criterio_insert')
   DROP PROCEDURE [clase].sp_criterio_insert
GO

CREATE PROC clase.sp_criterio_insert 
	@criterio nvarchar(500),
	@area_id int,
	@colegio_id int,
	@new_identity INT = NULL OUTPUT
AS
BEGIN
	INSERT INTO dbo.criterio(criterio, area_id, colegio_id)
	VALUES (@criterio, @area_id, @colegio_id)
	SET @new_identity = SCOPE_IDENTITY();
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_criterio_update')
   DROP PROCEDURE [clase].sp_criterio_update
GO

CREATE PROC clase.sp_criterio_update
	@criterio_id int,
	@criterio nvarchar(500),
	@area_id int,
	@colegio_id int
AS
BEGIN

UPDATE dbo.criterio 
set criterio = @criterio,
	area_id = @area_id,
	colegio_id = @colegio_id
where criterio_id = @criterio_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_criterio_delete')
   DROP PROCEDURE [clase].sp_criterio_delete
GO

CREATE PROC clase.sp_criterio_delete
	@criterio_id int
AS
BEGIN

delete from dbo.criterio where criterio_id = @criterio_id

END

GO
IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_metecnica_lstByCriterio')
   DROP PROCEDURE [clase].sp_metecnica_lstByCriterio
GO

CREATE PROC clase.sp_metecnica_lstByCriterio 
	@criterio_id int
AS
BEGIN
	SELECT m.criterio_id, m.metecnica_id, m.metecnica
	FROM dbo.metecnica m 
	WHERE m.criterio_id = @criterio_id
END

GO
IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_metecnica_insert')
   DROP PROCEDURE [clase].sp_metecnica_insert
GO

CREATE PROC clase.sp_metecnica_insert 
	@metecnica nvarchar(250),
	@criterio_id int,
	@new_identity INT = NULL OUTPUT
AS
BEGIN
	INSERT INTO dbo.metecnica(metecnica,criterio_id)
	VALUES (@metecnica, @criterio_id)
	SET @new_identity = SCOPE_IDENTITY();
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_metecnica_update')
   DROP PROCEDURE [clase].sp_metecnica_update
GO

CREATE PROC clase.sp_metecnica_update
	@metecnica_id int,
	@metecnica nvarchar(250),
	@criterio_id int
AS
BEGIN

UPDATE dbo.metecnica 
set metecnica = @metecnica,
	criterio_id = @criterio_id
where metecnica_id = @metecnica_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_metecnica_delete')
   DROP PROCEDURE [clase].sp_metecnica_delete
GO

CREATE PROC clase.sp_metecnica_delete
	@metecnica_id int
AS
BEGIN

delete from dbo.metecnica where metecnica_id = @metecnica_id

END

GO



IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_valores_lst')
   DROP PROCEDURE [clase].sp_valores_lst
GO

CREATE PROC clase.sp_valores_lst
	@colegio_id int
AS
BEGIN
	SELECT v.valores_id, v.valores, v.colegio_id
	FROM dbo.valores v
	WHERE v.colegio_id = @colegio_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_valores_insert')
   DROP PROCEDURE [clase].sp_valores_insert
GO

CREATE PROC clase.sp_valores_insert 
	@valores nvarchar(300),
	@colegio_id int,
	@new_identity INT = NULL OUTPUT
AS
BEGIN
	INSERT INTO dbo.valores(valores, colegio_id)
	VALUES (@valores, @colegio_id)
	SET @new_identity = SCOPE_IDENTITY();
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_valores_update')
   DROP PROCEDURE [clase].sp_valores_update
GO

CREATE PROC clase.sp_valores_update
	@valores_id int,
	@valores nvarchar(300),
	@colegio_id int
AS
BEGIN

UPDATE dbo.valores 
set valores = @valores,
	colegio_id = @colegio_id
where valores_id = @valores_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_valores_delete')
   DROP PROCEDURE [clase].sp_valores_delete
GO

CREATE PROC clase.sp_valores_delete
	@valores_id int
AS
BEGIN

delete from dbo.valores where valores_id = @valores_id

END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_actitud_lstByValores')
   DROP PROCEDURE [clase].sp_actitud_lstByValores
GO

CREATE PROC clase.sp_actitud_lstByValores
	@valores_id int
AS
BEGIN
	SELECT a.valores_id, a.actitud_id, a.actitud
	FROM dbo.actitud a 
	WHERE a.valores_id = @valores_id
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_actitud_insert')
   DROP PROCEDURE [clase].sp_actitud_insert
GO

CREATE PROC clase.sp_actitud_insert 
	@actitud nvarchar(500),
	@valores_id int,
	@new_identity INT = NULL OUTPUT
AS
BEGIN
	INSERT INTO dbo.actitud(valores_id,actitud)
	VALUES (@valores_id, @actitud)
	SET @new_identity = SCOPE_IDENTITY();
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_actitud_update')
   DROP PROCEDURE [clase].sp_actitud_update
GO

CREATE PROC clase.sp_actitud_update
	@actitud_id int,
	@actitud nvarchar(500),
	@valores_id int
AS
BEGIN

UPDATE dbo.actitud 
set actitud = @actitud,
	valores_id = @valores_id
where actitud_id = @actitud_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_actitud_delete')
   DROP PROCEDURE [clase].sp_actitud_delete
GO

CREATE PROC clase.sp_actitud_delete
	@actitud_id int
AS
BEGIN

delete from dbo.actitud where actitud_id = @actitud_id

END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_dearea_lst')
   DROP PROCEDURE [clase].sp_dearea_lst
GO

CREATE PROCEDURE clase.sp_dearea_lst
	@area as int,
	@colegio_id as int
AS
BEGIN
	SET NOCOUNT ON;

SELECT [dearea_id] ,[dearea] ,[area] FROM [dearea] where area=@area and colegio_id=@colegio_id 
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_dearea_insert')
   DROP PROCEDURE [clase].sp_dearea_insert
GO

CREATE PROCEDURE clase.sp_dearea_insert
	@dearea nvarchar(150)
    ,@area int
    ,@colegio_id int
	,@new_identity INT = NULL OUTPUT
AS

BEGIN

INSERT INTO [dearea]
          ([dearea]
           ,[area]
           ,[colegio_id])
     VALUES
           (@dearea
           ,@area
           ,@colegio_id)

	SET @new_identity = SCOPE_IDENTITY();

END 

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_dearea_update')
   DROP PROCEDURE [clase].sp_dearea_update
GO

CREATE PROCEDURE clase.sp_dearea_update
	@dearea nvarchar(150)
	,@dearea_id int 
	,@area int
	,@colegio_id int
AS

BEGIN

UPDATE [dearea]
SET [dearea] = @dearea
WHERE dearea_id=@dearea_id

END 

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_dearea_delete')
   DROP PROCEDURE [clase].sp_dearea_delete
GO

CREATE PROCEDURE clase.sp_dearea_delete
	@dearea_id int
AS

BEGIN

DELETE FROM [dearea]
WHERE dearea_id = @dearea_id

END
 
GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_especifica_lst')
   DROP PROCEDURE [clase].sp_especifica_lst
GO

CREATE PROCEDURE clase.sp_especifica_lst
	@dearea_id as int
AS


BEGIN
	SET NOCOUNT ON;

SELECT [especifica_id]
      ,[especifica]
      ,[dearea_id]
  FROM [especifica] 
  where [dearea_id]=@dearea_id
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_especifica_insert')
   DROP PROCEDURE [clase].sp_especifica_insert
GO

CREATE PROCEDURE [clase].sp_especifica_insert
	@especifica nvarchar(150)
    ,@dearea_id int
	,@new_identity INT = NULL OUTPUT
AS

BEGIN

INSERT INTO [especifica]([especifica]
           ,[dearea_id])
     VALUES
           (@especifica
           ,@dearea_id)
	SET @new_identity = SCOPE_IDENTITY();
END
           
GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_especifica_update')
   DROP PROCEDURE [clase].sp_especifica_update
GO

CREATE PROCEDURE clase.sp_especifica_update
	@especifica nvarchar(150)
	,@dearea_id int
	,@especifica_id int
AS

BEGIN

UPDATE [especifica]
   SET [especifica] = @especifica
WHERE especifica_id = @especifica_id

END 

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_especifica_delete')
   DROP PROCEDURE [clase].sp_especifica_delete
GO

CREATE PROCEDURE clase.sp_especifica_delete
    @especifica_id int
AS

BEGIN

DELETE FROM [especifica]
WHERE especifica_id=@especifica_id

END 
GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_operativa_lst')
   DROP PROCEDURE [clase].sp_operativa_lst
GO

CREATE PROCEDURE clase.sp_operativa_lst
	@especifica_id as int
AS

BEGIN
	SET NOCOUNT ON;

SELECT [operativa_id]
      ,[operativa]
      ,[especifica_id]
FROM [operativa] WHERE especifica_id=@especifica_id
  
END
GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_operativa_insert')
   DROP PROCEDURE [clase].sp_operativa_insert
GO

CREATE PROCEDURE clase.sp_operativa_insert
	@operativa nvarchar(150)
	,@especifica_id int
	,@new_identity INT = NULL OUTPUT
AS

BEGIN

INSERT INTO [operativa]
   ([operativa]
    ,[especifica_id])
     VALUES
    (@operativa
    ,@especifica_id)

	SET @new_identity = SCOPE_IDENTITY();

END
           
GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_operativa_update')
   DROP PROCEDURE [clase].sp_operativa_update
GO

CREATE PROCEDURE clase.sp_operativa_update
	@operativa nvarchar(150)
	,@especifica_id int
	,@operativa_id int
AS

BEGIN

UPDATE [operativa]
   SET [operativa] = @operativa
 WHERE operativa_id=@operativa_id

END 

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_operativa_delete')
   DROP PROCEDURE [clase].sp_operativa_delete
GO

CREATE PROCEDURE clase.sp_operativa_delete
   @operativa_id int
AS

BEGIN

DELETE FROM [operativa]
WHERE operativa_id =@operativa_id

END 

GO