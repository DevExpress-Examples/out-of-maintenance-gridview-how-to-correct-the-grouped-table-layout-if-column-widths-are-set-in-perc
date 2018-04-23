<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnGridViewEndCalback(s, e) {
            var columnInfo = s.cpColumnWidth;
            if (columnInfo) {
                dxColumnsWidth.Clear();
                dxColumnsWidth.Set(columnInfo.index, columnInfo.width);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" OnBeforeGetCallbackResult="ASPxGridView1_BeforeGetCallbackResult">
                <Settings ShowGroupPanel="true" />
                <SettingsBehavior ColumnResizeMode="NextColumn" />
                <ClientSideEvents EndCallback="OnGridViewEndCalback" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="ProductID" Width="10%" GroupIndex="0"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName1" Width="20%" Caption="ProductName1" GroupIndex="1"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName2" Width="40%" Caption="ProductName2"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName3" Width="10%" Caption="ProductName3"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName4" Width="10%" Caption="ProductName4"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName5" Width="10%" Caption="ProductName5"></dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <dx:ASPxHiddenField ID="DXColumnsWidth" ClientInstanceName="dxColumnsWidth" runat="server" />
        </div>
    </form>
</body>
</html>
