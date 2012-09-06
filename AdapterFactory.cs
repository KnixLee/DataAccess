using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
	class AdapterFactory
	{
		public Adapter createAdapter(string db)
		{
			Adapter adapter = null;
			switch (db.ToLower())
			{
 				case "mssql":
					adapter = new MsSqlAdapter();
					break;
				case "mysql":
				default:
					adapter = new MySqlAdapter();
					break;
			}
			return adapter;
		}
		public Adapter createAdapter(string db,string Host,string Username,string Password,int Port,string Catalog)
		{
			Adapter adapter = null;
			switch (db.ToLower().Trim())
			{
 				case "mssql":
					adapter = new MsSqlAdapter(Host, Username, Password, Port, Catalog);
					break;
				case "mysql":
				default:
					adapter = new MySqlAdapter(Host, Username, Password, Port, Catalog);
					break;
			}
			return adapter;
		}
	}
}
