const inputs = [...document.querySelectorAll("input")].filter(input => input.value !== "Delete" && input.type !== "hidden");
const modalBody = document.getElementsByClassName("modal-body")[0];
const fetchBtn = document.getElementById("FetchBtn");
const submit = document.getElementById("Submit");
const reset = document.getElementById("Reset");
const editBtns = [...document.querySelectorAll(".btn-secondary")].filter(edit => /(^Edit)/.test(edit.id) === true);
const dataTable = document.querySelector("table");



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


editBtns.forEach(edit => {
    edit.addEventListener("click", function (event) {
        event.preventDefault();

        const parentRow = edit.closest("tr[data-command-argument]");
        const tds = parentRow.querySelectorAll("td[data-label]");

        // Check if the first td is already editable
        const isEditable = tds[0].getAttribute("contenteditable") === "true";

        // Toggle contentEditable attribute for each td
        tds.forEach(td => {
            td.setAttribute("contenteditable", !isEditable);
            //td.style.outline = !isEditable ? "2px solid blue" : "none"; // Visual indicator
        });
    });
});