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
    public class MCliente
    {                   
        public bool Agregar(Cliente cliente)
        {     
            string vlcQuery = string.Format("Insert Into Cliente (cli_identificacion,cli_nombre,cli_apellido,cli_correo," +
                "cli_fecha_nacimiento,cli_telefono,cli_clave) " +
                "Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                            cliente.cli_identificacion,
                                            cliente.cli_nombre,
                                            cliente.cli_apellido,
                                            cliente.cli_correo,
                                            cliente.cli_fecha_nacimiento,
                                            cliente.cli_telefono,
                                            cliente.cli_clave);

            using (IDbConnection db = new SqlConnection(BD.Default.conexion))
            {                                         
                int vlnRegistrosAfectados = db.Execute(vlcQuery);

                if (vlnRegistrosAfectados >= 1) return true;
                else return false;
            }    
        }

        public List<Cliente> Listar()
        {                                                  
            string vlcQuery = "select * from Cliente";

            using (IDbConnection db = new SqlConnection(BD.Default.conexion))
            {
                return db.Query<Cliente>(vlcQuery).ToList();
            }

        }

        public bool Actualizar(Cliente cliente)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("UPDATE Cliente SET cli_identificacion = '{0}', cli_nombre = '{1}', cli_apellido = '{2}'," +
                        " cli_correo = '{3}', cli_fecha_nacimiento = '{4}', cli_telefono = '{5}', cli_clave = '{6}' " +
                        "WHERE cli_identificacion = '{0}'",
                                            cliente.cli_identificacion,
                                            cliente.cli_nombre,
                                            cliente.cli_apellido,
                                            cliente.cli_correo,
                                            cliente.cli_fecha_nacimiento,
                                            cliente.cli_telefono,
                                            cliente.cli_clave);

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

                    vlcQuery = string.Format("DELETE FROM Cliente WHERE cli_identificacion = '{0}'",
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

        public Cliente Buscar(string id)
        {
            Cliente resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    return db.Query<Cliente>(@"
                    SELECT * 
                        FROM Cliente
                        WHERE cli_identificacion = '" + id + "'").SingleOrDefault();

                }
                return resultList;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
