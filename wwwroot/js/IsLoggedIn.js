import { getCookie } from "./cookie.js";

// Check if the cookie exists and display the logout link if it does
window.onload = function () {
    const roles = ["Admin", "Manager", "Moderator"];
    var cookieValue = getCookie("Role");
    if (cookieValue) {
        if (roles.includes(cookieValue)) {
            document.getElementById("modifyUser").style.display = "block";

            if (document.getElementById("addPoll")) {
                document.getElementById("addPoll").style.display = "compact";
            }

            if (document.title == "Groups - DecisionDeck") {
                document.getElementById("addGroup").style.display = "block";
            } else {
                document.getElementById("addGroup").style.display = "none";
            }
        } else {
            document.getElementById("modifyUser").style.display = "none";

            if (document.getElementById("addPoll")) {
                document.getElementById("addPoll").style.display = "none";
            }

            document.getElementById("addGroup").style.display = "none";
        }
        // Cookie exists, show logout item
        document.getElementById("loginA").style.display = "none";
        document.getElementById("signUpA").style.display = "none";
        document.getElementById("logout").style.display = "block";
    } else {
        document.getElementById("logout").style.display = "none";
        document.getElementById("modifyUser").style.display = "none";
        document.getElementById("loginA").style.display = "block";
        document.getElementById("signUpA").style.display = "block";

        if (document.getElementById("addPoll")) {
            document.getElementById("addPoll").style.display = "none";
        }

        document.getElementById("addGroup").style.display = "none";
    }
};
