<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="ExamProject2015.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    </div>
        <br />
        <br />
        <hr />
        <br />
        Skole&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownSchool" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSchool_SelectedIndexChanged">
        </asp:DropDownList>
        
        <br />
        <br />
        Årgang <asp:DropDownList ID="DropDownYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownYear_SelectedIndexChanged">
        </asp:DropDownList>

        <br />
        <br />
        Klasse&nbsp; <asp:DropDownList ID="DropDownClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownClass_SelectedIndexChanged">
        </asp:DropDownList>

        <br />
        <br />
        Fag&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownSubject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSubject_SelectedIndexChanged">
        </asp:DropDownList>

        <br />
        <br />
        Mappe <asp:DropDownList ID="DropDownSubjectFolder" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSubjectFolder_SelectedIndexChanged">
        </asp:DropDownList>
    </form>
</body>
</html>