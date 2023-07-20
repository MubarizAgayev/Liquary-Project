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


    $('.responsive-images').slick({
        infinite: true,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 1,
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



    document.querySelector("main .bottom-product-detail .tab .item1").addEventListener("click",function(){
        document.querySelector("main .bottom-product-detail .sections .section-desc").classList.remove("d-none");
        document.querySelector("main .bottom-product-detail .sections .section-review").classList.add("d-none");
        this.classList.add("active")
        this.classList.remove("de-active")
        document.querySelector("main .bottom-product-detail .tab .item2").classList.remove("active")
        document.querySelector("main .bottom-product-detail .tab .item2").classList.add("de-active")
    })
    document.querySelector("main .bottom-product-detail .tab .item2").addEventListener("click",function(){
        document.querySelector("main .bottom-product-detail .sections .section-desc").classList.add("d-none");
        document.querySelector("main .bottom-product-detail .sections .section-review").classList.remove("d-none");
        this.classList.add("active")
        this.classList.remove("de-active")
        document.querySelector("main .bottom-product-detail .tab .item1").classList.remove("active")
        document.querySelector("main .bottom-product-detail .tab .item1").classList.add("de-active")
    })


    document.querySelector("main .bottom-product-detail .sections .section-review .review-btn").addEventListener("click",function(){
        document.querySelector("main .bottom-product-detail .sections .section-review .write-review").classList.toggle("d-none");
    })


    let starList = document.querySelectorAll("main .bottom-product-detail .sections .section-review .write-review .stars i");

    starList.forEach(item => {
        item.addEventListener("click",function(){
            let num = item.getAttribute("id");
            for (let i = 0; i < starList.length; i++) {
                if(starList[i].getAttribute("id")<=num){
                    starList[i].classList.add("fa-solid")
                    starList[i].classList.remove("fa-regular")
                }
                else{
                    if(starList[i].classList.contains("fa-solid")){
                        starList[i].classList.remove("fa-solid")
                        starList[i].classList.add("fa-regular")
                    }
                    else{
                        starList[i].classList.add("fa-regular")
                    }
                }
                
                
            }
            document.querySelector(".raiting-input").value = num;
            console.log(document.querySelector(".raiting-input").value)
        })
    });


    let listImg = document.querySelectorAll("main .common .product-images .corusel .team .img img")

    listImg.forEach(img => {
        img.addEventListener("click",function(){
            document.querySelector("main .common .product-images .main-img img").setAttribute("src",img.getAttribute("src"));
        })
    });


    

})