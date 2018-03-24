using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GP
{
    public class TB_User
    {
        #region Variables
        private string _Login;
        private string _Password;
        private string _Tel;
        private byte[] _Photo;
        private int _Role;
        private bool _Existe = false;
        public bool Existe
        {
            get { return _Existe; }
        }
        public string Login
        {
            get { return _Login; }
            set { _Login = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value;}
        }
        public byte [] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }
        public int Role
        {
            get { return _Role; }
            set { _Role = value; }
        }
        #endregion

        public TB_User()
        {
            _Existe = false;
        }


        public bool FindByKey(string Login)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"User\" WHERE \"Login\"='" + Login + "'");
            if (reader.Read())
            {
                this.Login = (string)reader["Login"];
                this.Password = (string)reader["Password"];
                this.Tel = (string)reader["Tel"];
                this.Photo = reader["Photo"] is DBNull ? null : (byte[])reader["Photo"];
                this.Role = (int)reader["Role"];
                _Existe = true;
                return true;
            }
            return false;
        }

        public Int32 SaveData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.CommandText = "INSERT INTO \"User\" (\"Login\",\"Password\",\"Tel\",\"Photo\", \"Role\")" +
                "VALUES(:nom,:password,:tel,:photo,:role)";
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":nom", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":password", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":tel", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":photo", DbType.Binary));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":role", DbType.Int16));
            command.Parameters[0].Value = this.Login;
            command.Parameters[1].Value = this.Password;
            command.Parameters[2].Value = this.Tel;
            command.Parameters[3].Value = this.Photo;
            command.Parameters[4].Value = this.Role;
            return dataBase.ExecuteCommand(command);
        }

        public Int32 UpdateData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.CommandText = "UPDATE \"User\" SET \"Password\"=:password, \"Tel\"=:tel, \"Photo\"=:photo, \"Role\"=:role WHERE \"Login\"='" + this.Login + "'";
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":nom", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":password", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":tel", DbType.String));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":photo", DbType.Binary));
            command.Parameters.Add(new Npgsql.NpgsqlParameter(":role", DbType.Int16));
            command.Parameters[0].Value = this.Login;
            command.Parameters[1].Value = this.Password;
            command.Parameters[2].Value = this.Tel;
            command.Parameters[3].Value = this.Photo;
            command.Parameters[4].Value = this.Role;
            return dataBase.ExecuteCommand(command);
        }

        public Int32 DeleteData()
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            return dataBase.ExecuteNonQuery("DELETE FROM \"User\" WHERE \"Login\"='" + this.Login + "'");
        }
    }
}
