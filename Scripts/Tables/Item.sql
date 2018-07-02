USE [KDS]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 02/07/2018 11:08:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item](
	[IdItem] [int] IDENTITY(1,1) NOT NULL,
	[IdPedido] [int] NOT NULL,
	[ObjectId] [varchar](50) NULL,
	[StatusAtualItem] [varchar](50) NULL,
	[CodigoStatusAtualItem] [int] NULL,
	[Descricao] [varchar](150) NULL,
	[Observacao] [varchar](150) NULL,
	[DataHoraInclusao] [datetime] NULL,
	[TempoMedioPreparacaoEmMinutos] [int] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[IdItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Pedio_ItemPedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([IdPedido])
GO

ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Pedio_ItemPedido]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relacionamento da tabela de Pedidos nos Itens' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Item', @level2type=N'CONSTRAINT',@level2name=N'FK_Pedio_ItemPedido'
GO


