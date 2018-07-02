USE [KDS]
GO

/****** Object:  Table [dbo].[Historico]    Script Date: 02/07/2018 11:08:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Historico](
	[IdHistorico] [int] IDENTITY(1,1) NOT NULL,
	[Id] [int] NULL,
	[IdStatus] [int] NULL,
	[Tipo] [varchar](50) NULL,
	[DataHora] [datetime] NULL,
 CONSTRAINT [PK_Historico] PRIMARY KEY CLUSTERED 
(
	[IdHistorico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Historico]  WITH CHECK ADD  CONSTRAINT [FK_Historico_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[Status] ([IdStatus])
GO

ALTER TABLE [dbo].[Historico] CHECK CONSTRAINT [FK_Historico_Status]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relacionamento do IdStatus com a tabela Status' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Historico', @level2type=N'CONSTRAINT',@level2name=N'FK_Historico_Status'
GO


