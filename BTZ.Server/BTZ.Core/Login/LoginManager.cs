using System;
using BTZ.Infrastructure;
using BTZ.Common;
using System.Linq;


namespace BTZ.Core
{
	public class LoginManager : ILoginManager
	{

		private readonly IUserRepository _userRepository;

		public LoginManager (IUserRepository _userRepository)
		{
			this._userRepository = _userRepository;
		}
		

		#region ILoginManager implementation

		public Tuple<string, bool> Login (LoginData loginData)
		{
			var user = _userRepository.GetAllUser ().FirstOrDefault (n => n.Username.ToLower().Equals(loginData.Username.ToLower()));

			if (user == null) {
				return new Tuple<string, bool> ("", false);
			}

			if (user.Password.Equals (loginData.Password)) {
				user.Token = Guid.NewGuid ().ToString ();
				_userRepository.UpdateUser (user);
				return new Tuple<string, bool> (user.Token, true);
			}

			return new Tuple<string, bool> ("", false);
		}

		public User VerifyToken (string token)
		{
			return _userRepository.GetAllUser().FirstOrDefault(t => t.Token.Equals(token));
		}

		public User RegisterUser (LoginData loginData)
		{
			if (_userRepository.GetAllUser ().Any (n => n.Username.ToLower ().Equals (loginData.Username.ToLower ()))) {
				return null;
			}

			User nUser = new User () {
				Username = loginData.Username,
				Password = loginData.Password,
				Token = Guid.NewGuid().ToString()
			};

			_userRepository.AddUser (nUser);

			return nUser;
		}
		#endregion
	}
}

