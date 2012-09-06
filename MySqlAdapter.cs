using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess
{
	class MySqlAdapter: Adapter
	{
		public MySqlAdapter()
		{
			Db = "mysql";
			Host = Properties.Settings.Default.db_host;
			Username = Properties.Settings.Default.db_username;
			Password = Properties.Settings.Default.db_password;
			try
			{
				string p = Properties.Settings.Default.db_port.Trim();
				if (p != "")
					Port = int.Parse(Properties.Settings.Default.db_port);
			}
			catch
			{ }
			Catalog = Properties.Settings.Default.db_catalog;
			MakeConnStr();
		}

		public MySqlAdapter(string Host, string Username, string Password, int Port, string Catalog)
		{
			this.Host = Host;
			this.Username = Username;
			this.Password = Password;
			this.Port = Port;
			this.Catalog = Catalog;
			MakeConnStr();
		}

		public override int ExcuteSQL(string sql)
		{
			sql = PreSql(sql);
			return MySqlHelper.ExecuteNonQuery(this.Connstr, sql);
		}

		public override int ExcuteSQL(string sql, List<FieldAndValue> list)
		{
			sql = PreSql(sql);
			return MySqlHelper.ExecuteNonQuery(this.Connstr, sql, (MySqlParameter[])MakeParameterArray(list));
		}

		public override DataSet GetDataSet(string sql)
		{
			sql = PreSql(sql);
			return MySqlHelper.ExecuteDataset(this.Connstr, sql);
		}

		public override DataSet GetDataSet(string sql, List<FieldAndValue>list)
		{
			sql = PreSql(sql);
			return MySqlHelper.ExecuteDataset(this.Connstr, sql, (MySqlParameter[])MakeParameterArray(list));
		}

		public override void MakeConnStr()
		{
			if (Host.IndexOf("'") > -1 || Username.IndexOf("'") > -1 || Password.IndexOf("'") > -1)
				Connstr = "";
			if (Port == 0)
				Port = 3306;
            Connstr = "server=" + Host + ";user id=" + Username + ";database=" + Catalog + ";password=" + Password + ";pooling=yes;port=" + Port.ToString() + ";Allow Zero Datetime=true; CharSet=utf8";
		}

		public override object[] MakeParameterArray(List<FieldAndValue> list)
		{
			int count = list.Count;
			MySqlParameter[] msp = new MySqlParameter[count];
			int i = 0;
			foreach (FieldAndValue fv in list)
			{
				msp[i] = new MySqlParameter("?" + fv.Field, fv.Value);
				i++;
			}
			return msp;
		}

		public override object ExecuteSqlScalar(string sql)
		{
			sql = PreSql(sql);
			return MySqlHelper.ExecuteScalar(this.Connstr, sql);
		}

        public override object ExecuteSqlScalar(string sql, List<FieldAndValue> list)
        {
            sql = PreSql(sql);
            return MySqlHelper.ExecuteScalar(this.Connstr, sql, (MySqlParameter[])MakeParameterArray(list));
        }

		public override string PreSql(string sql)
		{
			if (sql.IndexOf("@") > -1)
			{
				sql = sql.Replace("@", "?");
			}
			return sql;
		}

        public override object GetReader(string sql)
        {
            sql = PreSql(sql);
            return MySqlHelper.ExecuteReader(this.Connstr, sql);
        }

        public override object GetReader(string sql, List<FieldAndValue> list)
        {
            sql = PreSql(sql);
            return MySqlHelper.ExecuteReader(this.Connstr, sql, (MySqlParameter[])MakeParameterArray(list));
        }

	}
}
