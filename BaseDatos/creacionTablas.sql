CREATE TABLE dbo.tabla_general
(
	tabla varchar(10),
	codigo varchar(10),
	descripcion varchar(200),
	estado char(1),
	CONSTRAINT [PK_tabla_general] PRIMARY KEY (tabla,codigo)
)

GO

CREATE TABLE dbo.columna
(
	columna_id int identity(1,1),
	nombre nvarchar(100) NOT NULL,
	colegio bit NOT NULL,
	area bit NOT NULL,
	nivel bit NOT NULL,
	grado bit NOT NULL,
	estado char(1) NOT NULL,
	CONSTRAINT [PK_columna] PRIMARY KEY (columna_id)
)

GO

CREATE TABLE dbo.col_colegio
(
	columna_id int NOT NULL,
	colegio_id int NOT NULL,
	nombre nvarchar(100) NOT NULL,
	estado bit NOT NULL,
	CONSTRAINT [PK_col_colegio] PRIMARY KEY (columna_id,colegio_id)
)

GO

ALTER TABLE dbo.col_colegio ADD  CONSTRAINT [FK_col_colegio_columna] FOREIGN KEY(columna_id)
REFERENCES dbo.columna (columna_id)

GO

CREATE TABLE dbo.conf_col_colegio
(
	confcolcolegio_id int identity(1,1),
	columna_id int NOT NULL,
	colegio_id int NOT NULL,
	area_id int,
	nivel_id int,
	grado_id int,
	valor nvarchar(500) NOT NULL,
	orden int NOT NULL,
	estado bit NOT NULL,
	confcolcolegio_padre_id int,
	CONSTRAINT [PK_conf_col_colegio] PRIMARY KEY (confcolcolegio_id)
)
GO

ALTER TABLE dbo.conf_col_colegio ADD  CONSTRAINT [FK_conf_col_colegio_col_colegio] FOREIGN KEY(columna_id,colegio_id)
REFERENCES dbo.col_colegio (columna_id,colegio_id)

GO

CREATE INDEX conf_col_colegio_IX1 ON dbo.conf_col_colegio(columna_id,colegio_id,estado,confcolcolegio_padre_id)

GO

CREATE TABLE clase_conf_col_colegio
(
	clase_confcolcolegio_id int identity(1,1),
	clase_id int not null,
	confcolcolegio_id int not null,
	CONSTRAINT [PK_clase_conf_col_colegioo] PRIMARY KEY (clase_confcolcolegio_id)
)
GO


ALTER TABLE dbo.clase_conf_col_colegio ADD  CONSTRAINT [FK_clase_conf_col_colegio_clase] FOREIGN KEY(clase_id)
REFERENCES dbo.clase (clase_id)
GO

ALTER TABLE dbo.clase_conf_col_colegio ADD  CONSTRAINT [FK_clase_conf_col_colegio_conf] FOREIGN KEY(confcolcolegio_id)
REFERENCES dbo.conf_col_colegio (confcolcolegio_id)
GO
