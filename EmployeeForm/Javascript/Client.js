const form = document.getElementById("form1");
const inputs = form.querySelectorAll("input");
const modalBody = document.getElementsByClassName("modal-body")[0];


inputs.forEach(function(input) {
    input.addEventListener("focus", function() {
        input.classList.remove("is-valid", "is-invalid");
    });

    input.addEventListener("blur", () => {
        if (input.checkValidity()) {
            input.classList.add("is-valid");
        } else {
            input.classList.add("is-invalid");
        }
    });
});

form.addEventListener("submit", function (event) {
    var isValid = true;
    inputs.forEach(function (input) {
        if (input.checkValidity()) {
            input.classList.add("is-valid");
        } else {
            input.classList.add("is-invalid");
            isValid = false;
        }
    });

    if (!isValid) {
        event.preventDefault();
        modalBody.innerHTML = "Some fields are empty";
    }
});

form.addEventListener("reset", function(event) {
    inputs.forEach(function (input) {
        input.classList.remove("is-valid", "is-invalid");
    });
});
