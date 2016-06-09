Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports AIS_System.System_mod
Imports System.Data.SqlClient
Imports Telerik.WinControls.Data
Imports System.ComponentModel
Public Class Frm_lot_by_lot_monitoring
    Dim sysmod As New System_mod

#Region "LISTVIEW COLUMN"
    Sub lotno_listview_column()
        Me.lv_lotcodelist.Columns.Clear()

        With Me.lv_lotcodelist
            .Columns.Add("count", "#")
            .Columns.Add("lot_no", "LOT NUMBER")

        
            .Columns("count").Width = 60
            .Columns("lot_no").Width = 180

            .FullRowSelect = True
            .ShowGroups = True
            .EnableGrouping = True
            .MultiSelect = False
          
        End With
    End Sub

    Sub activity_listview_column()
        Me.lv_lotcode_history.Columns.Clear()

        With Me.lv_lotcode_history
            .Columns.Add("id", "hdr_id")
            .Columns.Add("count", "#")
            .Columns.Add("ticket_no", "TRIP TICKET NO.")
            .Columns.Add("need_date", "TRIP TICKET DATE")
            .Columns.Add("work_performed", "OPERATION PERFORMED")
            .Columns.Add("purpose", "PURPOSE")
            .Columns.Add("date_planted", "DATE PLANTED")
            .Columns.Add("cur_variety", "VARIETY")
            .Columns.Add("cur_area", "TOTAL AREA")
            .Columns.Add("operate_rate", "OPERATION RATE")
            .Columns.Add("area_done", "AREA FINISH")
            .Columns.Add("total_amount", "TOTAL AMOUNT")

            .Columns("id").Width = 60
            .Columns("id").Visible = False
            .Columns("count").Width = 60
            .Columns("ticket_no").Width = 120
            .Columns("need_date").Width = 150
            .Columns("work_performed").Width = 180
            .Columns("purpose").Width = 220
            .Columns("date_planted").Width = 100
            .Columns("cur_variety").Width = 110
            .Columns("cur_area").Width = 100
            .Columns("operate_rate").Width = 100
            .Columns("area_done").Width = 100
            .Columns("total_amount").Width = 110

            .FullRowSelect = True
            '.ShowGridLines = True
            .ShowGroups = True
            .EnableGrouping = True
            .MultiSelect = False

            Me.lv_lotcode_history.EnableGrouping = True
            Me.lv_lotcode_history.ShowGroups = True
        End With
    End Sub


    Sub equipment_listview_column()
        Me.lv_equipment.Columns.Clear()

        With Me.lv_equipment
            .Columns.Add("id", "hdr_id")
            .Columns.Add("count", "#")
            .Columns.Add("ticket_no", "TRIP TICKET NO.")
            .Columns.Add("need_date", "TRIP TICKET DATE")
            .Columns.Add("work_performed", "OPERATION PERFORMED")
            .Columns.Add("purpose", "PURPOSE")
            .Columns.Add("date_planted", "DATE PLANTED")
            .Columns.Add("cur_variety", "VARIETY")
            .Columns.Add("cur_area", "TOTAL AREA")
            .Columns.Add("operate_rate", "OPERATION RATE")
            .Columns.Add("area_done", "AREA FINISH")
            .Columns.Add("total_amount", "TOTAL AMOUNT")

            .Columns("id").Width = 60
            .Columns("id").Visible = False
            .Columns("count").Width = 60
            .Columns("ticket_no").Width = 180
            .Columns("need_date").Width = 200
            .Columns("work_performed").Width = 150
            .Columns("purpose").Width = 150
            .Columns("date_planted").Width = 100
            .Columns("cur_variety").Width = 110
            .Columns("cur_area").Width = 100
            .Columns("operate_rate").Width = 100
            .Columns("area_done").Width = 100
            .Columns("total_amount").Width = 100

            .FullRowSelect = True
            '.ShowGridLines = True
            .ShowGroups = True
            .EnableGrouping = True
            .MultiSelect = False

            Me.lv_equipment.EnableGrouping = True
            Me.lv_equipment.ShowGroups = True
        End With
    End Sub

#End Region
    Private Sub Frm_lot_by_lot_monitoring_Load(sender As Object, e As EventArgs) Handles Me.Load
        ThemeResolutionService.ApplicationThemeName = My.Settings.global_themes
        'Farming_Operation.Server_time()
        lot_history_class.dp_location_load()
    End Sub

    Private Sub dp_location_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles dp_location.SelectedIndexChanged
        Me.lv_lotcodelist.Items.Clear()
        lot_history_class.dp_cropyear_load()
    End Sub

    Private Sub dp_cropyear_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles dp_cropyear.SelectedIndexChanged
        lotno_listview_column()
    End Sub

    Private Sub lv_lotcodelist_CellFormatting(sender As Object, e As ListViewCellFormattingEventArgs) Handles lv_lotcodelist.CellFormatting
        lot_history_class.lv_cellformatting(e)
    End Sub

    Private Sub txt_reqno_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        lot_history_class.monitoring_lotcode_search(Me.dp_location.SelectedItem.ToString, Me.dp_cropyear.SelectedItem.ToString, Replace(Trim(Me.txt_search.Text), "'", "`"))
    End Sub

    Private Sub lv_lotcodelist_SelectedItemChanged(sender As Object, e As EventArgs) Handles lv_lotcodelist.SelectedItemChanged
        lot_history_class.Global_lot_number_selected()

        activity_listview_column()
        lot_history_class.activity_load_listview(lotno, Me.dp_cropyear.SelectedItem.ToString)

        Me.lv_lotcode_history.GroupDescriptors.Clear()
        Dim groupByType As New GroupDescriptor("cur_variety")
        Me.lv_lotcode_history.GroupDescriptors.Add(groupByType)
    End Sub

    Private Sub btn_lotno_Click(sender As Object, e As EventArgs) Handles btn_lotno.Click
        lot_history_class.monitoring_lotcode_load_listvoew(Me.dp_location.SelectedItem.ToString, Me.dp_cropyear.SelectedItem.ToString)
    End Sub

    Private Sub lv_lotcode_history_CellFormatting(sender As Object, e As ListViewCellFormattingEventArgs) Handles lv_lotcode_history.CellFormatting
        lot_history_class.lv_cellformatting(e)
    End Sub
End Class
