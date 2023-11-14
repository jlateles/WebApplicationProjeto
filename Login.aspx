<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplicationProjeto.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form action="/action_page.php">
  
    <div class="container">
    <h1>Login</h1>
    
    <hr>

    <label for="email"><b>Email:</b></label>
    <asp:TextBox ID="txbEmail" placeholder="Digite seu email" runat="server"  />
    <br />
    
    <label for="senha"><b>Senha:</b></label>
    <asp:TextBox ID="txbSenha" placeholder="Digite sua senha" runat="server" />
    <br />

        <asp:GridView ID="gdvExibir" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>
        
        
    <hr>

    <!-- <button type="submit" class="registerbtn">Entrar</button> --> 
   <asp:Button ID="btnLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" />
  </div>

    <asp:Label ID="lblMensagem" Text="Resposta" runat="server"></asp:Label>
</form>

</asp:Content>
