CREATE TABLE dbo.fields
	(
	id       INT IDENTITY NOT NULL,
	mainId   INT NOT NULL,
	codigo   VARCHAR (10) NULL,
	grouping VARCHAR (50) NULL,
	CONSTRAINT PK_fields PRIMARY KEY (id),
	CONSTRAINT FK_fields_RTable FOREIGN KEY (mainId) REFERENCES dbo.RTable (id) ON DELETE CASCADE ON UPDATE CASCADE
	)
GO

CREATE TABLE dbo.filters
	(
	id         INT IDENTITY NOT NULL,
	mainId     INT NOT NULL,
	tabela     VARCHAR (3) NOT NULL,
	campo      VARCHAR (10) NOT NULL,
	tipofiltro VARCHAR (10) NOT NULL,
	filtro     VARCHAR (50) NOT NULL,
	CONSTRAINT PK_filters PRIMARY KEY (id),
	CONSTRAINT FK_filters_RTable FOREIGN KEY (mainId) REFERENCES dbo.RTable (id) ON DELETE CASCADE ON UPDATE CASCADE
	)
GO

CREATE TABLE dbo.groupBy
	(
	id            INT IDENTITY NOT NULL,
	mainId        INT NOT NULL,
	indice        INT NOT NULL,
	displaymember VARCHAR (50) NOT NULL,
	valuemember   VARCHAR (50) NOT NULL,
	CONSTRAINT PK_groupBy PRIMARY KEY (id),
	CONSTRAINT FK_groupBy_RTable FOREIGN KEY (mainId) REFERENCES dbo.RTable (id) ON DELETE CASCADE ON UPDATE CASCADE
	)
GO

CREATE TABLE dbo.orderBy
	(
	id            INT IDENTITY NOT NULL,
	mainId        INT NULL,
	indice        INT NULL,
	displaymember VARCHAR (50) NULL,
	valuemember   VARCHAR (50) NULL,
	CONSTRAINT PK_orderBy PRIMARY KEY (id),
	CONSTRAINT FK_orderBy_RTable FOREIGN KEY (mainId) REFERENCES dbo.RTable (id) ON DELETE CASCADE ON UPDATE CASCADE
	)
GO

CREATE TABLE dbo.params
	(
	id      INT IDENTITY NOT NULL,
	mainId  INT NOT NULL,
	tamanho INT NOT NULL,
	tabela  VARCHAR (3) NOT NULL,
	campo   VARCHAR (10) NOT NULL,
	formato VARCHAR (25) NOT NULL,
	objeto  VARCHAR (50) CONSTRAINT DF_params_objeto DEFAULT (' ') NOT NULL,
	CONSTRAINT PK_params PRIMARY KEY (id),
	CONSTRAINT FK_params_RTable FOREIGN KEY (mainId) REFERENCES dbo.RTable (id) ON DELETE CASCADE ON UPDATE CASCADE
	)
GO

CREATE TABLE dbo.permissaoRelGrupo
	(
	id          INT IDENTITY NOT NULL,
	idUserGroup INT NOT NULL,
	idReport    INT NOT NULL,
	nivel       INT NOT NULL
	)
GO

CREATE TABLE dbo.permissaoRelUsu
	(
	id       INT IDENTITY NOT NULL,
	idUser   INT NOT NULL,
	idReport INT NOT NULL,
	nivel    INT NOT NULL
	)
GO

CREATE TABLE dbo.report
	(
	id            INT IDENTITY NOT NULL,
	nome          VARCHAR (50) NULL,
	empresa       VARCHAR (2) NULL,
	filial        VARCHAR (2) NULL,
	username      VARCHAR (30) NULL,
	idReportGroup INT NOT NULL,
	CONSTRAINT PK_report PRIMARY KEY (id),
	CONSTRAINT FK_report_reportgroup FOREIGN KEY (idReportGroup) REFERENCES dbo.reportgroup (id)
	)
GO

CREATE TABLE dbo.reportgroup
	(
	id        INT IDENTITY NOT NULL,
	descricao VARCHAR (50) NULL,
	CONSTRAINT PK_reportgroup PRIMARY KEY (id)
	)
GO

CREATE TABLE dbo.RTable
	(
	id           INT IDENTITY NOT NULL,
	indice       INT CONSTRAINT DF_RTable_indice DEFAULT ((0)) NOT NULL,
	relatedindex INT CONSTRAINT DF_RTable_relatedindex DEFAULT ((0)) NOT NULL,
	mainId       INT CONSTRAINT DF_RTable_mainId DEFAULT ((0)) NOT NULL,
	tabela       VARCHAR (3) NULL,
	relatedtype  VARCHAR (15) NULL,
	relatedident VARCHAR (3) NULL,
	idReport     INT NOT NULL,
	CONSTRAINT PK_table PRIMARY KEY (id),
	CONSTRAINT FK_RTable_report FOREIGN KEY (idReport) REFERENCES dbo.report (id) ON DELETE CASCADE ON UPDATE CASCADE
	)
GO

CREATE TABLE dbo.SIGAMAT
	(
	M0_CODIGO VARCHAR (2) NULL,
	M0_CODFIL VARCHAR (2) NULL,
	M0_FILIAL VARCHAR (15) NULL,
	M0_NOME   VARCHAR (15) NULL
	)
GO

CREATE TABLE dbo.SigaUsers
	(
	id          INT IDENTITY NOT NULL,
	username    VARCHAR (20) CONSTRAINT DF_SigaUsers_username DEFAULT (' ') NOT NULL,
	password    VARCHAR (20) CONSTRAINT DF_SigaUsers_password DEFAULT (' ') NOT NULL,
	name        VARCHAR (30) CONSTRAINT DF_SigaUsers_name DEFAULT (' ') NOT NULL,
	fullname    VARCHAR (50) CONSTRAINT DF_SigaUsers_fullname DEFAULT (' ') NOT NULL,
	idUserGroup INT CONSTRAINT DF_SigaUsers_idUserGroup DEFAULT ((0)) NOT NULL,
	MailServer  VARCHAR (50) CONSTRAINT DF_SigaUsers_MailServer DEFAULT (' ') NOT NULL,
	MailUser    VARCHAR (50) CONSTRAINT DF_SigaUsers_MailUser DEFAULT (' ') NOT NULL,
	MailPasswd  VARCHAR (50) CONSTRAINT DF_SigaUsers_MailPasswd DEFAULT (' ') NOT NULL,
	MailDoor    INT CONSTRAINT DF_SigaUsers_MailDoor DEFAULT ((21)) NOT NULL,
	MailAddress VARCHAR (50) CONSTRAINT DF_SigaUsers_MailAddress DEFAULT (' ') NOT NULL,
	CONSTRAINT PK_SysUsers PRIMARY KEY (id),
	CONSTRAINT FK_SysUsers_UsersGroups FOREIGN KEY (idUserGroup) REFERENCES dbo.UsersGroups (id)
	)
GO

CREATE TABLE dbo.UsersGroups
	(
	id        INT IDENTITY NOT NULL,
	descricao VARCHAR (100) NULL,
	name      VARCHAR (50) NULL,
	CONSTRAINT PK_UsersGroups PRIMARY KEY (id)
	)
GO

CREATE PROCEDURE SPR_ParametrosRecursivos (@mainId INT = 0, @Nivel INT = 0, @NOMETABELA VARCHAR(80)) AS
--CREATE FUNCTION ListaPessoasPorHierarquia(@mainId INT, @Nivel INT)
-- RETURNS
IF OBJECT_ID(@NOMETABELA,'U') IS NULL
BEGIN
 exec('CREATE TABLE '+@NOMETABELA+'(id int NOT NULL, Nivel int)')
 END

SET NOCOUNT ON

DECLARE @id INT, @oldId INT
--Abrindo o "cursor"
IF @mainId = 0
      SELECT TOP 1 @id = T.id
        FROM RTable T
       WHERE T.mainId = 0
       ORDER BY T.id
ELSE
      SELECT TOP 1 @id = T.id
        FROM RTable T
       WHERE T.mainId = @mainId
       ORDER BY T.id
--Condição de parada: não encontrar mais pessoas
WHILE @id IS NOT NULL
BEGIN
--Inserindo registro na tabela temporária
      exec('INSERT INTO '+@NOMETABELA+' VALUES('+@id+','+@Nivel+')')
--Incrementando nível antes de chamar a procedure
      SET @Nivel = @Nivel + 1
--Buscando todas as pessoas gerenciadas pela pessoa atual
      EXECUTE SPR_ParametrosRecursivos @id, @Nivel, @NOMETABELA
--Voltando ao nível anterior
      SET @Nivel = @Nivel - 1
--Definindo variável para a pessoa anterior
      SET @oldId = @id
      SET @id    = NULL
--Próxima pessoa
      IF @mainId = 0
            SELECT TOP 1 @id = T.id
              FROM RTable T
             WHERE T.mainId = 0
               AND T.id > @oldId
             ORDER BY T.id
      ELSE
            SELECT TOP 1 @id = T.id
              FROM RTable T
             WHERE T.mainId = @mainId
               AND T.id > @oldId
             ORDER BY T.id
END
--
/*
IF OBJECT_ID('TABELA','U') IS NOT NULL
BEGIN
    DROP TABLE TABELA
END
GO
EXECUTE SPR_ParametrosRecursivos 228, 0, TABELA
GO
SELECT DISTINCT RTable.*, params.*
  FROM RTable
 RIGHT JOIN TABELA TEMP
    ON TEMP.id = RTable.id
    OR RTable.id = 228
 INNER JOIN params
    ON params.mainId = RTable.id
*/
GO

