using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/* Biliotecas SQL */
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;



namespace WebApplicationProjeto
{
    public partial class Login : System.Web.UI.Page
    {

        /* inicio configuração SQL server */
        SqlConnection conexao = new SqlConnection();
        SqlCommand comandos = new SqlCommand();
        SqlDataAdapter adaptadorSql = new SqlDataAdapter();
        DataTable tabelaDados = new DataTable();
        DataSet dataSet = new DataSet();
        /* fim configuração SQL Server */
        protected void Page_Load(object sender, EventArgs e)
        {

        conexao.ConnectionString = "Data Source=51DE247989\\SENAC;Initial Catalog = escola;Integrated Security=true";
        conexao.Open();

        }


        public void checarUsuario() {

            dataSet = new DataSet();
            comandos.CommandText = "SELECT * FROM aluno WHERE email='" + txbEmail.Text + "' AND senha='" + txbSenha.Text + "' ";
            comandos.Connection = conexao;
            adaptadorSql = new SqlDataAdapter(comandos);
            adaptadorSql.Fill(dataSet);
            comandos.ExecuteNonQuery();
            /* carregar o conteudo em um objeto */
            SqlDataReader dados = comandos.ExecuteReader();
            /* dados ["ide_aluno"], dados["email"], dados["senha"]*/

            if (dados.HasRows)
            {
                dados.Read(); /*faz a leitura do que recebeuem dados */
                string dadosEmail = dados["email"].ToString();
                string dadosId = dados["id_aluno"].ToString();

                /* cria um cookie com os dados de email do banco*/
                HttpCookie cookieEmail = new HttpCookie("cookieEmail", dadosEmail);
                Response.Cookies.Add(cookieEmail); /*adiciona o cookie a seção*/

                /* cria um cookie com o id_aluno do banco*/
                HttpCookie cookieId = new HttpCookie("cookieId", dadosId);
                Response.Cookies.Add(cookieId);

                Response.Redirect("");
            }
            else
            {
                lblMensagem.Text = "Email ou senha inválido(s)!";
            }

        }
        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            checarUsuario();
        }


    }
}