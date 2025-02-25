import { showMessage } from "./showMessage.js";

document.getElementById('addPollButton').onclick = function () {
    const name = document.getElementById('pollName').value;
    const des = document.getElementById('description').value;
    const endDate = document.getElementById('endDate').value;
    const group = document.getElementById('selGroup').value;
    const op1 = document.getElementById('op1').value;
    const op2 = document.getElementById('op2').value;
    const op3 = document.getElementById('op3').value;
    const op4 = document.getElementById('op4').value;


    if (name != "" && des != "" && endDate != "" && group != "" && op1 != "" && op2 != "" && op3 != ""
        && op4 != "") {

        var list = [
            op1,
            op2,
            op3,
            op4
        ];

        const data =
        {
            PollName: name,
            Description: des,
            PollEndDate: endDate,
            GroupId: group,
            OptionList: list
        };

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
                showMessage('error', 'Failed to create poll');
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