using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DataAccess
{
	public class DAL
	{
		public Adapter adapter = null;

		public DAL()
		{
			if (this.adapter == null)
			{
                this.adapter = new AdapterFactory().createAdapter(Properties.Settings.Default.db_type);
			}
		}
		public DAL(string db)
		{
			if (this.adapter!=null && this.adapter.Db == db)
				return;
			this.adapter = new AdapterFactory().createAdapter(db);
		}
		public DAL(string db, string Host, string Username, string Password, int port, string Catalog)
		{
			if (this.adapter!=null && this.adapter.Db == db && this.adapter.Host == Host && this.adapter.Catalog == Catalog)
			{
				return;
			}
			this.adapter = new AdapterFactory().createAdapter(db, Host, Username, Password, port, Catalog);
		}
		public DataSet GetDataSet(string sql)
		{
			return adapter.GetDataSet(sql);
		}
		public DataSet GetDataSet(string sql, List<FieldAndValue> list)
		{
            return adapter.GetDataSet(sql, list);
		    //return null;2011年2月17日9:14:54 Lwt编辑 1行
		}

		public int ExecuteSql(string sql)
		{
			return adapter.ExcuteSQL(sql);
		}

		public int ExecuteSql(string sql, List<FieldAndValue> list)
		{
			if (list.Count == 0 || list == null)
				return ExecuteSql(sql);
			return adapter.ExcuteSQL(sql, list);
		}

		public object ExecuteSqlScalar(string sql)
		{
			return adapter.ExecuteSqlScalar(sql);
		}
        public object ExecuteSqlScalar(string sql, List<FieldAndValue> list)
        {
            return adapter.ExecuteSqlScalar(sql, list);
        }

		public string GetDb()
		{
			return adapter.Db;
		}

		public string GetHost()
		{
			return adapter.Host;
		}

        public object GetReader(string sql)
        {
            return adapter.GetReader(sql);
        }
        public object GetReader(string sql, List<FieldAndValue> list)
        {
            return adapter.GetReader(sql, list);
        }
	}
}
