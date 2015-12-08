using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common; // IMPORTANT pour utiliser DbProviderFactory
using MySql.Data.MySqlClient; // IMPORTANT pour utiliser MySQL avec PhpMyAdmin
using System.Data; // IMPORTANT pour utiliser CommandType

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Bachelor unBachelor = new Bachelor();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMeConnecter_Click(object sender, EventArgs e)
        {
            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM bachelor WHERE username = @username";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if (dbrdr.Read())
                {
                    int id;
                    int.TryParse(dbrdr["id"].ToString(), out id);
                    String username = dbrdr["username"].ToString();
                    String password = dbrdr["password"].ToString();
                    String email = dbrdr["email"].ToString();
                    int numberOfLikes;
                    int.TryParse(dbrdr["numberOfLikes"].ToString(), out numberOfLikes);
                    String imagePath = dbrdr["image"].ToString();

                    unBachelor.Id = id;
                    unBachelor.Username = username;
                    unBachelor.Password = password;
                    unBachelor.Email = email;
                    unBachelor.NumberOfLikes = numberOfLikes;
                    unBachelor.Image = imagePath;

                    if (txtPassword.Text.Trim().Equals(unBachelor.Password))
                    {
                        Session["isConnected"] = unBachelor.Username.ToString();
                        Session["profile"] = unBachelor;
                        Response.Redirect("accueil.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "<h3 style=\"color:red\">Erreur ! Le mot de passe saisi est incorrect.</h3>";
                    }
                }
                else
                {
                    lblMessage.Text = "<h3 style=\"color:red\">Erreur ! L'utilsateur " + txtUsername.Text + " est inexistant.</h3>";
                }                
            }
            cnx.Close();
        }
    }
}