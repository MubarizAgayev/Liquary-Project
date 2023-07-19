$(document).ready(function () {

    $(document).on("click", ".add-to-cart-button", function (ev) {

        ev.preventDefault();




        let dataId = $(this).attr("data-id");
        let data = { id: dataId }

        $.ajax({
            url: `home/addbasket`,
            type: "Post",
            data: data,
            success: function (res) {
                $(".cart-count").text(res)
            }
        })
    })

    $(document).on("click", ".add-to-cart-button1", function (ev) {

        ev.preventDefault();




        let dataId = $(this).attr("data-id");
        let data = { id: dataId }

        $.ajax({
            url: `shop/addbasket`,
            type: "Post",
            data: data,
            success: function (res) {
                $(".cart-count").text(res)

                Swal.fire(
                    'Good job!',
                    'You clicked the button!',
                    'success'
                )
            }
        })
    })

    $(document).on("click", ".add-to-cart-button2", function (ev) {

        ev.preventDefault();




        let dataId = $(this).attr("data-id");
        let count = $(this).prev().children().eq(1).text()
        let data = { id: dataId, count: count }

        $.ajax({
            url: `productdetail/addbasket`,
            type: "Post",
            data: data,
            success: function (res) {
                $(".cart-count").text(res)

                Swal.fire(
                    'Good job!',
                    'You clicked the button!',
                    'success'
                )
            }
        })
    })

    $(document).on("click", ".delete-button", function (ev) {

        ev.preventDefault();



        let dataId = $(this).attr("data-id");

        $.ajax({
            url: `cart/deleteproductfrombasket?id=${dataId}`,
            type: "Post",
            success: function (res) {

            }
        })

        var totalCommon = $(".grand-total span").html()
        var productTotal = $(this).parent().parent().next().children().eq(0).html()
        var res = parseFloat(totalCommon) - parseFloat(productTotal)

        $(".grand-total span").html(res)

        $(this).parent().parent().parent().remove()
    })



    $(document).on("click", ".plus", function (ev) {

        ev.preventDefault();



        let dataId = $(this).attr("data-id");

        $.ajax({
            url: `cart/IncreaseProductCount?id=${dataId}`,
            type: "Post",
            success: function (res) {

            }
        })

        var num = $(this).prev().text()
        var totalCommon = $(".grand-total span").html()
        var productTotal = $(this).parent().parent().parent().next().children().eq(0).html()
        var productPrice = $(this).parent().parent().parent().prev().children().eq(0).html()
        var res = parseFloat(totalCommon) + parseFloat(productPrice)
        ++num;
        $(this).prev().text(num)
        productTotal = parseFloat(productPrice) * num
        $(this).parent().parent().parent().next().children().eq(0).html(productTotal)
        $(".grand-total span").html(res)
    })



    $(document).on("click", ".minus", function (ev) {

        ev.preventDefault();



        let dataId = $(this).attr("data-id");

        $.ajax({
            url: `cart/DecreaseProductCount?id=${dataId}`,
            type: "Post",
            success: function (res) {

            }
        })

        var num = $(this).next().text()
        if (num > 1) {
            var totalCommon = $(".grand-total span").html()
            var productTotal = $(this).parent().parent().parent().next().children().eq(0).html()
            var productPrice = $(this).parent().parent().parent().prev().children().eq(0).html()
            var res = parseFloat(totalCommon) - parseFloat(productPrice)
            --num;
            $(this).next().text(num)
            productTotal = parseFloat(productTotal) - parseFloat(productPrice)
            $(this).parent().parent().parent().next().children().eq(0).html(productTotal)
            $(".grand-total span").html(res)
        }
    })




    $(document).on("change", "#product-filter", function (ev) {

        ev.preventDefault();

        let filter = $(this).val();
        let data = { filter: filter }


        $.ajax({
            url: "/Shop/Sort",
            type: "Get",
            data: data,
            success: function (res) {
                $(".partial-sort-datas").html(res)
            }
        })
        

    })

       

})