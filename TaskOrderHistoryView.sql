USE [WCS_Data-HK]
GO

/****** Object:  View [dbo].[task_order_history_view]    Script Date: 2021/1/18 21:01:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[task_order_history_view]
AS
SELECT dbo.task_order_history.id, dbo.task_order_history.end_time, dbo.task_order_history.pack_mode, dbo.task_order_history.insert_time, dbo.task_order_history.start_time, 
          dbo.task_order_history.order_status, dbo.task_order_history.product_count, dbo.task_order_history.defective_count, dbo.task_order_history.enable_check, dbo.task_order_history.product_name, 
          dbo.task_order_history.product_size, dbo.task_order_history.graphic_carton_size, dbo.task_order_history.noraml_carton_size, dbo.task_order_history.outer_carton_size, 
          dbo.task_order_history.pallet_size, dbo.task_order_history.robot_pg_no, dbo.task_order_history.pallet_num, dbo.task_order_history.open_machine_mode, dbo.task_order_history.barcode_machine_mode, 
          dbo.task_order_history.sn_barcode_enable, dbo.task_order_history.card_machine_enable, dbo.task_order_history.plate_enable, dbo.task_order_history.bubble_cover_enable, 
          dbo.task_order_detail_history.box_barcode, dbo.task_order_detail_history.insert_time AS box_insert_time
FROM   dbo.task_order_history INNER JOIN
          dbo.task_order_detail_history ON dbo.task_order_history.id = dbo.task_order_detail_history.order_id

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[54] 4[19] 2[7] 3) )"
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
         Begin Table = "task_order_history"
            Begin Extent = 
               Top = 12
               Left = 76
               Bottom = 666
               Right = 470
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "task_order_detail_history"
            Begin Extent = 
               Top = 12
               Left = 546
               Bottom = 570
               Right = 832
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
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 2925
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'task_order_history_view'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'task_order_history_view'
GO

