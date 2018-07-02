USE [KDS]
GO

/****** Object:  Table [dbo].[Pedido]    Script Date: 02/07/2018 11:09:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[IdComanda] [int] NOT NULL,
	[CanalAtendimento] [varchar](50) NULL,
	[CodigoPedido] [int] NULL,
	[StatusAtualPedido] [varchar](50) NULL,
	[CodigoStatusAtualPedido] [int] NULL,
	[DataHoraInclusao] [datetime] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Pedido] FOREIGN KEY([IdComanda])
REFERENCES [dbo].[Comanda] ([IdComanda])
GO

ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Comanda_Pedido]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relacionamento da Comanda com o Pedido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pedido', @level2type=N'CONSTRAINT',@level2name=N'FK_Comanda_Pedido'
GO


