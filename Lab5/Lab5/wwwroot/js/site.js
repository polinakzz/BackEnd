document.addEventListener("DOMContentLoaded", function () {
    console.log("JavaScript подключен и работает");

    const message = document.getElementById("js-message");
    if (message) {
        message.textContent = "Прив(site.js)";
        message.style.color = "green";
    }
});
