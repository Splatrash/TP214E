using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Commande
    {
        //Si dans le futur on a besoin de mettre dans une base de données
        //public ObjectId Id { get; set; }
        public string NumeroCommande { get; set; }
        public List<Tuple<string, int>> ObjetsCommande { get; set; }
        public DateTime CreerLe { get; set; }
    }
}
