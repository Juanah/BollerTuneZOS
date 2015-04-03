using MEF.Infrastructure;
using MEF.Core;
using System.Collections.Generic;
using BTZ.Common;


namespace BTZ.DataAccess
{
	public static class DatabaseInitializer
	{
		private static IDBConnectionInfo _connectionInfo;
		private static readonly EntityInitializer _initializer;

		static DatabaseInitializer ()
		{
			_connectionInfo  = new ConnectionInfo () {
				Databasename = "bollertunezapp",
				User = "root",
				Password = "",
				Servername = "localhost"
			};

			_initializer = new EntityInitializer (_connectionInfo);
			InitializeEntities ();
		}


		static void  InitializeEntities()
		{
			var entityList = new List<IEntity> ();
			entityList.Add (new User ());
			entityList.Add (new Binary ());
			entityList.Add (new CWallPost ());
			entityList.Add (new WallPost ());
			DbContext = _initializer.GetContext (entityList);
		}


		public static Context DbContext{ get; private set; }
	}
}

