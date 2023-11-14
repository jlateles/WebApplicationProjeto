using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


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

        conexao.ConnectionString = "Data Source=51DE247989\\SENAC;Initial CatalogL = escola;Integrated Security=true";
        conexao.Open();

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            checarUsuario();
        }


        public void checarUsuario() {

            dataSet = new DataSet();
            comandos.CommandText = "INSERT INTO aluno(email, senha)VALUES(' " + txbEmail.Text.ToString() + " ', ' " + txbSenha.Text.ToString() + " ')";
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
                ; Response.Cookies.Add(cookieEmail); /*adiciona o cookie a seção*/

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


    }
}