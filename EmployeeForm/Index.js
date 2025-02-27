var originalText = "";

function storeOriginalText(element) {
    originalText = element.innerText; // Store original value
    document.getElementById('<%= originalText.ClientID %>').value = originalText;
}

function updateChangedText(element) {
    document.getElementById('<%= updatedText.ClientID %>').value = element.innerText;
}

function sendToServer(element) {
    if (originalText !== element.innerText) {
        __doPostBack('<%= updatedText.ClientID %>', ''); // Trigger ASP.NET postback
    }
}