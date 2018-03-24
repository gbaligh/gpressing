using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace GP
{
    public class ListAF
    {
        public ListAF()
        {
            
        }

        public static List<ListAF> GetList()
        {
            List<ListAF> list = new List<ListAF>(); ;
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Ar_Fac\"");
            while (reader.Read())
            {
                ListAF s = new ListAF();
                s.Quantite = (int)reader["Quantite"];
                s.Operation = (string)reader["Operation"];
                s.Code_Article = (string)reader["Code_Article"];
                s.Code_Facture = (string)reader["Code_Facture"];
                s.Prix = (decimal)reader["Prix"];
                list.Add(s);
            }
            return list;
        }

        public static List<ListAF> GetList(string CodeFacture)
        {
            List<ListAF> list = new List<ListAF>(); ;
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Ar_Fac\" WHERE \"Code_Facture\"='" + CodeFacture + "'");
            while (reader.Read())
            {
                ListAF s = new ListAF();
                s.Quantite = (int)reader["Quantite"];
                s.Operation = (string)reader["Operation"];
                s.Code_Article = (string)reader["Code_Article"];
                s.Code_Facture = (string)reader["Code_Facture"];
                s.Prix = (decimal)reader["Prix"];
                list.Add(s);
            }
            return list;
        }

        public void deleteData(string CodeFacture)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            dataBase.ExecuteNonQuery("DELETE FROM \"Ar_Fac\" Where \"Code_Facture\"='" + CodeFacture + "'");
        }


        public void saveData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.CommandText = "INSERT INTO \"Ar_Fac\" (\"Code_Article\", \"Code_Facture\", \"Operation\", \"Quantite\", \"Prix\")" +
                " VALUES(:codeA,:codeF,:oper,:qua,:prix)";
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":codeA", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":codeF", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":oper", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":qua", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prix", DbType.String));
            command.Parameters[0].Value = this.Code_Article;
            command.Parameters[1].Value = this.Code_Facture;
            command.Parameters[2].Value = this.Operation;
            command.Parameters[3].Value = this.Quantite;
            command.Parameters[4].Value = this.Prix;
            dataBase.ExecuteCommand(command);
        }

        private string _Code_Article;
        private string _Code_Famille;
        private string _Code_Facture;
        private string _Libelle_Famille;
        private string _Libelle_Article;
        public TB_Articles article = new TB_Articles();
        public TB_Facture facture = new TB_Facture();
        public TB_Famille famille = new TB_Famille();
        private int _Quantite;
        private decimal _Prix_Operation;
        private int _Code_Operation;
        private string _Operation;


        public int Quantite
        {
            get { return _Quantite; }
            set { _Quantite = value; }
        }
        public string Code_Article
        {
            get { return _Code_Article; }
            set 
            { 
                _Code_Article = value;
                article.FindByKey(value);
            }
        }
        public string Code_Facture
        {
            get { return _Code_Facture; }
            set 
            { 
                _Code_Facture = value;
                facture.FindByKey(value);
            }
        }
        public string Code_Famille
        {
            get { return _Code_Famille; }
            set { _Code_Famille = value; }
        }
        public string Libelle_Famille
        {
            get { return _Libelle_Famille; }
            set { _Libelle_Famille = value; }
        }
        public string Libelle_Article
        {
            get { return _Libelle_Article; }
            set { _Libelle_Article = value; }
        }
        public decimal Prix
        {
            get { return _Prix_Operation; }
            set { _Prix_Operation = value; }
        }
        public int Code_Operation
        {
            get { return _Code_Operation; }
            set { _Code_Operation = value; }
        }
        public string Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }
}
