using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace DataAccess
{
	public class Adapter
	{
		private string db = "";

		public string Db
		{
			get { return db; }
			set { db = value; }
		}

		private string host = "";

		public string Host
		{
			get { return host; }
			set { host = value; }
		}

		private string username = "";

		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		private string password = "";

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		private int port = 0;

		public int Port
		{
			get { return port; }
			set { port = value; }
		}

		private string catalog = "";

		public string Catalog
		{
			get { return catalog; }
			set { catalog = value; }
		}

		private string connstr = "";

		public string Connstr
		{
			get { return connstr; }
			set { connstr = value; }
		}		

		public virtual DataSet GetDataSet(string sql)
		{

			return null;
		}

		public virtual DataSet GetDataSet(string sql, List<FieldAndValue> list) 
		{
			return null;
		}

		public virtual int ExcuteSQL(string sql)
		{
			return -1;
		}

		public virtual int ExcuteSQL(string sql, List<FieldAndValue> list)
		{
			return -1;
		}

		public virtual void MakeConnStr()
		{
		}

		public virtual object[] MakeParameterArray(List<FieldAndValue> list)
		{
			return null;
		}

		public virtual object ExecuteSqlScalar(string sql)
		{
			return null;
		}

        public virtual object ExecuteSqlScalar(string sql, List<FieldAndValue> list)
        {
            return null;
        }

		public virtual string PreSql(string sql)
		{
			return "";
		}

        public virtual object GetReader(string sql)
        {
            return null;
        }

        public virtual object GetReader(string sql, List<FieldAndValue> list)
        {
            return null;
        }

	}
}
