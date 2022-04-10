// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let btn = document.getElementById("btn");
let nav = document.getElementById("nav");

btn.addEventListener("click", function(){
    nav.classList.toggle("hidden");
})