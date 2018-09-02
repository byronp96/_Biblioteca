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

                    vlcQuery = string.Format("Insert Into Categoria (cat_descripcion) Values('{0}')", 
                                                                    vloCategoria.cat_descripcion);

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

        public bool Actualizar(Categoria vloCategoria)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("UPDATE Categoria SET cat_descripcion = '{0}' WHERE cat_codigo = '{1}'",
                                                                    vloCategoria.cat_descripcion, vloCategoria.cat_codigo);

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

                    vlcQuery = string.Format("DELETE FROM Categoria WHERE cat_codigo = '{0}'",
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

        public List<LibroXCategoria> ListaCategorias(string id)
        {
            List<LibroXCategoria> resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    resultList = db.Query<LibroXCategoria>(@"
 SELECT ISNULL(le.lib_codigo, '0') as [lxa_activo],e.[edi_codigo],edi_nombre
                                FROM editorial e
						LEFT JOIN
						        libro_editorial le
						ON e.edi_codigo= le.edi_codigo
                        WHERE le.edi_codigo is null OR le.edi_codigo =  " + id).ToList();
                }



                return resultList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool AgregarAutorLibro(LibroXCategoria vloLibro)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("INSERT INTO [dbo].[libro]([lib_codigo],[aut_codigo]" +
                                             "                   VALUES({0},{1})",
                                             vloLibro.lib_codigo, vloLibro.aut_codigo);
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
    }
}
