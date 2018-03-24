using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace GP
{
    public class TB_Articles
    {
        #region Variables

        private string _Code;
        private bool _Print;
        private string _Libelle;
        private decimal _N_Pieces;
        private string _Description;
        private decimal _Prix_Pressing;
        private decimal _Prix_Repassage;
        private decimal _Prix_Tenture;
        private decimal _Prix_Autre;
        private string  _Code_Famille;
        public TB_Famille Famille = new TB_Famille();
        public bool Pressing = false;
        public bool Repassage = false;
        public bool Tenture = false;
        public bool Autre = false;
        private byte[] _Photo;

        public bool Print
        {
            get { return(_Print); }
            set { _Print = value; }
        }

        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        public string Nom_Famille
        {
            get { return Famille.Libelle; }
        }

        public string Libelle
        {
            get { return _Libelle; }
            set { _Libelle = value; }
        }
        public decimal N_Pieces
        {
            get { return _N_Pieces; }
            set { _N_Pieces = value;}
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public decimal Prix_Pressing
        {
            get { return _Prix_Pressing; }
            set 
            { 
                _Prix_Pressing = value;
                if (value > 0) Pressing = true;
                else Pressing = false;
            }
        }
        public decimal Prix_Repassage
        {
            get {return _Prix_Repassage;}
            set 
            {
                _Prix_Repassage = value;
                if (value > 0) Repassage = true;
                else Repassage = false;
            }
        }
        public decimal Prix_Tenture
        {
            get {return _Prix_Tenture;}
            set 
            {
                _Prix_Tenture = value;
                if (value > 0) Tenture = true;
                else Tenture = false;
            }
        }
        public decimal Prix_Autre
        {
            get {return _Prix_Autre;}
            set 
            {
                _Prix_Autre = value;
                if (value > 0) Autre = true;
                else Autre = false;
            }
        }
        public string Code_Famille
        {
            get 
            {
                return _Code_Famille;
            }
            set 
            {
                _Code_Famille = value;
                Famille.FindByKey(_Code_Famille);
            }
        }
        public byte[] Photo
        {
            get {return _Photo;}
            set {_Photo = value;}
        }

        #endregion

        public TB_Articles()
        {
        }

        public TB_Articles(string Code)
        {
            FindByKey(Code);
        }

        public static List<TB_Articles> GetList(string Code_Famille,string Op)
        {
            List<TB_Articles> list = new List<TB_Articles>();
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Articles\" WHERE \"Code_Famille\"='" + Code_Famille + "'");
            while (reader.Read())
            {
                TB_Articles a = new TB_Articles();
                a.Code = (string)reader["Code"];
                a.Libelle = (string)reader["Libelle"];
                a.N_Pieces = (int)reader["N_Pieces"];
                a.Description = (string)reader["Description"];
                a.Prix_Pressing = (decimal)reader["Prix_Pressing"];
                a.Prix_Repassage = (decimal)reader["Prix_Repassage"];
                a.Prix_Tenture = (decimal)reader["Prix_Tenture"];
                a.Prix_Autre = (decimal)reader["Prix_Autre"];
                a.Code_Famille = (string)reader["Code_Famille"];
                a.Print = (bool)reader["Print"];
                a.Photo = reader["Photo"] != DBNull.Value ? (byte[])reader["Photo"] : null;
                if (Op != string.Empty)
                {
                    if ((Op == "Pressing") & (a.Pressing))
                        list.Add(a);
                    if ((Op == "Repassage") & (a.Repassage))
                        list.Add(a);
                    if ((Op == "Tenture") & (a.Tenture))
                        list.Add(a);
                    if ((Op == "Autre") & (a.Autre))
                        list.Add(a);
                }
                else
                    list.Add(a);
            }
            return list;
        }

        public static List<TB_Articles> GetList(string searchString)
        {
            List<TB_Articles> list = new List<TB_Articles>();
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Articles\" WHERE "+searchString);
            while (reader.Read())
            {
                TB_Articles a = new TB_Articles();
                a.Code = (string)reader["Code"];
                a.Libelle = (string)reader["Libelle"];
                a.N_Pieces = (int)reader["N_Pieces"];
                a.Description = (string)reader["Description"];
                a.Prix_Pressing = (decimal)reader["Prix_Pressing"];
                a.Prix_Repassage = (decimal)reader["Prix_Repassage"];
                a.Prix_Tenture = (decimal)reader["Prix_Tenture"];
                a.Prix_Autre = (decimal)reader["Prix_Autre"];
                a.Code_Famille = (string)reader["Code_Famille"];
                a.Print = (bool)reader["Print"];
                a.Photo = reader["Photo"] != DBNull.Value ? (byte[])reader["Photo"] : null;
                list.Add(a);
            }
            return list;
        }


        public static List<TB_Articles> GetList()
        {
            List<TB_Articles> list = new List<TB_Articles>();
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Articles\"");
            while (reader.Read())
            {
                TB_Articles a = new TB_Articles();
                a.Code = (string)reader["Code"];
                a.Libelle = (string)reader["Libelle"];
                a.N_Pieces = (int)reader["N_Pieces"];
                a.Description = (string)reader["Description"];
                a.Prix_Pressing = (decimal)reader["Prix_Pressing"];
                a.Prix_Repassage = (decimal)reader["Prix_Repassage"];
                a.Prix_Tenture = (decimal)reader["Prix_Tenture"];
                a.Prix_Autre = (decimal)reader["Prix_Autre"];
                a.Code_Famille = (string)reader["Code_Famille"];
                a.Print = (bool)reader["Print"];
                a.Photo = reader["Photo"]!=DBNull.Value?(byte[])reader["Photo"]:null;
                list.Add(a);
            }
            return list;
        }

        public bool FindByKey(string Code)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Articles\" WHERE \"Code\"='" + Code + "'");
            if (reader.Read())
            {
                this.Code = (string)reader["Code"];
                this.Libelle = (string)reader["Libelle"];
                this.N_Pieces = (int)reader["N_Pieces"];
                this.Description = (string)reader["Description"];
                this.Prix_Pressing = (decimal)reader["Prix_Pressing"];
                this.Prix_Repassage = (decimal)reader["Prix_Repassage"];
                this.Prix_Tenture = (decimal)reader["Prix_Tenture"];
                this.Prix_Autre = (decimal)reader["Prix_Autre"];
                this.Code_Famille = (string)reader["Code_Famille"];
                this.Print = (Boolean)reader["Print"];
                this.Photo = reader["Photo"] != DBNull.Value ? (byte[])reader["Photo"] : null;
                return true;
            }
            return false;
        }



        public Int32 SaveData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.CommandText = "INSERT INTO \"Articles\" (\"Code\"," +
                " \"Libelle\"," +
                " \"N_Pieces\"," +
                " \"Description\"," +
                " \"Prix_Pressing\"," +
                " \"Prix_Repassage\"," +
                " \"Prix_Tenture\"," +
                " \"Prix_Autre\"," +
                " \"Code_Famille\"," +
                " \"Photo\"," +
                " \"Pressing\"," +
                " \"Repassage\"," +
                " \"Tenture\"," +
                " \"Autre\"," +
                " \"Print\") "+
                "VALUES(:code, " +
                ":libelle, " +
                ":n_pieces, " +
                ":description, " +
                ":prixpressing, " +
                ":prixrepassage, " +
                ":prixtenture, " +
                ":prixautre, " +
                ":codef, " +
                ":photo, " +
                ":pressing, " +
                ":repassage, " +
                ":tenture, " +
                ":autre, "+
                ":print)";

            command.Parameters.Add(new Npgsql.NpgsqlParameter(":code", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":libelle", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":n_pieces", DbType.Decimal));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":description",DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prixpressing", DbType.Decimal));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prixrepassage", DbType.Decimal));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prixtenture", DbType.Decimal));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prixautre", DbType.Decimal));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":codef", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":pressing", DbType.Boolean));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":repassage", DbType.Boolean));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":tenture", DbType.Boolean));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":autre", DbType.Boolean));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":photo", DbType.Binary));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":print", DbType.Boolean));
            command.Parameters[0].Value = this.Code;
            command.Parameters[1].Value = this.Libelle;
            command.Parameters[2].Value = this.N_Pieces;
            command.Parameters[3].Value = this.Description;
            command.Parameters[4].Value = this.Prix_Pressing;
            command.Parameters[5].Value = this.Prix_Repassage;
            command.Parameters[6].Value = this.Prix_Tenture;
            command.Parameters[7].Value = this.Prix_Autre;
            command.Parameters[8].Value = this.Code_Famille;
            command.Parameters[9].Value = this.Pressing;
            command.Parameters[10].Value = this.Repassage;
            command.Parameters[11].Value = this.Tenture;
            command.Parameters[12].Value = this.Autre;
            command.Parameters[13].Value = this.Photo;
            command.Parameters[14].Value = this.Print;
            return dataBase.ExecuteCommand(command);
        }


        public Int32 UpdateData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.CommandText = "UPDATE \"Articles\" SET \"Libelle\"=:libelle,"+
                " \"N_Pieces\"=:npieces,"+
                " \"Description\"=:description,"+
                " \"Prix_Pressing\"=:prixpressing,"+
                " \"Prix_Repassage\"=:prixrepassage,"+
                " \"Prix_Tenture\"=:prixtenture," +
                " \"Prix_Autre\"=:prixautre,"+
                " \"Code_Famille\"=:codef,"+
                " \"Photo\"=:photo,"+
                " \"Pressing\"=:pressing," +
                " \"Repassage\"=:repassage," +
                " \"Tenture\"=:tenture," +
                " \"Autre\"=:autre," +
                " \"Print\"=:print" +
                " WHERE \"Code\"=:cde";

            command.Parameters.Add(new Npgsql.NpgsqlParameter(":cde", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":libelle", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":npieces", DbType.Decimal));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":description",DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prixpressing", DbType.Decimal));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prixrepassage", DbType.Decimal));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prixtenture", DbType.Decimal));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prixautre", DbType.Decimal));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":codef", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":photo", DbType.Binary));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":pressing", DbType.Boolean));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":repassage", DbType.Boolean));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":tenture", DbType.Boolean));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":autre", DbType.Boolean));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":print", DbType.Boolean));
            command.Parameters[0].Value = this.Code;
            command.Parameters[1].Value = this.Libelle;
            command.Parameters[2].Value = this.N_Pieces;
            command.Parameters[3].Value = this.Description;
            command.Parameters[4].Value = this.Prix_Pressing;
            command.Parameters[5].Value = this.Prix_Repassage;
            command.Parameters[6].Value = this.Prix_Tenture;
            command.Parameters[7].Value = this.Prix_Autre;
            command.Parameters[8].Value = this.Code_Famille;
            command.Parameters[9].Value = this.Photo;
            command.Parameters[10].Value = this.Pressing;
            command.Parameters[11].Value = this.Repassage;
            command.Parameters[12].Value = this.Tenture;
            command.Parameters[13].Value = this.Autre;
            command.Parameters[14].Value = this.Print;
            return dataBase.ExecuteCommand(command);
        }
        
        public Int32 DeleteData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            dataBase.ExecuteNonQuery("DELETE FROM \"Ar_Fac\" WHERE \"Code_Article\"='" + this.Code + "'");
            return dataBase.ExecuteNonQuery("DELETE FROM \"Articles\" WHERE \"Code\"='" + this.Code + "'");
        }

        
        public string GenerateCode(string libelle)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            long count = (Int64)dataBase.executeScalar("SELECT count(*) FROM \"Articles\"");

            string prefix = libelle != string.Empty ? libelle[0] + "_" : "_";
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
