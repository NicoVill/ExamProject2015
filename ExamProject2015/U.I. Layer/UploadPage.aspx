<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPage.aspx.cs" Inherits="ExamProject2015.UploadPage" %>

<!DOCTYPE html>

<html>
<head>
    <title>Upload Side</title>
    <link rel="stylesheet" href="Main.css">

</head>

<body>

    <header>
				<nav>
				<h1>Upload Side</h1>
					<ul>
						<li><asp:HyperLink id="hyperlink1" 
                                 NavigateUrl="Mainpage.aspx"
                                    Text="Home"
                                runat="server"
                            /> </li>
						<li><a href="#"></a>Blog</li>
						<li><a href="#"></a>About</li>
						<li><a href="#"></a>Contact</li>
						<li><a href="#"></a>Links</li>
					</ul>
				
				</nav>
			</header>

    <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btn_Upload" runat="server" OnClick="Upload" Text="Upload" />
        <br />
        <asp:TextBox ID="txtb_FileName" runat="server"></asp:TextBox>
    <div>
    
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
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    
    </div>
   


          <asp:Label ID="UrlNameLabel" runat="server" Text="Name of Link"></asp:Label>
&nbsp;&nbsp;&nbsp;

            <asp:TextBox ID="txtb_LinkName" runat="server"></asp:TextBox>
       
            &nbsp;&nbsp;&nbsp;
       
            <asp:Label ID="UrlLabel" runat="server" Text="Insert Url"></asp:Label>
            
            &nbsp;&nbsp;&nbsp;
            
            <asp:TextBox ID="txtb_LinkUpload" runat="server"></asp:TextBox>
            <asp:Button ID="UrlBtn" runat="server" Text="Upload Link" OnClick="UrlBtn_Click" />
        
        
     </form>
    <footer>footer</footer>
</body>
</html>
