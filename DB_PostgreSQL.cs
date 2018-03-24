using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace GP
{
    class DB_PostgreSQL
    {
        #region Variables & Constants
        protected string connString = GlobalVars.connString;
            
            
        private NpgsqlConnection conn;
        protected Boolean m_cnnOpen = false;
        #endregion

        public DB_PostgreSQL()
        {
            NpgsqlEventLog.Level = LogLevel.None;
            NpgsqlEventLog.LogName = "Npgsql_LogFile.txt";
            NpgsqlEventLog.EchoMessages = true;
            conn = new NpgsqlConnection(connString);
        }

        ~DB_PostgreSQL()
        {
            conn.Close();
        }
        public bool testConnection(string connString)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool testConnection()
        {
            if (!m_cnnOpen)
            {
                try
                {
                    conn.Open();
                    m_cnnOpen = true;
                    closeConnection();
                    return true;
                }
                catch (Exception)
                {
                    m_cnnOpen = false;
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public string strPostgresVersion()
        {
            String serverver = "Unknown";

            if (!m_cnnOpen)
            {
                try
                {
                    conn.Open();
                    m_cnnOpen = true;
                }
                catch (InvalidOperationException)
                {
                    conn.Open();
                    m_cnnOpen = true;
                }
            }

            if (m_cnnOpen)
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT version()", conn);
                try
                {
                    serverver = (String)command.ExecuteScalar();
                }
                finally
                {
                    command.Dispose();
                }
            }
            return serverver;
        }

        public void closeConnection()
        {
            if (m_cnnOpen)
            {
                conn.Close();
                m_cnnOpen = false;
            }

        }

        public object executeScalar(string strSQL)
        {

            if (!m_cnnOpen)
            {
                conn.Open();
                m_cnnOpen = true;
            }

            NpgsqlCommand command = new NpgsqlCommand(strSQL, conn);

            try
            {
                object result = command.ExecuteScalar();

                return result;
            }

            finally
            {
                conn.Close();
                m_cnnOpen = false;
                command.Dispose();
            }
        }

        public Int32 ExecuteNonQueryBlob(string strSQL, byte[] bBlob)
        {
            if (!m_cnnOpen)
            {
                conn.Open();
            }

            NpgsqlCommand command = new NpgsqlCommand(strSQL, conn);
            NpgsqlParameter param = new NpgsqlParameter(":photo", DbType.Binary);

            param.Value = bBlob;

            command.Parameters.Add(param);

            Int32 rowsaffected;

            try
            {
                rowsaffected = command.ExecuteNonQuery();
                return rowsaffected;
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show(ex.GetBaseException().ToString());
                return 999;         //Error
            }

            finally
            {
                conn.Close();
                m_cnnOpen = false;
                command.Dispose();
            }
        }

        public Int32 ExecuteCommand(NpgsqlCommand command)
        {
            if (!m_cnnOpen)
            {
                conn.Open();
            }

            Int32 rowsaffected;
            command.Connection = conn;

            try
            {
                //command.Prepare();
                rowsaffected = command.ExecuteNonQuery();
                return rowsaffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +" => "+ command.CommandText);
                return 999;
            }

            finally
            {
                conn.Close();
                m_cnnOpen = false;
                command.Dispose();
            }
        }

        public Int32 ExecuteNonQuery(string strSQL)
        {
            if (!m_cnnOpen)
            {
                conn.Open();
            }

            NpgsqlCommand command = new NpgsqlCommand(strSQL, conn);
            Int32 rowsaffected;

            try
            {
                rowsaffected = command.ExecuteNonQuery();
                return rowsaffected;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.GetBaseException().ToString());
                throw ex;         //Error
            }

            finally
            {
                conn.Close();
                m_cnnOpen = false;
                command.Dispose();
            }
        }

        public DataSet returnDataSet(string strSQL)
        {
            if (!m_cnnOpen)
            {
                conn.Open();
                m_cnnOpen = true;
            }

            DataSet ds = new DataSet();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSQL, conn);
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }
        /**
         * GASMI Baligh
         * 4/10/2006
         * formated string sql for postgres 8.1
         * 
         * */
        public DataSet returnDataSet(string strSQL,params object[] args)
        {
            if (!m_cnnOpen)
            {
                conn.Open();
                m_cnnOpen = true;
            }

            DataSet ds = new DataSet();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandText = strSQL;
            for (int i = 0; i < args.Length; i += 3)
            {
                command.Parameters.Add(new NpgsqlParameter((string)args[i], (DbType)args[i + 1]));
                command.Parameters[command.Parameters.Count - 1].Value = args[i + 2];
            }

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }


        public NpgsqlDataReader returnDataReader(string strSQL)
        {
            NpgsqlCommand command = new NpgsqlCommand(strSQL, conn);

            if (!m_cnnOpen)
            {
                try
                {
                    conn.Open();
                    m_cnnOpen = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Un problème de connexion à la Base des Données." + ex.ToString());
                }
            }

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.GetBaseException().ToString());
                return null;         //Error
            }
            finally
            {
                conn.Close();
                m_cnnOpen = false;
            }

        }

        #region executeDataFunction
        public NpgsqlDataReader executeDataSetFunction(string strFNC)
        {

            if (!m_cnnOpen)
            {
                conn.Open();
                m_cnnOpen = true;
            }

            try
            {
                NpgsqlCommand command = new NpgsqlCommand(strFNC, conn);
                command.CommandType = CommandType.StoredProcedure;
                NpgsqlDataReader result = command.ExecuteReader();

                return result;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.GetBaseException().ToString());
                return null;         //Error
            }

            finally
            {
                //conn.Close();
                //m_cnnOpen = false;
            }

        }
        #endregion

        #region executeScalarFunction
        public Object executeScalarFunction(string strFNC)
        {

            if (!m_cnnOpen)
            {
                conn.Open();
                m_cnnOpen = true;
            }

            try
            {
                NpgsqlCommand command = new NpgsqlCommand(strFNC, conn);
                command.CommandType = CommandType.StoredProcedure;
                object result = command.ExecuteScalar();

                return result;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.GetBaseException().ToString());
                return 999;         //Error
            }

            finally
            {
                conn.Close();
                m_cnnOpen = false;
            }

        }
        #endregion
    }
}
