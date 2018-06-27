USE [KDS]
GO

/****** Object:  Trigger [dbo].[TRU_PEDIDO]    Script Date: 27/06/2018 11:14:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TRU_PEDIDO] ON [dbo].[Pedido] FOR UPDATE    
AS 
BEGIN

DECLARE
@IdPedido INT, @CodigoStatusAtualPedido INT

	SELECT @IdPedido = IdPedido FROM inserted
	SELECT @CodigoStatusAtualPedido = CodigoStatusAtualPedido FROM Pedido WHERE IdPedido = @IdPedido

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO dbo.Historico (Id,IdStatus,Tipo) VALUES (@IdPedido, @CodigoStatusAtualPedido, 'PEDIDO')
    -- Insert statements for trigger here

END

GO

ALTER TABLE [dbo].[Pedido] ENABLE TRIGGER [TRU_PEDIDO]
GO

