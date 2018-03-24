using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace GP
{
    public class TB_Facture
    {
        #region Variables
        private string _Code;
        private DateTime _Date_Recu;
        private DateTime _Date_livraison;
        private double _Prix_Total;
        private double _Prix_Partiel;
        private TB_Client _Client;
        private string _Mode_Payement;
        private string _Etat;
        private string _Livree;
        private DateTime _Date_Sortie;
        private DateTime _Date_Payement;

        public string Livree
        {
            get { return _Livree; }
            set { _Livree = value; }
        }

        public DateTime Date_Sortie
        {
            get { return _Date_Sortie; }
            set { _Date_Sortie = value; }
        }

        public DateTime Date_Payement
        {
            get { return _Date_Payement; }
            set { _Date_Payement = value; }
        }

        public string Etat
        {
            get { return _Etat; }
            set { _Etat = value; }
        }
        
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        public DateTime Date_Recu
        {
            get { return _Date_Recu; }
            set { _Date_Recu = value; }
        }
        public DateTime Date_livraison
        {
            get { return _Date_livraison; }
            set { _Date_livraison = value;}
        }
        public double Prix_Total
        {
            get { return _Prix_Total; }
            set { _Prix_Total = value; }
        }
        public double Prix_Partiel
        {
            get { return _Prix_Partiel; }
            set { _Prix_Partiel = value; }
        }
        public TB_Client Client
        {
            get {return _Client;}
            set {_Client = value;}
        }
        public string Mode_Payement
        {
            get {return _Mode_Payement;}
            set {_Mode_Payement = value;}
        }
        #endregion

        public TB_Facture()
        {
        }

        public TB_Facture(string Code)
        {
            FindByKey(Code);
        }


        public static List<TB_Facture> GetList()
        {
            List<TB_Facture> list = new List<TB_Facture>();
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Facture\"");
            while (reader.Read())
            {
                TB_Facture f = new TB_Facture();
                f.Code = (string)reader["Code"];
                f.Date_Recu = (DateTime)reader["Date_Recu"];
                f.Date_livraison = (DateTime)reader["Date_Livraison"];
                f.Prix_Total = (double)reader["Prix_Total"];
                f.Prix_Partiel = (double)reader["Prix_Partiel"];
                f.Client = new TB_Client((string)reader["Code_Client"]);
                f.Mode_Payement = (string)reader["Mode_Payement"];
                f.Livree = (string)reader["Livree"];
                f.Date_Payement = /*reader["Date_Payement"] is DBNull ?  :*/ (DateTime)reader["Date_Payement"];
                f.Date_Sortie = /*reader["Date_Sortie"] is DBNull ? null : */(DateTime)reader["Date_Sortie"];
                list.Add(f);
            }
            return list;
        }



        public bool FindByKey(string Code)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Facture\" WHERE \"Code\"='" + Code + "'");
            if (reader.Read())
            {
                this.Code = (string)reader["Code"];
                this.Date_Recu = (DateTime)reader["Date_Recu"];
                this.Date_livraison = (DateTime)reader["Date_Livraison"];
                this.Prix_Total = (double)reader["Prix_Total"];
                this.Prix_Partiel = (double)reader["Prix_Partiel"];
                this.Client = new TB_Client((string)reader["Code_Client"]);
                this.Mode_Payement = (string)reader["Mode_Payement"];
                this.Etat = (string)reader["Etat"];
                this.Livree = (string)reader["Livree"];
                this.Date_Payement = (DateTime)reader["Date_Payement"];
                this.Date_Sortie = (DateTime)reader["Date_Sortie"];
                return true;
            }
            return false;
        }

        public Int32 SaveData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.CommandText = "INSERT INTO \"Facture\" (\"Code\", \"Date_Recu\", \"Date_Livraison\", \"Prix_Total\", \"Prix_Partiel\", \"Code_Client\", \"Mode_Payement\", \"Etat\", \"Livree\", \"Date_Sortie\", \"Date_Payement\" )" +
                "VALUES(:code,:date_recu,:date_livraison,:prix_total,:prix_partiel,:code_client,:mode_payement,:etat,:livree,:datesortie,:datepayement)";
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":code", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":date_recu", DbType.DateTime));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":date_livraison", DbType.DateTime));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prix_total",DbType.Double));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prix_partiel", DbType.Double));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":code_client", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":mode_payement", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":etat", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":livree", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":datesortie", DbType.DateTime));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":datepayement", DbType.DateTime));
            command.Parameters[0].Value = this.Code;
            command.Parameters[1].Value = this.Date_Recu;
            command.Parameters[2].Value = this.Date_livraison;
            command.Parameters[3].Value = this.Prix_Total;
            command.Parameters[4].Value = this.Prix_Partiel;
            command.Parameters[5].Value = this.Client.Code;
            command.Parameters[6].Value = this.Mode_Payement;
            command.Parameters[7].Value = this.Etat;
            command.Parameters[8].Value = this.Livree;
            command.Parameters[9].Value = this.Date_Sortie;
            command.Parameters[10].Value = this.Date_Payement;
            return dataBase.ExecuteCommand(command);
        }


        public Int32 UpdateData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.CommandText = "UPDATE \"Facture\" SET \"Date_Recu\"=:dater, \"Date_Livraison\"=:datel, \"Prix_Total\"=:prixt, \"Prix_Partiel\"=:prixp, \"Code_Client\"=:codec, \"Mode_Payement\"=:modep, \"Etat\"=:etat," +
                " \"Livree\"=:livree, \"Date_Sortie\"=:datesortie, \"Date_Payement\"=:datepayement"+
                " WHERE \"Code\"=:code";
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":code", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":dater", DbType.DateTime));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":datel", DbType.DateTime));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prixt", DbType.Double));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":prixp", DbType.Double));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":codec", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":modep", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":etat", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":livree", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":datesortie", DbType.DateTime));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":datepayement", DbType.DateTime));
            command.Parameters[0].Value = this.Code;
            command.Parameters[1].Value = this.Date_Recu;
            command.Parameters[2].Value = this.Date_livraison;
            command.Parameters[3].Value = this.Prix_Total;
            command.Parameters[4].Value = this.Prix_Partiel;
            command.Parameters[5].Value = this.Client.Code;
            command.Parameters[6].Value = this.Mode_Payement;
            command.Parameters[7].Value = this.Etat;
            command.Parameters[8].Value = this.Livree;
            command.Parameters[9].Value = this.Date_Sortie;
            command.Parameters[10].Value = this.Date_Payement;
            return dataBase.ExecuteCommand(command);
        }
        
        public Int32 DeleteData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            return dataBase.ExecuteNonQuery("DELETE FROM \"Facture\" WHERE \"Code\"='" + this.Code + "'");
        }

        
        public string GenerateCode(params string[] args)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            long count = (Int64)dataBase.executeScalar("SELECT count(*) FROM \"Facture\"");
            string prefix = GlobalVars.PrefixFacture;
            string premier = GlobalVars.PremierFacture;
            count = count > 0 ? count : int.Parse(premier);
            foreach (string s in args)
            {
                prefix += s[0];
            }
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
