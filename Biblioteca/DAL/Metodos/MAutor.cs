using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace DAL.Metodos
{
    public class MAutor
    {
         public bool Agregar(Autor vloAutor)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {
                    byte[] data = vloAutor.aut_foto;
                    // ... Convert byte array to Base64 string.
                    string result = Convert.ToBase64String(data);

                    vlcQuery = string.Format("INSERT INTO [dbo].[Autor]([aut_nombre],[aut_apellido],[aut_fecha_nacimiento],[aut_nacionalidad],[aut_foto])" +
                                             "                   VALUES('{0}'       ,'{1}'         ,'{2}'                 ,'{3}'              ,CAST('{4}' AS NVARCHAR(MAX)))", 
                                             vloAutor.aut_nombre, vloAutor.aut_apellido, vloAutor.aut_fecha_nacimiento, vloAutor.aut_nacionalidad, vloAutor._aut_foto);
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

        public bool Actualizar(Autor vloAutor)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {
                    byte[] data = vloAutor.aut_foto;
                    // ... Convert byte array to Base64 string.
                    string result = Convert.ToBase64String(data);

                    vlcQuery = string.Format("UPDATE Autor SET [aut_nombre] = '{1}',[aut_apellido] = '{2}',[aut_fecha_nacimiento] = '{3}',[aut_nacionalidad] = '{4}',[aut_foto] = '{5}'" +
                                             "       WHERE aut_codigo = {0}",
                                              vloAutor.aut_codigo, vloAutor.aut_nombre, vloAutor.aut_apellido, vloAutor.aut_fecha_nacimiento, vloAutor.aut_nacionalidad, vloAutor._aut_foto);

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

                    vlcQuery = string.Format("DELETE FROM Autor WHERE aut_codigo = '{0}'",
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

        public List<Autor> Lista()
        {
            List<Autor> resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    resultList = db.Query<Autor>(@"
                    SELECT 
                        [aut_codigo]
                              ,[aut_nombre]
                              ,[aut_apellido]
                              ,[aut_fecha_nacimiento]
                              ,[aut_nacionalidad]
                        ,[aut_foto]   '_aut_foto'
                    FROM Autor
                    ").ToList();
                    
                }

                
                
                return resultList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public Autor Buscar(int id)
        {
            Autor resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    return db.Query<Autor>(@"
                    SELECT 
[aut_codigo]
      ,[aut_nombre]
      ,[aut_apellido]
      ,[aut_fecha_nacimiento]
      ,[aut_nacionalidad]
,[aut_foto]   '_aut_foto'
                    FROM Autor
                        WHERE aut_codigo = " + id).SingleOrDefault();
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
