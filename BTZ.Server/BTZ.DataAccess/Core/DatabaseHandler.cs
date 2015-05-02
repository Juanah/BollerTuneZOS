using System;
using System.Linq;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using System.Data;
using BTZ.Data;


namespace BTZ.DataAccess
{
	public  class DatabaseHandler
	{
		//Server=localhost;Database=btz;Uid=root;Pwd=;
		public DatabaseHandler ()
		{
			OrmLiteConfig.DialectProvider = MySqlDialectProvider.Instance;
			//1rmRg65%
			Database = "Server = 127.0.0.1; Database = btz; Uid = appserver; Pwd = $xyz040123".OpenDbConnection ();
			Database.CreateTable<User> ();

		}

		public IDbConnection Database;

	}
}

