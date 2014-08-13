--CREATE SCHEMA clase AUTHORIZATION dbo

GO 

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_dearea_lst')
   DROP PROCEDURE [clase].[sp_dearea_lst]
GO

-- =============================================
-- Author:		Edagr Cruzado
-- Create date: 21-06-14
-- Description:	Lista dearea con sus especificas y operativas
-- =============================================
CREATE PROCEDURE [clase].[sp_dearea_lst]
@area as int,
@colegio_id as int
AS
BEGIN
	SET NOCOUNT ON;

select da.dearea_id, da.dearea, e.especifica_id, e.especifica, o.operativa_id, o.operativa
from dearea da inner join especifica e on da.dearea_id = e.dearea_id
	inner join operativa o on e.especifica_id = o.especifica_id
where da.area = @area
	and da.colegio_id = @colegio_id 
order by da.dearea, da.dearea_id, e.especifica, e.especifica_id, o.operativa, o.operativa_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_capacidad')
   DROP PROCEDURE [clase].[sp_clase_capacidad]
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 28-06-2014
-- Description:	Listar capacidades de la clase
-- =============================================
create PROCEDURE [clase].[sp_clase_capacidad]
@clase_id as int
AS
BEGIN
	SET NOCOUNT ON;


select  cc.clase_capacidad_id, da.dearea_id, da.dearea, e.especifica_id, 
	e.especifica, o.operativa_id, o.operativa
from clase_capacidad cc
	inner join operativa o on cc.operativa_id = o.operativa_id
	inner join especifica e on o.especifica_id = e.especifica_id
	inner join dearea da on e.dearea_id = da.dearea_id 
where cc.clase_id = @clase_id 
order by da.dearea, da.dearea_id, e.especifica, e.especifica_id, 
	o.operativa, o.operativa_id
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_crear_clase_capacidad')
   DROP PROCEDURE [clase].[sp_crear_clase_capacidad]
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 28-06-2014
-- Description:	Registrar capacidades de clase
-- =============================================
CREATE PROCEDURE [clase].[sp_crear_clase_capacidad]

            @operativa_id int
           ,@clase_id int
		   ,@new_identity INT = NULL OUTPUT
AS

BEGIN

IF NOT EXISTS(SELECT [operativa_id] ,[clase_id] FROM [clase_capacidad] WHERE operativa_id = @operativa_id AND clase_id=@clase_id)
BEGIN
	INSERT INTO [clase_capacidad]
			   ([operativa_id]
			   ,[clase_id])
		 VALUES
			   (@operativa_id
			   ,@clase_id)
END
IF @@ROWCOUNT = 0
	BEGIN
		SET	@new_identity = 0
	END
ELSE
	BEGIN

		SET @new_identity = SCOPE_IDENTITY();
	END           
END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_delete_clase_capacidad')
   DROP PROCEDURE [clase].[sp_delete_clase_capacidad]
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 28-06-2014
-- Description:	Eliminar capacidad de clase
-- =============================================
CREATE PROCEDURE [clase].[sp_delete_clase_capacidad]

            @clase_capacidad_id int
AS

BEGIN

DELETE FROM [clase_capacidad]
WHERE clase_capacidad_id=@clase_capacidad_id

END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_organizador3_lstByColegioAndAreaAndNivelAndGrado')
   DROP PROCEDURE [clase].[sp_organizador3_lstByColegioAndAreaAndNivelAndGrado]
GO



-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 29-06-2014
-- Description:	Lista conocimiento
-- =============================================
CREATE PROCEDURE [clase].[sp_organizador3_lstByColegioAndAreaAndNivelAndGrado]
 @colegio_id AS INT,
 @area	AS INT,
 @nivel_id AS INT,
 @grado_id AS INT
AS
BEGIN
	SET NOCOUNT ON;

SELECT o.organi_id, o.organi, o2.organi2_id, o2.organi2,
	o3.[organi3_id], o3.[organi3]
FROM [organizador3] o3
	INNER JOIN [organizador2] o2 ON o3.organi2_id = o2.organi2_id AND o2.nivel_id = @nivel_id AND o2.grado_id = @grado_id
	INNER JOIN [organizador] o ON o2.organi_id = o.organi_id
WHERE o.colegio_id = @colegio_id AND o.area = @area
ORDER BY o.organi, o.organi_id, o2.organi2, o2.organi2_id,
	o3.organi3, o3.organi3_id

END


GO



IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_contenido_lstByClase')
   DROP PROCEDURE [clase].[sp_clase_contenido_lstByClase]
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 28-06-2014
-- Description:	Listar contenidos de una clase
-- =============================================
create PROCEDURE [clase].[sp_clase_contenido_lstByClase]
@clase_id as int
AS
BEGIN
	SET NOCOUNT ON;


SELECT o.organi_id, o.organi, o2.organi2_id, o2.organi2,
	o3.[organi3_id], o3.[organi3], cc.clase_cono_id
FROM clase_contenido cc
	INNER JOIN clase c ON cc.clase_id = c.clase_id  
	INNER JOIN [organizador3] o3 ON cc.organi3_id = o3.organi3_id
	INNER JOIN [organizador2] o2 ON o3.organi2_id = o2.organi2_id AND o2.nivel_id = c.nivel_id AND o2.grado_id = c.grado_id
	INNER JOIN [organizador] o ON o2.organi_id = o.organi_id
WHERE cc.clase_id = @clase_id
ORDER BY o.organi, o.organi_id, o2.organi2, o2.organi2_id,
	o3.organi3, o3.organi3_id
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_nivel_lst')
   DROP PROCEDURE [clase].[sp_nivel_lst]
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Listar niveles
-- =============================================
create PROCEDURE [clase].[sp_nivel_lst]
AS
BEGIN
	SET NOCOUNT ON;


SELECT [nivel_id]
      ,[nivel]
FROM [niveles]
ORDER BY [nivel_id]
  
END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_grado_lstByNivel')
   DROP PROCEDURE [clase].[sp_grado_lstByNivel]
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Listar grado por niveles
-- =============================================
CREATE PROCEDURE [clase].[sp_grado_lstByNivel]

@nivel_id INT

AS
BEGIN
	SET NOCOUNT ON;

SELECT [grado_id]
      ,[grado]
FROM [grado]
WHERE [nivel_id] = @nivel_id
  
END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_valores_lstByClase')
   DROP PROCEDURE [clase].[sp_clase_valores_lstByClase]
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Listar clase valores por clase
-- =============================================
CREATE PROCEDURE clase.[sp_clase_valores_lstByClase]
@clase_id as int
AS
BEGIN
	SET NOCOUNT ON;

SELECT v.valores_id, v.valores, a.actitud_id, a.actitud, 
	cv.clase_valores_id
FROM [clase_valores] as cv
	inner join actitud as a on cv.actitud_id=a.actitud_id
	inner join valores as v on a.valores_id=v.valores_id
WHERE cv.clase_id=@clase_id
order by v.valores, v.valores_id, a.actitud, a.actitud_id
  
END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_metodo_lstByClase')
   DROP PROCEDURE [clase].sp_clase_metodo_lstByClase
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Listar metodos de clase
-- =============================================
CREATE PROCEDURE [clase].[sp_clase_metodo_lstByClase]
@clase_id as int
AS
BEGIN
	SET NOCOUNT ON;

SELECT c.criterio_id, c.criterio, m.metecnica_id, m.metecnica, 
	cm.clase_metodo_id
FROM [clase_metodo] as cm
	inner join metecnica as m on cm.metecnica_id=m.metecnica_id
	inner join criterio as c on m.criterio_id=c.criterio_id
WHERE cm.clase_id=@clase_id
ORDER BY c.criterio, c.criterio_id, m.metecnica, m.metecnica_id
  
END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_lst')
   DROP PROCEDURE [clase].sp_clase_lst
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Listar clases
-- =============================================
CREATE PROCEDURE [clase].sp_clase_lst
@colegio_id as int
AS
BEGIN
	SET NOCOUNT ON;

SELECT c.clase_id, c.clase_titulo, a.area, n.nivel, 
	g.grado, c.fecha_inicio, c.fecha_fin, c.fecha_reg,
	c.usuario, c.formato
FROM [clase] as c 
	inner join area as a on c.area_id=a.area_id
	inner join niveles as n on c.nivel_id=n.nivel_id
	inner join grado as g on c.grado_id=g.grado_id
where c.colegio_id=@colegio_id
ORDER BY c.clase_id DESC
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_getById')
   DROP PROCEDURE [clase].sp_clase_getById
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Obtener clase por identificador
-- =============================================
CREATE PROCEDURE [clase].sp_clase_getById
@clase_id int
AS
BEGIN
	SET NOCOUNT ON;

SELECT c.clase_id, c.clase_titulo, a.area, n.nivel, 
	g.grado, c.fecha_inicio, c.fecha_fin, c.fecha_reg,
	c.usuario, c.formato, c.nivel_id, c.grado_id,
	c.area_id, c.colegio_id
FROM [clase] as c 
	inner join area as a on c.area_id=a.area_id
	inner join niveles as n on c.nivel_id=n.nivel_id
	inner join grado as g on c.grado_id=g.grado_id
where c.clase_id=@clase_id
ORDER BY c.clase_id DESC
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_actividad_getByClase')
   DROP PROCEDURE [clase].sp_clase_actividad_getByClase
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Obtener actividades de clase
-- =============================================
CREATE PROCEDURE [clase].sp_clase_actividad_getByClase
@clase_id int
AS
BEGIN
	SET NOCOUNT ON;

SELECT actividades_id, actividades, actividades_hora, actividades1,
	actividades_hora1, actividades2, actividades_hora2, clase_id
FROM clase_actividad
WHERE clase_id=@clase_id
  
END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_actividad_insert')
   DROP PROCEDURE [clase].sp_clase_actividad_insert
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Obtener actividades de clase
-- =============================================
CREATE PROCEDURE [clase].sp_clase_actividad_insert
	@actividades as nvarchar(max)
	,@actividades_hora as nvarchar(max)
	,@clase_id int
	,@new_identity INT = NULL OUTPUT
AS
BEGIN

INSERT INTO clase_actividad
           (actividades
           ,actividades_hora
           ,clase_id)
     VALUES
           (@actividades
           ,@actividades_hora
           ,@clase_id)
     SET @new_identity = SCOPE_IDENTITY();
  
END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_actividad_update')
   DROP PROCEDURE [clase].sp_clase_actividad_update
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Obtener actividades de clase
-- =============================================
CREATE PROCEDURE [clase].sp_clase_actividad_update
	@actividades_id int
	,@actividades as nvarchar(max)
	,@actividades_hora as nvarchar(max)
	,@clase_id int
AS
BEGIN

UPDATE clase_actividad
SET actividades = @actividades,
	actividades_hora = @actividades_hora
WHERE actividades_id = @actividades_id
  
END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_actividad_update_actividades_hora')
   DROP PROCEDURE [clase].sp_clase_actividad_update_actividades_hora
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Obtener actividades de clase
-- =============================================
CREATE PROCEDURE [clase].sp_clase_actividad_update_actividades_hora
	@actividades_hora as nvarchar(max)
	,@clase_id int
AS
BEGIN

UPDATE clase_actividad
SET   actividades_hora1 = @actividades_hora
WHERE clase_id=@clase_id
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_matriz_getByClase')
   DROP PROCEDURE [clase].sp_clase_matriz_getByClase
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Obtener matriz clase por clase
-- =============================================
CREATE PROCEDURE [clase].sp_clase_matriz_getByClase
@clase_id int
AS
BEGIN
	SET NOCOUNT ON;

SELECT [clase_matriz_id],[formativa],[sumativa],[autoevaluativa]
      ,[coevaluativa],[heteroevaluacion],[censal],[muestral]
      ,[indicador_logro],[pruebatxt],[obsclase],[clase_id]
FROM [clase_matriz]
WHERE clase_id=@clase_id
  
END

GO



IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_matriz_insert')
   DROP PROCEDURE [clase].sp_clase_matriz_insert
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Insertar matriz clase
-- =============================================
CREATE PROCEDURE [clase].sp_clase_matriz_insert
	@formativa as bit
	,@sumativa as bit
	,@autoevaluativa as bit
	,@coevaluativa as bit
	,@heteroevaluacion as bit
	,@censal as bit
	,@muestral as bit
	,@indicador_logro as nvarchar(500)
	,@clase_id int
	,@pruebatxt as nvarchar(500)
	,@obsclase as nvarchar(500)
	,@new_identity INT = NULL OUTPUT
AS
BEGIN

INSERT INTO [dbo].[clase_matriz]([formativa],[sumativa],[autoevaluativa],[coevaluativa]
	,[heteroevaluacion],[censal],[muestral],[indicador_logro]
	,[clase_id],[pruebatxt],[obsclase])
VALUES(@formativa,@sumativa,@autoevaluativa,@coevaluativa,
	 @heteroevaluacion,@censal,@muestral, @indicador_logro,
	 @clase_id,@pruebatxt,@obsclase)

     SET @new_identity = SCOPE_IDENTITY();
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_matriz_update')
   DROP PROCEDURE [clase].sp_clase_matriz_update
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Actializar matriz clase
-- =============================================
CREATE PROCEDURE [clase].sp_clase_matriz_update
	@clase_matriz_id as int
	,@formativa as bit
	,@sumativa as bit
	,@autoevaluativa as bit
	,@coevaluativa as bit
	,@heteroevaluacion as bit
	,@censal as bit
	,@muestral as bit
	,@indicador_logro as nvarchar(500)
	,@clase_id int
	,@pruebatxt as nvarchar(500)
	,@obsclase as nvarchar(500)
AS
BEGIN

UPDATE dbo.clase_matriz
set formativa = @formativa, 
	sumativa = @sumativa, 
	autoevaluativa = @autoevaluativa,
	coevaluativa = @coevaluativa,
	heteroevaluacion = @heteroevaluacion,
	censal = @censal,
	muestral = @muestral,
	indicador_logro = @indicador_logro,
	pruebatxt = @pruebatxt,
	obsclase = @obsclase
 where @clase_matriz_id = @clase_matriz_id

END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_lstByFilto')
   DROP PROCEDURE [clase].sp_clase_lstByFilto
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 13-07-2014
-- Description:	Lista clases por filtro
-- =============================================
CREATE PROCEDURE [clase].sp_clase_lstByFilto
	@colegio_id int,
	@usuario nvarchar(50) = null,
	@area int = null,
	@nivelId int = null,
	@gradoId int = null,
	@fechaInicio nvarchar(10) = null,
	@fechaFin nvarchar(10) = null
AS
BEGIN
SELECT TOP 100 c.clase_id, c.clase_titulo,a.area,n.nivel
	,g.grado,c.fecha_inicio,c.fecha_fin,c.fecha_reg
	,c.usuario,c.formato
FROM [clase] as c
	inner join area as a on c.area_id=a.area_id
	inner join niveles as n on c.nivel_id=n.nivel_id
	inner join grado as g on c.grado_id=g.grado_id
where c.colegio_id=@colegio_id
	AND CASE 
		WHEN @usuario IS NULL THEN 1
		WHEN c.usuario = @usuario THEN 1
		ELSE 0
	END = 1 
	AND CASE
		WHEN @area IS NULL THEN 1
		WHEN C.area_id = @area THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @nivelId IS NULL THEN 1
		WHEN c.nivel_id = @nivelId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @gradoId IS NULL THEN 1
		WHEN c.grado_id = @gradoId THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @fechaInicio IS NULL OR @fechaFin IS NULL THEN 1
		WHEN c.fecha_reg BETWEEN  CONVERT(Datetime, @fechaInicio, 103) AND  CONVERT(Datetime, @fechaFin, 103) THEN 1
		ELSE 0
	END = 1
ORDER BY c.clase_id DESC

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_usuario_lstByColegio')
   DROP PROCEDURE [clase].sp_usuario_lstByColegio
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 13-07-2014
-- Description:	Lista usuario por colegio
-- =============================================
create PROCEDURE [clase].sp_usuario_lstByColegio
	@colegio_id as int
AS
BEGIN
	SET NOCOUNT ON;

SELECT     [usuario_id]
      ,tb1.[usuario]
      ,tb1.[nombres]
      ,tb1.[apematerno]
      ,tb1.[apepaterno]
      ,tb1.[correo]
	  ,tb1.colegio_id
      ,tb2.[colegio_nombre] colegio
      ,tb1.[estado]
      ,tb1.[diseno]
      ,tb1.[historia]
      ,tb1.[reporte]
      ,tb1.[mantenimiento]
      ,tb1.[administrador]
FROM  [usuarios] as tb1
inner join colegio as tb2 on tb1.colegio_id=tb2.colegio_id
where tb1.colegio_id=@colegio_id  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_area_lst')
   DROP PROCEDURE [clase].sp_area_lst
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 13-07-2014
-- Description:	Lista areas
-- =============================================
create PROCEDURE [clase].sp_area_lst
AS
BEGIN
	SET NOCOUNT ON;

SELECT a.area_id, a.area
FROM area a
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'conf_col_colegio_insert')
   DROP PROCEDURE [clase].conf_col_colegio_insert
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	insertar fila
-- =============================================
CREATE PROCEDURE [clase].conf_col_colegio_insert
	@columna_id int,
	@colegio_id int,
	@area_id int = NULL,
	@nivel_id int = NULL,
	@grado_id int = NULL,
	@valor nvarchar(500),
	@orden int = 1,
	@estado bit = 1,
	@confcolcolegio_padre_id int = NULL,
	@new_identity INT = NULL OUTPUT
AS
BEGIN

INSERT INTO [dbo].[conf_col_colegio] 
	([columna_id],[colegio_id],[area_id],[nivel_id]
	,[grado_id],[valor],[orden],[estado]
    ,[confcolcolegio_padre_id])
     VALUES
	(@columna_id,@colegio_id,@area_id,@nivel_id,
	@grado_id,@valor,@orden,@estado,
	@confcolcolegio_padre_id);

SET @new_identity = SCOPE_IDENTITY();
  
END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'conf_col_colegio_update')
   DROP PROCEDURE [clase].conf_col_colegio_update
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	actualizar fila
-- =============================================
CREATE PROCEDURE [clase].conf_col_colegio_update
	@confcolcolegio_id int,
	@columna_id int,
	@colegio_id int,
	@area_id int = NULL,
	@nivel_id int = NULL,
	@grado_id int = NULL,
	@valor nvarchar(500),
	@orden int = 1,
	@estado bit = 1,
	@confcolcolegio_padre_id int = NULL
AS
BEGIN

UPDATE [dbo].[conf_col_colegio]
   SET [columna_id] = @columna_id
      ,[colegio_id] = @colegio_id
      ,[area_id] = @area_id
      ,[nivel_id] = @nivel_id
      ,[grado_id] = @grado_id
      ,[valor] = @valor
      ,[orden] = @orden
      ,[estado] = @estado
      ,[confcolcolegio_padre_id] = @confcolcolegio_padre_id
 WHERE confcolcolegio_id = @confcolcolegio_id
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'conf_col_colegio_lstById')
   DROP PROCEDURE [clase].conf_col_colegio_lstById
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	obtener por id
-- =============================================
CREATE PROCEDURE [clase].conf_col_colegio_lstById
	@confcolcolegio_id int
AS
BEGIN

SELECT [confcolcolegio_id]
      ,[columna_id]
      ,[colegio_id]
      ,[area_id]
      ,[nivel_id]
      ,[grado_id]
      ,[valor]
      ,[orden]
      ,[estado]
      ,[confcolcolegio_padre_id]
FROM [dbo].[conf_col_colegio] 
WHERE confcolcolegio_id = @confcolcolegio_id
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'conf_col_colegio_lstByColumnaCole')
   DROP PROCEDURE [clase].conf_col_colegio_lstByColumnaCole
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar by columna y colegio
-- =============================================
CREATE PROCEDURE [clase].conf_col_colegio_lstByColumnaCole
	@columna_id int,
	@colegio_id int,
	@area_id int,
	@confcolcolegio_padre_id int = NULL,
	@nivel_id int = NULL,
	@grado_id int = NULL
AS
BEGIN

SELECT [confcolcolegio_id]
      ,[columna_id]
      ,[colegio_id]
      ,[area_id]
      ,[nivel_id]
      ,[grado_id]
      ,[valor]
      ,[orden]
      ,[estado]
      ,[confcolcolegio_padre_id]
FROM [dbo].[conf_col_colegio] 
WHERE columna_id = @columna_id
	AND colegio_id = @colegio_id
	AND area_id = @area_id
	AND CASE 
		WHEN (@confcolcolegio_padre_id IS NULL) AND (confcolcolegio_padre_id IS NULL) THEN 1 
		WHEN confcolcolegio_padre_id = @confcolcolegio_padre_id THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @nivel_id IS NULL THEN 1
		WHEN nivel_id = @nivel_id THEN 1
		ELSE 0
	END = 1
	AND CASE
		WHEN @grado_id IS NULL THEN 1
		WHEN grado_id = @grado_id THEN 1
		ELSE 0
	END = 1 
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'conf_col_colegio_lst3Nodos')
   DROP PROCEDURE [clase].conf_col_colegio_lst3Nodos
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar hasta 3 nodos 
-- =============================================
CREATE PROCEDURE [clase].conf_col_colegio_lst3Nodos
	@columna_id int,
	@colegio_id int,
	@area_id int
AS
BEGIN

SELECT n1.confcolcolegio_id n1_id, n1.valor n1_valor, n2.confcolcolegio_id n2_id, n2.valor n2_valor, 
	n3.confcolcolegio_id n3_id, n3.valor n3_valor
FROM dbo.conf_col_colegio n1
	INNER JOIN dbo.conf_col_colegio n2 ON n1.confcolcolegio_id = n2.confcolcolegio_padre_id
	INNER JOIN dbo.conf_col_colegio n3 ON n2.confcolcolegio_id = n3.confcolcolegio_padre_id
WHERE n1.columna_id = @columna_id
	AND n1.colegio_id = @colegio_id
	AND n1.area_id = @area_id
	AND n1.confcolcolegio_padre_id IS NULL
ORDER BY n1.confcolcolegio_id, n2.confcolcolegio_id, n3.confcolcolegio_id

END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_conf_col_colegio_insert')
   DROP PROCEDURE [clase].clase_conf_col_colegio_insert
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	insertar fila
-- =============================================
CREATE PROCEDURE [clase].clase_conf_col_colegio_insert
	@clase_id int,
	@confcolcolegio_id int,
	@new_identity INT = NULL OUTPUT
AS
BEGIN

INSERT INTO [dbo].clase_conf_col_colegio 
	(clase_id,confcolcolegio_id)
     VALUES
	(@clase_id,@confcolcolegio_id)

SET @new_identity = SCOPE_IDENTITY();
  
END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_conf_col_colegio_delete')
   DROP PROCEDURE [clase].clase_conf_col_colegio_delete
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	eliminar fila
-- =============================================
CREATE PROCEDURE [clase].clase_conf_col_colegio_delete
	@clase_confcolcolegio_id int
AS
BEGIN

DELETE FROM [dbo].clase_conf_col_colegio 
WHERE clase_confcolcolegio_id = @clase_confcolcolegio_id
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_conf_col_colegio_lstByClase3Nodos')
   DROP PROCEDURE [clase].clase_conf_col_colegio_lstByClase3Nodos
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar hasta 3 nodos 
-- =============================================
CREATE PROCEDURE [clase].clase_conf_col_colegio_lstByClase3Nodos
	@clase_id int,
	@columna_id int
AS
BEGIN

SELECT n1.confcolcolegio_id n1_id, n1.valor n1_valor, n2.confcolcolegio_id n2_id, n2.valor n2_valor, 
	n3.confcolcolegio_id n3_id, n3.valor n3_valor, c.clase_confcolcolegio_id, cc.nombre
FROM dbo.clase_conf_col_colegio c
	INNER JOIN dbo.conf_col_colegio n3 ON c.confcolcolegio_id = n3.confcolcolegio_id
	INNER JOIN dbo.conf_col_colegio n2 ON n3.confcolcolegio_padre_id = n2.confcolcolegio_id
	INNER JOIN dbo.conf_col_colegio n1 ON n2.confcolcolegio_padre_id = n1.confcolcolegio_id
	INNER JOIN dbo.col_colegio cc ON n1.colegio_id = cc.colegio_id AND n1.columna_id = cc.columna_id
WHERE c.clase_id = @clase_id
	AND n1.columna_id = @columna_id
	AND n1.confcolcolegio_padre_id IS NULL
ORDER BY n1.confcolcolegio_id, n2.confcolcolegio_id, n3.confcolcolegio_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'col_colegio_insert')
   DROP PROCEDURE [clase].col_colegio_insert
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	insertar fila
-- =============================================
CREATE PROCEDURE [clase].col_colegio_insert
	@columna_id int,
	@colegio_id int,
	@nombre nvarchar(100),
	@estado bit = 1
AS
BEGIN

INSERT INTO [dbo].col_colegio 
	([columna_id],[colegio_id],[nombre],[estado])
     VALUES
	(@columna_id,@colegio_id,@nombre,@estado);
  
END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'col_colegio_update')
   DROP PROCEDURE [clase].col_colegio_update
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	actualizar fila
-- =============================================
CREATE PROCEDURE [clase].col_colegio_update
	@columna_id int,
	@colegio_id int,
	@nombre nvarchar(100),
	@estado bit = 1
AS
BEGIN

UPDATE [dbo].col_colegio
   SET [nombre] = @nombre
      ,[estado] = @estado
 WHERE [columna_id] = @columna_id
	AND[colegio_id] = @colegio_id
  
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'col_colegio_lstByColuAndCole')
   DROP PROCEDURE [clase].col_colegio_lstByColuAndCole
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar 
-- =============================================
CREATE PROCEDURE [clase].col_colegio_lstByColuAndCole
	@columna_id int,
	@colegio_id int
AS
BEGIN

SELECT columna_id, colegio_id, nombre, estado
FROM dbo.col_colegio
WHERE columna_id = @columna_id
	AND colegio_id = @colegio_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'conocimiento_lst2Nodos')
   DROP PROCEDURE [clase].conocimiento_lst2Nodos
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 31-07-2014
-- Description:	listar hasta 3 nodos 
-- =============================================
CREATE PROCEDURE [clase].conocimiento_lst2Nodos
AS
BEGIN

SELECT c.conocimiento_id n1_id, c.conocimiento n1_valor, tc.tipo_conocimiento_id n2_id, tc.tipo_conocimiento n2_valor
FROM dbo.conocimiento c
	INNER JOIN dbo.tipo_conocimiento tc ON c.conocimiento_id = tc.conocimiento_id
ORDER BY c.conocimiento_id, tc.tipo_conocimiento_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'prueba_lst2Nodos')
   DROP PROCEDURE [clase].prueba_lst2Nodos
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 31-07-2014
-- Description:	listar hasta 3 nodos 
-- =============================================
CREATE PROCEDURE [clase].prueba_lst2Nodos
AS
BEGIN

SELECT p.prueba_id n1_id, p.prueba n1_valor, i.item_reg_act_id n2_id, i.item_reg_act n2_valor
FROM dbo.prueba p
	INNER JOIN dbo.item_registro_reactivo i ON p.prueba_id = i.prueba_id
ORDER BY p.prueba_id, i.item_reg_act_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_tipo_conocimiento_insert')
   DROP PROCEDURE [clase].clase_tipo_conocimiento_insert
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar 
-- =============================================
CREATE PROCEDURE [clase].clase_tipo_conocimiento_insert
	@tipo_conocimiento_id int,
	@clase_id int,
	@new_identity INT = NULL OUTPUT
AS
BEGIN

INSERT INTO [dbo].[clase_tipo_conocimiento]
           ([tipo_conocimiento_id]
           ,[clase_id])
     VALUES
           (@tipo_conocimiento_id
           ,@clase_id)
SET @new_identity = SCOPE_IDENTITY();
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_tipo_conocimiento_delete')
   DROP PROCEDURE [clase].clase_tipo_conocimiento_delete
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	eliminar clase tipo conocimiento 
-- =============================================
CREATE PROCEDURE [clase].clase_tipo_conocimiento_delete
	@clase_tipo_cono_id int
AS
BEGIN

DELETE dbo.clase_tipo_conocimiento 
where clase_tipo_cono_id = @clase_tipo_cono_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_item_registro_reactivo_insert')
   DROP PROCEDURE [clase].clase_item_registro_reactivo_insert
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	insert 
-- =============================================
CREATE PROCEDURE [clase].clase_item_registro_reactivo_insert
	@item_reg_act_id int,
	@clase_id int,
	@new_identity INT = NULL OUTPUT
AS
BEGIN

INSERT INTO [dbo].[clase_item_registro_reactivo]
           (item_reg_act_id
           ,[clase_id])
     VALUES
           (@item_reg_act_id
           ,@clase_id)
SET @new_identity = SCOPE_IDENTITY();
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_item_registro_reactivo_delete')
   DROP PROCEDURE [clase].clase_item_registro_reactivo_delete
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	eliminar clase examen
-- =============================================
CREATE PROCEDURE [clase].clase_item_registro_reactivo_delete
	@clase_item_reg_act_id int
AS
BEGIN

DELETE dbo.clase_item_registro_reactivo 
where clase_item_reg_act_id = @clase_item_reg_act_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_tipo_conocimiento_lst')
   DROP PROCEDURE [clase].clase_tipo_conocimiento_lst
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar tipo conocimiento por clase
-- =============================================
CREATE PROCEDURE [clase].clase_tipo_conocimiento_lst
	@clase_id int
AS
BEGIN

SELECT c.conocimiento_id n1_id, c.conocimiento n1_valor, tc.tipo_conocimiento_id n2_id, tc.tipo_conocimiento n2_valor, 
	ctc.clase_tipo_cono_id
FROM dbo.clase_tipo_conocimiento ctc
	INNER JOIN dbo.tipo_conocimiento tc ON ctc.tipo_conocimiento_id = tc.tipo_conocimiento_id
	INNER JOIN dbo.conocimiento c ON tc.conocimiento_id = c.conocimiento_id
WHERE ctc.clase_id = @clase_id
ORDER BY c.conocimiento_id, tc.tipo_conocimiento_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_item_registro_reactivo_lst')
   DROP PROCEDURE [clase].clase_item_registro_reactivo_lst
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar prueba por clase
-- =============================================
CREATE PROCEDURE [clase].clase_item_registro_reactivo_lst
	@clase_id int
AS
BEGIN

SELECT p.prueba_id n1_id, p.prueba n1_valor, ir.item_reg_act_id n2_id, ir.item_reg_act n2_valor, 
	cir.clase_item_reg_act_id
FROM dbo.clase_item_registro_reactivo cir
	INNER JOIN dbo.item_registro_reactivo ir ON cir.item_reg_act_id = ir.item_reg_act_id
	INNER JOIN dbo.prueba p ON ir.prueba_id = p.prueba_id
WHERE cir.clase_id = @clase_id
ORDER BY p.prueba_id, ir.item_reg_act_id

END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_archivo_lstByClase')
   DROP PROCEDURE [clase].clase_archivo_lstByClase
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar archivos de clase
-- =============================================
CREATE PROCEDURE [clase].clase_archivo_lstByClase
	@clase_id int
AS
BEGIN

SELECT ca.clase_archivo_id, ca.archivo, ca.nombre, ca.clase_id, ca.estado
FROM clase_archivo ca
WHERE ca.clase_id = @clase_id
	AND ca.estado = 'A'
order by ca.nombre

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_archivo_getById')
   DROP PROCEDURE [clase].clase_archivo_getById
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar archivos de clase
-- =============================================
CREATE PROCEDURE [clase].clase_archivo_getById
	@clase_archivo_id int
AS
BEGIN

SELECT ca.clase_archivo_id, ca.archivo, ca.nombre, ca.clase_id, ca.estado
FROM clase_archivo ca
WHERE ca.clase_archivo_id = @clase_archivo_id

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_archivo_insert')
   DROP PROCEDURE [clase].clase_archivo_insert
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar archivos de clase
-- =============================================
CREATE PROCEDURE [clase].clase_archivo_insert
	@clase_id int,
	@nombre nvarchar(250),
	@archivo uniqueidentifier,
	@estado char(1) = 'A',
	@new_identity INT = NULL OUTPUT
AS
BEGIN

INSERT INTO [dbo].[clase_archivo](clase_id, nombre, archivo, estado)
VALUES (@clase_id,@nombre,@archivo,@estado)

SET @new_identity = SCOPE_IDENTITY();

END

GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'clase_archivo_update')
   DROP PROCEDURE [clase].clase_archivo_update
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	actualizar archivos de clase
-- =============================================
CREATE PROCEDURE [clase].clase_archivo_update
	@clase_archivo_id int,
	@clase_id int,
	@nombre nvarchar(250),
	@archivo uniqueidentifier,
	@estado char(1) = 'A'
AS
BEGIN

update [dbo].[clase_archivo]
set nombre = @nombre,
	archivo = @archivo,
	estado = @estado
where clase_archivo_id = @clase_archivo_id

END

GO

	
IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_usuario_lstByUsuarioAndPass')
   DROP PROCEDURE [clase].sp_usuario_lstByUsuarioAndPass
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar prueba por clase
-- =============================================
CREATE PROCEDURE [clase].sp_usuario_lstByUsuarioAndPass
	@usuario as nvarchar(50),
	@pass as nvarchar(50)
AS
BEGIN

SELECT [usuario_id],[usuario],[nombres],[apematerno]
  ,[apepaterno],[pass],[correo],[colegio_id]
  ,[estado],[diseno],[historia],[reporte]
  ,[mantenimiento],[administrador],(select c.colegio_nombre from colegio c where c.colegio_id = u.colegio_id) colegio
FROM  [usuarios] u
where usuario =@usuario and PWDCOMPARE(@pass, pass)=1 and estado=1

END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_usuario_getByid')
   DROP PROCEDURE [clase].sp_usuario_getByid
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 27-07-2014
-- Description:	listar prueba por clase
-- =============================================
CREATE PROCEDURE [clase].sp_usuario_getByid
	@usuario_id int
AS
BEGIN

SELECT [usuario_id],[usuario],[nombres],[apematerno]
  ,[apepaterno],[pass],[correo],[colegio_id]
  ,[estado],[diseno],[historia],[reporte]
  ,[mantenimiento],[administrador],(select c.colegio_nombre from colegio c where c.colegio_id = u.colegio_id) colegio
FROM  [usuarios] u
where u.usuario_id = @usuario_id

END


GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_usuario_insert')
   DROP PROCEDURE [clase].sp_usuario_insert
GO

CREATE PROCEDURE [clase].sp_usuario_insert
	@usuario as nvarchar(50)
	,@nombres  as nvarchar(250)
	,@apematerno  as nvarchar(150)
	,@apepaterno  as nvarchar(150)
	,@pass  as nvarchar(150)
	,@correo  as nvarchar(150)
	,@colegio_id as int
	,@estado as bit
	,@diseno as bit
	,@historia as bit
	,@reporte as bit
	,@mantenimiento as bit
	,@administrador as bit
	,@new_identity INT = NULL OUTPUT
AS

BEGIN

INSERT INTO [usuarios]([usuario],[nombres],[apematerno],[apepaterno]
	,[pass],[correo],[colegio_id],[estado]
	,[diseno],[historia],[reporte],[mantenimiento]
	,[administrador])
VALUES(@usuario,@nombres,@apematerno,@apepaterno
	,PWDENCRYPT(@pass),@correo,@colegio_id,@estado
	,@diseno,@historia,@reporte,@mantenimiento
	,@administrador)


SET @new_identity = SCOPE_IDENTITY();
   
END

GO

IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_usuario_update')
   DROP PROCEDURE [clase].sp_usuario_update
GO


CREATE PROCEDURE [clase].sp_usuario_update
	@usuario_id as int
	,@usuario as nvarchar(50)
	,@nombres  as nvarchar(250)
	,@apematerno  as nvarchar(150)
	,@apepaterno  as nvarchar(150)
	,@correo  as nvarchar(150)
	,@colegio_id as int
	,@estado as bit
	,@diseno as bit
	,@historia as bit
	,@reporte as bit
	,@mantenimiento as bit
	,@administrador as bit
AS
BEGIN

SET NOCOUNT ON;

UPDATE [usuarios]
   SET [usuario] = @usuario
      ,[nombres] = @nombres
      ,[apematerno] = @apematerno
      ,[apepaterno] = @apepaterno
      --,[pass] = PWDENCRYPT('@pass')
      ,[correo] = @correo
      ,[colegio_id] = @colegio_id
      ,[estado] = @estado
      ,[diseno] = @diseno
      ,[historia] = @historia
      ,[reporte] = @reporte
      ,[mantenimiento] = @mantenimiento
      ,[administrador] = @administrador
 WHERE usuario_id = @usuario_id 
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

END

GO
IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_colegio_update')
   DROP PROCEDURE [clase].sp_colegio_update
GO

-- =============================================
-- Author:		carlos onocuica
-- Create date: 30-10-2013
-- Description:	registrar clase 
-- =============================================
CREATE PROCEDURE clase.sp_colegio_update
	@colegio_nombre as nvarchar(250)
	,@colegio_dirección as nvarchar(250)
	,@colegio_telefono as nvarchar(25)
	,@colegio_id as int
AS
BEGIN

SET NOCOUNT ON;

UPDATE [colegio]
   SET [colegio_nombre] = @colegio_nombre
      ,[colegio_dirección] = @colegio_dirección
      ,[colegio_telefono] = @colegio_telefono
WHERE colegio_id=@colegio_id

END

GO
IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_colegio_lst')
   DROP PROCEDURE [clase].sp_colegio_lst
GO

-- =============================================
-- Author:		Carlos Onocuica
-- Create date: 21-10-2013
-- Description:	Lista dearea
-- =============================================
CREATE PROCEDURE clase.sp_colegio_lst

AS
BEGIN
	SET NOCOUNT ON;

SELECT [colegio_id]
      ,[colegio_nombre]
      ,[colegio_dirección]
      ,[colegio_telefono]
  FROM [colegio]
  
END
GO


IF EXISTS (
	SELECT * FROM sys.objects o
		inner join sys.schemas s on o.[schema_id] = s.[schema_id] 
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_colegio_getById')
   DROP PROCEDURE [clase].sp_colegio_getById
GO

-- =============================================
-- Author:		Carlos Onocuica
-- Create date: 21-10-2013
-- Description:	Lista dearea
-- =============================================
CREATE PROCEDURE clase.sp_colegio_getById
	@colegio_id int
AS
BEGIN
	SET NOCOUNT ON;

SELECT [colegio_id]
      ,[colegio_nombre]
      ,[colegio_dirección]
      ,[colegio_telefono]
  FROM [colegio]
  where colegio_id = @colegio_id
  
END
