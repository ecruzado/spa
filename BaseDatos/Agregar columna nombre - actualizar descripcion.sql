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

delete [dbo].[area_colegio] 

GO

insert into [dbo].[area_colegio] ( area_id, colegio_id, nombre, estado)
select a.area_id, c.colegio_id, a.area, 1 
from [dbo].[area] a, colegio c
where a.esOpcional = 1

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

-- sp_helptext 'clase.sp_area_lst'


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

go

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
/*
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
*/

DECLARE @colegio_id int
DECLARE @area_origen int
DECLARE @dearea_destino_max int
DECLARE @dearea_origen_actual int

SELECT @colegio_id = colegio_id,
	@dearea_origen_actual = orden,
	@area_origen = area
FROM dearea 
WHERE dearea_id = @dearea_id_origen

SELECT @dearea_destino_max = ISNULL(MAX(orden), 0) + 1
FROM dearea
WHERE colegio_id = @colegio_id and area = @area_id_destino

UPDATE dearea
set area = @area_id_destino,
	orden = @dearea_destino_max
WHERE dearea_id = @dearea_id_origen

UPDATE dearea
set orden = orden - 1
WHERE colegio_id = @colegio_id 
	and area = @area_origen
	and orden >= @dearea_origen_actual

END

go

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_exportar_mantenimiento_columna')
   DROP PROCEDURE [clase].sp_exportar_mantenimiento_columna
GO

--exec [clase].sp_exportar_mantenimiento 1, 4, 0,0,0,0,1
CREATE PROCEDURE [clase].sp_exportar_mantenimiento_columna
	@colegio_id_origen int,
	@colegio_id_destino int,
	@columna_id int
AS
BEGIN

DECLARE @nivel1 table(id_origen int, id_destino int)
DECLARE @nivel2 table(id_origen int, id_destino int)

MERGE INTO dbo.conf_col_colegio
USING (
	SELECT * FROM conf_col_colegio 
	where colegio_id = @colegio_id_origen and columna_id = @columna_id and confcolcolegio_padre_id is null) as SRC
ON 1=0
WHEN NOT MATCHED BY TARGET THEN
INSERT(columna_id, colegio_id, area_id, nivel_id, grado_id, valor, orden, estado)
VALUES (SRC.columna_id, @colegio_id_destino, SRC.area_id, SRC.nivel_id, SRC.grado_id, SRC.valor, SRC.orden, SRC.estado)
OUTPUT SRC.confcolcolegio_id as id_origen
	,inserted.confcolcolegio_id as id_destino
INTO @nivel1(id_origen, id_destino);

MERGE INTO dbo.conf_col_colegio
USING (
	SELECT * FROM conf_col_colegio cc
	INNER JOIN @nivel1 n on cc.confcolcolegio_padre_id = n.id_origen
) as SRC
ON 1=0
WHEN NOT MATCHED BY TARGET THEN
INSERT(columna_id, colegio_id, area_id, nivel_id, grado_id, valor, orden, estado, confcolcolegio_padre_id)
VALUES (SRC.columna_id, @colegio_id_destino, SRC.area_id, SRC.nivel_id, SRC.grado_id, SRC.valor, SRC.orden, SRC.estado, SRC.id_destino)
OUTPUT SRC.confcolcolegio_id as id_origen
	,inserted.confcolcolegio_id as id_destino
INTO @nivel2(id_origen, id_destino);

INSERT INTO conf_col_colegio
(columna_id, colegio_id, area_id, nivel_id, grado_id, valor, orden, estado, confcolcolegio_padre_id)
SELECT columna_id, @colegio_id_destino, area_id, nivel_id, grado_id, valor, orden, estado, n.id_destino 
FROM conf_col_colegio cc
INNER JOIN @nivel2 n on cc.confcolcolegio_padre_id = n.id_origen

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_exportar_mantenimiento')
   DROP PROCEDURE [clase].sp_exportar_mantenimiento
GO

--exec [clase].sp_exportar_mantenimiento 1, 5, 0,0,0,0,1,1,1,1
CREATE PROCEDURE [clase].sp_exportar_mantenimiento
	@colegio_id_origen int,
	@colegio_id_destino int,
	@capacidad bit = 0,
	@contenido bit = 0,
	@valores bit = 0,
	@metodologia bit = 0,
	@columna1 bit = 0,
	@columna2 bit = 0,
	@columna3 bit = 0,
	@columna4 bit = 0
AS

BEGIN

IF @capacidad = 1
BEGIN
	DECLARE @deareas_inserts table(dearea_id_origen int, dearea_id_destino int)
	DECLARE @especificas_inserts table(especifica_id_origen int, especifica_id_destino int)

	MERGE INTO dbo.dearea
	USING (SELECT * FROM dearea where colegio_id = @colegio_id_origen) as SRC
	ON 1=0
	WHEN NOT MATCHED BY TARGET THEN
	INSERT(dearea, area, colegio_id, orden)
	VALUES (SRC.dearea, SRC.area, @colegio_id_destino, SRC.orden)
	OUTPUT SRC.dearea_id as dearea_id_origen
		,inserted.dearea_id as  dearea_id_destino
	INTO @deareas_inserts(dearea_id_origen, dearea_id_destino);

	MERGE INTO dbo.[especifica]
	USING (
		SELECT * FROM especifica e
		INNER JOIN @deareas_inserts dai on e.dearea_id = dai.dearea_id_origen
	) as SRC
	ON 1=0
	WHEN NOT MATCHED BY TARGET THEN
	INSERT(especifica, dearea_id, orden)
	VALUES (SRC.especifica, SRC.dearea_id_destino, SRC.orden)
	OUTPUT SRC.especifica_id as especifica_id_origen
		,inserted.especifica_id as especifica_id_destino
	INTO @especificas_inserts(especifica_id_origen, especifica_id_destino);

	INSERT INTO [dbo].[operativa] ([operativa], [especifica_id], orden)
	SELECT o.operativa, ei.especifica_id_destino, o.orden FROM [dbo].[operativa] o
	INNER JOIN @especificas_inserts ei ON o.especifica_id = especifica_id_origen

END

IF @contenido = 1
BEGIN

	DECLARE @organizador_inserts table(organi_id_origen int, organi_id_destino int)
	DECLARE @organizador2_inserts table(organi2_id_origen int, organi2_id_destino int)

	MERGE INTO dbo.organizador
	USING (SELECT * FROM organizador where colegio_id = @colegio_id_origen) as SRC
	ON 1=0
	WHEN NOT MATCHED BY TARGET THEN
	INSERT(organi, area, colegio_id, orden)
	VALUES (SRC.organi, SRC.area, @colegio_id_destino, SRC.orden)
	OUTPUT SRC.organi_id as organi_id_origen
		,inserted.organi_id as  organi_id_destino
	INTO @organizador_inserts(organi_id_origen, organi_id_destino);

	MERGE INTO dbo.organizador2
	USING (
		SELECT * FROM organizador2 o
		INNER JOIN @organizador_inserts oi on o.organi_id = oi.organi_id_origen
	) as SRC
	ON 1=0
	WHEN NOT MATCHED BY TARGET THEN
	INSERT(organi2, organi_id, nivel_id, grado_id, orden)
	VALUES (SRC.organi2, SRC.organi_id_destino, SRC.nivel_id, SRC.grado_id, SRC.orden)
	OUTPUT SRC.organi2_id as organi2_id_origen
		,inserted.organi2_id as organi2_id_destino
	INTO @organizador2_inserts(organi2_id_origen, organi2_id_destino);

	INSERT INTO [dbo].organizador3(organi3, organi2_id, orden)
	SELECT o.organi3, oi.organi2_id_destino, o.orden 
	FROM [dbo].organizador3 o
	INNER JOIN @organizador2_inserts oi ON o.organi2_id = oi.organi2_id_origen

END

IF @valores = 1
BEGIN
	DECLARE @valores_inserts table(valores_id_origen int, valores_id_destino int)

	MERGE INTO dbo.valores
	USING (SELECT * FROM valores where colegio_id = @colegio_id_origen) as SRC
	ON 1=0
	WHEN NOT MATCHED BY TARGET THEN
	INSERT(valores, colegio_id, orden)
	VALUES (SRC.valores, @colegio_id_destino, SRC.orden)
	OUTPUT SRC.valores_id as valores_id_origen
		,inserted.valores_id as valores_id_destino
	INTO @valores_inserts(valores_id_origen, valores_id_destino);

	INSERT INTO [dbo].actitud(actitud, valores_id, orden)
	SELECT a.actitud, vi.valores_id_destino, a.orden
	FROM [dbo].actitud a
	INNER JOIN @valores_inserts vi ON a.valores_id = vi.valores_id_origen
END

IF @metodologia = 1
BEGIN
	DECLARE @criterio_inserts table(criterio_id_origen int, criterio_id_destino int)

	MERGE INTO dbo.criterio
	USING (SELECT * FROM criterio where colegio_id = @colegio_id_origen) as SRC
	ON 1=0
	WHEN NOT MATCHED BY TARGET THEN
	INSERT(criterio, area_id, colegio_id, orden)
	VALUES (SRC.criterio, SRC.area_id, @colegio_id_destino, SRC.orden)
	OUTPUT SRC.criterio_id as criterio_id_origen
		,inserted.criterio_id as criterio_id_destino
	INTO @criterio_inserts(criterio_id_origen, criterio_id_destino);

	INSERT INTO [dbo].metecnica(metecnica, criterio_id, orden)
	SELECT m.metecnica, ci.criterio_id_destino, m.orden
	FROM [dbo].metecnica m
	INNER JOIN @criterio_inserts ci ON m.criterio_id = criterio_id_origen

END

IF @columna1 = 1
BEGIN
	exec clase.sp_exportar_mantenimiento_columna @colegio_id_origen, @colegio_id_destino, 1
END

IF @columna2 = 1
BEGIN
	exec clase.sp_exportar_mantenimiento_columna @colegio_id_origen, @colegio_id_destino, 2
END

IF @columna3 = 1
BEGIN
	exec clase.sp_exportar_mantenimiento_columna @colegio_id_origen, @colegio_id_destino, 3
END

IF @columna4 = 1
BEGIN
	exec clase.sp_exportar_mantenimiento_columna @colegio_id_origen, @colegio_id_destino, 4
END
	
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_especifica_exportar')
   DROP PROCEDURE [clase].sp_especifica_exportar
GO

-- sp_helptext 'clase.sp_dearea_exportar'
CREATE PROC [clase].sp_especifica_exportar
	@dearea_id_destino int,
	@especifica_id_origen int
AS
BEGIN
/*
DECLARE @especifica_id_nuevo int

	INSERT INTO [dbo].especifica(especifica, dearea_id, orden)
	SELECT especifica, @dearea_id_destino, orden
	FROM  [dbo].especifica 
	WHERE especifica_id = @especifica_id_origen

	SET @especifica_id_nuevo = SCOPE_IDENTITY()

	INSERT INTO [dbo].[operativa] ([operativa], [especifica_id], orden)
	SELECT o.operativa, @especifica_id_nuevo, o.orden
	FROM [dbo].[operativa] o
	WHERE especifica_id = @especifica_id_origen
*/

DECLARE @dearea_origen int
DECLARE @especifica_destino_max int
DECLARE @especifica_origen_actual int

SELECT
	@especifica_origen_actual = orden,
	@dearea_origen = dearea_id
FROM especifica 
WHERE especifica_id = @especifica_id_origen

SELECT @especifica_destino_max = ISNULL(MAX(orden), 0) + 1
FROM especifica
WHERE dearea_id = @dearea_id_destino

UPDATE especifica
set dearea_id = @dearea_id_destino,
	orden = @especifica_destino_max
WHERE especifica_id = @especifica_id_origen

UPDATE especifica
set orden = orden - 1
WHERE dearea_id = @dearea_origen
	and orden >= @especifica_origen_actual

END

GO

	
IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_operativa_exportar')
   DROP PROCEDURE [clase].sp_operativa_exportar
GO

-- sp_helptext 'clase.sp_dearea_exportar'
CREATE PROC [clase].sp_operativa_exportar
	@operativa_id_origen int,
	@especifica_id_destino int
AS
BEGIN
/*
	INSERT INTO [dbo].[operativa] ([operativa], [especifica_id], orden)
	SELECT o.operativa, @especifica_id_destino, o.orden
	FROM [dbo].[operativa] o
	WHERE operativa_id = @operativa_id_origen
*/

DECLARE @especifica_origen int
DECLARE @operativa_destino_max int
DECLARE @operativa_origen_actual int

SELECT
	@operativa_origen_actual = orden,
	@especifica_origen = especifica_id
FROM operativa 
WHERE operativa_id = @operativa_id_origen

SELECT @operativa_destino_max = ISNULL(MAX(orden), 0) + 1
FROM operativa
WHERE especifica_id = @especifica_id_destino

UPDATE operativa
set especifica_id = @especifica_id_destino,
	orden = @operativa_destino_max
WHERE operativa_id = @operativa_id_origen

UPDATE operativa
set orden = orden - 1
WHERE especifica_id = @especifica_origen
	and orden >= @operativa_origen_actual

END


GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_dearea_combinar')
   DROP PROCEDURE [clase].sp_dearea_combinar
GO

-- sp_helptext 'clase.sp_dearea_exportar'
CREATE PROC [clase].sp_dearea_combinar
	@dearea_id_origen int,
	@dearea_id_destino int
AS
BEGIN

DECLARE @deareaOrigen nvarchar(150)
DECLARE @deareaDestino nvarchar(150)
DECLARE @especifica_origen_max_orden int
DECLARE @deareDetino_orden int
DECLARE @colegio_id int
DECLARE @area_id int

SELECT @deareaOrigen = dearea
FROM  [dbo].dearea 
WHERE dearea_id = @dearea_id_origen

SELECT @deareaDestino = dearea, @deareDetino_orden = orden, 
	@colegio_id = colegio_id, @area_id = area
FROM  [dbo].dearea 
WHERE dearea_id = @dearea_id_destino

SELECT @especifica_origen_max_orden = ISNULL(MAX(orden), 1)
FROM especifica
WHERE dearea_id = @dearea_id_origen

UPDATE dbo.dearea
SET dearea = @deareaOrigen + ' ' + @deareaDestino
WHERE dearea_id = @dearea_id_origen

UPDATE dbo.dearea
set orden = orden - 1
WHERE colegio_id = @colegio_id and area = @area_id
	AND orden >= @deareDetino_orden

UPDATE dbo.especifica
SET dearea_id = @dearea_id_origen,
	orden = @especifica_origen_max_orden,
	@especifica_origen_max_orden = @especifica_origen_max_orden + 1 
where dearea_id = @dearea_id_destino

DELETE dbo.dearea
where dearea_id = @dearea_id_destino

END


GO



IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_especifica_combinar')
   DROP PROCEDURE [clase].sp_especifica_combinar
GO

-- sp_helptext 'clase.sp_dearea_exportar'
CREATE PROC [clase].sp_especifica_combinar
	@especifica_id_origen int,
	@especifica_id_destino int
AS
BEGIN

DECLARE @especificaOrigen nvarchar(150)
DECLARE @especificaDestino nvarchar(150)
DECLARE @operativa_origen_max_orden int
DECLARE @dearea_id int
DECLARE @especifica_destino_orden int

SELECT @especificaOrigen = especifica
FROM  [dbo].especifica 
WHERE especifica_id = @especifica_id_origen

SELECT @especificaDestino = especifica,
	@dearea_id = dearea_id,
	@especifica_destino_orden = orden
FROM  [dbo].especifica 
WHERE especifica_id = @especifica_id_destino

SELECT @operativa_origen_max_orden = ISNULL(MAX(orden), 1)
FROM operativa
WHERE especifica_id = @especificaOrigen

UPDATE dbo.especifica
SET especifica = @especificaOrigen + ' ' + @especificaDestino
WHERE especifica_id = @especifica_id_origen

UPDATE dbo.especifica
SET orden = orden -1
WHERE dearea_id = @dearea_id
	AND orden >= @especifica_destino_orden

UPDATE dbo.operativa
SET especifica_id = @especifica_id_origen,
	orden = @operativa_origen_max_orden,
	@operativa_origen_max_orden = @operativa_origen_max_orden + 1
where especifica_id = @especifica_id_destino

DELETE dbo.especifica
where especifica_id = @especifica_id_destino

END


GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_operativa_combinar')
   DROP PROCEDURE [clase].sp_operativa_combinar
GO

-- sp_helptext 'clase.sp_dearea_exportar'
CREATE PROC [clase].sp_operativa_combinar
	@operativa_id_origen int,
	@operativa_id_destino int
AS
BEGIN

DECLARE @operativaOrigen nvarchar(150)
DECLARE @operativaDestino nvarchar(150)
DECLARE @especifica_id int;
DECLARE @operativa_orden_destino int

SELECT @operativaOrigen = operativa
FROM  [dbo].operativa 
WHERE operativa_id = @operativa_id_origen

SELECT @operativaDestino = operativa,
	@especifica_id = especifica_id,
	@operativa_orden_destino = orden
FROM  [dbo].operativa 
WHERE operativa_id = @operativa_id_destino

UPDATE dbo.operativa
SET operativa = @operativaOrigen + ' ' + @operativaDestino
WHERE operativa_id = @operativa_id_origen

UPDATE dbo.operativa
SET orden = orden - 1
where especifica_id = @especifica_id
	and orden >= @operativa_orden_destino

DELETE dbo.operativa
where operativa_id = @operativa_id_destino

END


GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_colegio_insert')
   DROP PROCEDURE [clase].sp_colegio_insert
GO


-- =============================================
-- Author:		carlos onocuica
-- Create date: 30-10-2013
-- Description:	registrar clase 
-- =============================================
CREATE PROCEDURE clase.sp_colegio_insert
	@colegio_nombre as nvarchar(250)
	,@colegio_dirección as nvarchar(250)
	,@colegio_telefono as nvarchar(25)
	,@new_identity INT = NULL OUTPUT
AS
BEGIN

INSERT INTO [colegio]
           ([colegio_nombre]
           ,[colegio_dirección]
           ,[colegio_telefono])
VALUES
           (@colegio_nombre
           ,@colegio_dirección
           ,@colegio_telefono)
  

SET @new_identity = SCOPE_IDENTITY();

INSERT INTO [dbo].[col_colegio] (columna_id, colegio_id, nombre, estado)
VALUES(1, @new_identity, 'Columna 1', 1)

INSERT INTO [dbo].[col_colegio] (columna_id, colegio_id, nombre, estado)
VALUES(2, @new_identity, 'Columna 2', 1)

INSERT INTO [dbo].[col_colegio] (columna_id, colegio_id, nombre, estado)
VALUES(3, @new_identity, 'Columna 3', 1)

INSERT INTO [dbo].[col_colegio] (columna_id, colegio_id, nombre, estado)
VALUES(4, @new_identity, 'Columna 4', 1)

insert into [dbo].[area_colegio] ( area_id, colegio_id, nombre, estado)
select a.area_id, c.colegio_id, a.area, 1 
from [dbo].[area] a, colegio c
where a.esOpcional = 1 and c.colegio_id = @new_identity

END

GO


GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_copiar')
   DROP PROCEDURE [clase].sp_clase_copiar
GO


CREATE PROCEDURE clase.sp_clase_copiar
	@clase_id_origen int 
    ,@colegio_id int
    ,@fecha_inicio nvarchar(10)
    ,@fecha_fin nvarchar(10)
    ,@fecha_reg datetime
    ,@usuario nvarchar(50)
	,@new_identity INT = NULL OUTPUT
AS
BEGIN
	INSERT INTO [dbo].[clase] ([clase_titulo], [colegio_id], [area_id], [nivel_id], [grado_id],[fecha_inicio],
		[fecha_fin], [fecha_reg], [usuario], [obs_clase], [obs_pruebas], [formato])
	SELECT c.clase_titulo, @colegio_id, c.area_id, c.nivel_id, c.grado_id,CONVERT(Datetime, @fecha_inicio, 103),
		CONVERT(Datetime, @fecha_fin, 103), @fecha_reg, @usuario, c.obs_clase, c.obs_pruebas, c.formato
	FROM dbo.clase c WHERE c.clase_id = @clase_id_origen

	SET @new_identity = SCOPE_IDENTITY();

	INSERT INTO dbo.clase_actividad([actividades], [actividades_hora], [clase_id], [actividades1], [actividades_hora1],
		[actividades2], [actividades_hora2])
	SELECT [actividades], [actividades_hora], @new_identity, [actividades1], [actividades_hora1],
		[actividades2], [actividades_hora2]
	FROM dbo.clase_actividad WHERE clase_id = @clase_id_origen

	INSERT INTO dbo.clase_capacidad([clase_id], [operativa_id])
	SELECT @new_identity, operativa_id FROM dbo.clase_capacidad WHERE clase_id = @clase_id_origen

	INSERT INTO [dbo].[clase_conf_col_colegio]([clase_id], [confcolcolegio_id])
	SELECT @new_identity, confcolcolegio_id FROM dbo.[clase_conf_col_colegio] WHERE clase_id = @clase_id_origen

	INSERT INTO [dbo].[clase_contenido](organi3_id, clase_id)
	SELECT organi3_id, @new_identity FROM dbo.clase_contenido WHERE clase_id = @clase_id_origen

	INSERT INTO [dbo].[clase_item_registro_reactivo]([item_reg_act_id], [clase_id])
	SELECT clase_item_reg_act_id, @new_identity FROM [dbo].[clase_item_registro_reactivo] WHERE clase_id = @clase_id_origen

	INSERT INTO [dbo].[clase_matriz]([formativa], [sumativa], [autoevaluativa], [coevaluativa], [heteroevaluacion],
		[censal], [muestral], [indicador_logro], [clase_id], [pruebatxt], [obsclase])
	SELECT formativa, sumativa, autoevaluativa, coevaluativa, heteroevaluacion,
		censal, muestral, indicador_logro, @new_identity, pruebatxt, obsclase 
	FROM [dbo].[clase_matriz] WHERE clase_id = @clase_id_origen
	
	INSERT INTO clase_metodo(metecnica_id, clase_id)
	SELECT metecnica_id, @new_identity FROM clase_metodo WHERE clase_id = @clase_id_origen

	INSERT INTO [dbo].[clase_tipo_conocimiento]( tipo_conocimiento_id, clase_id)
	SELECT tipo_conocimiento_id, @new_identity FROM clase_tipo_conocimiento
	WHERE clase_id = @clase_id_origen

	INSERT INTO [dbo].[clase_valores] ([actitud_id], [clase_id])
	SELECT actitud_id, @new_identity FROM dbo.clase_valores WHERE clase_id = @clase_id_origen
END
