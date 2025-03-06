import { showMessage } from "./showMessage.js";

const elements = document.querySelectorAll('.deleteGroup');

elements.forEach(element => {
    element.onclick = function () {
        DeleteGroup();
    };
});

export function DeleteGroup () {
    if (confirm("Are you Sure! You want to delete Group.") == true) {
        console.log("inside");
        const groupId = document.getElementById('groupId').innerText;

        const data =
        {
            GroupId: groupId,
        };

        fetch('/Group/Delete', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                location.reload();
            })
            .catch((error) => {
                console.error('Error:', error);
                showMessage('error', 'Failed to delete group');
            });
    }
}