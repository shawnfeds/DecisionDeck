import { showMessage } from "./showMessage.js";

document.getElementById('loginButton').onclick = function () {

    const password = document.getElementById('password').value;
    const username = document.getElementById('username').value;

    if (password != "" && username != "") {
        const data = { Password: password, Username: username };

        fetch('/Login/AuthenticateUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                window.location.href = "/Home/Index";
            })
            .catch((error) => {
                console.error('Error:', error);
                showMessage('error', 'Failed to enter the entry in the journal');
            });
    } else {
        alert("Please fill the required details..");
    }
    
}

document.getElementById('username').addEventListener("focusout", function () {
    const element = document.getElementById('errorUname');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Username";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

document.getElementById('password').addEventListener("focusout", function () {
    const element = document.getElementById('errorPassword');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Password";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});