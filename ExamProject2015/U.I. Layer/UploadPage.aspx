﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPage.aspx.cs" Inherits="ExamProject2015.UploadPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btn_Upload" runat="server" OnClick="Upload" Text="Upload" />
        <br />
        <asp:TextBox ID="txtb_FileName" runat="server"></asp:TextBox>
    <div>
    
        <asp:GridView ID="GridView" runat="server" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000" AutoGenerateColumns="false" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="File Name" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                   <%-- <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="DownloadFile" Text="Download"></asp:LinkButton>
                    </ItemTemplate>--%>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
