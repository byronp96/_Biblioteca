﻿using System;
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
    public class MEditorial
    {

        public bool Agregar(Editorial vloCategoria)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("Insert Into editorial (edi_nombre) Values('{0}')", 
                                                                    vloCategoria.edi_nombre);

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

        public bool Actualizar(Editorial vloCategoria)
        {
            string vlcQuery = "";
            int vlnRegistrosAfectados = 0;
            try
            {
                using (IDbConnection db = new SqlConnection(BD.Default.conexion))
                {

                    vlcQuery = string.Format("UPDATE editorial SET edi_nombre = '{0}' WHERE edi_codigo = '{1}'",
                                                                    vloCategoria.edi_nombre, vloCategoria.edi_codigo);

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

                    vlcQuery = string.Format("DELETE FROM editorial WHERE edi_codigo = '{0}'",
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

        public List<Editorial> Lista()
        {
            List<Editorial> resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    resultList = db.Query<Editorial>(@"
                    SELECT * 
                    FROM editorial
                    ").ToList();
                }
                return resultList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public Editorial Buscar(int id)
        {
            Editorial resultList;
            try
            {
                using (var db = new SqlConnection(BD.Default.conexion))
                {
                    return db.Query<Editorial>(@"
                    SELECT * 
                        FROM editorial 
                        WHERE edi_codigo = "+ id).SingleOrDefault();

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