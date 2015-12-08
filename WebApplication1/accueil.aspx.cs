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
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<Bachelor> uneListeDeBacheliers = new List<Bachelor>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isConnected"] == null) Response.Redirect("login.aspx");                
            if(Session["profile"] != null) {
                Bachelor unBachelor = (Bachelor)Session["profile"];
                lblMessageDeBienvenue.Text = "<h1>Bonjour " + unBachelor.Username + ", bienvenue sur Amélia</h1>";
            }
            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM bachelor ORDER BY numberOfLikes DESC LIMIT 10";
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                while (dbrdr.Read())
                {
                    int id;
                    int.TryParse(dbrdr["id"].ToString(), out id);
                    String username = dbrdr["username"].ToString();
                    String password = dbrdr["password"].ToString();
                    String email = dbrdr["email"].ToString();
                    int numberOfLikes;
                    int.TryParse(dbrdr["numberOfLikes"].ToString(), out numberOfLikes);
                    String imagePath = dbrdr["image"].ToString();
                    int idBookGenres;
                    int.TryParse(dbrdr["idbookgenres"].ToString(), out idBookGenres);
                    int idBrands;
                    int.TryParse(dbrdr["idbrands"].ToString(), out idBrands);
                    int idHobbies;
                    int.TryParse(dbrdr["idHobbies"].ToString(), out idHobbies);
                    int idMovieGenres;
                    int.TryParse(dbrdr["idmoviegenres"].ToString(), out idMovieGenres);
                    int idMusicGenres;
                    int.TryParse(dbrdr["idmusicgenres"].ToString(), out idMusicGenres);
                    int idSports;
                    int.TryParse(dbrdr["idsports"].ToString(), out idSports);

                    uneListeDeBacheliers.Add(new Bachelor(id, username, password, email, numberOfLikes, imagePath, idBookGenres, idBrands, idHobbies, idMovieGenres, idMusicGenres, idSports));
                    //lblMessage.Text += id + username + password + email + numberOfLikes;
                }
                LiteralControl chaineHtml = new LiteralControl();
                chaineHtml.Text = "<table border=\"1px solid black\" style=\"float:left;padding:10px\">";
                chaineHtml.Text += "<tr><th>Rang</th><th>username</th><th>Likes</th></tr>";
                for (int i = 0; i < uneListeDeBacheliers.Count; i++)
                {
                    chaineHtml.Text += "<tr>";
                    chaineHtml.Text += "<td>" + (i+1) + "</td>";
                    //chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].Id + "</td>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].Username + "</td>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].NumberOfLikes + "</td>";
                    chaineHtml.Text += "</tr>";
                }
                chaineHtml.Text += "</table>";
                leaderboard.Controls.Add(chaineHtml);
            }
            cnx.Close();           
        }
    }
}