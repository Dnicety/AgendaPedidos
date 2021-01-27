using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAR
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string NombreProducto { get; set; }
        public string DescProducto { get; set; }
        public string PrecProducto { get; set; }
        public string TipoProducto { get; set; }

    }
}
