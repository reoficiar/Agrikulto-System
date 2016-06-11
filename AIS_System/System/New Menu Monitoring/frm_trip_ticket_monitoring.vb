﻿Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports AIS_System.System_mod
Imports System.Data.SqlClient
Imports Telerik.WinControls.Data
Imports System.ComponentModel
Public Class Frm_trip_ticket_monitoring
    Dim sysmod As New System_mod

#Region "LISTVIEW COLUMN"
    Sub trip_ticket_list_listview_column()
        Me.lv_trip_ticket_list.Columns.Clear()

        With Me.lv_trip_ticket_list
            .Columns.Add("count", "#")
            .Columns.Add("trip_no", "TRIP TICKET NO.")
            .Columns.Add("destination", "DESTINATION")
            .Columns.Add("status", "STATUS")

            .Columns("count").Width = 40
            .Columns("trip_no").Width = 110
            .Columns("destination").Width = 120
            .Columns("status").Width = 80

            .FullRowSelect = True
            .ShowGroups = True
            .EnableGrouping = True
            .MultiSelect = False

        End With
    End Sub

    Sub trip_ticket_processed_listview_column()
        Me.lv_tripticket_processed.Columns.Clear()

        With Me.lv_tripticket_processed
            .Columns.Add("hdr_id", "hdrid")
            .Columns.Add("count", "#")
            .Columns.Add("trip_no", "TRIP TICKET NO.")
            .Columns.Add("equip_type", "EQUIPMENT TYPE")
            .Columns.Add("imple_code", "IMPLEMENT CODE")
            .Columns.Add("driver", "DRIVER")
            .Columns.Add("prpose", "PURPOSE")

            .Columns("hdr_id").Width = 60
            .Columns("hdr_id").Visible = False
            .Columns("count").Width = 50
            .Columns("trip_no").Width = 110
            .Columns("equip_type").Width = 140
            .Columns("imple_code").Width = 120
            .Columns("driver").Width = 150
            .Columns("prpose").Width = 200

            .FullRowSelect = True
            .ShowGroups = True
            .EnableGrouping = True
            .MultiSelect = False
        End With
    End Sub

    Sub trip_ticket_unprocessed_listview_column()
        Me.lv_tripticket_unprocessed.Columns.Clear()

        With Me.lv_tripticket_unprocessed
            .Columns.Add("hdr_id", "hdrid")
            .Columns.Add("count", "#")
            .Columns.Add("trip_no", "TRIP TICKET NO.")
            .Columns.Add("equip_type", "EQUIPMENT TYPE")
            .Columns.Add("imple_code", "IMPLEMENT CODE")
            .Columns.Add("driver", "DRIVER")
            .Columns.Add("prpose", "PURPOSE")

            .Columns("hdr_id").Width = 60
            .Columns("hdr_id").Visible = False
            .Columns("count").Width = 50
            .Columns("trip_no").Width = 110
            .Columns("equip_type").Width = 140
            .Columns("imple_code").Width = 120
            .Columns("driver").Width = 150
            .Columns("prpose").Width = 200

            .FullRowSelect = True
            .ShowGroups = True
            .EnableGrouping = True
            .MultiSelect = False
        End With
    End Sub

    Sub trip_ticket_information_listview_column()
        Me.lv_tripticket_information.Columns.Clear()

        With Me.lv_tripticket_information
            .Columns.Add("count", "#")
            .Columns.Add("lot_no", "LOT NO.")
            .Columns.Add("date_planted", "DATE PLANTED")
            .Columns.Add("variety", "VARIETY")
            .Columns.Add("lot_owner", "LOT OWNER")
            .Columns.Add("operation", "WORK TO PERFORMED")
            .Columns.Add("request_date", "REQUEST DATE")
            .Columns.Add("request_by", "REQUEST BY")
            .Columns.Add("approved_date", "APPROVED DATE")
            .Columns.Add("approved_by", "APPROVED BY")

            .Columns("count").Width = 50
            .Columns("lot_no").Width = 110
            .Columns("date_planted").Width = 140
            .Columns("variety").Width = 120
            .Columns("lot_owner").Width = 150
            .Columns("operation").Width = 200
            .Columns("request_date").Width = 150
            .Columns("request_by").Width = 150
            .Columns("approved_date").Width = 150
            .Columns("approved_by").Width = 150

            .FullRowSelect = True
            .ShowGroups = True
            .EnableGrouping = True
            .MultiSelect = False
        End With
    End Sub
#End Region
    Private Sub Frm_trip_ticket_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeResolutionService.ApplicationThemeName = My.Settings.global_themes
        'Farming_Operation.Server_time()

        trip_ticket_list_listview_column() : trip_ticket_processed_listview_column() : trip_ticket_unprocessed_listview_column() : trip_ticket_information_listview_column()
    End Sub

End Class
