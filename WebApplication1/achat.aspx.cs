using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.Common; 

namespace WebApplication1
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["profile"] == null)
                Response.Redirect("login.aspx");
        }

        protected void btnCommander_Click(object sender, EventArgs e)
        {
            if (txtNumeroDeCarteDeCredit.Text.Length > 12)
            {                
                int numberOfLikes;
                int.TryParse(txtNumberOfLikes.Text, out numberOfLikes);
                numberOfLikes += ((Bachelor)Session["profile"]).NumberOfLikes;
                using (MySqlConnection con = new MySqlConnection(("server=localhost;user=root;password=root;database=katnisseverdeen")))
                {
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE bachelor SET numberOfLikes = @numberOfLikes WHERE id = @idUser"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@numberOfLikes", numberOfLikes);
                            cmd.Parameters.AddWithValue("@idUser", ((Bachelor)Session["profile"]).Id);
                            cmd.Connection = con;
                            con.Open();
                            int nombreLignesAffectees = cmd.ExecuteNonQuery();
                            con.Close();
                            if (nombreLignesAffectees > 0)
                                bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-info\"><strong>Communiqué </strong>Votre commande a été placée. Nous vérifions vos informations le plus rapidement que possible."+ numberOfLikes +"</div>"));
                            else
                                bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-danger\"><strong>ERREUR !</strong> Transaction annulée...</div>"));
                        }
                    }
                }
            }
            else
            {
                bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-warning\"><strong>Attention ! </strong>Vous avez oublié de saisir votre numéro de carte de crédit.</div>"));
            }
        }

        protected void chkBut_Click(object sender, EventArgs e)
        {
            String cn = Request.Form["card_number"];
            String cname =Request.Form["card_name"];
            String expi = Request.Form["month"] +"/" +Request.Form["card_year"];
            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            
            // Vérification si le nom d'utilisateur est déjà utilisé dans la base de données 
            cmd.CommandText = "SELECT * FROM credit WHERE numeroCarte = @idCarte";
            cmd.Parameters.AddWithValue("@idCarte", cn);
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if (dbrdr.Read())
                {
                    bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-danger\"><strong>ERREUR !</strong>Désolé, il existe déjà une carte { " + cn + " }</div>"));
                }
                else
                {
                    cnx.Close();// fermeture de ExecuteReader()
                    
                    // ouverture pour ExecuteNonQuery()
                    MySqlConnection cnx2 = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen");
                    cnx2.Open();
                    MySqlCommand cmd2 = cnx2.CreateCommand();

                    //works
                    //cmd.CommandText = "INSERT INTO bachelor (username, password, email) VALUES ('test','test','test');";
                    //cmd.CommandText = "INSERT INTO bachelor (username, password, email,image) VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtEmail.Text + "','"+img+");";
                    //cmd.CommandText = "INSERT INTO bachelor (username, password, email,image) VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtEmail.Text + "','" + img + "');";
                    cmd2.CommandText = "INSERT INTO credit (`numeroCarte`, `nomCarte`, `dateExpiration`) VALUES (@idC,@nomC,@date);";
                    cmd2.Parameters.AddWithValue("@idC", cn);
                    cmd2.Parameters.AddWithValue("@nomC", cname);
                    cmd2.Parameters.AddWithValue("@date", expi);
                    int nombreDeLignesAffectees = cmd2.ExecuteNonQuery();
                    if (nombreDeLignesAffectees > 0)
                    {
                        bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-success\"><strong>BRAVO !</strong>Votre carte va être étudier! nous vous enverrons un message très bientôt.</div>"));
                        // source de : http://www.beansoftware.com/ASP.NET-Tutorials/Using-PlaceHolder-Control.aspx 
                        /*txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtPasswordC.Text = "";
                        txtEmail.Text = "";
                         */
                    }
                    cnx2.Close();
                }
            }
            cnx.Close();
        }
    }
}