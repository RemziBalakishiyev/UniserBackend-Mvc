

$(document).ready(function () {

    $("#addBtn").click(function () {
        var categoryName = $("#categoryName").val();

        $.ajax({
            async: true,
            url: "/Admin/Admin/AddCategory",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ name: categoryName }),
            success: function (response) {
                if (response.success) {
                    alert("Category added successfully!");
                    // You can do further actions here like updating a list of categories
                } else {
                    alert("Category can't be added successfully!");
                }
            },
            error: function () {
                alert("An error occurred while adding the category.");
            }
        });
    });
});
