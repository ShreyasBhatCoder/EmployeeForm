const inputs = [...document.querySelectorAll("input")].filter(input => input.type === "text" && /(^Text)/.test(input.id));
const modalBody = document.getElementsByClassName("modal-body")[0];
const fetchBtn = document.getElementById("FetchBtn");
const submit = document.getElementById("Submit");
const reset = document.getElementById("Reset");

const actionBtns = [...document.querySelectorAll(".btn-group")].filter(btnGrp => /(^actions)/.test(btnGrp.id) === true);
const saveBtns = [...document.querySelectorAll(".btn-success")];

const actionToSave = new Map(actionBtns.map((action, save) => [action, saveBtns[save]]));

let originalData = {}; // To store original values
let updatedData = {};  // To store updated values

const originalHiddenId = 'OriginalHidden';
const updatedHiddenID = 'UpdatedHidden';


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
    var parentRow = edit.closest("tr[data-command-argument]");
    var tds = parentRow.querySelectorAll("td[data-label]");

    var isEditable = tds[0].getAttribute("contenteditable") === "true"; // Initially false

    function toggleElement() {
        isEditable = !isEditable;  // Now it properly toggles

        tds.forEach(td => {
            td.setAttribute("contenteditable", isEditable);
        });

        if (isEditable) {
            actions.classList.add("replaced");
            save.classList.remove("replaced");

            parentRow.classList.add("focused", "no-hover");
            
            document.querySelectorAll("tr:not(.focused)").forEach(row => row.classList.add("blurred"));

        } else {
            actions.classList.remove("replaced");
            save.classList.add("replaced");
            parentRow.classList.remove("no-hover");
            document.querySelectorAll("tr").forEach(row => row.classList.remove("focused", "blurred"));
        }
    }

    edit.addEventListener("click", function (event) {
        event.preventDefault();
        event.stopPropagation();
        toggleElement();
    });

    // Move this outside to prevent multiple event bindings
    save.addEventListener("click", function (event) {
        event.preventDefault();
        toggleElement();
    });
});



function storeOriginal(element) {
    let row = element.getAttribute("data-row");
    let field = element.getAttribute("data-label");

    if (!originalData[row]) {
        originalData[row] = {};
    }

    if (!originalData[row][field]) {
        originalData[row][field] = element.innerText.trim();
        document.getElementById(originalHiddenId).value = JSON.stringify(originalData);
    }

}

function updateHiddenField(element) {
    let row = element.getAttribute("data-row");
    let field = element.getAttribute("data-label");

    if (!updatedData[row]) {
        updatedData[row] = {};
    }

    updatedData[row][field] = element.innerText.trim();
    document.getElementById(updatedHiddenID).value = JSON.stringify(updatedData);
}

