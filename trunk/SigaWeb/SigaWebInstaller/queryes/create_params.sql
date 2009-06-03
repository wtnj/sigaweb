/****** Object:  Table [dbo].[params]    Script Date: 05/04/2009 14:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[params](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mainId] [int] NOT NULL,
	[tamanho] [int] NOT NULL,
	[tabela] [varchar](3) NOT NULL,
	[campo] [varchar](10) NOT NULL,
	[formato] [varchar](25) NOT NULL,
 CONSTRAINT [PK_params] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF