using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsCrud.Models
{
    public class Product
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public int prix { get; set; }
        //public string Photo { get; set; }

        public override string ToString()
        {
            return this.nom + "  " + "(" + this.description + ")" + "  " + this.prix;
        }

    }
}
