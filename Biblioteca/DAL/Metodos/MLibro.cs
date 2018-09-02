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
    public class MLibro
    {

        public bool Agregar(Libro vloLibro)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {
                    byte[] data = vloLibro.lib_portada;
                    // ... Convert byte array to Base64 string.
                    string result = Convert.ToBase64String(data);

                    vlcQuery = string.Format("INSERT INTO [dbo].[libro]([lib_codigo],[lib_titulo],[lib_fecha_publicacion],[lib_idioma],[lib_paginas],[lib_sinopsis],[lib_portada],[lib_estado], [lib_cantidad])" +
                                             "                   VALUES({0}         ,'{1}'         ,'{2}'                    ,'{3}'         ,{4}          ,'{5}'           ,CAST('{6}' AS NVARCHAR(MAX))          ,{7}         ,{8})", 
                                             vloLibro.lib_codigo, vloLibro.lib_titulo, vloLibro.lib_fecha_publicacion, vloLibro.lib_idioma, vloLibro.lib_paginas, vloLibro.lib_sinopsis, vloLibro._lib_portada, Convert.ToInt32 (vloLibro.lib_estado), Convert.ToInt32(vloLibro.lib_cantidad));
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

        public bool Actualizar(Libro vloLibro)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {
                    byte[] data = vloLibro.lib_portada;
                    // ... Convert byte array to Base64 string.
                    string result = Convert.ToBase64String(data);

                    vlcQuery = string.Format("UPDATE Libro SET lib_codigo = {0},[lib_titulo] = '{1}',[lib_fecha_publicacion] = '{2}',[lib_idioma] = '{3}',[lib_paginas] = {4},[lib_sinopsis] = '{5}',[lib_portada] = '{6}',[lib_estado] = {7} , lib_cantidad ={8}" +
                                             "       WHERE lib_codigo = {0}",
                                             vloLibro.lib_codigo, vloLibro.lib_titulo, vloLibro.lib_fecha_publicacion, vloLibro.lib_idioma, vloLibro.lib_paginas, vloLibro.lib_sinopsis, result, Convert.ToInt32(vloLibro.lib_estado), Convert.ToInt32(vloLibro.lib_cantidad));

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

                    vlcQuery = string.Format("DELETE FROM Libro WHERE lib_codigo = '{0}'",
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

        public List<Libro> Lista()
        {
            List<Libro> resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    resultList = db.Query<Libro>(@"
                    SELECT 
[lib_codigo]
      ,[lib_titulo]
      ,[lib_fecha_publicacion]
      ,[lib_idioma]
      ,[lib_paginas]
      ,[lib_sinopsis]
      ,[lib_portada] AS _lib_portada
      ,[lib_estado],lib_cantidad
                    FROM Libro
                    ").ToList();
                }

                
                
                return resultList;
            }
            catch (Exception EX)
            {

                throw;
            }
           
        }

        public Libro Buscar(int id)
        {
            Libro resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    return db.Query<Libro>(@"
                    SELECT 
[lib_codigo]
      ,[lib_titulo]
      ,[lib_fecha_publicacion]
      ,[lib_idioma]
      ,[lib_paginas]
      ,[lib_sinopsis]
      ,[lib_portada] AS _lib_portada
      ,[lib_estado],lib_cantidad
                    FROM Libro
                        WHERE lib_codigo = " + id).SingleOrDefault();

                    resultList.lib_estado = Convert.ToBoolean(resultList.lib_estado);
                }
                return resultList;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<Libro> Reservas(string libros)
        {
            List<Libro> resultList;
            string pvcConsulta;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    pvcConsulta = string.Format("SELECT [lib_codigo],[lib_titulo],[lib_fecha_publicacion],[lib_idioma],[lib_paginas],[lib_sinopsis],[lib_portada] AS _lib_portada,[lib_estado], lib_cantidad FROM Libro where lib_codigo IN({0})", libros);
                    resultList = db.Query<Libro>(@pvcConsulta).ToList();
                }



                return resultList;
            }
            catch (Exception EX)
            {

                throw;
            }

        }

        public List<LibroXAutor> ListaAutores(string id)
        {
            List<LibroXAutor> resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    resultList = db.Query<LibroXAutor>(@"
                        SELECT ISNULL(la.aut_codigo, '0') as [lxa_activo],a.[aut_codigo],Concat([aut_nombre],' ', aut_apellido) as [aut_nombre]
                                FROM autor a
						LEFT JOIN
						        libro_autor la
						ON a.aut_codigo = la.aut_codigo
                        WHERE la.aut_codigo is null OR la.lib_codigo = " + id).ToList();
                }



                return resultList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool AgregarAutorLibro(LibroXAutor vloLibro)
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
