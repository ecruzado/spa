ALTER TABLE dbo.area
ADD esOpcional bit NOT NULL DEFAULT 0

GO

CREATE TABLE dbo.area_colegio
(
	area_colegio_id int identity(1,1),
	area_id int NOT NULL,
	colegio_id int NOT NULL,
	nombre nvarchar(500) NOT NULL,
	estado bit NOT NULL,
	CONSTRAINT [PK_area_colegio] PRIMARY KEY (area_colegio_id)
)

GO

ALTER TABLE dbo.area_colegio ADD CONSTRAINT [FK_area_colegio_area] FOREIGN KEY(area_id)
REFERENCES dbo.area (area_id)

ALTER TABLE dbo.area_colegio ADD CONSTRAINT [FK_area_colegio_colegio] FOREIGN KEY(colegio_id)
REFERENCES dbo.colegio (colegio_id)
GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_area_lst_ByColegio')
   DROP PROCEDURE [clase].sp_area_lst_ByColegio
GO

CREATE PROC clase.sp_area_lst_ByColegio 
	@colegio_id int
AS
BEGIN
	SELECT a.area_id, a.esOpcional, a.area, @colegio_id as colegio_id, ac.nombre as nombreAlternativo
	FROM dbo.area a
	LEFT JOIN dbo.area_colegio ac on a.area_id = ac.area_id
	WHERE ac.area_id IS NULL OR ac.colegio_id = @colegio_id

END

GO

UPDATE [dbo].[area]
SET esOpcional = 1
WHERE area in ('Opcional 1', 'Opcional 2', 'Opcional 3');
GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_area_update')
   DROP PROCEDURE [clase].sp_area_update
GO


CREATE PROC clase.sp_area_update
	@area_id int,
	@colegio_id int,
	@nombre nvarchar(500)
AS
BEGIN
	if EXISTS(SELECT 0 FROM area_colegio WHERE colegio_id = @colegio_id AND area_id = @area_id)
		UPDATE area_colegio
		SET [nombre] = @nombre
		WHERE colegio_id = @colegio_id AND area_id = @area_id
	else 
		INSERT INTO area_colegio(area_id, colegio_id, nombre, estado) 
		VALUES (@area_id, @colegio_id, @nombre, 1)

END

GO

sp_helptext 'clase.sp_area_lst'


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_area_lst')
   DROP PROCEDURE [clase].sp_area_lst
GO


CREATE PROCEDURE [clase].sp_area_lst
	@colegio_id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT a.area_id, ISNULL(ac.nombre, a.area) area
	FROM dbo.area a
	LEFT JOIN dbo.area_colegio ac on a.area_id = ac.area_id AND ac.colegio_id = @colegio_id
	WHERE a.esOpcional = 0
		OR (a.esOpcional = 1 AND NULLIF(ac.nombre, '') IS NOT NULL)
END

	
IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_dearea_exportar')
   DROP PROCEDURE [clase].sp_dearea_exportar
GO

-- sp_helptext 'clase.sp_dearea_exportar'
CREATE PROC [clase].sp_dearea_exportar
	@dearea_id_origen int,
	@area_id_destino int
AS
BEGIN
DECLARE @dearea_id_nuevo int
DECLARE @especificas_inserts table(especifica_id_origen int, especifica_id_destino int)

	INSERT INTO [dbo].[dearea] (dearea, area, colegio_id, orden)
	SELECT dearea, @area_id_destino, colegio_id, orden
	FROM  [dbo].dearea 
	WHERE dearea_id = @dearea_id_origen

	SET @dearea_id_nuevo = SCOPE_IDENTITY()

	MERGE INTO dbo.[especifica]
	USING (SELECT * FROM especifica where dearea_id = @dearea_id_origen) as SRC
	ON 1=0
	WHEN NOT MATCHED BY TARGET THEN
	INSERT(especifica, dearea_id, orden)
	VALUES (SRC.especifica, @dearea_id_nuevo, SRC.orden)
	OUTPUT SRC.especifica_id as especifica_id_origen
		,inserted.especifica_id as especifica_id_destino
	INTO @especificas_inserts(especifica_id_origen, especifica_id_destino);

	INSERT INTO [dbo].[operativa] ([operativa], [especifica_id], orden)
	SELECT o.operativa, ei.especifica_id_destino, o.orden FROM [dbo].[operativa] o
	INNER JOIN @especificas_inserts ei ON o.especifica_id = especifica_id_origen

END


exec [clase].sp_dearea_exportar 8, 2

	SELECT a.area_id, ISNULL(a.area, ac.nombre) as area
	FROM dbo.area a
	LEFT JOIN dbo.area_colegio ac on a.area_id = ac.area_id

	SELECT * from dearea