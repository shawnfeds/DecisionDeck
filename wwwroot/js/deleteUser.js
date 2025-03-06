import { showMessage } from "./showMessage.js";

const elements = document.querySelectorAll('.deleteUser');

elements.forEach(element => {
    element.onclick = function () {
        DeleteUser();
    };
});

function DeleteUser () {
    if (confirm("Are you Sure! You want to delete User.") == true) {
        console.log("inside");
        const userId = document.getElementById('userId').innerText;

        const data =
        {
            UserId: userId,
        };

        fetch('/User/Delete', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        }).then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                location.reload();
            })
            .catch((error) => {
                console.error('Error:', error);
                showMessage('error', 'Failed to delete user');
            });
    }
}