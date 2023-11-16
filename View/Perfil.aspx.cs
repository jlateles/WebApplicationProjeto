using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplicationProjeto.View
{
    public partial class Perfil : System.Web.UI.Page
    {
        /* Inicio Configuração */
        SqlConnection conexao = new SqlConnection();
        SqlCommand comandos = new SqlCommand();
        SqlDataAdapter adaptadorSql = new SqlDataAdapter();
        DataTable tabelaDados = new DataTable();
        DataSet dataSet = new DataSet();
        /* Final Configuração */
        protected void Page_Load(object sender, EventArgs e)
        {
            conexao.ConnectionString = "Data Source=51DE247989\\SENAC;Initial Catalog=escola;Integrated Security=True";
            conexao.Open();

            VerificarCookie();
        }

        public void VerificarCookie()
        {
            HttpCookie cookie = this.Page.Request.Cookies["cookieEmail"];
            lblBemvindo.Text = cookie.Value.ToString();

            dataSet = new DataSet();
            HttpCookie cookieId = this.Page.Request.Cookies["cookieID"];
            int id_aluno = Convert.ToInt32(cookieId.Value);
            comandos.CommandText = "SELECT * alunos WHERE id_aluno='" + id_aluno + "'";
            comandos.Connection = conexao;
            adaptadorSql = new SqlDataAdapter(comandos);
            adaptadorSql.Fill(dataSet);
            comandos.ExecuteNonQuery();
            SqlDataReader dados = comandos.ExecuteReader();

            lblId.Text = dados["id_aluno"].ToString();
            lblEmail.Text = dados["email"].ToString();
        }
    }
}