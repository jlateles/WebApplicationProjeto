<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplicationProjeto.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- Inicio do Código Content2 -->
    <form action="/action_page.php">

    <div class="container">
    <h1>Login</h1>
    <p>Digite Suas Informações.</p>
    
    <hr>

    <label for="email"><b>Email:</b></label>
    <asp:TextBox ID="txbEmail" placeholder="Digite seu email" runat="server"  />
    <br />
    
    <label for="senha"><b>Senha:</b></label>
    <asp:TextBox ID="txbSenha" placeholder="Digite sua senha" runat="server" />
    <br />

        <asp:GridView ID="gdvExibir" runat="server" ></asp:GridView>
        
        
        
    <hr>

    <!-- <button type="submit" class="registerbtn">Entrar</button> --> 
   <asp:Button ID="btnLogin" class="registerbtn" runat="server" Text="Entrar" OnClick="btnLogin_Click" />
  </div>

    <asp:Label ID="lblMensagem" Text="Resposta" runat="server"></asp:Label>
        
</form>
<!-- Fim do Código Content2 -->
</asp:Content>
