export function showMessage(type, message) {
    const messageContainer = document.getElementById('message-container');

    // Create a div element for the alert
    const alertDiv = document.createElement('div');

    // Set the Bootstrap classes for the alert
    alertDiv.classList.add('alert');
    alertDiv.classList.add(type === 'success' ? 'alert-success' : 'alert-danger');
    alertDiv.classList.add('alert-dismissible');
    alertDiv.setAttribute('role', 'alert');

    // Set the message
    alertDiv.innerHTML = message;

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