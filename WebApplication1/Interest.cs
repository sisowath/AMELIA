using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Interest
    {
            // attribut(s)
        private int id;
        private String nom;        
            // methode(s)
        //constructeur(s)
        public Interest(int id, String nom)
        {
            this.id = id;
            this.nom = nom;
        }
        public Interest() : this(1, "no nom") { }
        // proprietes en lecture et en ecriture
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        // autre(s)
        public override string ToString()
        {
            return id + " :: " + nom;
        }
    }
}