<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Identifikohu.aspx.cs" Inherits="Sistemeinterneti.Identifikohu" %>

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

            ID:<asp:TextBox ID="id" runat="server"  ></asp:TextBox>
           
      <%--/// Limitimi i ID ///--%>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="ID nuk eshte e rregullt!" ValidationExpression="^(?=.*[A-Z])(?=.*[0-9])[A-Z0-9]{10,}" ControlToValidate="id"></asp:RegularExpressionValidator>
            <%--///perjashtim i thonjezave teke per ID///--%>
            <asp:RegularExpressionValidator ID="moslejimithonjezaveteke" runat="server" ErrorMessage="Nuklejohen thonjezat teke!" ValidationExpression="^[^']*$" ControlToValidate="id"></asp:RegularExpressionValidator>
            <br />
         
             
			   <br />
			   Fjalekalimi:<asp:TextBox ID="fjalekalim" runat="server" TextMode="Password"></asp:TextBox>
            
           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ju lutem vendosni nje Fjalekalim" ControlToValidate="fjalekalim"></asp:RequiredFieldValidator>
           
            <%--/// Limitimi i Passwordit///--%>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Fjalekalimi nuk eshte i rregullt!" ValidationExpression="^(?=.*[A-Z])(?=.*[0-9])[A-Z0-9]{10,}" ControlToValidate="fjalekalim"></asp:RegularExpressionValidator>
            <%--///Perjashtim i thonjezave teke per fjalekalimin///--%>
            <asp:RegularExpressionValidator ID="moslejimithonjezaveteke2" runat="server" ErrorMessage="Nuk lejohen thonjezat teke!" ValidationExpression="^[^']*$" ControlToValidate="fjalekalim"></asp:RegularExpressionValidator>
            <br />
           
            <br />
          
             <%-- ///Captcha --%>
            <div id="ReCaptchContainer"></div>
        <asp:Label ID="lblMessage1" runat="server"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Hyr" OnClick="Button1_Click"   />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="true" />
       <br />
            
            </div>
        </div>
     
    </form>
    <script src="https://www.google.com/recaptcha/api.js?onload=renderRecaptcha&render=explicit" async defer></script>
    <script type="text/javascript">
        var your_site_key = '6LciwAEVAAAAAGrGIigl3SIDs1Y40xHy0lg57GI-';
        var renderRecaptcha = function () {
            grecaptcha.render('ReCaptchContainer', {
                'sitekey': '6LciwAEVAAAAAGrGIigl3SIDs1Y40xHy0lg57GI-',
                'callback': reCaptchaCallback,
                theme: 'light', //light or dark
                type: 'image',// image or audio
                size: 'normal'//normal or compact
            });
        };
        var reCaptchaCallback = function (response) {
            if (response !== '') {
                document.getElementById('lblMessage1').innerHTML = "";
            }
        };
       </script> 


</body>
        
</html>
