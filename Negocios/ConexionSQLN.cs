using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidades;

namespace Negocios
{
    public class ConexionSQLN
    {
        ConexionSQL cn = new ConexionSQL();

        public int conSQL(string user, string pass)
        {
            return cn.consultaLogin(user, pass);
        }

        public DataTable ConsultaDT()
        {
            return cn.consultaProductos();
        }

        public DataTable ConsultaDTClientes()
        {
            return cn.consultaClientes();
        }

        public int insertarProducto(string cod, string nom, string med)
        {
            return cn.insertarProducto(cod, nom, med);
        }

        public int insertarCliente(string nom, string dir, string ciu, string est, string tel,
            string correo, string cp, string rfc)
        {
            return cn.insertarCliente(nom, dir, ciu, est, tel, correo, cp, rfc);
        }

        public string consultaCotizaciones()
        {
            return cn.consultaCotizaciones();
        }

        public Tuple<string, string> consultaProductosLlenar(string code)
        {
            return cn.consultaProductosLlenar(code);
        }

        public void cerrarCon()
        {
            cn.cerrarCon();
        }

        public int insertarCotizaciones(string nom, string dir, string ciu, string est, string tel,
            string correo, string cp, string rfc, string atiende, string fecha, string rec,
            string sub, string iva, string total)
        {
            return cn.insertarCotizaciones(nom, dir, ciu, est, tel,
            correo, cp, rfc, atiende, fecha, rec,
            sub, iva, total);
        }


        public void insertarTablaCotizacion (List<Guardar> F)
        {
            cn.insertarTablaCotizacion(F);
        }


        public Tuple<string, string, string, string, string, string, string> consultaCotizacionLlenar1(string nocot)
        {
            return cn.consultaCotizacionLlenar1(nocot);
        }

        public Tuple<string, string, string, string, string, string, string> consultaCotizacionLlenar2(string nocot)
        {
            return cn.consultaCotizacionLlenar2(nocot);
        }

        public DataTable consultaCotizacionTabla(string nocot)
        {
            return cn.consultaCotizacionTabla(nocot);
        }

    }

}
