using System;
using MEF.Infrastructure;
using MEF.Core;
using System.Collections.Generic;
using System.Linq;
using log4net;
using BTZ.Common;
using BTZ.Infrastructure;
using BTZ.Data;

namespace BTZ.DataAccess
{
	/// <summary>
	/// Datenzugriff auf die Nutzer
	/// Jonas Ahlf 16.04.2015 10:27:32
	/// </summary>
	public class UserRepository: IUserRepository
	{
		List<User> _localUser;
		ILog s_log = LogManager.GetLogger(typeof(UserRepository));
		DatabaseHandler _dbHandler;
		/// <summary />
		public UserRepository ()
		{
			_dbHandler = new DatabaseHandler ();
			_localUser = new List<User> ();
		}
		

		#region Get
		/// <summary />
		public List<User> GetAllUser()
		{
			if (!_localUser.Any ()) {
				UpdateUser ();
			}
			return _localUser;
		}
		#endregion

		#region Update

		/// <summary />
		public void UpdateUser(User user)
		{
			
			if (!_dbHandler.DbContext.Update<User> (user)) {
				s_log.Error (String.Format ("Could not Update User {0}", user.Username));
				return;
			}
			UpdateUser ();
			s_log.Info (String.Format ("Updated User {0}", user.Username));

		}
		/// <summary />
		public void UpdateUsers(IList<User> users)
		{
			foreach (var user in users) {
				UpdateUser (user);
			}
		}
		#endregion

		#region Delete
		/// <summary />
		public void DeleteUser(User user)
		{
			if (!_dbHandler.DbContext.Delete<User> (user)) {
				s_log.Error (String.Format ("Could not delete User {0}", user.Username));
				return;
			}
			UpdateUser ();
			s_log.Info (String.Format ("Deleted User {0}", user.Username));
		}
		/// <summary />
		public void DeleteUsers(IList<User> users)
		{
			foreach (var user in users) {
				DeleteUser (user);
			}
		}
		#endregion

		#region Insert
		/// <summary />
		public void AddUser(User user)
		{
			s_log.Info (String.Format ("Added User {0}", user.Username));
			_dbHandler.DbContext.Insert<User> (new User (){ Username = "HalloPenis", Password = "Welt23", Token = "123" });
		}
		/// <summary />
		public void AddUsers(IList<User> users)
		{
			foreach (var user in users) {
				AddUser (user);
			}
		}
		#endregion

		#region Member
		void UpdateUser()
		{
			_localUser = _dbHandler.DbContext.GetTable<User> (typeof(User));
		}
		#endregion
	}
}

