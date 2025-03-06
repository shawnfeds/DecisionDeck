import { showMessage } from "./showMessage.js";

document.getElementById('updateGroupBtn').onclick = function () {
    const urlParams = new URLSearchParams(window.location.search);
    const groupId = urlParams.get('GroupId');

    const name = document.getElementById('groupName').value;

    if (name != "") {
        const data =
        {
            GroupId: groupId,
            GroupName: name
        };

        fetch('/Group/Update', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                window.location.href = "/Group/Index";
            })
            .catch((error) => {
                console.error('Error:', error);
                showMessage('error', 'Failed to update group');
            });
    } else {
        alert("Please fill the required details..");
    }
}

document.getElementById('groupName').addEventListener("focusout", function () {
    const element = document.getElementById('errorGname');

    if (this.value == "") {
        this.focus;
        element.innerText = "Enter Group name";
        element.classList.add("text-danger");
    } else {
        element.innerText = "";
    }
});