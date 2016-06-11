Imports System.Data.SqlClient
Imports Telerik.WinControls.UI

Public Class trip_ticket_class

#Region "LISTVIEW FORMATTING"
    Shared Sub lv_cellformatting(e)
        If TypeOf e.CellElement Is DetailListViewHeaderCellElement Then
            e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
        Else
            e.CellElement.ResetValue(LightVisualElement.TextAlignmentProperty, Telerik.WinControls.ValueResetFlags.Local)
        End If

        If (TypeOf e.CellElement Is DetailListViewDataCellElement) Then
            e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
        End If

        If (e.CellElement).Data.Name = "count" Then
            If (TypeOf e.CellElement Is DetailListViewHeaderCellElement) Then
                e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
            End If

            If (TypeOf e.CellElement Is DetailListViewDataCellElement) Then
                e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
            End If
        End If

        ''''''''''DISABLED CELL COLOR SELECTION
        If (TypeOf e.Cellelement Is DetailListViewCellElement) Then
            e.CellElement.DrawFill = False
            e.CellElement.DrawBorder = False
        Else
            e.CellElement.ResetValue(LightVisualElement.DrawBorderProperty, Telerik.WinControls.ValueResetFlags.Local)
            e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, Telerik.WinControls.ValueResetFlags.Local)
        End If
    End Sub
#End Region

#Region "LOAD LISTVIEW"
    Shared Sub issued_trip_ticket_listview()
        Try
            sql = ""
            sql = "SELECT  ROW_NUMBER() over (PARTITION BY CONVERT(VARCHAR(12), need_date, 107)ORDER BY CONVERT(VARCHAR(12), need_date, 107) DESC,trip_ticket_no,location  ) as #," _
                    & "REPLICATE('0', 6 - LEN(trip_ticket_no)) + CAST(trip_ticket_no AS varchar) AS trip_ticket_no,location," _
                     & "(SELECT Case status  WHEN 0 THEN 'UNPROCESSED' WHEN 1 THEN 'PROCESSED' End) as Statuses,CONVERT(VARCHAR(12), need_date, 107) as need_date," _
                      & "CONVERT(VARCHAR(12), GETDATE(), 107) as cur_date FROM v_trip_ticket_schedule_form ORDER BY need_date DESC"

            Using sqlCnn = New SqlConnection(My.Settings.Conn_string)

                Frm_trip_ticket_monitoring.lv_trip_ticket_list.Items.Clear()

                sqlCnn.Open()
                sqlCmd = New SqlCommand(sql, sqlCnn)

                Using sqlReader As SqlDataReader = sqlCmd.ExecuteReader()

                    While (sqlReader.Read())
                        Dim list As New ListViewDataItem
                        list.SubItems.Add(sqlReader(0).ToString())
                        list.SubItems.Add(sqlReader(1).ToString())
                        list.SubItems.Add(sqlReader(2).ToString())
                        list.SubItems.Add(sqlReader(3).ToString())
                        'list.SubItems.Add(sqlReader(4).ToString())

                        If sqlReader(5) = sqlReader(4) Then
                            list.SubItems.Add("Today")
                        Else
                            list.SubItems.Add(sqlReader(4).ToString())
                        End If

                        Frm_trip_ticket_monitoring.lv_trip_ticket_list.Items.Add(list)
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
