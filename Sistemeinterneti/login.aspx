<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Sistemeinterneti.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" ></asp:Label>  
            <br />

            Id:<asp:TextBox ID="id" runat="server" ></asp:TextBox>
            <br />
            Email:<asp:TextBox ID="email" runat="server"></asp:TextBox> <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ju lutem vendosni nje email" ControlToValidate="email"></asp:RequiredFieldValidator>
              
			   <br />
			   Fjalekalimi:<asp:TextBox ID="fjalekalim" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ju lutem vendosni nje Fjalekalim" ControlToValidate="fjalekalim"></asp:RequiredFieldValidator>
                          

            <br />
           
            
            <asp:Button ID="Button1" runat="server" Text="Regjistrohu" OnClick="Button1_Click" /> <br />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="true" />
            
       <br />
 <asp:HyperLink runat="server" ID="hyperlink100" NavigateUrl="~/Identifikohu.aspx"  ForeColor="Green">Identifikohu</asp:HyperLink>
            
            </div>
    </form>
</body>
</html>
