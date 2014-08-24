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



