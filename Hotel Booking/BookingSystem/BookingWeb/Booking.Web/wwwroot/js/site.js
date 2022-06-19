// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var StartDate = document.getElementById("StartDate");
var today = new Date();
StartDate.value = today.toISOString().substr(0, 10);

today.setDate(today.getDate());
StartDate.setAttribute("min", today.toISOString().substr(0, 10));

today.setDate(today.getDate() + 10);
StartDate.setAttribute("max", today.toISOString().substr(0, 10));

var EndDate = document.getElementById("EndDate");
var today = new Date();
today.setDate(today.getDate() + 1);
EndDate.value = today.toISOString().substr(0, 10);

today.setDate(today.getDate());
EndDate.setAttribute("min", today.toISOString().substr(0, 10));

today.setDate(today.getDate() + 15);
EndDate.setAttribute("max", today.toISOString().substr(0, 10));