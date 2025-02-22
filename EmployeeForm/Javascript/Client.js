const inputs = [...document.querySelectorAll("input")].filter(input => input.value !== "Delete" && input.type !== "hidden");
const modalBody = document.getElementsByClassName("modal-body")[0];
const fetchBtn = document.getElementById("FetchBtn");
const submit = document.getElementById("Submit");
const reset = document.getElementById("Reset");
const popovers = [...document.querySelectorAll('[data-bs-toggle="popover"]')];



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


submit.addEventListener("click", function (event) {
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

reset.addEventListener("click", function(event) {
    inputs.forEach(function (input) {
        input.classList.remove("is-valid", "is-invalid");
    });
});

fetchBtn.addEventListener("click", function (event) {
    form.classList.remove("needs-validation");
    inputs.forEach(function (input) {
        input.classList.remove("is-invalid");
    });
})

popovers.forEach(pop => new bootstrap.Popover(pop, {
    //trigger: "focus",
    html: true,
    sanitize: false
}));

document.body.addEventListener("click", function (event) {
    if (event.target.id === "Delete") {
        console.log("Delete button clicked");
        event.preventDefault();
        __doPostBack("Delete", '');
    }
});