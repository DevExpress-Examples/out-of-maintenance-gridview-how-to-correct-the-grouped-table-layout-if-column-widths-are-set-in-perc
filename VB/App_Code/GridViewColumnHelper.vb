Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI.WebControls

''' <summary>
''' Summary description for GridViewColumnHelper
''' </summary>
Public Class GridViewColumnHelper
    Public Sub New(ByVal grid As ASPxGridView)
        Me.Grid = grid
    End Sub

    Private privateGrid As ASPxGridView
    Protected Property Grid() As ASPxGridView
        Get
            Return privateGrid
        End Get
        Private Set(ByVal value As ASPxGridView)
            privateGrid = value
        End Set
    End Property

    Public Sub RestoreColumnWidth(ByVal clientColumnsWidth As IDictionary(Of Integer, Double))
        For Each keyPairValue In clientColumnsWidth
            Grid.Columns(keyPairValue.Key).Width = Unit.Percentage(keyPairValue.Value)
        Next keyPairValue
    End Sub
    Public Function GetColumnToResetWidth() As GridViewDataColumn
        If GetTotalColumnPercentWidth() >= 100 Then
            Return Nothing
        End If
        Return FindWidestDataColumn()
    End Function
    Private Function GetTotalColumnPercentWidth() As Double
        Dim totalPercentWidth As Double = 0
        For Each dataColumn In GetVisibleUnGroupedColumns()
            If dataColumn.Width.Type <> UnitType.Percentage Then
                Continue For
            End If
            totalPercentWidth += dataColumn.Width.Value
        Next dataColumn
        Return totalPercentWidth
    End Function
    Private Function FindWidestDataColumn() As GridViewDataColumn
        Dim widestColumn As GridViewDataColumn = Nothing
        For Each column In GetVisibleUnGroupedColumns()
            If column.Width.Type <> UnitType.Percentage Then
                Continue For
            End If
            If widestColumn Is Nothing OrElse widestColumn.Width.Value < column.Width.Value Then
                widestColumn = column
            End If
        Next column
        Return widestColumn
    End Function
    Private Function GetVisibleUnGroupedColumns() As IEnumerable(Of GridViewDataColumn)
        Return Grid.DataColumns.Where(Function(c) c.GroupIndex = -1 AndAlso c.Visible)
    End Function
End Class