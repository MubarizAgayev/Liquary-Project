

$(document).ready(function () {
    let mybutton = document.getElementById("myBtn");

    window.onscroll = function () { scrollFunction() };
    function scrollFunction() {
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            mybutton.style.display = "block";
        } else {
            mybutton.style.display = "none";
        }
    }

    mybutton.addEventListener("click",topFunction);
    function topFunction() {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    }


    $('.multiple-items').slick({
        infinite: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        prevArrow: `<i class="fa-solid fa-chevron-left prev"></i>`,
        nextArrow: `<i class="fa-solid fa-chevron-right next"></i>`
    });

    $('.responsive').slick({
        infinite: true,
        speed: 300,
        slidesToShow: 5,
        slidesToScroll: 4,
        prevArrow: `<i class="fa-solid fa-chevron-left prev"></i>`,
        nextArrow: `<i class="fa-solid fa-chevron-right next"></i>`,
        responsive: [
            {
                breakpoint: 1400,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    infinite: true,
                }
            },
            {
                breakpoint: 1200,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 1,
                    infinite: true,
                }
            },
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                    infinite: true,
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
        ]
    });



    document.querySelector("header .down .tab-menu").addEventListener("click",function(){
        document.querySelector("header .down .menu").classList.toggle("d-none");
    })

    window.addEventListener("click",function(event){
        if(event.target != document.querySelector("header .down .menu") && event.target != document.querySelector("header .down .menu img") && event.target != document.querySelector("header .down .menu .category-list") && event.target != document.querySelector("header .down .menu .category-list .item") && event.target != document.querySelector("header .down .tab-menu") && event.target != document.querySelector("header .down .tab-menu i") && event.target != document.querySelector("header .down .tab-menu p")){
            document.querySelector("header .down .menu").classList.add("d-none")
        }
    })

    document.querySelector("header .up .side-bar .side-bar-close").addEventListener("click",function(){
        document.querySelector("header .up .side-bar").style.transform="translateX(-200px)";
    })

    document.querySelector("header .up .hamburger").addEventListener("click",function(){
        document.querySelector("header .up .side-bar").style.transform="translateX(0px)";
    })



})