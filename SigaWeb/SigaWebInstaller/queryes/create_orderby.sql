/****** Object:  Table [dbo].[orderBy]    Script Date: 05/04/2009 14:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[orderBy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mainId] [int] NULL,
	[indice] [int] NULL,
	[displaymember] [varchar](50) NULL,
	[valuemember] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF