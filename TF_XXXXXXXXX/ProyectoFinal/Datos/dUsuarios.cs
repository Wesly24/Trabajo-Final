using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Datos;
using Entidad;


namespace Datos
{
    public class dUsuarios
    {
        Database db = new Database();

        public string Insertar(eUsuarios o) {
            try
            {
                SqlConnection conn = db.ConectaDb();
                string insert = "sp_insertar";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombresapellidos", o.Nombresapellidos);
                cmd.Parameters.AddWithValue("@DNI", o.DNI);
                cmd.Parameters.AddWithValue("@Telefono", o.Telefono);
                cmd.Parameters.AddWithValue("@Correo", o.Correo);
                cmd.Parameters.AddWithValue("@Distrito", o.Distrito);
                cmd.Parameters.AddWithValue("@Situacionlaboral", o.Situacionlaboral);
                cmd.Parameters.AddWithValue("@Descripcion", o.Descripcion);
                cmd.Parameters.AddWithValue("@L1", o.L1);
                cmd.Parameters.AddWithValue("@L2", o.L2);
                cmd.Parameters.AddWithValue("@L3", o.L3);
                cmd.Parameters.AddWithValue("@L4", o.L4);
                cmd.Parameters.AddWithValue("@C1", o.C1);
                cmd.Parameters.AddWithValue("@C2", o.C2);
                cmd.Parameters.AddWithValue("@C3", o.C3);
                cmd.Parameters.AddWithValue("@C4", o.C4);
                cmd.Parameters.AddWithValue("@Foto", o.Foto);
                cmd.Parameters.AddWithValue("@Valoracion", o.Valoracion);
                cmd.Parameters.AddWithValue("@P1", o.P1);
                cmd.Parameters.AddWithValue("@P2", o.P2);
                cmd.Parameters.AddWithValue("@P3", o.P3);
                cmd.Parameters.AddWithValue("@Link", o.Link);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return "Insert";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally { db.DesconectaDb(); }
        
        }
        public byte[] VerFoto(eUsuarios o)
        {
            try
            {

                SqlConnection conn = db.ConectaDb();
                string ver=string.Format("select Foto from Empleados where Codigo={0}",o.Codigo);
                SqlCommand cmd = new SqlCommand(ver, conn);
                SqlDataAdapter ad=new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds,"img");
                byte[] datos = new byte[0];
                DataRow dr=ds.Tables["img"].Rows[0];
                datos = (byte[])dr["Foto"];
                return datos;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { db.DesconectaDb(); }

        }
        public string Eliminar(eUsuarios o)
        {
            try
            {
                SqlConnection conn = db.ConectaDb();
                string delete = "sp_eliminar";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", o.Codigo);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return "Eliminado";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally { db.DesconectaDb(); }
        }
        public string Modificar(eUsuarios o)
        {
            try
            {
                SqlConnection conn = db.ConectaDb();
                string update = "sp_modificar";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombresapellidos", o.Nombresapellidos);
                cmd.Parameters.AddWithValue("@DNI", o.DNI);
                cmd.Parameters.AddWithValue("@Telefono", o.Telefono);
                cmd.Parameters.AddWithValue("@Correo", o.Correo);
                cmd.Parameters.AddWithValue("@Distrito", o.Distrito);
                cmd.Parameters.AddWithValue("@Situacionlaboral", o.Situacionlaboral);
                cmd.Parameters.AddWithValue("@Codigo", o.Codigo);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return "Eliminado";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally { db.DesconectaDb(); }

        }
        public string Puntuar(eUsuarios o)
        {
            try
            {
                SqlConnection conn = db.ConectaDb();
                string insert = "sp_puntuar";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Valoracion", o.Valoracion);
                cmd.Parameters.AddWithValue("@Codigo", o.Codigo);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return "Puntuado";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            finally { db.DesconectaDb(); }
        }
        public List<eUsuarios> Buscarc(string t)
        {
            try
            {
                List<eUsuarios> lsUsuario = new List<eUsuarios>();
                eUsuarios usuario = null;
                SqlConnection conn = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("sp_busqcar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@valor", t);
                
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuario = new eUsuarios();
                    usuario.Codigo = (int)reader["Codigo"];
                    usuario.Nombresapellidos = (string)reader["Nombresapellidos"];
                    usuario.DNI = (string)reader["Dni"];
                    usuario.Telefono = (string)reader["Telefono"];
                    usuario.Correo = (string)reader["Correo"];
                    usuario.Distrito = (string)reader["Distrito"];
                    usuario.Situacionlaboral = (string)reader["SituacionLaboral"];
                    usuario.Descripcion = (string)reader["Descripcion"];
                    usuario.L1 = (string)reader["L1"];
                    usuario.L2 = (string)reader["L2"];
                    usuario.L3 = (string)reader["L3"];
                    usuario.L4 = (string)reader["L4"];
                    usuario.C1 = (string)reader["C1"];
                    usuario.C2 = (string)reader["C2"];
                    usuario.C3 = (string)reader["C3"];
                    usuario.C4 = (string)reader["C4"];
                    usuario.Foto = (byte[])reader["Foto"];
                    usuario.Valoracion = (int)reader["Valoracion"];
                    usuario.P1 = (int)reader["P1"];
                    usuario.P2 = (int)reader["P2"];
                    usuario.P3 = (int)reader["P3"];
                    usuario.Link = (string)reader["Link"];
                    lsUsuario.Add(usuario);

                }
                reader.Close();

                return lsUsuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<eUsuarios> BuscarDis(eUsuarios o)
        {
            try
            {
                List<eUsuarios> lsUsuario = new List<eUsuarios>();
                eUsuarios usuario = null;
                SqlConnection conn = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("sp_distrit", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Distrito",o.Distrito);

                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuario = new eUsuarios();
                    usuario.Codigo = (int)reader["Codigo"];
                    usuario.Nombresapellidos = (string)reader["Nombresapellidos"];
                    usuario.DNI = (string)reader["Dni"];
                    usuario.Telefono = (string)reader["Telefono"];
                    usuario.Correo = (string)reader["Correo"];
                    usuario.Distrito = (string)reader["Distrito"];
                    usuario.Situacionlaboral = (string)reader["SituacionLaboral"];
                    usuario.Descripcion = (string)reader["Descripcion"];
                    usuario.L1 = (string)reader["L1"];
                    usuario.L2 = (string)reader["L2"];
                    usuario.L3 = (string)reader["L3"];
                    usuario.L4 = (string)reader["L4"];
                    usuario.C1 = (string)reader["C1"];
                    usuario.C2 = (string)reader["C2"];
                    usuario.C3 = (string)reader["C3"];
                    usuario.C4 = (string)reader["C4"];
                    usuario.Foto = (byte[])reader["Foto"];
                    usuario.Valoracion = (int)reader["Valoracion"];
                    usuario.P1 = (int)reader["P1"];
                    usuario.P2 = (int)reader["P2"];
                    usuario.P3 = (int)reader["P3"];
                    usuario.Link = (string)reader["Link"];
                    lsUsuario.Add(usuario);

                }
                reader.Close();

                return lsUsuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<eUsuarios> Listarpunt()
        {
            try
            {
                List<eUsuarios> lsUsuario = new List<eUsuarios>();
                eUsuarios usuario = null;
                SqlConnection conn = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("sp_listarpunt", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuario = new eUsuarios();
                    usuario.Codigo = (int)reader["Codigo"];
                    usuario.Nombresapellidos = (string)reader["Nombresapellidos"];
                    usuario.DNI = (string)reader["Dni"];
                    usuario.Telefono = (string)reader["Telefono"];
                    usuario.Correo = (string)reader["Correo"];
                    usuario.Distrito = (string)reader["Distrito"];
                    usuario.Situacionlaboral = (string)reader["SituacionLaboral"];
                    usuario.Descripcion = (string)reader["Descripcion"];
                    usuario.L1 = (string)reader["L1"];
                    usuario.L2 = (string)reader["L2"];
                    usuario.L3 = (string)reader["L3"];
                    usuario.L4 = (string)reader["L4"];
                    usuario.C1 = (string)reader["C1"];
                    usuario.C2 = (string)reader["C2"];
                    usuario.C3 = (string)reader["C3"];
                    usuario.C4 = (string)reader["C4"];
                    usuario.Foto = (byte[])reader["Foto"];
                    usuario.Valoracion = (int)reader["Valoracion"];
                    usuario.P1 = (int)reader["P1"];
                    usuario.P2 = (int)reader["P2"];
                    usuario.P3 = (int)reader["P3"];
                    usuario.Link = (string)reader["Link"];
                    lsUsuario.Add(usuario);

                }
                reader.Close();

                return lsUsuario;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<eUsuarios> Listar()
        {
            try
            {
                List<eUsuarios> lsUsuario = new List<eUsuarios>();
                eUsuarios usuario = null;
                SqlConnection conn = db.ConectaDb();                
                SqlCommand cmd = new SqlCommand("sp_listar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader= cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuario = new eUsuarios();
                    usuario.Codigo = (int)reader["Codigo"];
                    usuario.Nombresapellidos = (string)reader["Nombresapellidos"];
                    usuario.DNI = (string)reader["Dni"];
                    usuario.Telefono = (string)reader["Telefono"];
                    usuario.Correo = (string)reader["Correo"];
                    usuario.Distrito = (string)reader["Distrito"];
                    usuario.Situacionlaboral = (string)reader["SituacionLaboral"];                    
                    usuario.Descripcion = (string)reader["Descripcion"];
                    usuario.L1 = (string)reader["L1"];
                    usuario.L2 = (string)reader["L2"];
                    usuario.L3 = (string)reader["L3"];
                    usuario.L4 = (string)reader["L4"];
                    usuario.C1 = (string)reader["C1"];
                    usuario.C2 = (string)reader["C2"];
                    usuario.C3 = (string)reader["C3"];
                    usuario.C4 = (string)reader["C4"];
                    usuario.Foto = (byte[])reader["Foto"];
                    usuario.Valoracion = (int)reader["Valoracion"];
                    usuario.P1 = (int)reader["P1"];
                    usuario.P2 = (int)reader["P2"];
                    usuario.P3 = (int)reader["P3"];
                    usuario.Link= (string)reader["Link"];
                    lsUsuario.Add(usuario);
                }
                reader.Close();              
                
                return lsUsuario;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally {db.DesconectaDb(); }
        }        
    }
}
