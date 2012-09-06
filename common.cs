using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
	class common
	{
		public DB GetDB(string db)
		{
			DB _db = DB.mysql;
			switch (db.ToLower().Trim())
			{
 				case "mssql":
					_db = DB.mysql;
					break;
				case "mysql":
					_db = DB.mysql;
					break;
			}
			return _db;
		}
	}
	public enum DB
	{
 		mysql=1,
		mssql=2
	}
	

}
