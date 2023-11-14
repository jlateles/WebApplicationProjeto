using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/* chamando o cliente do SQL */
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.EnterpriseServices;

namespace WebApplicationProjeto
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        /* Inicio configuraçãoSQL SERVER */

        SqlConnection conexao = new SqlConnection(); /* criando conexao */
        SqlCommand comandos = new SqlCommand(); /* Executará os comandos */
        SqlDataAdapter adaptadorSql = new SqlDataAdapter(); /* criando de adaptador para conexao */
        DataTable tabelaDados = new DataTable(); /* TABELA CONTEND DADOS */
        DataSet dataSet = new DataSet(); /* objeto de interação com os dados */
        /* fim configuração SQL Server */
        protected void Page_Load(object sender, EventArgs e)
        {

            /* chave de Connection string, Propriedade Caddeia de Caracteres */
            conexao.ConnectionString = "Data Source=51DE247989\\SENAC;Initial CatalogL = escola;Integrated Security=true";

        }

        /* clique do botao que faz o envio */

        protected void btnEnviar_Click(object sender, EventArgs e)
        {


            if (txbSenha.Text != txbsenhaRepete.Text)
            {
                lblMensagem.Text = "As senhas não conferem! Tente outra vez!";
                lblMensagem.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                string email = Convert.ToString(txbEmail.Text);
                tabelaDados = new DataTable(); /* chamada da tabela de dados */
                comandos.CommandText = "INSERT INTO aluno(email, senha)VALUES(' " + email + " ', ' " + txbSenha.Text.ToString() + " ')";
                comandos.Connection = conexao; /* execução dos comandos com conexão */
                comandos.ExecuteNonQuery(); /* execução da query insert */
                lblMensagem.Text = "Aluno cadastrado!";
                lblMensagem.BackColor = System.Drawing.Color.Green;
                ExibirDados(); 
            }
        }

        /* função ExibirDados aqui!!!!!!!!!!!! */

        public void ExibirDados()
        {
            dataSet = new DataSet();
            comandos.CommandText = "SELECT * FROM alunos WHERE email= ' " + txbEmail.Text + " '";
            comandos.Connection = conexao;
            adaptadorSql = new SqlDataAdapter(comandos);
            adaptadorSql.Fill(dataSet);
            comandos.ExecuteNonQuery();
            gdvExibir.DataSource = dataSet;
            gdvExibir.DataBind();
            conexao.Close();
        }
    }

}