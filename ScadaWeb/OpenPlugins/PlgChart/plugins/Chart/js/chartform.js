﻿// Set the chart width and height
function updateLayout()
{
    var BODY_PADDING = 20;
    $("#cnvChart")
        .outerWidth($(window).width() - BODY_PADDING)
        .outerHeight($(window).height() - $("#divTitle").outerHeight(true) - BODY_PADDING);
}

$(document).ready(function () {
    // chart parameters must be defined in Chart.aspx
    var chartData = new scada.chart.ChartData();
    chartData.TimePoints = timePoints;
    chartData.Trends = [trend];
    chartData.QuantityName = quantityName;

    var chart = new scada.chart.Chart($("#cnvChart"));
    chart.displaySettings = displaySettings;
    chart.timeRange = timeRange;
    chart.chartData = chartData;

    updateLayout();
    chart.draw();

    $(window).resize(function () {
        updateLayout();
        chart.draw();
    });

    $(window).mousemove(function (event) {
        chart.showHint(event.pageX, event.pageY);
    })
});