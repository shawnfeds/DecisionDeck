import { getCookie } from "./cookie.js";

document.getElementById('vote').addEventListener('click', function () {
    const selectedOption = document.querySelector('input[name="pollOption"]:checked');

    const urlParams = new URLSearchParams(window.location.search);
    const pollId = urlParams.get('PollId');

    this.disabled = true;

    vote(selectedOption.value, pollId);
});

function vote(optionName, pollId) {
    var userId = getCookie("UserId");

    const data = { PollId: pollId, UserId: userId, OptionName: optionName };

    fetch('/Poll/UpdatePoll', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(response => response.json())
        .then(data => {
            showMessage(optionName);
            setTimeout(() => {
                window.location.href = "/Poll/Index?UserId=" + userId;
            }, 7000);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showMessage(votedOption) {
    const messageContainer = document.getElementById('pollResult');

    // Create a div element for the alert
    const alertDiv = document.createElement('div');

    // Set the Bootstrap classes for the alert
    alertDiv.classList.add('alert');
    alertDiv.classList.add('alert-info');
    alertDiv.classList.add('alert-dismissible');
    alertDiv.setAttribute('role', 'alert');

    // Set the message
    alertDiv.innerHTML = '<h5>Thank you for voting!</h5>' +
        '<p>You voted for: <span i><b>' + votedOption + '</b></span></p></hr>' +
        '<p>You will be redirected to Polls page in few seconds..</p>';

    // Append the alert message to the container
    messageContainer.appendChild(alertDiv);

    // Automatically close the alert after 30 seconds
    setTimeout(() => {
        alertDiv.classList.add('fade'); // Optional: for fade-out effect
        alertDiv.style.transition = "opacity 1s ease-out"; // Smooth fade-out
        alertDiv.style.opacity = 0;  // Make it invisible

        // After fade-out, remove the element from DOM
        setTimeout(() => {
            alertDiv.remove();
        }, 500); // Allow time for the fade effect before removal
    }, 5000); // 5 seconds
}