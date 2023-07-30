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





})