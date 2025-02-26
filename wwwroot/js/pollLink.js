import { getCookie } from "./cookie.js";

document.getElementById('poll').onclick = function () {
    var userId = getCookie("UserId");
    window.location.href = "/Poll/Index?UserId=" + userId;
}