USE [KDS]
GO

/****** Object:  View [dbo].[V_Comanda]    Script Date: 27/06/2018 18:25:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_Comanda]
AS
SELECT        dbo.Comanda.NumeroComanda, dbo.Comanda.IdComanda, dbo.Pedido.IdPedido, dbo.Pedido.CanalAtendimento, dbo.Pedido.CodigoPedido, dbo.Pedido.StatusAtualPedido, dbo.Pedido.CodigoStatusAtualPedido, 
                         dbo.Pedido.DataHoraInclusao, dbo.ItemAdicional.Descricao AS AdicionalDescricao, dbo.ItemAdicional.IdAdicional, dbo.Item.IdItem, dbo.Item.ObjectId, dbo.Item.StatusAtualItem, dbo.Item.CodigoStatusAtualItem, 
                         dbo.Item.Descricao AS ItemDescricao, dbo.Item.Observacao, dbo.Item.TempoMedioPreparacaoEmMinutos, dbo.ItemInsumo.IdInsumo, dbo.ItemInsumo.Descricao AS InsumoDescricao, dbo.ItemInsumo.ObjectId AS InsumoId, 
                         dbo.ItemInsumo.Remover, dbo.ItemInsumo.Quantidade
FROM            dbo.Comanda INNER JOIN
                         dbo.Pedido ON dbo.Comanda.IdComanda = dbo.Pedido.IdComanda INNER JOIN
                         dbo.Item ON dbo.Pedido.IdPedido = dbo.Item.IdPedido INNER JOIN
                         dbo.ItemAdicional ON dbo.Item.IdItem = dbo.ItemAdicional.IdItem INNER JOIN
                         dbo.ItemInsumo ON dbo.Item.IdItem = dbo.ItemInsumo.IdItem
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[31] 4[16] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Comanda"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 235
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Pedido"
            Begin Extent = 
               Top = 6
               Left = 273
               Bottom = 136
               Right = 498
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Item"
            Begin Extent = 
               Top = 152
               Left = 282
               Bottom = 282
               Right = 563
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "ItemAdicional"
            Begin Extent = 
               Top = 132
               Left = 21
               Bottom = 245
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ItemInsumo"
            Begin Extent = 
               Top = 95
               Left = 613
               Bottom = 225
               Right = 810
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 23
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         W' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Comanda'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'idth = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Comanda'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Comanda'
GO

