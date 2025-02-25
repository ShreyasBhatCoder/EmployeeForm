const updateBtn = document.createElement("button");

const form1 = document.getElementById("form1");

updateBtn.innerText = "Click";
updateBtn.id = "ClickBtn";
updateBtn.click = function (event) {
    __doPostBack("ClickBtn", "");
};

form1.appendChild(updateBtn);