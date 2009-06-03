/****** Object:  Table [dbo].[report]    Script Date: 05/04/2009 14:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[report](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
	[empresa] [varchar](2) NULL,
	[filial] [varchar](2) NULL,
	[username] [varchar](30) NULL,
	[idReportGroup] [int] NOT NULL,
 CONSTRAINT [PK_report] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[report]  WITH CHECK ADD  CONSTRAINT [FK_report_reportgroup] FOREIGN KEY([idReportGroup])
REFERENCES [dbo].[reportgroup] ([id])
GO
ALTER TABLE [dbo].[report] CHECK CONSTRAINT [FK_report_reportgroup]