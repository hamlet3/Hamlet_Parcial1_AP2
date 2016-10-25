﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Materiales
    {
        public int MaterialId { get; set; }
        public string Material { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int RazonId { get; set; }

        public Materiales(string material,int precio, int cantidad)
        {
            this.Material = material;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

        public Materiales() { }
    }
}
