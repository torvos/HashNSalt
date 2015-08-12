<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HashNSalt.aspx.cs" Inherits="HashNSalt_C_Sharp_V4_5_2_.HashNSalt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblPassword" runat="server" Text="Enter some text:"></asp:Label><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox> 
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br />
            <br />
            <asp:Label ID="lblSalt" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblHash" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblValidate" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
