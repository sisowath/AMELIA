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
    public partial class WebForm7 : System.Web.UI.Page
    {
        private Bachelor unBachelor = new Bachelor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isConnected"] == null) Response.Redirect("login.aspx");
            if (Request.QueryString["username"] == null) Response.Redirect("match.aspx");

            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM bachelor WHERE username = @username";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@username", Request.QueryString["username"].ToString().Trim());
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

                    unBachelor.Id = id;
                    unBachelor.Username = username;
                    unBachelor.Password = password;
                    unBachelor.Email = email;
                    unBachelor.NumberOfLikes = numberOfLikes;
                    unBachelor.Image = imagePath;
                    unBachelor.IdBookGenres = idBookGenres;
                    unBachelor.IdBrands = idBrands;
                    unBachelor.IdHobbies = idHobbies;
                    unBachelor.IdMovieGenres = idMovieGenres;
                    unBachelor.IdMusicGenres = idMusicGenres;
                    unBachelor.IdSports = idSports;
                }
            }
            txtId.Text = unBachelor.Id.ToString();
            txtUsername.Text = unBachelor.Username;
            txtPassword.Text = unBachelor.Password;
            txtEmail.Text = unBachelor.Email;
            txtNumberOfLikes.Text = unBachelor.NumberOfLikes.ToString();
            pbxImage.ImageUrl = unBachelor.Image;
            pbxImage.Height = 300;
            pbxImage.Width = 530;
// bookGenres
            cmd.CommandText = "SELECT nom FROM bookgenres WHERE id = @idBookGenres";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@idBookGenres", unBachelor.IdBookGenres); 
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if(dbrdr.Read())
                {
                }
                lblBookGenres.Text = dbrdr["nom"].ToString();
            }
// brands
            cmd.CommandText = "SELECT nom FROM brands WHERE id = @idBrands";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@idBrands", unBachelor.IdBrands);
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if(dbrdr.Read())
                {
                }
                lblBrand.Text = dbrdr["nom"].ToString();
            }
// hobbies
            cmd.CommandText = "SELECT nom FROM hobbies WHERE id = @idHobbies";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@idHobbies", unBachelor.IdHobbies);
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if(dbrdr.Read())
                {
                }
                lblHobbies.Text = dbrdr["nom"].ToString();
            }
// musicGenres
            cmd.CommandText = "SELECT nom FROM musicgenres WHERE id = @idMusicGenres";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@idMusicGenres", unBachelor.IdMusicGenres);
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if(dbrdr.Read())
                {
                }
                lblMusicGenres.Text = dbrdr["nom"].ToString();
            }
// sports
            cmd.CommandText = "SELECT * FROM sports WHERE id = @idSports";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@idSports", unBachelor.IdSports);
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if(dbrdr.Read())
                {
                }
                lblSports.Text = dbrdr["nom"].ToString();
            }
// movieGenres
            cmd.CommandText = "SELECT * FROM moviegenres WHERE id = @idMovieGenres";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@idMovieGenres", unBachelor.IdMovieGenres);
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if(dbrdr.Read())
                {
                }
                lblMovieGenres.Text = dbrdr["nom"].ToString();
            }
            cnx.Close();
        }
        protected void btnLike_Click(object sender, EventArgs e)
        {
            int numberOfLikes;
            int.TryParse(txtNumberOfLikes.Text, out numberOfLikes);
            numberOfLikes++;
            using (MySqlConnection con = new MySqlConnection(("server=localhost;user=root;password=root;database=katnisseverdeen")))
            {
                using (MySqlCommand cmd = new MySqlCommand("UPDATE bachelor SET numberOfLikes = @numberOfLikes WHERE id = @idUser"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@numberOfLikes", numberOfLikes);
                        cmd.Parameters.AddWithValue("@idUser", txtId.Text);
                        cmd.Connection = con;
                        con.Open();
                        int nombreLignesAffectees = cmd.ExecuteNonQuery();
                        con.Close();
                        if (nombreLignesAffectees > 0)
                            bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-success\"><strong>BRAVO !</strong> Merci pour votre vote !</div>"));
                        else
                            bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-danger\"><strong>ERREUR !</strong> Votre vote a été refusé...</div>"));
                    }
                }
            }
            /*
            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT numberOfLikes FROM bachelor WHERE id = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", unBachelor.Id);
            int x = 0;
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if (dbrdr.Read())
                {
                    int.TryParse(dbrdr["numberOfLikes"].ToString(), out x);
                }
            }
            cmd.CommandText = "UPDATE bachelor SET numberOfLikes = @numberOfLikes WHERE id = @id";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@numberOfLikes", (x++));
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if (dbrdr.Read())
                {
                }
                unBachelor.NumberOfLikes = x++;
                txtNumberOfLikes.Text = unBachelor.NumberOfLikes.ToString();
                Session["profile"] = unBachelor;
                lblMessage.Text = "<h3 style=\"color:blue\">Likes Updated !!</h3>";
            }
            cnx.Close();
             */ 
        }
    }
}