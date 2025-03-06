import { showMessage } from "./showMessage.js";

document.getElementById('updateUserBtn').onclick = function () {
    const urlParams = new URLSearchParams(window.location.search);
    const groupId = urlParams.get('UserId');

    const uname = document.getElementById('userName').value;
    const fname = document.getElementById('fullName').value;
    const role = document.getElementById('selRole').value;
    const group = document.getElementById('selGroup').value;

    if (uname != "" && fname != "" && role != "" && group != "") {
        const data =
        {
            UserName: uname,
            FullName: fname,
            RoleId: role,
            GroupId: group
        };

        fetch('/User/Update', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                window.location.href = "/User/Index";
            })
            .catch((error) => {
                console.error('Error:', error);
                showMessage('error', 'Failed to update group');
            });
    } else {
        alert("Please fill the required details..");
    }
}

document.getElementById('userName').addEventListener("focusout", function () {
    const element = document.getElementById('errorUname');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Username";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

document.getElementById('fullName').addEventListener("focusout", function () {
    const element = document.getElementById('errorFname');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Full name";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

document.getElementById('selRole').addEventListener("focusout", function () {
    const element = document.getElementById('errorPRole');

    if (this.value == "-- Select User --") {
        this.focus;
        element.innerText = "Select Role";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});

document.getElementById('selGroup').addEventListener("focusout", function () {
    const element = document.getElementById('errorPGroup');

    if (this.value == "-- Select Group --") {
        this.focus;
        element.innerText = "Select Group";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});