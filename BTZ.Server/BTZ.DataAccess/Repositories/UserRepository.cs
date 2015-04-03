using System;
using MEF.Core;
using System.Collections.Generic;
using System.Linq;
using log4net;
using BTZ.Common;
using BTZ.Infrastructure;

namespace BTZ.DataAccess
{
	public class UserRepository: IUserRepository
	{
		readonly Context _context;
		List<User> _localUser;
		ILog s_log = LogManager.GetLogger(typeof(UserRepository));

		public UserRepository (Context _context)
		{
			this._context = _context;
			_localUser = new List<User> ();
		}
		

		#region Get
		public List<User> GetAllUser()
		{
			if (!_localUser.Any ()) {
				UpdateUser ();
			}
			return _localUser;
		}
		#endregion

		#region Update
		public void UpdateUser(User user)
		{
			if (!_context.Update<User> (user)) {
				s_log.Error (String.Format ("Could not Update User {0}", user.Username));
				return;
			}
			UpdateUser ();
			s_log.Info (String.Format ("Updated User {0}", user.Username));

		}
		public void UpdateUsers(IList<User> users)
		{
			foreach (var user in users) {
				UpdateUser (user);
			}
		}
		#endregion

		#region Delete
		public void DeleteUser(User user)
		{
			if (!_context.Delete<User> (user)) {
				s_log.Error (String.Format ("Could not delete User {0}", user.Username));
				return;
			}
			UpdateUser ();
			s_log.Info (String.Format ("Deleted User {0}", user.Username));
		}
		public void DeleteUsers(IList<User> users)
		{
			foreach (var user in users) {
				DeleteUser (user);
			}
		}
		#endregion

		#region Insert
		public void AddUser(User user)
		{
			if (!_context.Insert<User> (user)) {
				s_log.Error (String.Format ("Could not add User {0}", user.Username));
				return;
			}
			UpdateUser ();
			s_log.Info (String.Format ("Added User {0}", user.Username));
		}
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
			_localUser = _context.GetTable<User> (typeof(User));
		}
		#endregion
	}
}

