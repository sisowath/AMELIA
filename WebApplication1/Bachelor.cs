using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Bachelor
    {
            // attribut(s)
        private int id;
        private String username;
        private String password;
        private String email;
        private int numberOfLikes;
        private String image;
        private int idBookGenres;
        private int idBrands;
        private int idHobbies;
        private int idMovieGenres;
        private int idMusicGenres;
        private int idSports;        
        //private String nom;
        //private String prenom;
        //private int age;
        /* Il y a sûrement beaucoup plus d'aatributs, mais je vais rester sur l'essentiel - Samnang */
            // methode(s)
        // constructeur(s)
        public Bachelor(int id, String username, String password, String email, 
                        int numberOfLikes, String image, int idBookGenres, int idBrands, 
                        int idHobbies, int idMovieGenres, int idMusicGenres, int idSports)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
            this.numberOfLikes = numberOfLikes;
            this.image = image;
            this.idBookGenres = idBookGenres;
            this.idBrands = idBrands;
            this.idHobbies = idHobbies;
            this.idMovieGenres = idMovieGenres;
            this.idMusicGenres = idMusicGenres;
            this.idSports = idSports;
        }
        public Bachelor() : this (1, "no username", "no password", "no email", 0, "noimage", 0, 0, 0, 0, 0, 0) {}
        // proprietes en lecture et en ecriture
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public int NumberOfLikes
        {
            get { return numberOfLikes; }
            set { numberOfLikes = value; }
        }
        public String Image
        {
            get { return image; }
            set { image = value; }
        }
        public int IdBookGenres
        {
            get { return idBookGenres; }
            set { idBookGenres = value; }
        }
        public int IdBrands
        {
            get { return idBrands; }
            set { idBrands = value; }
        }
        public int IdHobbies
        {
            get { return idHobbies; }
            set { idHobbies = value; }
        }
        public int IdMovieGenres
        {
            get { return idMovieGenres; }
            set { idMovieGenres = value; }
        }
        public int IdMusicGenres
        {
            get { return idMusicGenres; }
            set { idMusicGenres = value; }
        }
        public int IdSports
        {
            get { return idSports; }
            set { idSports = value; }
        }
        // autre(s)
        public override string ToString()
        {
            return id + " :: " + username + " :: " + email + " :: " + numberOfLikes; 
        }
    }
}