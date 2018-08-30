using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DAL.Metodos
{
    public class MUsuario
    {
        public bool Agregar(Usuario usuario)
        {
            string vlcQuery = string.Format("Insert Into Usuario (usu_identificacion,usu_nombre,usu_apellido,usu_correo," +
                "usu_fecha_nacimiento,usu_telefono,usu_clave) " +
                "Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                            usuario.usu_identificacion,
                                            usuario.usu_nombre,
                                            usuario.usu_apellido,
                                            usuario.usu_correo,
                                            usuario.usu_fecha_nacimiento,
                                            usuario.usu_telefono,
                                            usuario.usu_clave);

            using (IDbConnection db = new SqlConnection(BD.Default.conexion))
            {
                int vlnRegistrosAfectados = db.Execute(vlcQuery);

                if (vlnRegistrosAfectados >= 1) return true;
                else return false;
            }
        }

        public List<Usuario> Listar()
        {
            string vlcQuery = "select * from Usuario";

            using (IDbConnection db = new SqlConnection(BD.Default.conexion))
            {
                return db.Query<Usuario>(vlcQuery).ToList();
            }

        }

        public bool Actualizar(Usuario usuario)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("UPDATE Usuario SET usu_identificacion = '{0}', usu_nombre = '{1}', usu_apellido = '{2}'," +
                        " usu_correo = '{3}', usu_fecha_nacimiento = '{4}', usu_telefono = '{5}', usu_clave = '{6}' " +
                        "WHERE usu_identificacion = '{0}'",
                                            usuario.usu_identificacion,
                                            usuario.usu_nombre,
                                            usuario.usu_apellido,
                                            usuario.usu_correo,
                                            usuario.usu_fecha_nacimiento,
                                            usuario.usu_telefono,
                                            usuario.usu_clave);

                    vlnRegistrosAfectados = db.Execute(vlcQuery);

                    if (vlnRegistrosAfectados >= 1) return true;
                    else return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(string vlnId)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("DELETE FROM Usuario WHERE usu_identificacion = '{0}'",
                                                                    vlnId);

                    vlnRegistrosAfectados = db.Execute(vlcQuery);

                    if (vlnRegistrosAfectados >= 1) return true;
                    else return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Usuario Buscar(string id)
        {
            Usuario resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    return db.Query<Usuario>(@"
                    SELECT * 
                        FROM Usuario
                        WHERE usu_identificacion = '" + id + "'").SingleOrDefault();

                }
                return resultList;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool IniciarSesion(Usuario usuario)
        {
            try
            {
                Usuario usu = new Usuario();
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    usu =  db.Query<Usuario>(@"
                    SELECT *
                        FROM Usuario
                        WHERE usu_correo = '" + usuario.usu_correo + "' and usu_clave = '" + usuario.usu_clave + "'").SingleOrDefault();
                }
                if (usu == null)
                {
                    return false;
                }
                else { return true; }
                
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
