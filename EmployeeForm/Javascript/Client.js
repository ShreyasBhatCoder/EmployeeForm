const inputs = [...document.querySelectorAll("input")].filter(input => input.value !== "Delete" && input.type !== "hidden");
const modalBody = document.getElementsByClassName("modal-body")[0];
const fetchBtn = document.getElementById("FetchBtn");
const submit = document.getElementById("Submit");
const reset = document.getElementById("Reset");
const actionBtns = [...document.querySelectorAll(".btn-group")].filter(btnGrp => /(^actions)/.test(btnGrp.id) === true);
const saveBtns = [...document.querySelectorAll(".btn-secondary")].filter(save => /(Save$)/.test(save.id) === true);

const actionToSave = new Map(actionBtns.map((action, save) => [action, saveBtns[save]]));




inputs.forEach(function (input) {
    input.addEventListener("focus", function () {
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

reset.addEventListener("click", function (event) {
    inputs.forEach(function (input) {
        input.classList.remove("is-valid", "is-invalid");
    });
});

fetchBtn.addEventListener("click", function (event) {
    form.classList.remove("needs-validation");
    inputs.forEach(function (input) {
        input.classList.remove("is-invalid");
    });
});



actionToSave.forEach((save, actions) => {
    var edit = actions.querySelector("input");
    edit.addEventListener("click", function (event) {
        event.preventDefault();
        event.stopPropagation();

        const parentRow = edit.closest("tr[data-command-argument]");
        const tds = parentRow.querySelectorAll("td[data-label]");

        actions.classList.add("replaced");
        save.classList.remove("replaced");

        const isEditable = tds[0].getAttribute("contenteditable") === "true" && actions.classList.contains("replaced") === true;

        tds.forEach(td => {
            td.setAttribute("contenteditable", !isEditable);
        });


        // Reset the blur and focused effects
        document.querySelectorAll("tr").forEach(row => row.classList.remove("focused", "blurred"));
        if (!isEditable) {
            parentRow.classList.add("focused");
            document.querySelectorAll("tr:not(.focused)").forEach(row => row.classList.add("blurred"));
        }
    });
});



