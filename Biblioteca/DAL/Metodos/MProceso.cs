using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Metodos
{
    public class MProceso
    {
       public int AgregarPrestamo(int cli_codigo, int lib_codigo )
        {
            string vlcQuery = "";
            int vlnRegistrosAfectadosInt = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("EXEC sp_InsertarPrestamo {0}, {1}, {2}, {3}", cli_codigo, pre_fecha_inicio, pre_fecha_fin, pre_estado);

                    vlnRegistrosAfectadosInt = db.Execute(vlcQuery);
                    return vlnRegistrosAfectadosInt;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


    
       public int AgregarPrestamoLibro(int cli_codigo,int lib_codigo)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectadosInt = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("EXEC  sp_InsertarPrestamoLibro {0}, {1}", cli_codigo, lib_codigo);

                    vlnRegistrosAfectadosInt = db.Execute(vlcQuery);
                    return vlnRegistrosAfectadosInt;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

    }
}
