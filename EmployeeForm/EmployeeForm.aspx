<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="EmployeeForm.EmployeeForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Details</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-aFq/bzH65dt+w6FI2ooMVUpc+21e0SRygnTpmBvdBgSdnuTN7QbdgL+OapgHtvPp" crossorigin="anonymous" />
    <link rel="stylesheet" href="~/CSS/Style.css" />
    
</head>
<body>
    <form id="form1" runat="server" class="needs-validation" novalidate="novalidate" style="z-index: 100;">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div id="formDiv">
            <p>Employee Details</p>
            <div id="form">
                <div class="EmployeeField">
                    <asp:TextBox CssClass="form-control" ID="TextName" runat="server" Placeholder="Name" required="required"></asp:TextBox>
                </div>

                <div class="EmployeeField">
                    <asp:TextBox CssClass="form-control" ID="TextMobile" runat="server" Placeholder="Mobile" required="required"></asp:TextBox>
                </div>

                <div class="EmployeeField">
                    <asp:TextBox CssClass="form-control" ID="TextEmail" runat="server" Placeholder="Email" required="required"></asp:TextBox>
                </div>

                <div class="EmployeeField">
                    <asp:TextBox CssClass="form-control" ID="TextDOB" runat="server" onblur="(this.type = 'text')" onfocus="(this.type = 'date')" Placeholder="DOB" required="required"></asp:TextBox>
                </div>

                <div class="EmployeeField">
                    <asp:TextBox CssClass="form-control" ID="TextDesignation" runat="server" Placeholder="Designation" required="required"></asp:TextBox>
                </div>

                <div class="btn-group gap-2" id="form-actions">
                    <asp:Button runat="server" Text="Submit" CssClass="btn btn-lg btn-secondary" ID="Submit" OnClick="Submit_Click" data-bs-toggle="modal" data-bs-target="#staticBackdrop"/>
                    <button type="reset" runat="server" class="btn btn-lg btn-secondary" id="Reset" onserverclick="Reset_Click">Reset</button>
                </div>
                <hr style="color: black;"/>
                <div>
                    <div class="Fetch gap-3">
                        <asp:TextBox ID="FetchEmp" runat="server" Placeholder="Fetch Employee Name"></asp:TextBox>
                        <asp:Button runat="server" Text="Get" CssClass="btn btn-secondary" ID="FetchBtn" OnClick="Fetch_Click" UseSubmitBehavior="false"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <h1 class="modal-title fs-5" id="staticBackdropLabel">Error</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">
              </div>
            </div>
          </div>
        </div>
        <asp:UpdatePanel runat="server" ID="RefreshTable">
            <ContentTemplate>
                <asp:Panel runat="server" id="EmpTable"></asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

        
        
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/js/bootstrap.bundle.min.js" integrity="sha384-qKXV1j0HvMUeCBQ+QVp7JcfGl760yU08IQ+GpUo5hlbpg51QRiuqHAJz8+BrxE/N" crossorigin="anonymous"></script>
        
    </form>

    <script type="text/javascript" src="./Javascript/Client.js"></script>
</body>
</html>
