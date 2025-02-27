<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="EmployeeForm.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Page</title>
    <link rel="stylesheet" href="TestStyle.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-aFq/bzH65dt+w6FI2ooMVUpc+21e0SRygnTpmBvdBgSdnuTN7QbdgL+OapgHtvPp" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/js/bootstrap.bundle.min.js" integrity="sha384-qKXV1j0HvMUeCBQ+QVp7JcfGl760yU08IQ+GpUo5hlbpg51QRiuqHAJz8+BrxE/N" crossorigin="anonymous"></script>


</head>
<body>

    <form id="form1" runat="server">
        <asp:Table runat="server" ID="myTable" BorderWidth="1">
            <asp:TableRow>
                <asp:TableCell>
            <div contenteditable="true" onfocus="storeOriginalText(this)" 
                 oninput="updateChangedText(this)" onblur="sendToServer(this)">
                Editable Cell
            </div>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:HiddenField runat="server" ID="originalText" />
        <asp:HiddenField runat="server" ID="updatedText" />

        <script src="Index.js"></script>
    </form>
</body>
</html>
