using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Guardar
    {
        private string nocot;
        private string cliente;
        private string codigo;
        private string concepto;
        private string cantidad;
        private string precio;
        private string importe;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Concepto { get => concepto; set => concepto = value; }
        public string Cantidad { get => cantidad; set => cantidad = value; }
        public string Precio { get => precio; set => precio = value; }
        public string Importe { get => importe; set => importe = value; }
        public string Nocot { get => nocot; set => nocot = value; }
        public string Cliente { get => cliente; set => cliente = value; }
    }
}
