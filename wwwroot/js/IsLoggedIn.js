// Function to get a cookie by its name
function getCookie(name) {
    let cookieArr = document.cookie.split(";");
    for (let i = 0; i < cookieArr.length; i++) {
        let cookie = cookieArr[i].trim();
        if (cookie.startsWith(name + "=")) {
            return cookie.substring(name.length + 1, cookie.length);
        }
    }
    return null;
}

// Check if the cookie exists and display the logout link if it does
window.onload = function () {
    const roles = ["Admin", "Manager", "Moderator"];
    var cookieValue = getCookie("Role");
    if (cookieValue) {
        console.log(cookieValue);
        if (roles.includes(cookieValue)) {
            document.getElementById("modifyUser").style.display = "block";
            //document.getElementById("addPoll").style.display = "compact";
        } else {
            document.getElementById("modifyUser").style.display = "none";
            //document.getElementById("addPoll").style.display = "none";
        }
        // Cookie exists, show logout item
        document.getElementById("loginA").style.display = "none";
        document.getElementById("signUpA").style.display = "none";
        document.getElementById("logout").style.display = "block";
    } else {
        document.getElementById("logout").style.display = "none";
        document.getElementById("modifyUser").style.display = "none";
        //document.getElementById("addPoll").style.display = "none";
        document.getElementById("loginA").style.display = "block";
        document.getElementById("signUpA").style.display = "block";
    }
};
