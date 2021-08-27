<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128575801/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T327370)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/CustomDateTimeMeasureUnitSample/Form1.cs) (VB: [Form1.vb](./VB/CustomDateTimeMeasureUnitSample/Form1.vb))**
<!-- default file list end -->
# How to: use a custom date-time measure unit in automatic scale mode


This example demonstrates how to specify a custom date-time measure unit in <strong>Automatic</strong> scale mode.


<h3>Description</h3>

To do this, assign an object of a class implementing the&nbsp;<a href="https://documentation.devexpress.com/#corelibraries/clsDevExpressXtraChartsIDateTimeMeasureUnitsCalculatortopic">IDateTimeMeasureUnitsCalculator</a>&nbsp;interface to the&nbsp;<a href="https://documentation.devexpress.com/#corelibraries/DevExpressXtraChartsDateTimeScaleOptions_AutomaticMeasureUnitsCalculatortopic">DateTimeScaleOptions.AutomaticMeasureUnitsCalculator</a>&nbsp;property of&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsAxisBase_DateTimeScaleOptionstopic">AxisBase.DateTimeScaleOptions</a>.

<br/>


