using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace DataAccess
{
	class MsSqlAdapter:Adapter
	{
		public MsSqlAdapter()
		{
			Db = "mssql";
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

		public MsSqlAdapter(string Host, string Username, string Password, int Port, string Catalog)
		{
			this.Host = Host;
			this.Username = Username;
			this.Password = Password;
			this.Port = Port;
			this.Catalog = Catalog;
			MakeConnStr();
		}

		public override DataSet GetDataSet(string sql)
		{
			sql = PreSql(sql);
			return SqlHelper.ExecuteDataset(this.Connstr, CommandType.Text, sql);
		}

		public override DataSet GetDataSet(string sql, List<FieldAndValue> list)
		{
			sql = PreSql(sql);
			return SqlHelper.ExecuteDataset(this.Connstr, CommandType.Text, sql, (SqlParameter[])MakeParameterArray(list));
			//return null;
		}

		public override int ExcuteSQL(string sql)
		{
			sql = PreSql(sql);
			return SqlHelper.ExecuteNonQuery(this.Connstr, CommandType.Text, sql);
		}

		public override int ExcuteSQL(string sql, List<FieldAndValue> list)
		{
			sql = PreSql(sql);
			return SqlHelper.ExecuteNonQuery(this.Connstr, CommandType.Text, sql, (SqlParameter[])MakeParameterArray(list));
			//return -1;
		}

		public override void MakeConnStr()
		{
			if (Host.IndexOf("'") > -1 || Username.IndexOf("'") > -1 || Password.IndexOf("'") > -1)
				Connstr = "";
			if (Port == 0)
				Port = 3306;
			Connstr = "Password="+this.Password+";Persist Security Info=True;User ID="+this.Username+";Initial Catalog="+this.Catalog+";Data Source="+this.Host;
		}

		public override object[] MakeParameterArray(List<FieldAndValue> list)
		{
			int count = list.Count;
			SqlParameter[] msp = new SqlParameter[count];
			int i = 0;
			foreach (FieldAndValue fv in list)
			{
				msp[i] = new SqlParameter("@" + fv.Field, fv.Value);
				i++;
			}
			return msp;
		}

		public override object ExecuteSqlScalar(string sql)
		{
			sql = PreSql(sql);
			return SqlHelper.ExecuteScalar(this.Connstr, CommandType.Text, sql);
		}
        public override object ExecuteSqlScalar(string sql, List<FieldAndValue> list)
        {
            sql = PreSql(sql);
            return SqlHelper.ExecuteScalar(this.Connstr, CommandType.Text, sql, (SqlParameter[])MakeParameterArray(list));
        }
		public override string PreSql(string sql)
		{
			if (sql.IndexOf("?") > -1)
			{
				sql = sql.Replace("?", "@");
			}
			return sql;
		}

        public override object GetReader(string sql)
        {
            //throw new Exception();
            sql = PreSql(sql);
            return SqlHelper.ExecuteReader(this.Connstr, CommandType.Text, sql);
        }
        public override object GetReader(string sql, List<FieldAndValue> list)
        {
            //throw new Exception();
            sql = PreSql(sql);
            return SqlHelper.ExecuteReader(this.Connstr, CommandType.Text, sql, (SqlParameter[])MakeParameterArray(list));
        }
	}
}
