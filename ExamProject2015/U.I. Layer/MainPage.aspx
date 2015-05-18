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
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
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
        Mappe

        <asp:DropDownList ID="DropDownSubjectFolder" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSubjectFolder_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        ID
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        Parent <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="btn_upload" runat="server" Text="Upload Fil" OnClick="btn_upload_Click" />
        <br />
        <asp:GridView ID="GridView" runat="server" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000" AutoGenerateColumns="false" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="GivenName" HeaderText="File Name" />
                <asp:BoundField DataField="Name" HeaderText="Real File Name" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" runat="server"  OnClick="DownloadFile" Text="Download" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>