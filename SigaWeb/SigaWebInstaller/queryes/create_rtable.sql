/****** Object:  Table [dbo].[RTable]    Script Date: 05/04/2009 14:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mainId] [int] NULL,
	[tabela] [varchar](3) NULL,
	[relatedtype] [varchar](15) NULL,
	[relatedtable] [varchar](3) NULL,
	[idReport] [int] NOT NULL,
 CONSTRAINT [PK_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF