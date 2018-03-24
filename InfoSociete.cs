using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace GP
{
    class InfoSociete
    {
        #region Les Variables
        private string _nom;
        private string _adresse;
        private string _tel;
        private string _fax;
        private byte[] _logo;
        private bool _existe = false;
        public string nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public string adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        public string fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        public byte[] logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
        public bool existe
        {
            get { return _existe; }
        }
        #endregion

        private DB_PostgreSQL dataBase = new DB_PostgreSQL();
        
        
        public InfoSociete()
        {
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Info_Societe\"");
            if (reader.Read())
            {
                this.nom = (string)reader["Nom"];
                this.adresse = (string)reader["Adresse"];
                this.tel = (string)reader["Tel"];
                this.fax = (string)reader["Fax"];
                this.logo = (byte[])reader["Logo"];
                this._existe = true;
            }
        }

        public Int32 SaveData()
        {
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            if (!this.existe)
            {
                command.CommandText = "INSERT INTO \"Info_Societe\" (\"Nom\",\"Adresse\",\"Tel\",\"Fax\",\"Logo\")" +
                    "VALUES(:nom,:adresse,:tel,:fax,:logo)";
            }
            else
            {
                command.CommandText = "UPDATE \"Info_Societe\" SET \"Nom\" =:nom,\"Adresse\"=:adresse, \"Logo\"=:logo, \"Tel\"=:tel, \"Fax\"=:fax";
            }
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":nom", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":adresse", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":tel", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":fax", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":logo", DbType.Binary));
            command.Parameters[0].Value = this.nom;
            command.Parameters[1].Value = this.adresse;
            command.Parameters[2].Value = this.tel;
            command.Parameters[3].Value = this.fax;
            command.Parameters[4].Value = this.logo;
            return dataBase.ExecuteCommand(command);
        }
    }
}
