USE [KDS]
GO

/****** Object:  Trigger [dbo].[TRI_PEDIDO]    Script Date: 27/06/2018 11:13:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TRI_PEDIDO] ON [dbo].[Pedido] FOR INSERT    
AS 
BEGIN

DECLARE
@IdPedido INT, @CodigoStatusAtualPedido INT

	SELECT @IdPedido = IdPedido FROM inserted

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO dbo.Historico (Id,IdStatus,Tipo) VALUES (@IdPedido, 1, 'PEDIDO')
    -- Insert statements for trigger here

END
GO

ALTER TABLE [dbo].[Pedido] ENABLE TRIGGER [TRI_PEDIDO]
GO

