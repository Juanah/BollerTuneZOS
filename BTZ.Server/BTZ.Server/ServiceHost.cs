using System;
using BTZ.Infrastructure;
using BTZ.DataAccess;
using MEF.Core;
namespace BTZ.Server
{
	/// <summary>
	/// Klasse welche die Services Verwaltet
	/// Jonas Ahlf 03.04.2015 22:58:43
	/// </summary>
	public class ServiceHost
	{

		Context _context;
		LoginManager _loginManager;
		#region Repositories
		IUserRepository _userRepository;
		#endregion

		public ServiceHost ()
		{
		}

		#region Initialiation

		void InitRepos()
		{
			_context = DatabaseInitializer.DbContext;
			_userRepository = new UserRepository (_context);
			_loginManager = new LoginManager (_userRepository);
		}
		#endregion

	}
}

