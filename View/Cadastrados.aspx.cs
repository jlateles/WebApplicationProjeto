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
    public partial class Cadastrados : System.Web.UI.Page
    {

        /* Inicio Configuração SQL Server */
        SqlConnection conexcao = new SqlConnection();/* Criando a conexão */
        SqlCommand comandos = new SqlCommand();/* Executará os comandos */
        SqlDataAdapter adaptadorSql = new SqlDataAdapter(); /* Criação do Adaptador para Conexão */
        DataTable tabelaDados = new DataTable(); /* Tabela contendo os Dados */
        DataSet dataSet = new DataSet(); /* Objeto de interação com os dados */
        /* Fim Configuração SQl Server */
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Chave do Connection Strig, Propriedade Cadeia de Caracteres*/
            conexcao.ConnectionString = "Data Source=51DE247989\\SENAC;Initial Catalog=escola;Integrated Security=True";
            conexcao.Open();/* Abertura da Conexão com o Connection String */

            dataSet = new DataSet();/* Recebendo o virá da tabela*/
            comandos.CommandText = " SELECT * FROM aluno ";
            comandos.Connection = conexcao;
            adaptadorSql = new SqlDataAdapter(comandos);
            adaptadorSql.Fill(dataSet);
            comandos.ExecuteNonQuery();
            gdvExibir.DataSource = dataSet;
            gdvExibir.DataBind();
            conexcao.Close();

        }
    }
}