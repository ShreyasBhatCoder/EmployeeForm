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
        <asp:Table runat="server" ID="Table1" BorderWidth="1">
            <asp:TableRow>
                <asp:TableCell contenteditable="true" data-field="Name" data-row="1" onfocus="storeOriginal(this)" oninput="updateHiddenField(this)">
            John Doe
                </asp:TableCell>
                <asp:TableCell contenteditable="true" data-field="Age" data-row="1" onfocus="storeOriginal(this)" oninput="updateHiddenField(this)">
            30
                </asp:TableCell>
                <asp:TableCell contenteditable="true" data-field="City" data-row="1" onfocus="storeOriginal(this)" oninput="updateHiddenField(this)">
            New York
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell contenteditable="true" data-field="Name" data-row="2" onfocus="storeOriginal(this)" oninput="updateHiddenField(this)">
            Jane Doe
                </asp:TableCell>
                <asp:TableCell contenteditable="true" data-field="Age" data-row="2" onfocus="storeOriginal(this)" oninput="updateHiddenField(this)">
            28
                </asp:TableCell>
                <asp:TableCell contenteditable="true" data-field="City" data-row="2" onfocus="storeOriginal(this)" oninput="updateHiddenField(this)">
            Los Angeles
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell contenteditable="true" data-field="Name" data-row="3" onfocus="storeOriginal(this)" oninput="updateHiddenField(this)">
            Alice Smith
                </asp:TableCell>
                <asp:TableCell contenteditable="true" data-field="Age" data-row="3" onfocus="storeOriginal(this)" oninput="updateHiddenField(this)">
            25
                </asp:TableCell>
                <asp:TableCell contenteditable="true" data-field="City" data-row="3" onfocus="storeOriginal(this)" oninput="updateHiddenField(this)">
            Chicago
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <!-- Single Pair of Hidden Fields -->
        <asp:HiddenField ID="OriginalHidden" runat="server" />
        <asp:HiddenField ID="UpdatedHidden" runat="server" />

        <asp:Button runat="server" ID="SubmitButton" Text="Submit" OnClick="SubmitButton_Click" />




    </form>
    <script src="Index.js"></script>
</body>
</html>
