USE [BDConsilium]
GO

--insercion columnas
SET IDENTITY_INSERT [BDConsilium].[dbo].columna ON
GO

INSERT INTO dbo.columna(columna_id,nombre,colegio,area,nivel,grado,estado) values (1,'Columna 1',1,1,0,0,1)
INSERT INTO dbo.columna(columna_id,nombre,colegio,area,nivel,grado,estado) values (2,'Columna 2',1,1,0,0,1)

GO

SET IDENTITY_INSERT [BDConsilium].[dbo].columna OFF
GO


--insercion col_colegio

INSERT INTO dbo.col_colegio(columna_id,colegio_id,nombre,estado) values (1,5,'Columna 1',1)
INSERT INTO dbo.col_colegio(columna_id,colegio_id,nombre,estado) values (2,5,'Columna 2',1)
GO

--insercion conf_col_colegio
SET IDENTITY_INSERT [dbo].conf_col_colegio ON
GO


GO

SET IDENTITY_INSERT [dbo].conf_col_colegio OFF
GO
