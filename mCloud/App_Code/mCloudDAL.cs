﻿using System;
using System.Web;
#region Namespace for Database Connection
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
#endregion



namespace mCloud.App_Code
{
    public class mCloudDAL
    {
        #region Variable for Database Connection
        SqlConnection SqlConn;
        SqlDataAdapter SqlDa;
        SqlCommand Sqlcmd;
        SqlDataReader SqlDr;
        DataTable Dt;
        DataSet Ds;
        int a;
        object ab;
        #endregion

        #region Function for Open Connection
        public void OpenConn()
        {
            try
            {
                if (SqlConn == null)
                    SqlConn = new SqlConnection(ConfigurationManager.
                        ConnectionStrings["mConstr"].ToString());
                if (SqlConn.State == ConnectionState.Closed)
                    SqlConn.Open();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }

        }
        #endregion

        #region Function for Close Connection
        public void CloseConn()
        {
            if (SqlConn.State == ConnectionState.Open)
                SqlConn.Close();
        }
        #endregion

        #region Function for Dataset for Disconnected Mode
        public DataSet FunDataSet(string Commmand)
        {
            OpenConn();
            SqlDa = new SqlDataAdapter(Commmand, SqlConn);
            Ds = new DataSet();
            try
            {
                SqlDa.Fill(Ds);
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
            finally
            {

                CloseConn();
            }
            return Ds;

        }
        #endregion

        #region Function For DataTable(Disconnected Mode)
        public DataTable FunDataTable(string Command)
        {
            OpenConn();
            SqlDa = new SqlDataAdapter(Command, SqlConn);
            Dt = new DataTable();
            try
            {
                SqlDa.Fill(Dt);
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
            finally
            {
                CloseConn();
            }
            return Dt;
        }
        #endregion

        #region Function for ExecuteNonQuery(Insert,Update,Delete)
        public int FunExecuteNonQuery(string Command)
        {
            OpenConn();
            Sqlcmd = new SqlCommand(Command, SqlConn);
            try
            {
                 a = Sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
            finally
            {
                CloseConn();
            }
            return a;

        }
        #endregion

        #region Function For ExecuteReader fetch number of rows
        public SqlDataReader FunExecuteReader(string Command)
        {
            OpenConn();
            Sqlcmd = new SqlCommand(Command, SqlConn);

            try
            {
                SqlDr = Sqlcmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
            return SqlDr;
        }
        #endregion

        #region Function for ExecuteScalar(Fetch a single value)
        public object FunExecuteScalar(string Command)
        {
            OpenConn();
            Sqlcmd = new SqlCommand(Command, SqlConn);
            try
            {
                ab = Sqlcmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
            finally
            {
                CloseConn();
            }
            return ab;
        }
        #endregion

        #region Function for BulkInsert
        public void FuncBulkCopy(DataTable dt, string DestinationTable)
        {
            using (var bulkcopy = new SqlBulkCopy(SqlConn.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                foreach (DataColumn col in dt.Columns)
                {
                    bulkcopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }
                bulkcopy.BulkCopyTimeout = 600;
                bulkcopy.DestinationTableName = DestinationTable;
                bulkcopy.WriteToServer(dt);
            }
        }
        #endregion

        #region Function for StoreProcedure ExecuteNonQuery(Insert,Update,Delete)
        public int FunExecuteNonQuerySP(string Command, params SqlParameter[] parameters)
        {
            OpenConn();

            Sqlcmd = new SqlCommand(Command, SqlConn);
            Sqlcmd.CommandType = CommandType.StoredProcedure;

            if (parameters != null && parameters.Length > 0)
            {
                foreach (var p in parameters)
                    Sqlcmd.Parameters.Add(p);
            }
            try { a = Sqlcmd.ExecuteNonQuery(); }
            catch (Exception ex) { OnError(ex); }
            finally { CloseConn(); }
            return a;
        }
        #endregion

        #region Function for Store Procedure ExecuteScalar (Fetch a single value)
        public object FunExecuteScalarSP(string Command, params SqlParameter[] parameters)
        {
            OpenConn();
            Sqlcmd = new SqlCommand(Command, SqlConn);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null && parameters.Length > 0)
            {
                foreach (var p in parameters)
                    Sqlcmd.Parameters.Add(p);
            }
            try
            {
                ab = Sqlcmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
            finally
            {
                CloseConn();
            }
            return ab;
        }
        #endregion

        #region Function For StoreProcedure DataTable  (Disconnected Mode)
        public DataTable FunDataTableSP(string Command, params SqlParameter[] parameters)
        {
            OpenConn();
            SqlDa = new SqlDataAdapter(Command, SqlConn);
            SqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (parameters != null && parameters.Length > 0)
            {
                foreach (var p in parameters)
                    SqlDa.SelectCommand.Parameters.Add(p);
            }
            Dt = new DataTable();
            try
            {
                SqlDa.Fill(Dt);
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
            finally
            {
                CloseConn();
            }
            return Dt;
        }
        #endregion

        #region Function for StoreProcedure Dataset for Disconnected Mode
        public DataSet FunDataSetSP(string Commmand, params SqlParameter[] parameters)
        {
            OpenConn();
            SqlDa = new SqlDataAdapter(Commmand, SqlConn);
            if (parameters != null && parameters.Length > 0)
            {
                foreach (var p in parameters)
                    Sqlcmd.Parameters.Add(p);
            }
            Ds = new DataSet();
            try
            {
                SqlDa.Fill(Ds);
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
            finally
            {
                CloseConn();
            }
            return Ds;

        }
        #endregion

        #region Function for SQLParaMeter
        public SqlParameter SqlParam(string Pname, object Pvalue, SqlDbType Ptype)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = Pname;
            param.Value = Pvalue;
            param.SqlDbType = Ptype;
            return param;
        }
        #endregion

        #region Function for Bind_DropDown
        public void Bind_DropDown(string SqlCommand, string DataTextField, string DataValueField, System.Web.UI.WebControls.DropDownList DDL)
        {
            OpenConn();
            Sqlcmd = new SqlCommand(SqlCommand, SqlConn);
            //Sqlcmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDr = Sqlcmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
            DDL.DataSource = SqlDr;
            DDL.Items.Clear();
            DDL.Items.Add("-- Please select --");
            DDL.DataTextField = DataTextField;
            DDL.DataValueField = DataValueField;
            DDL.Items.Add("Others");
            DDL.DataBind();
            CloseConn();
        }
        #endregion

        #region
        public void OnError(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("error.txt"), append: true))
            {
                sw.WriteLine(ex);
                sw.WriteLine("-----------------" + DateTime.Now + "-----------------");
                sw.Close();
                HttpContext.Current.Response.Write(
                    "<div style='padding:80px 80px; margin:100px;'>" +
                    "<img src='img/error.png' alt='error' width = '10%' /><br>" +
                    "<div style='padding:5px 5px;background-color:#7f7f7f;width:50%;'><h1>Oops!</h1>" +
                    "<h2>I'm afraid, something went wrong.</h2></div>" +
                    "<h4><a href='./'>Take me home</a></h4></div><div style='display:none;'>"
                    );
            }
        }
        #endregion
    }
}

