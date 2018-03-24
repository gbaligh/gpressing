using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace GP
{
    public class TB_Famille
    {
        #region Variables
        private string _Code;
        private string _Libelle;
        private string _Description;
        
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        public string Libelle
        {
            get { return _Libelle; }
            set { _Libelle = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value;}
        }
        #endregion

        public TB_Famille()
        {
        }

        public TB_Famille(string Code)
        {
            FindByKey(Code);
        }

        public static List<TB_Famille> GetList()
        {
            List<TB_Famille> list = new List<TB_Famille>();
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Famille\"");
            while (reader.Read())
            {
                TB_Famille f = new TB_Famille();
                f.Code = (string)reader["Code"];
                f.Libelle = (string)reader["Libelle"];
                f.Description = reader["Description"]!=DBNull.Value?(string)reader["Description"]:"------------";
                list.Add(f);
            }
            return list;
        }

        public bool FindByKey(string Code)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Famille\" WHERE \"Code\"='" + Code + "'");
            if (reader.Read())
            {
                this.Code = Code;
                this.Libelle = (string)reader["Libelle"];
                this.Description = reader["Description"]!=DBNull.Value?(string)reader["Description"]:"------------";
                return true;
            }
            return false;
        }

        public Int32 SaveData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.CommandText = "INSERT INTO \"Famille\" (\"Code\", \"Libelle\", \"Description\")" +
                "VALUES(:code,:libelle,:description)";
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":libelle", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":description", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":code", DbType.String));
            command.Parameters[0].Value = this.Libelle;
            command.Parameters[1].Value = this.Description;
            command.Parameters[2].Value = this.Code;
            return dataBase.ExecuteCommand(command);
        }


        public Int32 UpdateData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.CommandText = "UPDATE \"Famille\" SET \"Libelle\"=:libelle, \"Description\"=:description WHERE \"Code\"=:code";
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":libelle", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":description", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":code", DbType.String));
            command.Parameters[0].Value = this.Libelle;
            command.Parameters[1].Value = this.Description;
            command.Parameters[2].Value = this.Code;
            return dataBase.ExecuteCommand(command);
        }
        
        public Int32 DeleteData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            return dataBase.ExecuteNonQuery("DELETE FROM \"Famille\" WHERE \"Code\"='" + this.Code + "'");
        }

        
        public string GenerateCode()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            long count = (Int64)dataBase.executeScalar("SELECT count(*) FROM \"Famille\"");

            string code = "F_"+count.ToString();

            while(FindByKey(code))
            {
               count++;
               code = "F_" + count.ToString();
            }
            

            this.Code = code;
            return code;
        }
    }
}
