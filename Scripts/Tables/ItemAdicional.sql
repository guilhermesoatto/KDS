USE [KDS]
GO

/****** Object:  Table [dbo].[ItemAdicional]    Script Date: 02/07/2018 11:08:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemAdicional](
	[IdAdicional] [int] IDENTITY(1,1) NOT NULL,
	[IdItem] [int] NULL,
	[Descricao] [varchar](150) NULL,
 CONSTRAINT [PK_Adicional] PRIMARY KEY CLUSTERED 
(
	[IdAdicional] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ItemAdicional]  WITH CHECK ADD  CONSTRAINT [FK_Adicional_Item] FOREIGN KEY([IdItem])
REFERENCES [dbo].[Item] ([IdItem])
GO

ALTER TABLE [dbo].[ItemAdicional] CHECK CONSTRAINT [FK_Adicional_Item]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relacionamento do Adicional com o a tabela Item' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ItemAdicional', @level2type=N'CONSTRAINT',@level2name=N'FK_Adicional_Item'
GO


