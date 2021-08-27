<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128537529/15.1.10%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T366963)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [GridViewColumnHelper.cs](./CS/App_Code/GridViewColumnHelper.cs) (VB: [GridViewColumnHelper.vb](./VB/App_Code/GridViewColumnHelper.vb))
* **[Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))**
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# GridView - How to correct the grouped table layout if column widths are set in percentages
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t366963/)**
<!-- run online end -->


<p>This example illustrates the solution for the first issue described at <a href="https://www.devexpress.com/Support/Center/p/T362981">ASPxGridView - Why column layout may become broken after user actions if certain column widths are set in percentages</a>. <br>The main idea is to determine the widest column and delete its width setting. As a result, the widest column will fill the space that appears after moving one of the columns to the Group panel. <br>For this, we implemented the GridViewColumnHelper class and use <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxHiddenFieldtopic">ASPxHiddenField</a>  to preserve information about column width between requests to the server. </p>

<br/>


