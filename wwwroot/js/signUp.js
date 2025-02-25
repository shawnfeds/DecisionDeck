import { showMessage } from "./showMessage.js";

document.getElementById('signUpButton').onclick = function () {
    const passwordElement = document.getElementById('password');
    const usernameElement = document.getElementById('username');
    const firstElement = document.getElementById('firstname');
    const lastElement = document.getElementById('lastname');

    const password = passwordElement.value;
    const username = usernameElement.value;
    const firstName = firstElement.value;
    const lastName = lastElement.value;


    if (password != "" && username != "" && firstName != "" && lastName != "") {
        const data = { Password: password, Username: username, FullName: firstName + " " + lastName };

        fetch('/Login/AddUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                window.location.href = "/Login/Index";
            })
            .catch((error) => {
                console.error('Error:', error);
                showMessage('error', 'Failed to enter the entry in the journal');
            });
    } else {
        alert("Please fill the required details..");
    }
}

document.getElementById('firstname').addEventListener("focusout", function(){
    const element = document.getElementById('errorFname');

    if(this.value == "") {
        this.focus;
        element.innerText = "Enter Firstname";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

document.getElementById('lastname').addEventListener("focusout", function () {
    const element = document.getElementById('errorLname');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Lastname";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

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