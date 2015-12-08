using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common; // IMPORTANT pour utiliser DbProviderFactory
using MySql.Data.MySqlClient; // IMPORTANT pour utiliser MySQL avec PhpMyAdmin
using System.Data;
using System.IO; // IMPORTANT pour utiliser CommandType

namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private List<Interest> uneListeDeChampInterets = new List<Interest>();
        private Bachelor unBachelor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isConnected"] == null) Response.Redirect("login.aspx");

            /*
            if (IsPostBack)
            {
                int idMusicGenres = 0;
                if (Request.Form["musicGenres"] != null)
                {                    
                    int.TryParse(Request.Form["musicGenres"].ToString(), out idMusicGenres);
                }
                int idBookGenres;
                if (Request.Form["bookGenres"] != null)
                {                    
                    int.TryParse(Request.Form["bookGenres"].ToString(), out idBookGenres);
                }
                int idMovieGenres;
                int.TryParse(Request.Form["movieGenres"].ToString(), out idMovieGenres);
                int idBrands;
                int.TryParse(Request.Form["brands"].ToString(), out idBrands);
                int idHobbies;
                int.TryParse(Request.Form["hobbies"].ToString(), out idHobbies);
                int idSports;
                int.TryParse(Request.Form["Sports"].ToString(), out idSports);
                MySqlConnection cnx0 = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen");
                cnx0.Open();
                MySqlCommand cmd0 = cnx0.CreateCommand();
                cmd0.CommandType = CommandType.Text;
                cmd0.CommandText = "UPDATE bachelor SET idmusicgenres=@idMusicGenres WHERE id=@idUser";
                cmd0.Parameters.AddWithValue("@idMusicGenres", idMusicGenres);
                cmd0.Parameters.AddWithValue("@idUser", ((Bachelor)Session["profile"]).Id);
                int nombreLignesAffectees = cmd0.ExecuteNonQuery();
                if (nombreLignesAffectees > 0)
                    bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-success\"><strong>BRAVO !</strong> Vos intérêts ont été modifiés.</div>"));
                else
                    bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-danger\"><strong>ERREUR !</strong> Vos intérêts n'ont pas pu être modifiés...</div>"));
                cnx0.Close();
            }
            */

            if (Session["profile"] != null)
            {
                unBachelor = (Bachelor)Session["profile"];
                txtId.Text = unBachelor.Id.ToString();
                txtUsername.Text = unBachelor.Username;
                txtPassword.Text = unBachelor.Password;
                txtEmail.Text = unBachelor.Email;
                txtNumberOfLikes.Text = unBachelor.NumberOfLikes.ToString();
                pbxImage.ImageUrl = unBachelor.Image;
                pbxImage.Height = 300;
                pbxImage.Width = 530;
            }
            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            // Chercher les champs d'intérêt de l'utilisateur
            cmd.CommandText = "SELECT * FROM bachelor WHERE id = @idBachelor";
            cmd.Parameters.AddWithValue("@idBachelor", unBachelor.Id);
            Bachelor temp = new Bachelor();
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if (dbrdr.Read())
                {
                    int id;
                    int.TryParse(dbrdr["idbookgenres"].ToString(), out id);
                    temp.IdBookGenres = id;
                    int.TryParse(dbrdr["idbrands"].ToString(), out id);
                    temp.IdBrands = id;
                    int.TryParse(dbrdr["idhobbies"].ToString(), out id);
                    temp.IdHobbies = id;
                    int.TryParse(dbrdr["idmoviegenres"].ToString(), out id);
                    temp.IdMovieGenres = id;
                    int.TryParse(dbrdr["idmusicgenres"].ToString(), out id);
                    temp.IdMusicGenres = id;
                    int.TryParse(dbrdr["idsports"].ToString(), out id);
                    temp.IdSports = id;
                }
            }
            // bookgenres
            cmd.CommandText = "SELECT * FROM bookgenres ORDER BY id";
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                while (dbrdr.Read())
                {
                    int id;
                    int.TryParse(dbrdr["id"].ToString(), out id);
                    String nom = dbrdr["nom"].ToString();

                    uneListeDeChampInterets.Add(new Interest(id, nom));
                }
                if (ddlBooks.Items.Count <= 1)
                {
                    for (int i = 0; i < uneListeDeChampInterets.Count; i++)
                    {
                        if (uneListeDeChampInterets[i].Id.Equals(temp.IdBookGenres))
                        {
                            ddlBooks.Items.Add(uneListeDeChampInterets[i].Nom);
                            ddlBooks.SelectedIndex = ddlBooks.Items.IndexOf(ddlBooks.Items.FindByText(uneListeDeChampInterets[i].Nom));
                        }
                        else
                            ddlBooks.Items.Add(uneListeDeChampInterets[i].Nom);
                    }
                }
            }
            // brands
            uneListeDeChampInterets = new List<Interest>();
            cmd.CommandText = "SELECT * FROM brands ORDER BY id";
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                while (dbrdr.Read())
                {
                    int id;
                    int.TryParse(dbrdr["id"].ToString(), out id);
                    String nom = dbrdr["nom"].ToString();

                    uneListeDeChampInterets.Add(new Interest(id, nom));
                }
                if (ddlBrands.Items.Count <= 1)
                {
                    for (int i = 0; i < uneListeDeChampInterets.Count; i++)
                    {
                        if (uneListeDeChampInterets[i].Id.Equals(temp.IdBrands))
                        {
                            ddlBrands.Items.Add(uneListeDeChampInterets[i].Nom);
                            ddlBrands.SelectedIndex = ddlBrands.Items.IndexOf(ddlBrands.Items.FindByText(uneListeDeChampInterets[i].Nom));
                        }
                        else
                            ddlBrands.Items.Add(uneListeDeChampInterets[i].Nom);
                    }
                }
            }
            // hobbies
            uneListeDeChampInterets = new List<Interest>();
            cmd.CommandText = "SELECT * FROM hobbies ORDER BY id";
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                while (dbrdr.Read())
                {
                    int id;
                    int.TryParse(dbrdr["id"].ToString(), out id);
                    String nom = dbrdr["nom"].ToString();

                    uneListeDeChampInterets.Add(new Interest(id, nom));
                }
                if (ddlHobbies.Items.Count <= 1)
                {
                    for (int i = 0; i < uneListeDeChampInterets.Count; i++)
                    {
                        if (uneListeDeChampInterets[i].Id.Equals(temp.IdHobbies))
                        {
                            ddlHobbies.Items.Add(uneListeDeChampInterets[i].Nom);
                            ddlHobbies.SelectedIndex = ddlHobbies.Items.IndexOf(ddlHobbies.Items.FindByText(uneListeDeChampInterets[i].Nom));
                        }
                        else
                            ddlHobbies.Items.Add(uneListeDeChampInterets[i].Nom);
                    }
                }
            }
            // musicGenres
            uneListeDeChampInterets = new List<Interest>();
            cmd.CommandText = "SELECT * FROM musicgenres ORDER BY id";
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                while (dbrdr.Read())
                {
                    int id;
                    int.TryParse(dbrdr["id"].ToString(), out id);
                    String nom = dbrdr["nom"].ToString();

                    uneListeDeChampInterets.Add(new Interest(id, nom));
                }
                //LiteralControl chaineHtml = new LiteralControl();
                //chaineHtml.Text = "<select id=\"musicGenres\" width=\"100%\" class=\"form-control\">";
                if (ddlMusic.Items.Count <= 1)
                {
                    for (int i = 0; i < uneListeDeChampInterets.Count; i++)
                    {
                        if (uneListeDeChampInterets[i].Id.Equals(temp.IdMusicGenres))
                        {
                            //chaineHtml.Text += "<option value=\"" + uneListeDeChampInterets[i].Id + "\" selected=\"selected\">" + uneListeDeChampInterets[i].Nom + "</option>";
                            ddlMusic.Items.Add(uneListeDeChampInterets[i].Nom);
                            ddlMusic.SelectedIndex = ddlMusic.Items.IndexOf(ddlMusic.Items.FindByText(uneListeDeChampInterets[i].Nom));// source de: http://stackoverflow.com/questions/3496456/setting-dropdownlist-selecteditem-programmatically
                        }
                        else
                            //chaineHtml.Text += "<option value=\"" + uneListeDeChampInterets[i].Id + "\">" + uneListeDeChampInterets[i].Nom + "</option>";                    
                            ddlMusic.Items.Add(uneListeDeChampInterets[i].Nom);
                    }
                }
                //chaineHtml.Text += "</select>";
                //musicGenres.Controls.Add(chaineHtml);
            }
            // sports
            uneListeDeChampInterets = new List<Interest>();
            cmd.CommandText = "SELECT * FROM sports ORDER BY id";
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                while (dbrdr.Read())
                {
                    int id;
                    int.TryParse(dbrdr["id"].ToString(), out id);
                    String nom = dbrdr["nom"].ToString();

                    uneListeDeChampInterets.Add(new Interest(id, nom));
                }
                if (ddlSports.Items.Count <= 1)
                {
                    for (int i = 0; i < uneListeDeChampInterets.Count; i++)
                    {
                        if (uneListeDeChampInterets[i].Id.Equals(temp.IdSports))
                        {
                            ddlSports.Items.Add(uneListeDeChampInterets[i].Nom);
                            ddlSports.SelectedIndex = ddlSports.Items.IndexOf(ddlSports.Items.FindByText(uneListeDeChampInterets[i].Nom));
                        }
                        else
                            ddlSports.Items.Add(uneListeDeChampInterets[i].Nom);
                    }
                }
            }
            // movieGenres
            uneListeDeChampInterets = new List<Interest>();
            cmd.CommandText = "SELECT * FROM moviegenres ORDER BY id";
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                while (dbrdr.Read())
                {
                    int id;
                    int.TryParse(dbrdr["id"].ToString(), out id);
                    String nom = dbrdr["nom"].ToString();

                    uneListeDeChampInterets.Add(new Interest(id, nom));
                }
                if (ddlMovies.Items.Count <= 1)
                {
                    for (int i = 0; i < uneListeDeChampInterets.Count; i++)
                    {
                        if (uneListeDeChampInterets[i].Id.Equals(temp.IdMovieGenres))
                        {
                            ddlMovies.Items.Add(uneListeDeChampInterets[i].Nom);
                            ddlMovies.SelectedIndex = ddlMovies.Items.IndexOf(ddlMovies.Items.FindByText(uneListeDeChampInterets[i].Nom));
                        }
                        else
                            ddlMovies.Items.Add(uneListeDeChampInterets[i].Nom);
                    }
                }
            }
            cnx.Close();
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
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
                string p = HttpContext.Current.Server.MapPath("~"); p += "\\images";
                p = ReplaceLastOccurrence(p, "\\", "");
                lblMessage.Text = "<h3 style=\"color:blue\">Likes Updated !!</h3>" + p;
            }
            cnx.Close();
        }

        protected void btnMAJ_Click(object sender, EventArgs e)
        {
            String selectedUsername = txtUsername.Text;
            String password = txtPassword.Text;
            String email = txtEmail.Text;
            using(MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen"))
            {
                using(MySqlCommand cmd = new MySqlCommand("UPDATE bachelor SET username = @Username  WHERE id = @idUser"))
                {
                    using(MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        /*
                        cmd.Parameters.AddWithValue("@username", username);                        
                        cmd.Parameters.AddWithValue("@password", password);                        
                        cmd.Parameters.AddWithValue("@email", email);
                        */
                        cmd.Parameters.AddWithValue("@Username", new LiteralControl(selectedUsername) );
                        cmd.Parameters.AddWithValue("@idUser", ((Bachelor)Session["profile"]).Id);                        
                        cmd.Connection = con;
                        con.Open();
                        int nombreDeLignesAffectees = cmd.ExecuteNonQuery();
                        if (nombreDeLignesAffectees > 0)
                        {
                            bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-success\"><strong>BRAVO !</strong> Vos informations ont été modifiées.</div>"));
                            Bachelor temp = (Bachelor)Session["profile"];
                            temp.Username = txtUsername.Text;
                            temp.Password = txtPassword.Text;
                            temp.Email = txtEmail.Text;
                            Session["profile"] = temp;
                        }
                        else
                            bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-danger\"><strong>ERREUR !</strong> Vos informations n'ont pas pu être modifiées...</div>"));
                        con.Close();            
                    }
                }
            }
            /*//int x = 0;
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if (dbrdr.Read())
                {
                }
                //Page_Load(object sender, EventArgs e);
                lblMessage.Text = "<h3 style=\"color:green\">Profile Updated !!</h3>"+cmd.CommandText;
                this.Load += this.Page_Load;
            }*/
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    string p = HttpContext.Current.Server.MapPath("~"); p += "\\images";
                    p = ReplaceLastOccurrence(p, "\\", "");
                    p += @"\";
                    FileUploadControl.SaveAs(p + filename);

                    StatusLabel.Text = "Upload status: File uploaded! " + p;
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }

            /*if (FileUploadControl.HasFile)
            {
                try
                {

                    //if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                    //{
                        if (FileUploadControl.PostedFile.ContentLength < 102400)
                        {
                            string p = HttpContext.Current.Server.MapPath("~"); p += "\\images";
                            p = ReplaceLastOccurrence(p, "\\", "");
                            string filename =  p;
                                //Path.GetFileName(FileUploadControl.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                            StatusLabel.Text = "Upload status: File uploaded!";
                            lblMessage.Text = "<h3 style=\"color:green\">Profile Updated !!</h3>" + filename;
                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                    //}
                    //else
                        //StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }*/

        }
        public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return string.Empty;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }

        protected void btnMAJinterests_Click(object sender, EventArgs e)
        {
            int selectedMusic = ddlMusic.SelectedIndex + 1;
            int selectedBook = ddlBooks.SelectedIndex + 1;
            int selectedBrand = ddlBrands.SelectedIndex + 1;
            int selectedHobbie = ddlHobbies.SelectedIndex + 1;
            int selectedMovie = ddlMovies.SelectedIndex + 1;
            int selectedSport = ddlSports.SelectedIndex + 1;
            using (MySqlConnection con = new MySqlConnection(("server=localhost;user=root;password=root;database=katnisseverdeen")))
            {                 
                using (MySqlCommand cmd = new MySqlCommand("UPDATE bachelor SET idmusicgenres = @selectedMusic, idbrands = @selectedBrand, idhobbies = @selectedHobbie, idmoviegenres = @selectedMovie, idbookgenres = @selectedBook, idsports = @selectedSport WHERE id = @idUser"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        /*
                        cmd.Parameters.AddWithValue("@idMusicGenres", selectedMusic);                        
                        */
                        cmd.Parameters.AddWithValue("@selectedMusic", selectedMusic);
                        cmd.Parameters.AddWithValue("@selectedBrand", selectedBrand);
                        cmd.Parameters.AddWithValue("@selectedHobbie", selectedHobbie);
                        cmd.Parameters.AddWithValue("@selectedMovie", selectedMovie);
                        cmd.Parameters.AddWithValue("@selectedBook", selectedBook);
                        cmd.Parameters.AddWithValue("@selectedSport", selectedSport);
                        cmd.Parameters.AddWithValue("@idUser", ((Bachelor)Session["profile"]).Id);
                        cmd.Connection = con;
                        con.Open();
                        int nombreLignesAffectees = cmd.ExecuteNonQuery();
                        con.Close();
                        if (nombreLignesAffectees > 0)
                            bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-success\"><strong>BRAVO !</strong> Vos intérêts ont été modifiés.</div>"));
                        else
                            bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-danger\"><strong>ERREUR !</strong> Vos intérêts n'ont pas pu être modifiés...</div>"));
                    }
                }

                /*
                int selectedBook = ddlBooks.SelectedIndex + 1;
                int selectedMovie = ddlMovies.SelectedIndex + 1;
                int selectedBrand = ddlBrands.SelectedIndex + 1;
                int selectedHobbie = ddlHobbies.SelectedIndex + 1;
                int selectedMusic = ddlMusic.SelectedIndex + 1;
                int selectedSport = ddlSports.SelectedIndex + 1;                       
                cmd0.CommandText = "UPDATE bachelor SET idbookgenres=@idBookGenres, idbrands=@idBrands, idhobbies=@idHobbies, idmoviegenres=@idMovieGenres, idmusicgenres=@idMusicGenres, idsports=@idSports WHERE id=@idUser";            
                cmd0.Parameters.AddWithValue("@idBrands", selectedBrand);
                cmd0.Parameters.AddWithValue("@idHobbies", selectedHobbie);
                cmd0.Parameters.AddWithValue("@idMovieGenres", selectedMovie);
                cmd0.Parameters.AddWithValue("@idMusicGenres", selectedMusic);
                cmd0.Parameters.AddWithValue("@idSports", selectedSport);            
                */
            }
        }
    }
}