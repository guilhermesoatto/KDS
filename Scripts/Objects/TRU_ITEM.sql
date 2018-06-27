USE [KDS]
GO

/****** Object:  Trigger [dbo].[TRU_ITEM]    Script Date: 27/06/2018 11:21:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TRU_ITEM] ON [dbo].[Item] FOR UPDATE    
AS 
BEGIN

DECLARE
@IdItem INT, @CodigoStatusAtualItem INT

	SELECT @IdItem = IdItem FROM inserted
	SELECT @CodigoStatusAtualItem = CodigoStatusAtualItem FROM Item WHERE IdItem = @IdItem

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO dbo.Historico (Id,IdStatus,Tipo) VALUES (@IdItem, @CodigoStatusAtualItem, 'ITEM')
    -- Insert statements for trigger here

END


GO

ALTER TABLE [dbo].[Item] ENABLE TRIGGER [TRU_ITEM]
GO

