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
    public partial class WebForm5 : System.Web.UI.Page
    {
        private List<Bachelor> uneListeDeBacheliers = new List<Bachelor>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isConnected"] == null) Response.Redirect("login.aspx");    

            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
// trouver les utilisateurs ayant 6 intérêts en commun
            cmd.CommandText = 
                "SELECT * " +
                "FROM bachelor " +
                "WHERE idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = @id) AND " +
                    "idbrands = (SELECT idbrands FROM bachelor WHERE id = @id) AND " +
                    "idhobbies = (SELECT idhobbies FROM bachelor WHERE id = @id) AND " +
                    "idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = @id) AND " +
                    "idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = @id) AND " +
                    "idsports = (SELECT idsports FROM bachelor WHERE id = @id) AND " +
                    "id != @id " +
                "ORDER BY numberOfLikes DESC";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", ((Bachelor)Session["profile"]).Id);
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
                }
                LiteralControl chaineHtml = new LiteralControl();
                chaineHtml.Text = "<table border=\"1px solid black\" class=\"table table-bordered table-striped\">";
                chaineHtml.Text += "<tr><th>Username</th><th>NumberOfLikes</th><th>Pourcentage (%)</th></tr>";
                for (int i = 0; i < uneListeDeBacheliers.Count; i++)
                {
                    chaineHtml.Text += "<tr>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].Username + "</td>";                    
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].NumberOfLikes + "</td>";
                    chaineHtml.Text += "<td>" + "100%" + "</td>";
                    chaineHtml.Text += "<td><a href=\"profileView.aspx?username="+uneListeDeBacheliers[i].Username+"\">Voir profile</a></td>";
                    chaineHtml.Text += "</tr>";
                }
                suggestionList.Controls.Add(chaineHtml);
            }
// trouver les utilisateurs ayant 5 intérêts en commun
            cmd.CommandText =
                "SELECT * " +
                "FROM bachelor " +
                "WHERE (idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = @id) OR " +
                    "idbrands = (SELECT idbrands FROM bachelor WHERE id = @id)) AND " +
                    "idhobbies = (SELECT idhobbies FROM bachelor WHERE id = @id) AND " +
                    "idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = @id) AND " +
                    "idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = @id) AND " +
                    "idsports = (SELECT idsports FROM bachelor WHERE id = @id) AND " +
                    "id != @id AND id NOT IN (" +

                    "SELECT id " +
                    "FROM bachelor " +
                    "WHERE idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = @id) AND " +
                        "idbrands = (SELECT idbrands FROM bachelor WHERE id = @id) AND " +
                        "idhobbies = (SELECT idhobbies FROM bachelor WHERE id = @id) AND " +
                        "idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = @id) AND " +
                        "idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = @id) AND " +
                        "idsports = (SELECT idsports FROM bachelor WHERE id = @id) AND " +
                        "id != @id )" +

                "ORDER BY numberOfLikes DESC";
            cmd.Prepare();
            //cmd.Parameters.AddWithValue("@id", ((Bachelor)Session["profile"]).Id); Pas besoin de le « redire »
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
                }
                LiteralControl chaineHtml = new LiteralControl();
                chaineHtml.Text += "<tr><hr /></tr>";
                for (int i = 0; i < uneListeDeBacheliers.Count; i++)
                {
                    chaineHtml.Text += "<tr>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].Username + "</td>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].NumberOfLikes + "</td>";
                    chaineHtml.Text += "<td>" + "84%" + "</td>";
                    chaineHtml.Text += "<td><a href=\"profileView.aspx?username=" + uneListeDeBacheliers[i].Username + "\">Voir profile</a></td>";
                    chaineHtml.Text += "</tr>";
                }
                suggestionList.Controls.Add(chaineHtml);
            }
// trouver les utilisateurs ayant 4 intérêts en commun
            cmd.CommandText =
                "SELECT * " +
                "FROM bachelor " +
                "WHERE (idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = @id) OR " +
                    "idbrands = (SELECT idbrands FROM bachelor WHERE id = @id) OR " +
                    "idhobbies = (SELECT idhobbies FROM bachelor WHERE id = @id)) AND " +
                    "idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = @id) AND " +
                    "idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = @id) AND " +
                    "idsports = (SELECT idsports FROM bachelor WHERE id = @id) AND " +
                    "id != @id " +
                "ORDER BY numberOfLikes DESC";
            cmd.Prepare();
            //cmd.Parameters.AddWithValue("@id", ((Bachelor)Session["profile"]).Id); Pas besoin de le « redire »
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
                }
                LiteralControl chaineHtml = new LiteralControl();
                chaineHtml.Text += "<tr><hr /></tr>"; 
                for (int i = 0; i < uneListeDeBacheliers.Count; i++)
                {
                    chaineHtml.Text += "<tr>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].Username + "</td>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].NumberOfLikes + "</td>";
                    chaineHtml.Text += "<td>" + "67%" + "</td>";
                    chaineHtml.Text += "<td><a href=\"profileView.aspx?username=" + uneListeDeBacheliers[i].Username + "\">Voir profile</a></td>";
                    chaineHtml.Text += "</tr>";
                }
                suggestionList.Controls.Add(chaineHtml);
            }
// trouver tous les utilisateurs qui possèdent exactement 3 intérêts en commun
            cmd.CommandText =
                "SELECT * " +
                "FROM bachelor " +
                "WHERE (idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = @id) OR " +
                    "idbrands = (SELECT idbrands FROM bachelor WHERE id = @id) OR " +
                    "idhobbies = (SELECT idhobbies FROM bachelor WHERE id = @id) OR " +
                    "idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = @id)) AND " +
                    "idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = @id) AND " +
                    "idsports = (SELECT idsports FROM bachelor WHERE id = @id) AND " +
                    "id != @id " +
                "ORDER BY numberOfLikes DESC";
            cmd.Prepare();
            //cmd.Parameters.AddWithValue("@id", ((Bachelor)Session["profile"]).Id); Pas besoin de le « redire »
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
                }
                LiteralControl chaineHtml = new LiteralControl();
                chaineHtml.Text += "<tr><hr /></tr>";
                for (int i = 0; i < uneListeDeBacheliers.Count; i++)
                {
                    chaineHtml.Text += "<tr>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].Username + "</td>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].NumberOfLikes + "</td>";
                    chaineHtml.Text += "<td>" + "50%" + "</td>";
                    chaineHtml.Text += "<td><a href=\"profileView.aspx?username=" + uneListeDeBacheliers[i].Username + "\">Voir profile</a></td>";
                    chaineHtml.Text += "</tr>";
                }
                suggestionList.Controls.Add(chaineHtml);
            }
// trouver tous les utilisateurs qui possèdent exactement 2 intérêts en commun
            cmd.CommandText =
                "SELECT * " +
                "FROM bachelor " +
                "WHERE (idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = @id) OR " +
                    "idbrands = (SELECT idbrands FROM bachelor WHERE id = @id) OR " +
                    "idhobbies = (SELECT idhobbies FROM bachelor WHERE id = @id) OR " +
                    "idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = @id) OR " +
                    "idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = @id)) AND " +
                    "idsports = (SELECT idsports FROM bachelor WHERE id = @id) AND " +
                    "id != @id " +
                "ORDER BY numberOfLikes DESC";
            cmd.Prepare();
            //cmd.Parameters.AddWithValue("@id", ((Bachelor)Session["profile"]).Id); Pas besoin de le « redire »
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
                }
                LiteralControl chaineHtml = new LiteralControl();
                chaineHtml.Text += "<tr><hr /></tr>";
                for (int i = 0; i < uneListeDeBacheliers.Count; i++)
                {
                    chaineHtml.Text += "<tr>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].Username + "</td>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].NumberOfLikes + "</td>";
                    chaineHtml.Text += "<td>" + "34%" + "</td>";
                    chaineHtml.Text += "<td><a href=\"profileView.aspx?username=" + uneListeDeBacheliers[i].Username + "\">Voir profile</a></td>";
                    chaineHtml.Text += "</tr>";
                }
                suggestionList.Controls.Add(chaineHtml);
            }
// trouver tous les utilisateurs qui possèdent exactement 1 intérêts en commun
            cmd.CommandText =
                "SELECT * " +
                "FROM bachelor " +
                "WHERE (idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = @id) OR " +
                    "idbrands = (SELECT idbrands FROM bachelor WHERE id = @id) OR " +
                    "idhobbies = (SELECT idhobbies FROM bachelor WHERE id = @id) OR " +
                    "idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = @id) OR " +
                    "idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = @id) OR " +
                    "idsports = (SELECT idsports FROM bachelor WHERE id = @id)) AND " +
                    "id != @id " +
                "ORDER BY numberOfLikes DESC";
            cmd.Prepare();
            //cmd.Parameters.AddWithValue("@id", ((Bachelor)Session["profile"]).Id); Pas besoin de le « redire »
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
                }
                LiteralControl chaineHtml = new LiteralControl();
                chaineHtml.Text += "<tr><hr /></tr>";
                for (int i = 0; i < uneListeDeBacheliers.Count; i++)
                {
                    chaineHtml.Text += "<tr>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].Username + "</td>";
                    chaineHtml.Text += "<td>" + uneListeDeBacheliers[i].NumberOfLikes + "</td>";
                    chaineHtml.Text += "<td>" + "17%" + "</td>";
                    chaineHtml.Text += "<td><a href=\"profileView.aspx?username=" + uneListeDeBacheliers[i].Username + "\">Voir profile</a></td>";
                    chaineHtml.Text += "</tr>";
                }
                chaineHtml.Text += "</table>";
                suggestionList.Controls.Add(chaineHtml);
            }
// Fermeture de la connexion
            cnx.Close();
            /*
            LiteralControl chaineHtml = new LiteralControl();
            chaineHtml.Text = "<table border=\"1px solid black\">";
            chaineHtml.Text += "<tr><th>Nom d'utilisateur</td><th>Pourcentage</th></tr>";
            for (int i = 0; i < 50; i++)
            {
                chaineHtml.Text += "<tr>";
                chaineHtml.Text += "<td>" + i + "</td>";
                chaineHtml.Text += "<td>" + i*i + "</td>";
                chaineHtml.Text += "</tr>";
            }
            chaineHtml.Text += "</table";
            suggestionList.Controls.Add(chaineHtml);
            */
        }
    }
}