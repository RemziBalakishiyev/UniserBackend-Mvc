$(document).ready(function () {
    FillCategoryList();

    debugger;


    function AddNewProduct() {


        var product = {
            ProductName: $("#productName").val(),
            Quantity: $("#quantity").val(),
            Price: $("#price").val(),
            CategoryId: $("#categorySelect").val()
        }

        $.ajax({
            type: "POST",
            url: "/Admin/Admin/AddProduct",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(product),
            success: function (response) {

                console.log(response)
            },
            error: function () {
                alert("An error occurred while adding the category.");
            }
        })
    }
    
  
})


console.log($("#test").val());



function FillCategoryList() {
    let selectBox = $("#categorySelect");

    $.ajax({
        type: "GET",
        url: "/Admin/Admin/GetCategories",
        dataType: "json",
        success: function (data) {
            for (let i = 0; i < data.length; i++) {
                selectBox.append($('<option>',
                    {
                        value: data[i].Id,
                        text: data[i].Name
                    }
                ));
            }
        }
    })
}



