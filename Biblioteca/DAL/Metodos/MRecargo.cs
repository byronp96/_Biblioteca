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
    public class MRecargo
    {
        public bool Agregar(Recargo recargo)
        {
            string vlcQuery = string.Format("Insert Into Recargo (rec_descripcion,rec_estado,rec_monto) " +
                "Values('{0}',{1},{2})",               
                                    recargo.rec_descripcion,
                                    recargo.rec_estado,
                                    recargo.rec_monto);

            using (IDbConnection db = new SqlConnection(BD.Default.conexion))
            {
                int vlnRegistrosAfectados = db.Execute(vlcQuery);

                if (vlnRegistrosAfectados >= 1) return true;
                else return false;
            }
        }

        public List<Recargo> Listar()
        {
            string vlcQuery = "select * from Recargo";

            using (IDbConnection db = new SqlConnection(BD.Default.conexion))
            {
                return db.Query<Recargo>(vlcQuery).ToList();
            }

        }

        public bool Actualizar(Recargo recargo)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("UPDATE Recargo SET rec_descripcion = '{1}', rec_estado = {2}, rec_monto = {3} " +
                        "WHERE rec_codigo = {0}",
                                    recargo.rec_codigo,
                                    recargo.rec_descripcion,
                                    recargo.rec_estado,
                                    recargo.rec_monto);

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

        public bool Eliminar(int vlnId)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("DELETE FROM Recargo WHERE rec_codigo  = '{0}'",
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

        public Recargo Buscar(int id)
        {
            Recargo resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    return db.Query<Recargo>(@"
                    SELECT * 
                        FROM Recargo
                        WHERE rec_codigo = " + id).SingleOrDefault();

                }
                return resultList;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
