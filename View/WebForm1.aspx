<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplicationProjeto.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
  
    <div class="container">
        <h1>Cadastra-se</h1>
    
    <hr>

        <label for="email"><b>Email:</b></label>
        <asp:TextBox ID="txbEmail" placeholder="Digite seu email" runat="server"  />
    <br />
    
        <label for="senha"><b>Senha:</b></label>
        <asp:TextBox ID="txbSenha" placeholder="Digite sua senha" runat="server" />
        <br />
    
        <label for="senhaRepete"><b>Confirme sua senha:</b></label>
        <asp:TextBox ID="txbsenhaRepete" placeholder="Confirme sua senha" runat="server" />
    <br />

        <asp:GridView ID="gdvExibir" runat="server" ></asp:GridView>
        
    <hr>
        <p>Criando uma conta você concorda com nossos<a href="#">Termos & Privacidade</a>.</p>
  </div>

    <asp:Label ID="lblMensagem" Text="Resposta" runat="server"></asp:Label>

    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" />
  
  <div class="container signin">
    <p>Já tem uma conta? <a href="#">Entre aqui</a>.</p>
  </div>



</asp:Content>
