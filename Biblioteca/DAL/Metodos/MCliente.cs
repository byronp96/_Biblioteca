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
            string vlcQuery = string.Format("Insert Into Cliente (cli_identificacion,cli_nombre,cli_apellido,cli_correo,cli_fecha_nacimiento,cli_telefono,cli_clave) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
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
    }
}
