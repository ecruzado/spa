SELECT * FROM clase_capacidad
GO

select * from operativa
go

select * from especifica
go

select * from dearea
go

SELECT [dearea_id] ,[dearea] ,[area],colegio_id FROM [dearea] where area=1 and colegio_id=@colegio_id 

SELECT 
	   tb4.dearea_id
      ,tb4.dearea
      ,tb3.especifica_id
      ,tb3.especifica
      --,tb2.operativa_id
	  ,tb1.clase_capacidad_id      
      ,tb2.operativa
      ,(tb2.operativa + '.aspx') as url
FROM [clase_capacidad] as tb1
INNER JOIN operativa as tb2
on tb1.operativa_id = tb2.operativa_id
INNER JOIN especifica as tb3
on tb2.especifica_id=tb3.especifica_id
INNER JOIN dearea as tb4
on tb3.dearea_id=tb4.dearea_id
WHERE clase_id=5717


select da.dearea_id, da.dearea, e.especifica_id, e.especifica, o.operativa_id, o.operativa
from dearea da inner join especifica e on da.dearea_id = e.dearea_id
	inner join operativa o on e.especifica_id = o.especifica_id
where da.area = 1
	and da.colegio_id = 4
order by da.dearea_id, e.especifica_id, o.operativa_id

go


select * from usuarios where colegio_id = 4
select * from clase where clase_id = 4481
select * from grado 
select * from niveles

select distinct grado_id from clase



--conocimiento, por colegio_id y area_id
select * from organizador

--nivel 2 conocimiento, por organizador, nivel_id y grado_id
SELECT *FROM [organizador2] 

--nivel 3 conocimiento, por organizador2
select * from [organizador3] 

SELECT o.organi_id, o.organi, o2.organi2_id, o2.organi2,
	o3.[organi3_id], o3.[organi3], o.area, o.colegio_id,o2.grado_id, o2.nivel_id
FROM [organizador3] o3
	INNER JOIN [organizador2] o2 ON o3.organi2_id = o2.organi2_id AND o2.nivel_id = 1 AND o2.grado_id = 4
	INNER JOIN [organizador] o ON o2.organi_id = o.organi_id
WHERE o.area = 2 and o.colegio_id = 5
ORDER BY o.organi, o.organi_id, o2.organi2, o2.organi2_id,
	o3.organi3, o3.organi3_id

SELECT * FROM colegio

SELECT * FROM clase_contenido CC

SELECT * FROM CLASE C WHERE C.colegio_id = 5 AND C.area_id = 1


select * from dbo.usuarios u where u.colegio_id = 5

sp_crear_actividades_clase
sp_update_actividades_clase1
sp_matriz_clase
sp_crear_clase
sp_clase_filtro_null
sp_clase_lst
sp_clase_filtro_fecha
sp_clase_mod
sp_clase_actividad_lst
SELECT ca.actividades_hora, ca.actividades FROM clase_actividad ca where ca.clase_id = 4481
SELECT * FROM clase_matriz cm where cm.clase_id = 5718
SELECT * FROM clase c where c.clase_id = 5718
SELECT * FROM clase c where c