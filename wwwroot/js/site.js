// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

getLocation();
function showPosition(position) {
    let latitude = position.coords.latitude;
    let longitude = position.coords.longitude;

    $.ajax({
        type: "POST",
        url: "/Car/UpdateLocation",
        dataType: "application/json",
        data: {
            lat: position.coords.latitude,
            lng: position.coords.longitude
        },
        
    });
}