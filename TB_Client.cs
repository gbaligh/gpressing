using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace GP
{
    public class TB_Client
    {
        #region Variables
        private string _Code;
        private string _Nom;
        private string _Prenom;
        private string _NTel;
        private string _Adresse;
        private bool _Existe = false;
        public bool Existe
        {
            get { return _Existe; }
        }
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }
        public string Prenom
        {
            get { return _Prenom; }
            set { _Prenom = value;}
        }
        public string NTel
        {
            get { return _NTel; }
            set { _NTel = value; }
        }
        public string Adresse
        {
            get { return _Adresse; }
            set { _Adresse = value; }
        }
        #endregion

        public TB_Client()
        {
        }

        public TB_Client(string Code)
        {
            FindByKey(Code);
        }

        public static List<TB_Client> GetList()
        {
            List<TB_Client> list = new List<TB_Client>();
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Client\"");
            while (reader.Read())
            {
                TB_Client c = new TB_Client();
                c.Code = (string)reader["Code"];
                c.Nom = (string)reader["Nom"];
                c.Prenom = (string)reader["Prenom"];
                c.NTel = (string)reader["Tel"];
                c.Adresse = (string)reader["Adresse"];
                list.Add(c);
            }
            return list;
        }

        public bool FindByKey(string Code)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Client\" WHERE \"Code\"='" + Code + "'");
            if (reader.Read())
            {
                this.Code = Code;
                this.Nom = (string)reader["Nom"];
                this.Prenom = (string)reader["Prenom"];
                this.NTel = (string)reader["Tel"];
                this.Adresse = (string)reader["Adresse"];
                return true;
            }
            return false;
        }

        public Int32 SaveData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.CommandText = "INSERT INTO \"Client\" (\"Code\", \"Nom\", \"Prenom\", \"Tel\", \"Adresse\")" +
                "VALUES(:code,:nom,:prenom,:tel,:adresse)";
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":nom", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prenom", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":tel",DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":adresse", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":code", DbType.String));
            command.Parameters[0].Value = this.Nom;
            command.Parameters[1].Value = this.Prenom;
            command.Parameters[2].Value = this.NTel;
            command.Parameters[3].Value = this.Adresse;
            command.Parameters[4].Value = this.Code;
            return dataBase.ExecuteCommand(command);
        }


        public Int32 UpdateData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.CommandText = "UPDATE \"Client\" SET \"Nom\"=:nom, \"Prenom\"=:prenom, \"Tel\"=:tel, \"Adresse\"=:adresse WHERE \"Code\"=:code";
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":nom", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prenom", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":tel",DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":adresse", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":code", DbType.String));
            command.Parameters[0].Value = this.Nom;
            command.Parameters[1].Value = this.Prenom;
            command.Parameters[2].Value = this.NTel;
            command.Parameters[3].Value = this.Adresse;
            command.Parameters[4].Value = this.Code;
            return dataBase.ExecuteCommand(command);
        }
        
        public Int32 DeleteData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            return dataBase.ExecuteNonQuery("DELETE FROM \"Client\" WHERE \"Code\"='" + this.Code + "'");
        }

        
        public string GenerateCode()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            string prefix = string.Empty;
            long count = (Int64)dataBase.executeScalar("SELECT count(*) FROM \"Client\"");

            prefix = GlobalVars.PrefixClient;
            string code = prefix + count.ToString();

            while(FindByKey(code))
            {
               count++;
               code = prefix + count.ToString();
            }
            this.Code = code;
            return code;
        }

    }
}
