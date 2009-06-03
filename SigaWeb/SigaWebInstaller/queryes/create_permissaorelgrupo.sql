/****** Object:  Table [dbo].[permissaoRelGrupo]    Script Date: 05/04/2009 14:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permissaoRelGrupo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUserGroup] [int] NOT NULL,
	[idReport] [int] NOT NULL,
	[nivel] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[permissaoRelGrupo]  WITH CHECK ADD  CONSTRAINT [FK_permissaoRelGrupo_UsersGroups] FOREIGN KEY([idUserGroup])
REFERENCES [dbo].[UsersGroups] ([id])
GO
ALTER TABLE [dbo].[permissaoRelGrupo] CHECK CONSTRAINT [FK_permissaoRelGrupo_UsersGroups]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grupo de Usuários e suas Permissões' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'permissaoRelGrupo', @level2type=N'CONSTRAINT',@level2name=N'FK_permissaoRelGrupo_UsersGroups'
GO
ALTER TABLE [dbo].[permissaoRelGrupo]  WITH CHECK ADD  CONSTRAINT [FK_permissaoRelGrupo_report] FOREIGN KEY([idReport])
REFERENCES [dbo].[report] ([id])
GO
ALTER TABLE [dbo].[permissaoRelGrupo] CHECK CONSTRAINT [FK_permissaoRelGrupo_report]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permissão daquele grupo à este relatório' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'permissaoRelGrupo', @level2type=N'CONSTRAINT',@level2name=N'FK_permissaoRelGrupo_report'