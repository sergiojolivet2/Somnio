$(document).ready(function () {
    $('#filterButton').click(function () {
        $.get('/Home/FilterByCost', function (data) {
            $('#purchaseHistoryTable').html(data);
        });
    });

    $('#sortButton').click(function () {
        $.get('/Home/SortByDateDesc', function (data) {
            $('#purchaseHistoryTable').html(data);
        });
    });
});