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
    public class MCategoria
    {

        public bool Agregar(Categoria vloCategoria)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("Insert Into Categoria (cat_codigo, cat_descripcion) Values({0},'{1}')", 
                                                                    vloCategoria.cat_codigo, vloCategoria.cat_descripcion);

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

        public List<Categoria> Lista()
        {
            List<Categoria> resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    resultList = db.Query<Categoria>(@"
                    SELECT * 
                    FROM Categoria
                    ").ToList();
                }
                return resultList;
            }
            catch (Exception EX)
            {

                throw;
            }
           
        }

        public Categoria Buscar(int id)
        {
            Categoria resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    return db.Query<Categoria>(@"
                    SELECT * 
                        FROM Categoria
                        WHERE cat_codigo = '"+ id +"'").SingleOrDefault();

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
