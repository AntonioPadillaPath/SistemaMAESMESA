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

        public int insertarUsuario(string nom, string ape, string usu, string pas, byte[]foto)
        {
            return cn.insertarUsuario(nom, ape, usu, pas, foto);
        }

        public int eliminarUsuario(string nom)
        {
            return cn.eliminarUsuario(nom);
        }

        public byte[] abrirMatrizPerfil(string usuario)
        {
            return cn.abrirMatrizPerfil(usuario);
        }

        public Tuple<string, string> consultaUsuarioLlenar(string usuario)
        {
            return cn.consultaUsuarioLlenar(usuario);
        }

        public DataTable ConsultaDT()
        {
            return cn.consultaProductos();
        }

        public DataTable ConsultaTablaUsuarios()
        {
            return cn.consultaTablaUsuarios();
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

        public int eliminarProducto(string nom)
        {
            return cn.eliminarProducto(nom);
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

        public int insertarCotizaciones(string nom, string dir, string ciu, string est, string cp,
            string tel, string correo, string rfc, string atiende, string fecha, string rec,
            string sub, string iva, string total)
        {
            return cn.insertarCotizaciones(nom, dir, ciu, est, cp,
            tel, correo, rfc, atiende, fecha, rec,
            sub, iva, total);
        }

        public int insertarPedidos(string nom, string dir, string ciu, string est, string tel,
            string correo, string cp, string rfc, string atiende, string fecha, string sub, string iva, string total,
            string orden, string pago, string entrega, string com)
        {
            return cn.insertarPedidos(nom, dir, ciu, est, tel,
            correo, cp, rfc, atiende, fecha, sub, iva, total, orden, pago, entrega, com);
        }

        public void insertarTablaCotizacion(List<Guardar> F)
        {
            cn.insertarTablaCotizacion(F);
        }


        public void insertarTablaPedidos(List<Guardar> F)
        {
            cn.insertarTablaPedidos(F);
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


        public string consultaYear()
        {
            return cn.consultaYear();
        }

        public string consultaCotizacionesIndex()
        {
            return cn.consultaCotizacionesIndex();
        }

        public int updateYear(int year)
        {
            return cn.updateYear(year);
        }

        public int updateIndexCot(int index)
        {
            return cn.updateIndexCot(index);
        }

        public string consultaPedidosIndex()
        {
            return cn.consultaPedidosIndex();
        }

        public int updateIndexPed(int index)
        {
            return cn.updateIndexPed(index);
        }


        public int insertarDiseños(string cli, string cod, string pro, string nom, byte[] doc)
        {
            return cn.insertarDiseños(cli, cod, pro, nom, doc);
        }


        public DataTable ConsultaDiseños()
        {
            return cn.consultaDiseños();
        }

        public string abrirDiseño(int id)
        {
            return cn.abrirDiseño(id);
        }

        public byte[] abrirMatriz(int id)
        {
            return cn.abrirMatriz(id);
        }

    }

}
