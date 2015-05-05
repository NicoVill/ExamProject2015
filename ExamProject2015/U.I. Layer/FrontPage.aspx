<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrontPage.aspx.cs" Inherits="ExamProject2015.FrontPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <h2>
        Velkommen til Toftlund Distrikt skoles Fil Delings Service
            </h2>
        <p>
        &nbsp;<asp:Label ID="lbl_Username" runat="server" Text="Brugernavn"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txtb_Username" runat="server"></asp:TextBox>
            </p>
         <p>
        &nbsp;<asp:Label ID="lbl_Password" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txtb_Password" runat="server"></asp:TextBox>
            </p>
        <p>
            <asp:Button ID="btn_Login" runat="server" Text="Login" OnClick="btn_Login_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_msg" runat="server" Text="Test"></asp:Label>
            </p>
            </form>
</body>
</html>
