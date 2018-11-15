<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/CustomDateTimeMeasureUnitSample/Form1.cs) (VB: [Form1.vb](./VB/CustomDateTimeMeasureUnitSample/Form1.vb))**
<!-- default file list end -->
# How to: use a custom date-time measure unit in automatic scale mode


This example demonstrates how to specify a custom date-time measure unit in <strong>Automatic</strong> scale mode.


<h3>Description</h3>

To do this, assign an object of a class implementing the&nbsp;<a href="https://documentation.devexpress.com/#corelibraries/clsDevExpressXtraChartsIDateTimeMeasureUnitsCalculatortopic">IDateTimeMeasureUnitsCalculator</a>&nbsp;interface to the&nbsp;<a href="https://documentation.devexpress.com/#corelibraries/DevExpressXtraChartsDateTimeScaleOptions_AutomaticMeasureUnitsCalculatortopic">DateTimeScaleOptions.AutomaticMeasureUnitsCalculator</a>&nbsp;property of&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsAxisBase_DateTimeScaleOptionstopic">AxisBase.DateTimeScaleOptions</a>.

<br/>


