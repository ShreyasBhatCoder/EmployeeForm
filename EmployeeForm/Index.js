let originalData = {}; // To store original values
let updatedData = {};  // To store updated values

const originalHiddenId = 'OriginalHidden';
const updatedHiddenID = 'UpdatedHidden';

function storeOriginal(element) {
    let row = element.getAttribute("data-row");
    let field = element.getAttribute("data-field");

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
    let field = element.getAttribute("data-field");

    if (!updatedData[row]) {
        updatedData[row] = {};
    }

    updatedData[row][field] = element.innerText.trim();
    document.getElementById(updatedHiddenID).value = JSON.stringify(updatedData);
}

console.log(originalData[0]);
console.log(updatedData[0]);