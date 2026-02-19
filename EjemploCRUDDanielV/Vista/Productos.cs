using System;
using System.Collections.Generic;
using System.Text;

namespace Vista
{
    public class Productos

    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double Precio{ get; set; }
        public DateTime Fecha { get; set; }
    }
}
