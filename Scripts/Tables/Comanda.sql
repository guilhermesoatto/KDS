USE [KDS]
GO

/****** Object:  Table [dbo].[Comanda]    Script Date: 02/07/2018 11:06:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comanda](
	[IdComanda] [int] IDENTITY(1,1) NOT NULL,
	[NumeroComanda] [varchar](50) NOT NULL,
	[DataHoraInclusao] [datetime] NULL,
 CONSTRAINT [PK_Comanda] PRIMARY KEY CLUSTERED 
(
	[IdComanda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


