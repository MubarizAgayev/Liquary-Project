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

                Swal.fire(
                    'Good job!',
                    'You clicked the button!',
                    'success'
                )
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

    //$(document).on("click", ".product-detail-star", function () {

    //})


    //$(document).on("click", ".search-icon", function () {

    //    let searchText = $(".search-input").val();

    //    $(this).parent().attr("asp-route-searchText", searchText)
    //    $(this).attr("date-item", searchText)
    //    console.log($(this).attr("date-item"))

    //    //console.log($(this).parent().attr("asp-route-searchText"))


    //    //let url = `/Shop/Index?searchText = ${searchText}`;

    //    //window.location.assign(url);

        

    //})


   

    //document.querySelector(".search-input").addEventListener("keyup", function () {
    //    console.log(this.value)
    //})

   
    //$(".search-btn").submit(function (ev) {
    //    //ev.preventDefault();

    //    let searchText = $(this).prev().val();

    //    console.log(searchText)

    //    //let url = `Home/Search?searchText = ${searchText}`;

    //    //window.location.assign(url);
    //})
    

})