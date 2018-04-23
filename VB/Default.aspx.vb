Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page


    Private gridViewColumnHelper_Renamed As GridViewColumnHelper
    Protected ReadOnly Property GridViewColumnHelper() As GridViewColumnHelper
        Get
            If gridViewColumnHelper_Renamed Is Nothing Then
                gridViewColumnHelper_Renamed = New GridViewColumnHelper(ASPxGridView1)
            End If
            Return gridViewColumnHelper_Renamed
        End Get
    End Property

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        GridViewColumnHelper.RestoreColumnWidth(GetColumnsWidthFormHiddenField())

        ASPxGridView1.DataSource = Enumerable.Range(0, 10).Select(Function(i) New With {Key .ProductID = i, Key .ProductName1 = "ProductName " & i, Key .ProductName2 = "ProductName " & i, Key .ProductName3 = "ProductName " & i, Key .ProductName4 = "ProductName " & i, Key .ProductName5 = "ProductName " & i})
        If Not IsPostBack Then
            ASPxGridView1.DataBind()
        End If

        If Not IsCallback Then
            Dim column = GridViewColumnHelper.GetColumnToResetWidth()
            If column IsNot Nothing Then
                DXColumnsWidth.Add(column.Index.ToString(), column.Width.Value)
                column.Width = Unit.Empty
            End If
        End If
    End Sub
    Protected Sub ASPxGridView1_BeforeGetCallbackResult(ByVal sender As Object, ByVal e As EventArgs)
        Dim column = GridViewColumnHelper.GetColumnToResetWidth()
        If column IsNot Nothing Then
            ASPxGridView1.JSProperties("cpColumnWidth") = New With {Key .index = column.Index, Key .width = column.Width.Value}
            column.Width = Unit.Empty
        End If
    End Sub

    Protected Function GetColumnsWidthFormHiddenField() As IDictionary(Of Integer, Double)
        Dim result = New Dictionary(Of Integer, Double)()
        For Each dataColumn In ASPxGridView1.DataColumns
            Dim widthObj As Object = Nothing
            If DXColumnsWidth.TryGet(dataColumn.Index.ToString(), widthObj) AndAlso dataColumn.Width.IsEmpty Then
                result.Add(dataColumn.Index, DirectCast(widthObj, Double))
            End If
        Next dataColumn
        Return result
    End Function
End Class

