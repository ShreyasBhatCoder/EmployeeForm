<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="EmployeeForm.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Page</title>
    <link rel="stylesheet" href="TestStyle.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-aFq/bzH65dt+w6FI2ooMVUpc+21e0SRygnTpmBvdBgSdnuTN7QbdgL+OapgHtvPp" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/js/bootstrap.bundle.min.js" integrity="sha384-qKXV1j0HvMUeCBQ+QVp7JcfGl760yU08IQ+GpUo5hlbpg51QRiuqHAJz8+BrxE/N" crossorigin="anonymous"></script>

    <style>
        th, td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 5px;
        }
        @media screen and (max-width: 600px) {
            table,
            thead,
            tbody,
            tr,
            th,
            td {
                display: block;
            }

            thead tr {
                display: none;
            }

            tr {
                margin-bottom: 20px;
                border: 1px solid black;
            }

            td {
                border: none;
                position: relative;
                padding-left: 50%;
            }

            td:before {
                position: absolute;
                left: 6px;
                content: attr(data-label);
                font-weight: bold;
            }

            #container {
                padding: 10px;
            }
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <div id="container" runat="server">
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Age</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td data-label="Name">Shreyas</td>
                        <td data-label="Age">22</td>
                    </tr>
                    <tr>
                        <td data-label="Name">Sandhya</td>
                        <td data-label="Age">47</td>
                    </tr>
                    <tr>
                        <td data-label="Name">Rajesh</td>
                        <td data-label="Age">53</td>
                    </tr>
                </tbody>
            </table>
        </div>
        
    </form>
</body>
</html>
