/****** Object:  Table [dbo].[permissaoRelUsu]    Script Date: 05/04/2009 14:48:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permissaoRelUsu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NOT NULL,
	[idReport] [int] NOT NULL,
	[nivel] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[permissaoRelUsu]  WITH CHECK ADD  CONSTRAINT [FK_permissaoRelUsu_SysUsers] FOREIGN KEY([idUser])
REFERENCES [dbo].[SigaUsers] ([id])
GO
ALTER TABLE [dbo].[permissaoRelUsu] CHECK CONSTRAINT [FK_permissaoRelUsu_SysUsers]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relação entre Usuários e Permissão' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'permissaoRelUsu', @level2type=N'CONSTRAINT',@level2name=N'FK_permissaoRelUsu_SysUsers'
GO
ALTER TABLE [dbo].[permissaoRelUsu]  WITH CHECK ADD  CONSTRAINT [FK_permissaoRelUsu_report] FOREIGN KEY([idReport])
REFERENCES [dbo].[report] ([id])
GO
ALTER TABLE [dbo].[permissaoRelUsu] CHECK CONSTRAINT [FK_permissaoRelUsu_report]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relação de Relatório e Permissão' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'permissaoRelUsu', @level2type=N'CONSTRAINT',@level2name=N'FK_permissaoRelUsu_report'