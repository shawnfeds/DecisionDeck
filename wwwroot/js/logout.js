document.getElementById('logout').onclick = function () {

    fetch('/Login/Logout', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
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
}