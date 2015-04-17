using MEF.Infrastructure;
using MEF.Core;
using System.Collections.Generic;
using BTZ.Data;


namespace BTZ.DataAccess
{
	public class DatabaseHandler
	{
		private IDBConnectionInfo _connectionInfo;
		private readonly EntityInitializer _initializer;

		public DatabaseHandler ()
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


		public void InitializeEntities()
		{
			var entityList = new List<IEntity> ();
			entityList.Add (new User ());
			entityList.Add (new Binary ());
			entityList.Add (new CWallPost ());
			entityList.Add (new WallPost ());
			var context = _initializer.GetContext (entityList);
			context.CreateDatabase ();
			context.Parse ();
			context.Create ();
			DbContext = context;
		}


		public Context DbContext{ get; private set;}
	}
}

