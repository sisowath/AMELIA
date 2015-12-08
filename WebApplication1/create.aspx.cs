using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common; // IMPORTANT pour utiliser DbProviderFactory
using MySql.Data.MySqlClient; // IMPORTANT pour utiliser MySQL avec PhpMyAdmin
using System.Data;
using System.IO; 

namespace WebApplication1
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            MySqlConnection cnx = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen");
            cnx.Open();
            MySqlCommand cmd = cnx.CreateCommand();
            
            // Vérification si le nom d'utilisateur est déjà utilisé dans la base de données 
            cmd.CommandText = "SELECT * FROM bachelor WHERE username = @username";
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            using (DbDataReader dbrdr = cmd.ExecuteReader())
            {
                if (dbrdr.Read())
                {
                    bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-danger\"><strong>ERREUR !</strong>Désolé, il existe déjà un utilisateur { " + txtUsername.Text + " }</div>"));
                }
                else
                {
                    cnx.Close();// fermeture de ExecuteReader()
                    
                    // ouverture pour ExecuteNonQuery()
                    MySqlConnection cnx2 = new MySqlConnection("server=localhost;user=root;password=root;database=katnisseverdeen");
                    cnx2.Open();
                    MySqlCommand cmd2 = cnx2.CreateCommand();

                    String img = "";
                    if (FileUploadControl.HasFile)
                    {
                        try
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            string p = HttpContext.Current.Server.MapPath("~"); p += "\\images";
                            p = ReplaceLastOccurrence(p, "\\", "");
                            p += @"\";
                            FileUploadControl.SaveAs(p + filename);
                            //img = p + filename;
                            img = "~/images/" + filename;
                            StatusLabel.Text = "Upload status: File uploaded!";
                        }
                        catch (Exception ex)
                        {
                            StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                        }
                    }

                    //works
                    //cmd.CommandText = "INSERT INTO bachelor (username, password, email) VALUES ('test','test','test');";
                    //cmd.CommandText = "INSERT INTO bachelor (username, password, email,image) VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtEmail.Text + "','"+img+");";
                    //cmd.CommandText = "INSERT INTO bachelor (username, password, email,image) VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtEmail.Text + "','" + img + "');";
                    cmd2.CommandText = "INSERT INTO bachelor (username, password, email,image) VALUES (@u,@pass,@e,@img);";
                    cmd2.Parameters.AddWithValue("@u", txtUsername.Text);
                    cmd2.Parameters.AddWithValue("@pass", txtPassword.Text);
                    cmd2.Parameters.AddWithValue("@e", txtEmail.Text);
                    cmd2.Parameters.AddWithValue("@img", img);
                    int nombreDeLignesAffectees = cmd2.ExecuteNonQuery();
                    if (nombreDeLignesAffectees > 0)
                    {
                        bootstrapMessage.Controls.Add(new LiteralControl("<div class=\"alert alert-success\"><strong>BRAVO !</strong>Votre compte a été créé avec succès. Vous pouvez maintenant vous connecter.</div>"));
                        // source de : http://www.beansoftware.com/ASP.NET-Tutorials/Using-PlaceHolder-Control.aspx 
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtPasswordC.Text = "";
                        txtEmail.Text = "";
                    }
                    cnx2.Close();
                }
            }
            cnx.Close();
            //cmd.Prepare();
            //cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            //using (DbDataReader dbrdr = cmd.ExecuteReader()) ;            
        }
        public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return string.Empty;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }
    }
}