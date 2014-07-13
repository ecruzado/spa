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
	c.usuario, c.formato, c.nivel_id, c.grado_id
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
		WHERE s.name = 'clase' and o.[type] = 'P' AND o.[name] = 'sp_clase_actividad_update_actividades')
   DROP PROCEDURE [clase].sp_clase_actividad_update_actividades
GO

-- =============================================
-- Author:		Edgar Cruzado
-- Create date: 30-06-2014
-- Description:	Obtener actividades de clase
-- =============================================
CREATE PROCEDURE [clase].sp_clase_actividad_update_actividades
	@actividades as nvarchar(max)
	,@clase_id int
AS
BEGIN

UPDATE clase_actividad
SET    actividades = @actividades
WHERE clase_id=@clase_id
  
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