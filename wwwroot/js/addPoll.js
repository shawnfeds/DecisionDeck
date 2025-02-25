import { showMessage } from "./showMessage.js";

document.getElementById('addPollButton').onclick = function () {
    const passwordElement = document.getElementById('password');
    const usernameElement = document.getElementById('username');
    const firstElement = document.getElementById('firstname');
    const lastElement = document.getElementById('lastname');
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

        fetch('/Poll/CreatePoll', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                window.location.href = "/Poll/Index";
            })
            .catch((error) => {
                console.error('Error:', error);
                showMessage('error', 'Failed to enter the entry in the journal');
            });
    } else {
        alert("Please fill the required details..");
    }
}

document.getElementById('pollName').addEventListener("focusout", function () {
    const element = document.getElementById('errorPname');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Poll name";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

document.getElementById('description').addEventListener("focusout", function () {
    const element = document.getElementById('errorPDes');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Poll description";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

document.getElementById('endDate').addEventListener("focusout", function () {
    const element = document.getElementById('errorPED');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Poll end date";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});


document.getElementById('selGroup').addEventListener("focusout", function () {
    const element = document.getElementById('errorPGroup');
    
    if (this.value == "-- Select Group --") {
        this.focus;
        element.innerText = "Select group";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

document.getElementById('op1').addEventListener("focusout", function () {
    const element = document.getElementById('errorOp1');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Option 1";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

document.getElementById('op2').addEventListener("focusout", function () {
    const element = document.getElementById('errorOp2');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Option 2";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

document.getElementById('op3').addEventListener("focusout", function () {
    const element = document.getElementById('errorOp3');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Option 3";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

document.getElementById('op4').addEventListener("focusout", function () {
    const element = document.getElementById('errorOp4');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Option 4";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});