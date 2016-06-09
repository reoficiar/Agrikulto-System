Imports System.Data.SqlClient
Imports Telerik.WinControls.UI

Public Class lot_history_class

#Region "LISTVIEW FORMATTING CELL"
    Shared Sub lv_cellformatting(e)
        If TypeOf e.CellElement Is DetailListViewHeaderCellElement Then
            e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
        Else
            e.CellElement.ResetValue(LightVisualElement.TextAlignmentProperty, Telerik.WinControls.ValueResetFlags.Local)
        End If

        If (TypeOf e.CellElement Is DetailListViewDataCellElement) Then
            e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
        End If

        If (e.CellElement).Data.Name = "grand_amount" Then
            If (TypeOf e.CellElement Is DetailListViewHeaderCellElement) Then
                e.CellElement.TextAlignment = ContentAlignment.MiddleRight
            End If

            If (TypeOf e.CellElement Is DetailListViewDataCellElement) Then
                e.CellElement.TextAlignment = ContentAlignment.MiddleRight
            End If
        End If
    End Sub
#End Region

#Region "LOAD DROP DOWN"
    Shared Sub dp_location_load()
        Try
            Frm_lot_by_lot_monitoring.dp_location.Items.Clear()
            sql = ""
            sql = "SELECT DISTINCT location FROM v_trip_ticket_schedule_form ORDER BY location ASC"

            Using sqlCnn = New SqlConnection(My.Settings.Conn_string)
                sqlCnn.Open()
                Using sqlCmd = New SqlCommand(sql, sqlCnn)
                    Dim sqlReader As SqlDataReader = sqlCmd.ExecuteReader()
                    While (sqlReader.Read())
                        Dim desc = sqlReader.Item("location")
                        Frm_lot_by_lot_monitoring.dp_location.Items.Add(desc)
                        'Frm_master_list_location_info.dp_locationinfo_desc.Items.Add(desc)
                    End While
                End Using
                sqlCnn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Shared Sub dp_cropyear_load()
        Try
            Frm_lot_by_lot_monitoring.dp_cropyear.Items.Clear()
            sql = ""
            sql = "SELECT DISTINCT fiscal_year FROM v_trip_ticket_schedule_form ORDER BY fiscal_year DESC"

            Using sqlCnn = New SqlConnection(My.Settings.Conn_string)
                sqlCnn.Open()
                Using sqlCmd = New SqlCommand(sql, sqlCnn)
                    Dim sqlReader As SqlDataReader = sqlCmd.ExecuteReader()
                    While (sqlReader.Read())
                        Dim desc = sqlReader.Item("fiscal_year")
                        Frm_lot_by_lot_monitoring.dp_cropyear.Items.Add(desc)
                        'Frm_master_list_location_info.dp_locationinfo_desc.Items.Add(desc)
                    End While
                End Using
                sqlCnn.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "LOT MONITORING FORM LISTVIEW LOAD"
    Shared Sub monitoring_lotcode_load_listvoew(location, cropyear)
        Try
            sql = ""
            sql = "SELECT  ROW_NUMBER() over (ORDER BY lot_no) as #,lot_no FROM v_trip_ticket_schedule_form WHERE status=1 and dtl_stats=2 AND location ='" _
                    & "" & location & "' AND fiscal_year='" & cropyear & "' GROUP BY lot_no"

            Using sqlCnn = New SqlConnection(My.Settings.Conn_string)

                Frm_lot_by_lot_monitoring.lv_lotcodelist.Items.Clear()

                sqlCnn.Open()
                sqlCmd = New SqlCommand(sql, sqlCnn)

                Using sqlReader As SqlDataReader = sqlCmd.ExecuteReader()

                    While (sqlReader.Read())
                        Dim list As New ListViewDataItem
                        list.SubItems.Add(sqlReader(0).ToString())
                        list.SubItems.Add(sqlReader(1).ToString())

                        Frm_lot_by_lot_monitoring.lv_lotcodelist.Items.Add(list)
                    End While
                End Using
                sqlCmd.Connection.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "SEARCH DATA RECORD"
    Shared Sub monitoring_lotcode_search(location, cropyear, search)
        Try
            sql = ""
            sql = "SELECT  ROW_NUMBER() over (ORDER BY lot_no) as #,lot_no FROM v_trip_ticket_schedule_form WHERE status=1 and dtl_stats=2 AND location ='" _
                    & "" & location & "' AND fiscal_year='" & cropyear & "' AND lot_no LIKE '%" & search & "%' GROUP BY lot_no"


            Using sqlCnn = New SqlConnection(My.Settings.Conn_string)

                Frm_lot_by_lot_monitoring.lv_lotcodelist.Items.Clear()
                sqlCnn.Open()
                sqlCmd = New SqlCommand(sql, sqlCnn)

                Using sqlReader As SqlDataReader = sqlCmd.ExecuteReader()

                    While (sqlReader.Read())
                        Dim list As New ListViewDataItem
                        list.SubItems.Add(sqlReader(0).ToString())
                        list.SubItems.Add(sqlReader(1).ToString())

                        Frm_lot_by_lot_monitoring.lv_lotcodelist.Items.Add(list)
                    End While
                End Using
                sqlCmd.Connection.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
End Class
