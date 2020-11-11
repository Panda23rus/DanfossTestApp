// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#btnsave").on("click", function () {
        var formData = new FormData();
        formData.append("vendorcode", $("#vendorcode").val());
        formData.append("description", $("#description").val());
        formData.append("cost", $("#cost").val());
        formData.append("onwarehouse", $("#onwarehouse").is(':checked'));

        $.ajax({
            url: "/Home/Save",
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            success: function (result) {
                if (result[0].data) {
                    alertify.success(result[0].mess);
                }
                else {
                    alertify.error(result[0].mess)
                }
            },
            complete: function () {
                $("#equipmentFrm").trigger("reset");
                $.ajax({
                    url: "/Home/List",
                    type: "GET",
                    success: function (data) {
                        $("#list").html(data);
                    }
                })
            }
        }); 
    })
});