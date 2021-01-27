using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAR
{
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Producto { get; set; }
        public double Total { get; set; }

    }
}
