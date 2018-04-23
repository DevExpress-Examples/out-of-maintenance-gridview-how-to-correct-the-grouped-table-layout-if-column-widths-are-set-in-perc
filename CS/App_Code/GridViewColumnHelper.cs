using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for GridViewColumnHelper
/// </summary>
public class GridViewColumnHelper
{
    public GridViewColumnHelper(ASPxGridView grid)
    {
        Grid = grid;
    }

    protected ASPxGridView Grid { get; private set; }

    public void RestoreColumnWidth(IDictionary<int, double> clientColumnsWidth)
    {
        foreach (var keyPairValue in clientColumnsWidth)
        {
            Grid.Columns[keyPairValue.Key].Width = Unit.Percentage(keyPairValue.Value);
        }
    }
    public GridViewDataColumn GetColumnToResetWidth()
    {
        if (GetTotalColumnPercentWidth() >= 100)
            return null;
        return FindWidestDataColumn();
    }
    double GetTotalColumnPercentWidth()
    {
        double totalPercentWidth = 0;
        foreach (var dataColumn in GetVisibleUnGroupedColumns())
        {
            if (dataColumn.Width.Type != UnitType.Percentage) continue;
            totalPercentWidth += dataColumn.Width.Value;
        }
        return totalPercentWidth;
    }
    GridViewDataColumn FindWidestDataColumn()
    {
        GridViewDataColumn widestColumn = null;
        foreach (var column in GetVisibleUnGroupedColumns())
        {
            if (column.Width.Type != UnitType.Percentage) continue;
            if (widestColumn == null || widestColumn.Width.Value < column.Width.Value)
                widestColumn = column;
        }
        return widestColumn;
    }
    IEnumerable<GridViewDataColumn> GetVisibleUnGroupedColumns()
    {
        return Grid.DataColumns.Where(c => c.GroupIndex == -1 && c.Visible);
    }
}