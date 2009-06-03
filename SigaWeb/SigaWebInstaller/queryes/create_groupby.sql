/****** Object:  Table [dbo].[groupBy]    Script Date: 05/04/2009 14:45:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[groupBy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mainId] [int] NOT NULL,
	[indice] [int] NOT NULL,
	[displaymember] [varchar](50) NOT NULL,
	[valuemember] [varchar](50) NOT NULL,
 CONSTRAINT [PK_groupBy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF