/****** Object:  Table [dbo].[SigaUsers]    Script Date: 05/04/2009 14:36:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SigaUsers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](20) NULL,
	[password] [varchar](20) NULL,
	[name] [varchar](30) NULL,
	[fullname] [varchar](50) NULL,
	[idUserGroup] [int] NULL,
 CONSTRAINT [PK_SysUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[SigaUsers]  WITH CHECK ADD  CONSTRAINT [FK_SysUsers_UsersGroups] FOREIGN KEY([idUserGroup])
REFERENCES [dbo].[UsersGroups] ([id])
GO
ALTER TABLE [dbo].[SigaUsers] CHECK CONSTRAINT [FK_SysUsers_UsersGroups]