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
						<li><a href="#"></a>Home</li>
						<li><a href="#"></a>Blog</li>
						<li><a href="#"></a>About</li>
						<li><a href="#"></a>Contact</li>
						<li><a href="#"></a>Links</li>
					</ul>
				
				</nav>
			</header>

    <div id="section">
    <h1>London</h1>
    <p>
    London is the capital city of England. It is the most populous city in the United Kingdom,
    with a metropolitan area of over 13 million inhabitants.
    </p>
    <p>
    Standing on the River Thames, London has been a major settlement for two millennia,
    its history going back to its founding by the Romans, who named it Londinium.
    </p>
    </div>

    <div id="navbar">
    <form id="form1" runat="server">
    <div>
        
    </div>
        <asp:DropDownList ID="DropDownSchool" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSchool_SelectedIndexChanged">
        </asp:DropDownList>
        
        <asp:DropDownList ID="DropDownYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownYear_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:DropDownList ID="DropDownClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownClass_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:DropDownList ID="DropDownSubject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSubject_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:DropDownList ID="DropDownSubjectFolder" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSubjectFolder_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:TextBox ID="txtb_FolderName" runat="server"></asp:TextBox>

        <asp:Button ID="btn_CreateFolder" runat="server" Text="Create Folder" OnClick="btn_CreateFolder_Click" />
        <br />
        <br />
        <asp:TextBox ID="RenameFolderTxt" runat="server"></asp:TextBox>

        <asp:Button ID="btn_RenameFolder" runat="server" Text="Rename Folder" OnClick="btn_RenameFolder_Click" />



        <br />
        <asp:Button ID="btn_Delete" runat="server" Text="Delete Folder" OnClick="btn_Delete_Click" />



        <br />



        <br />
        <br />
        <p>
            <asp:Label ID="UrlNameLabel" runat="server" Text="Name of Link"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txtb_LinkName" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="UrlLabel" runat="server" Text="Insert Url"></asp:Label>
            <br />
            <asp:TextBox ID="txtb_LinkUpload" runat="server"></asp:TextBox>
            <asp:Button ID="UrlBtn" runat="server" Text="Upload Link" OnClick="UrlBtn_Click" />
        </p>
        
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
    </div>

    <footer>footer</footer>

</body>
    

</html>


<%--<html xmlns="http://www.w3.org/1999/xhtml">
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
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Årgang <asp:DropDownList ID="DropDownYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownYear_SelectedIndexChanged">
        </asp:DropDownList>

        &nbsp;&nbsp;&nbsp;
        Klasse&nbsp; <asp:DropDownList ID="DropDownClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownClass_SelectedIndexChanged">
        </asp:DropDownList>

        &nbsp;&nbsp;&nbsp;
        Fag&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownSubject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownSubject_SelectedIndexChanged">
        </asp:DropDownList>

        &nbsp;&nbsp;&nbsp;
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
        <br />
        Mappe Navn
        <asp:TextBox ID="txtb_FolderName" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="btn_CreateFolder" runat="server" Text="Lav Mappe" OnClick="btn_CreateFolder_Click" />
        <br />
        Mappe Navn
        <asp:TextBox ID="RenameFolderTxt" runat="server"></asp:TextBox>

        <asp:Button ID="RenameFolderBtn" runat="server" Text="Rename Folder" OnClick="RenameFolderBtn_Click" />
        <br />
        <asp:Button ID="btn_DeleteFolder" runat="server" Text="Delete Folder" OnClick="btn_DeleteFolder_Click" />
        <br />
        <br />
        --&gt;
        <asp:Label ID="UrlNameLabel" runat="server" Text="Name of Link"></asp:Label>
        <asp:TextBox ID="UrlNameTxt" runat="server"></asp:TextBox>
        <asp:Label ID="UrlLabel" runat="server" Text="Insert Url"></asp:Label>
        <asp:TextBox ID="UrlTxt" runat="server"></asp:TextBox>
        <asp:Button ID="UrlBtn" runat="server" OnClick="UrlBtn_Click" Text="Upload Link" />
        <br />
    </form>
</body>
</html>--%>