const inputs = [...document.querySelectorAll("input")].filter(input => input.value !== "Delete" && input.type !== "hidden");
const modalBody = document.getElementsByClassName("modal-body")[0];
const fetchBtn = document.getElementById("FetchBtn");
const submit = document.getElementById("Submit");
const reset = document.getElementById("Reset");
const editBtns = [...document.querySelectorAll(".btn-secondary")].filter(edit => /(Edit$)/.test(edit.id) === true);
//const updateBtns = document.querySelectorAll(".btn-success");
const actionBtns = [...document.querySelectorAll(".btn-group")].filter(btnGrp => /(^actions)/.test(btnGrp.id) === true);





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
});




editBtns.forEach(edit => {
});




actionBtns.forEach(actionsDiv => {
    const originalDivHTML = actionsDiv.outerHTML; // Store original div as a string

    let isReplaced = false; // Toggle state
    let replacedElement = "";

    const edit = actionsDiv.querySelector("input");

    function toggleElement() {
        // Copy the original btn-grp div element that stored in a temporary variable
        const tempContainer = document.createElement("div");
        tempContainer.innerHTML = originalDivHTML;

        // If the div was replaced by the input element, then restore the div, else keep the input
        if (isReplaced) {
            replacedElement = tempContainer.firstElementChild
            replacedElement.value = "Edit";
        } else {
            replacedElement = edit.cloneNode(true);
            replacedElement.value = "Save";
        }

        replacedElement.addEventListener("click", toggleElement);

        // Replace Edit button with full div
        actionsDiv.replaceWith(replacedElement);
        // Update reference
        actionsDiv = replacedElement;
        isReplaced = !isReplaced;
    }



    edit.addEventListener("click", function (event) {
        event.preventDefault();
        event.stopPropagation();

        const parentRow = edit.closest("tr[data-command-argument]");
        const tds = parentRow.querySelectorAll("td[data-label]");
        const isEditable = tds[0].getAttribute("contenteditable") === "true";

        tds.forEach(td => {
            td.setAttribute("contenteditable", !isEditable);
        });

        toggleElement();

        document.querySelectorAll("tr").forEach(row => row.classList.remove("focused", "blurred"));
        if (!isEditable) {
            parentRow.classList.add("focused");
            document.querySelectorAll("tr:not(.focused)").forEach(row => row.classList.add("blurred"));
        }
    });

    // Attach the event listener initially to the div
    //actionsDiv.addEventListener("click", toggleElement);
})




//console.log();