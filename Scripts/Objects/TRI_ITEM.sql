USE [KDS]
GO

/****** Object:  Trigger [dbo].[TRI_ITEM]    Script Date: 27/06/2018 11:09:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TRI_ITEM] ON [dbo].[Item] FOR INSERT    
AS 
BEGIN

DECLARE
@IdItem INT, @CodigoStatusAtualItem INT

	SELECT @IdItem = IdItem FROM inserted

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO dbo.Historico (Id,IdStatus,Tipo) VALUES (@IdItem, 1, 'ITEM')
    -- Insert statements for trigger here

END

GO

ALTER TABLE [dbo].[Item] ENABLE TRIGGER [TRI_ITEM]
GO

