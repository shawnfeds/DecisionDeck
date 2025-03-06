import { showMessage } from "./showMessage.js";
import { getCookie } from "./cookie.js";

document.getElementById('editPollButton').onclick = function () {
    const name = document.getElementById('pollName').value;
    const des = document.getElementById('description').value;
    const endDate = document.getElementById('endDate').value;
    const group = document.getElementById('selGroup').value;

    const urlParams = new URLSearchParams(window.location.search);
    const pollId = urlParams.get('PollId');

    if (name != "" && des != "" && endDate != "" && group != "") {

        const data =
        {
            PollId: pollId,
            PollName: name,
            Description: des,
            PollEndDate: endDate,
            GroupId: group,
        };

        fetch('/Poll/Edit', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                var userId = getCookie("UserId");
                window.location.href = "/Poll/Index?UserId=" + userId;
            })
            .catch((error) => {
                console.error('Error:', error);
                showMessage('error', 'Failed to update poll');
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