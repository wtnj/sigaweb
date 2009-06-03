/****** Object:  Table [dbo].[filters]    Script Date: 05/04/2009 14:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[filters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mainId] [int] NOT NULL,
	[tabela] [varchar](3) NOT NULL,
	[campo] [varchar](10) NOT NULL,
	[tipofiltro] [varchar](10) NOT NULL,
	[filtro] [varchar](50) NOT NULL,
 CONSTRAINT [PK_filters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF