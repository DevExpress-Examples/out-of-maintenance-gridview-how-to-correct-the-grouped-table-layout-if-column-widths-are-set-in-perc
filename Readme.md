<!-- default file list -->
*Files to look at*:

* [GridViewColumnHelper.cs](./CS/App_Code/GridViewColumnHelper.cs) (VB: [GridViewColumnHelper.vb](./VB/App_Code/GridViewColumnHelper.vb))
* **[Default.aspx](./CS/Default.aspx) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))**
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# GridView - How to correct the grouped table layout if column widths are set in percentages


<p>This example illustrates the solution for the first issue described at <a href="https://www.devexpress.com/Support/Center/p/T362981">ASPxGridView - Why column layout may become broken after user actions if certain column widths are set in percentages</a>. <br>The main idea is to determine the widest column and delete its width setting. As a result, the widest column will fill the space that appears after moving one of the columns to the Group panel. <br>For this, we implemented the GridViewColumnHelper class and use <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxHiddenFieldtopic">ASPxHiddenField</a>  to preserve information about column width between requests to the server. </p>

<br/>


