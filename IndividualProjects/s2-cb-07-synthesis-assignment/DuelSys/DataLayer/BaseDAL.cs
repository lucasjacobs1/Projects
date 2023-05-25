using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public abstract class BaseDAL
    {
        private MySqlConnection DatabaseConnection;

        protected BaseDAL()
        {
            string DatabaseConnection = "Server = studmysql01.fhict.local; Uid = dbi490692; Database = dbi490692; Pwd = apengaaier123";
            this.DatabaseConnection = new MySqlConnection(DatabaseConnection);
        }

        protected MySqlConnection GetDBConnection()
        {
            return this.DatabaseConnection;
        }

        //Types of queries
        public void CloseConnection()
        {
            if (this.DatabaseConnection.State == System.Data.ConnectionState.Open)
            {
                this.DatabaseConnection.Close();
            }
        }

        public void CloseDataReader(MySqlDataReader dr)
        {
            if(dr != null)
            {
                dr.Close();
            }
        }

        public int ExecuteNonQuery(MySqlCommand sqlNonQueryCommand)
        {
            try
            {
                this.DatabaseConnection.Open();
                int numberAffectedRows = sqlNonQueryCommand.ExecuteNonQuery();

                return numberAffectedRows;
            }
            finally
            {
                if (this.DatabaseConnection.State == System.Data.ConnectionState.Open)
                {
                    this.DatabaseConnection.Close();
                }
            }
        }

        public MySqlDataReader OpenExecuteReader(MySqlCommand sqlReaderCommand)
        {
            this.DatabaseConnection.Open();
            MySqlDataReader reader = sqlReaderCommand.ExecuteReader();
            return reader;
        }

        public void CloseExecuteReader(MySqlDataReader reader)
        {
            try
            {
                if (reader != null)
                    reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (this.DatabaseConnection.State == System.Data.ConnectionState.Open)
                {
                    this.DatabaseConnection.Close();
                }
            }
        }
    }
}
