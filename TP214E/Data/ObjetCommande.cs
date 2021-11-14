﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public interface IObjetCommande
    {
        string NomAliment { get; set; }
        int QuantiteAliment { get; set; }
        
    }

    public class ObjetCommande : IObjetCommande
    {
        public string NomAliment { get; set; }
        public int QuantiteAliment { get; set; }

        public ObjetCommande(string nomAliment, int quantiteAliment = 1)
        {
            NomAliment = nomAliment;
            QuantiteAliment = quantiteAliment;
        }

        public void ChangerQuantite(int quantiteAjoutee)
        {
            QuantiteAliment += quantiteAjoutee;
        }
    }
}
