using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    GridViewColumnHelper gridViewColumnHelper;
    protected GridViewColumnHelper GridViewColumnHelper
    {
        get
        {
            if (gridViewColumnHelper == null)
                gridViewColumnHelper = new GridViewColumnHelper(ASPxGridView1);
            return gridViewColumnHelper;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        GridViewColumnHelper.RestoreColumnWidth(GetColumnsWidthFormHiddenField());

        ASPxGridView1.DataSource = Enumerable.Range(0, 10).Select(i => new
        {
            ProductID = i,
            ProductName1 = "ProductName " + i,
            ProductName2 = "ProductName " + i,
            ProductName3 = "ProductName " + i,
            ProductName4 = "ProductName " + i,
            ProductName5 = "ProductName " + i
        });
        if(!IsPostBack)
            ASPxGridView1.DataBind();

        if (!IsCallback)
        {
            var column = GridViewColumnHelper.GetColumnToResetWidth();
            if (column != null)
            {
                DXColumnsWidth.Add(column.Index.ToString(), column.Width.Value);
                column.Width = Unit.Empty;
            }
        }
    }
    protected void ASPxGridView1_BeforeGetCallbackResult(object sender, EventArgs e)
    {
        var column = GridViewColumnHelper.GetColumnToResetWidth();
        if (column != null)
        {
            ASPxGridView1.JSProperties["cpColumnWidth"] = new { index = column.Index, width = column.Width.Value };
            column.Width = Unit.Empty;
        }
    }

    protected IDictionary<int, double> GetColumnsWidthFormHiddenField()
    {
        var result = new Dictionary<int, double>();
        foreach (var dataColumn in ASPxGridView1.DataColumns)
        {
            object widthObj;
            if (DXColumnsWidth.TryGet(dataColumn.Index.ToString(), out widthObj) && dataColumn.Width.IsEmpty)
                result.Add(dataColumn.Index, (double)widthObj);
        }
        return result;
    }
}

