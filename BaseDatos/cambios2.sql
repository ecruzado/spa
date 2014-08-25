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