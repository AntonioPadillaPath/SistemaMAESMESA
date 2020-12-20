using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

using Entidades;

namespace Datos
{
    
    public class ConexionSQL
    {
        static string conexionString = "server=localhost;database=MAESMESA;" +
            "integrated security=true";

        SqlConnection con = new SqlConnection(conexionString);


        //Manejo de Usuarios

        public int consultaLogin(string Usuario, string Contrasena)
        {
            int count;

            con.Open();

            string Query = "Select Count(*) From UsuariosEjemplo5 where Usuario = '" + Usuario + "'" +
                " and Contrasena = '" + Contrasena + "'";

            SqlCommand cmd = new SqlCommand(Query, con);
            count = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            return count;
        }

        public Tuple<string, string> consultaUsuarioLlenar(string usuario)
        {
            con.Open();
            string query = "select * from UsuariosEjemplo5 where Usuario = '" + usuario + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                return Tuple.Create(reg["Nombre"].ToString(), reg["Apellido"].ToString());
            }
            else
            {
                return Tuple.Create("Null", "");
            }
            //con.Close();
        }

        public byte[] abrirMatrizPerfil(string usuario)
        {
            con.Open();
            string query = "select Foto from UsuariosEjemplo5 where Usuario = '" + usuario+ "'";
            SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader reg = cmd.ExecuteReader();


            byte[] content = cmd.ExecuteScalar() as byte[];

            return content;

        }

        //Inserción de Usuarios

        public int insertarUsuario(string nom, string ape, string usu, string pas, byte[]foto)
        {
            int flag = 0;

            con.Open();

            string Query = "insert into UsuariosEjemplo5 values ( '" + nom + "','" + ape + "','" + usu +
                "','" + pas + "', @foto)";

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = foto; //Pasamos la referencia del arreglo de bytes

            flag = cmd.ExecuteNonQuery();

            con.Close();

            return flag;
        }

        //Llenado de la tabla de Productos

        public DataTable consultaTablaUsuarios()
        {
            string query = "select Nombre, Apellido, Usuario from UsuariosEjemplo5 where ID > 1";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }



        //Inserción para Productos

        public int insertarProducto(string cod, string nom, string med)
        {
            int flag = 0;

            con.Open();

            string Query = "insert into Productos values ( '" + cod + "','" + nom + "','" + med + "')";

            SqlCommand cmd = new SqlCommand(Query, con);
            flag = cmd.ExecuteNonQuery();

            con.Close();

            return flag;
        }

        //Inserción para Clientes

        public int insertarCliente(string nom, string dir, string ciu, string est, string tel,
            string correo, string cp, string rfc)
        {
            int flag = 0;

            con.Open();

            string Query = "insert into ClientesEjemplo values ( '" + nom + "','" + dir + "','" + ciu + "'," +
                "'" + est + "','" + cp + "','" + tel + "'," +
                "'" + correo + "','" + rfc + "')";

            SqlCommand cmd = new SqlCommand(Query, con);
            flag = cmd.ExecuteNonQuery();

            con.Close();

            return flag;
        }

        //Llenado de la tabla de Productos

        public DataTable consultaProductos()
        {
            string query = "select * from Productos";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }

        //Llenado de la tabla de Clientes

        public DataTable consultaClientes()
        {
            string query = "select * from ClientesEjemplo order by Nombre";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }

        //Inserción y operaciones para Cotizaciones

        public string consultaCotizaciones()
        {
            con.Open();
            string query = "select (select distinct top 1 NoCot from CotizacionesEjemplo4 order by NoCot desc) + 1 as NoCot";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                return reg["NoCot"].ToString();
            }
            else
            {
                return "Null";
            }
            //con.Close();
        }

        //Método para cerrar la conexión que las consultas dejan abierta
        public void cerrarCon()
        {
            con.Close();
        }

        public int insertarCotizaciones(string nom, string dir, string ciu, string est, string tel,
            string correo, string cp, string rfc, string atiende, string fecha, string rec,
            string sub, string iva, string total)
        {
            int flag = 0;

            con.Open();

            string Query = "insert into CotizacionesEjemplo4 values ( '" + nom + "','" + dir + "','" + ciu + "'," +
                "'" + est + "','" + cp + "','" + tel + "'," +
                "'" + correo + "','" + rfc + "','" + atiende + "'," +
                "'" + fecha + "','" + rec + "','" + sub + "'," +
                "'" + iva + "','" + total + "')";

            SqlCommand cmd = new SqlCommand(Query, con);
            flag = cmd.ExecuteNonQuery();

            con.Close();

            return flag;
        }

        //Contulta para llenado automático de Productos en Cotización y Venta

        public Tuple<string, string> consultaProductosLlenar(string codigo)
        {
            con.Open();
            string query = "select * from Productos where Codigo = '" + codigo + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                return Tuple.Create(reg["Codigo"].ToString(), reg["Nombre"].ToString());
            }
            else
            {
                return Tuple.Create("Null", "");
            }
            //con.Close();
        }

        //Inserción se la tabla de Cotizaciones

        public void insertarTablaCotizacion(List<Guardar> F)
        {
            con.Open();

            foreach (Guardar guardar in F)
            {
                string query = "insert into cotizacionesProductosEjemplo " +
                    "(NoCot, Cliente, Codigo, Concepto, PU, Cantidad, Importe) values('" + guardar.Nocot + "','"
                    + guardar.Cliente + "','" + guardar.Codigo + "','" + guardar.Concepto + "','" + guardar.Precio + "','"
                    + guardar.Cantidad + "','" + guardar.Importe + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }

            con.Close();

        }

        //Contulta para llenado de la búsqueda de una cotiación (Se realizan 2 tuplas)

        public Tuple<string, string, string, string, string, string, string> consultaCotizacionLlenar1(string codigo)
        {
            con.Open();
            string query = "select * from CotizacionesEjemplo4 where NoCot = '" + codigo + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                return Tuple.Create
                    (
                    reg["NoCot"].ToString(), reg["Nombre"].ToString(),
                    reg["Dirección"].ToString(), reg["Ciudad"].ToString(),
                    reg["Estado"].ToString(), reg["CP"].ToString(),
                    reg["Teléfono"].ToString()
                    );
            }
            else
            {
                return Tuple.Create("Null", "", "", "", "", "", "");
            }
            //con.Close();
        }

        public Tuple<string, string, string, string, string, string, string> consultaCotizacionLlenar2(string codigo)
        {
            con.Open();
            string query = "select * from CotizacionesEjemplo4 where NoCot = '" + codigo + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                return Tuple.Create
                    (
                    reg["Email"].ToString(),
                    reg["RFC"].ToString(), reg["Atiende"].ToString(),
                    reg["Fecha"].ToString(), reg["Subtotal"].ToString(),
                    reg["IVA"].ToString(), reg["Total"].ToString()
                    );
            }
            else
            {
                return Tuple.Create("Null", "", "", "", "", "", "");
            }
            //con.Close();
        }

        //Llenado de la tabla de Cotización por NoCot

        public DataTable consultaCotizacionTabla(string nocot)
        {
            string query = "select Codigo, Concepto, PU, Cantidad, Importe " +
                "from cotizacionesProductosEjemplo where NoCot = '" + nocot + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }


        //Métodos para consultar años e índices

        public string consultaYear()
        {
            con.Open();
            string query = "select * from IteraYearGeneral";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                return reg["valor"].ToString();
            }
            else
            {
                return "Null";
            }
            //con.Close();
        }

        public string consultaCotizacionesIndex()
        {
            con.Open();
            string query = "select (select valor from IteraYearCot) + 1 as valor";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                return reg["valor"].ToString();
            }
            else
            {
                return "Null";
            }
            //con.Close();
        }

        public int updateYear(int year)
        {
            int flag = 0;

            con.Open();

            string Query = "update IteraYearGeneral set valor = " + year;

            SqlCommand cmd = new SqlCommand(Query, con);
            flag = cmd.ExecuteNonQuery();

            con.Close();

            return flag;
        }

        public int updateIndexCot(int index)
        {
            int flag = 0;

            con.Open();

            string Query = "update IteraYearCot set valor = " + index;

            SqlCommand cmd = new SqlCommand(Query, con);
            flag = cmd.ExecuteNonQuery();

            con.Close();

            return flag;
        }

        public string consultaPedidosIndex()
        {
            con.Open();
            string query = "select (select valor from IteraIndexPedido) + 1 as valor";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                return reg["valor"].ToString();
            }
            else
            {
                return "Null";
            }
            //con.Close();
        }

        public int updateIndexPed(int index)
        {
            int flag = 0;

            con.Open();

            string Query = "update IteraIndexPedido set valor = " + index;

            SqlCommand cmd = new SqlCommand(Query, con);
            flag = cmd.ExecuteNonQuery();

            con.Close();

            return flag;
        }


        //Inserción de Datos de Pedido
        public int insertarPedidos(string nom, string dir, string ciu, string est, string tel,
            string correo, string cp, string rfc, string atiende, string fecha, string sub, string iva, string total,
            string orden, string pago, string entrega, string com)
        {
            int flag = 0;

            con.Open();

            string Query = "insert into PedidosEjemplo values ( '" + nom + "','" + dir + "','" + ciu + "'," +
                "'" + est + "','" + cp + "','" + tel + "'," +
                "'" + correo + "','" + rfc + "','" + atiende + "'," +
                "'" + fecha + "','" + sub + "'," +
                "'" + iva + "','" + total + "','" + orden + "','" + pago + "','" + entrega + "','" + com + "')";

            SqlCommand cmd = new SqlCommand(Query, con);
            flag = cmd.ExecuteNonQuery();

            con.Close();

            return flag;
        }

        //Inserción se la tabla de Pedidos

        public void insertarTablaPedidos(List<Guardar> F)
        {
            con.Open();

            foreach (Guardar guardar in F)
            {
                string query = "insert into pedidosProductosEjemplo " +
                    "(NoCot, Cliente, Codigo, Concepto, PU, Cantidad, Importe) values('" + guardar.Nocot + "','"
                    + guardar.Cliente + "','" + guardar.Codigo + "','" + guardar.Concepto + "','" + guardar.Precio + "','"
                    + guardar.Cantidad + "','" + guardar.Importe + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }

            con.Close();

        }


        //Métodos para guardar y descargar Diseños
        public int insertarDiseños(string cli, string cod, string pro, string nom, byte[] doc)
        {
            int flag = 0;

            //doc.ToArray();

            con.Open();

            //string Query = "insert into Diseños1 values ( '" + cli + "','" + cod + "','" + pro + "'," + doc + ")";
            string Query = "insert into DiseñosEjemplo values ( '" + cli + "','" + cod + "','" + pro +
              "', '" + nom + "', @archivo)";

            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.Add("@archivo", SqlDbType.VarBinary).Value = doc; //Pasamos la referencia del arreglo de bytes


            flag = cmd.ExecuteNonQuery();

            con.Close();

            return flag;
        }

        //Llenado del data grid view Diseños

        public DataTable consultaDiseños()
        {
            string query = "select id, Cliente, Codigo, Producto, Archivo from DiseñosEjemplo order by Cliente";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            return tabla;
        }

        //Consultas para abrir el diseño y el mapa de bytes
        public string abrirDiseño(int id)
        {
            con.Open();
            string query = "select Archivo from DiseñosEjemplo where id = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                return reg["Archivo"].ToString();
            }
            else
            {
                return "Null";
            }
            //con.Close();
        }

        
        public byte[] abrirMatriz(int id)
        {
            con.Open();
            string query = "select Documento from DiseñosEjemplo where id = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader reg = cmd.ExecuteReader();


            byte[] content = cmd.ExecuteScalar() as byte[];

            return content;
            //foreach (byte b in mapaBytes)
            //{
            //    Console.WriteLine(b);
            //}




            //if (reg.Read())
            //{
            //    return reg["Documento"].ToString();
            //}
            //else
            //{
            //    return "Null";
            //}



        }



    }
}
