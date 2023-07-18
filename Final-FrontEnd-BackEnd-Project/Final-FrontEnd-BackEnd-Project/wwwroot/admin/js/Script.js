$(document).ready(function () {

    $(document).on("click", ".delete-product-image", function () {

        console.log("dfdsfhdsfdsfdsf");

        let dataId = $(this).attr("data-id");
        let data = { id: dataId }

        $.ajax({
            url: "product/EditImage",
            type: "Post",
            data:data,
            success: function () {


                
            }
        })
    })






})