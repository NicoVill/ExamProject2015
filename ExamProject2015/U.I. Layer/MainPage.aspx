<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="ExamProject2015.MainPage" %>

	<!doctype html>
	
<html>
<head>
    <title>Awesome</title>
    <link rel="stylesheet" href="Main.css">

</head>

<body>

    <header>
				<nav>
				<h1>Awesome page</h1>
					<ul>
						<li><a href="/Mainpage.aspx"></a>Home</li>
						<li><a href="#"></a>Blog</li>
						<li><a href="#"></a>About</li>
						<li><a href="#"></a>Contact</li>
						<li><a href="#"></a>Links</li>
					</ul>
				
				</nav>
			</header>
    <form runat="server">
    <div id="section">
    
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
        <br />
        <asp:GridView ID="GridViewLink" runat="server">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Link navn" />
                <asp:hyperlinkfield DataTextField="Url" datanavigateurlformatstring="http://{0}" HeaderText="URL" DataNavigateUrlFields="Url" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="label_Grid" runat="server" Text=""></asp:Label>
        <br/>
        <asp:Button ID="btn_upload" runat="server" Text="Upload Fil" OnClick="btn_upload_Click" />
    
    </div>

    <div id="navbar">
    
    <div>
        
    </div>
        <asp:DropDownList ID="DropDownSchool" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSchool_SelectedIndexChanged">
        </asp:DropDownList>
        
        <br />
        
        <asp:DropDownList ID="DropDownYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownYear_SelectedIndexChanged">
        </asp:DropDownList>

        <br />

        <asp:DropDownList ID="DropDownClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownClass_SelectedIndexChanged">
        </asp:DropDownList>

        <br />

        <asp:DropDownList ID="DropDownSubject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSubject_SelectedIndexChanged">
        </asp:DropDownList>

        <br />

        <asp:DropDownList ID="DropDownSubjectFolder" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSubjectFolder_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:TextBox ID="txtb_FolderName" runat="server"></asp:TextBox>

        <asp:Button ID="btn_CreateFolder" runat="server" Text="Create Folder" OnClick="btn_CreateFolder_Click" />
        <br />
        <asp:Label ID="label_CreateFolder" runat="server" Text=""></asp:Label>
        <br />
        <asp:TextBox ID="RenameFolderTxt" runat="server"></asp:TextBox>

        <asp:Button ID="btn_RenameFolder" runat="server" Text="Rename Folder" OnClick="btn_RenameFolder_Click" />



        <br />
        <asp:Label ID="label_RenameFolder" runat="server" Text=""></asp:Label>



        <br />



        <asp:Button ID="btn_Delete" runat="server" Text="Delete Folder" OnClick="btn_Delete_Click" />



        <br />
        <br />
        <p>
      
        
       

    
    </div>
    </form>
    <footer>footer</footer>

</body>
    

</html>
