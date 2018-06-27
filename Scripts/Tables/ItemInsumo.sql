USE [KDS]
GO

/****** Object:  Table [dbo].[ItemInsumo]    Script Date: 27/06/2018 11:08:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemInsumo](
	[IdInsumo] [int] IDENTITY(1,1) NOT NULL,
	[IdItem] [int] NOT NULL,
	[ObjectId] [varchar](50) NULL,
	[Descricao] [varchar](250) NULL,
	[Remover] [int] NULL,
	[Quantidade] [int] NULL,
 CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED 
(
	[IdInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemInsumo]  WITH CHECK ADD  CONSTRAINT [FK_Insumo_Item] FOREIGN KEY([IdItem])
REFERENCES [dbo].[Item] ([IdItem])
GO

ALTER TABLE [dbo].[ItemInsumo] CHECK CONSTRAINT [FK_Insumo_Item]
GO

