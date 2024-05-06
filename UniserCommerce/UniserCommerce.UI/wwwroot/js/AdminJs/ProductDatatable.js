$(document).ready(function () {
 
    $("#productTable").dataTable({
        autoWidth: false,
        pageLength: 5,
        lengthMenu: [[5], [10], [15]],
        ajax: {
            url: "/Admin/Admin/GetProducts",
            dataSrc: ""
        },
        columns: [
            { data: 'Id' },
            { data: 'ProductName' },
            { data: 'Quantity' },
            { data: 'Price' },
            { data: 'StockInHand' },
            { data: 'CategoryName' }
        ]



    });;


})