using System;
using BTZ.Common;

namespace BTZ.Infrastructure
{
	public interface ILoginManager
	{

		Tuple<string,bool> Login(LoginData loginData);

		User VerifyToken(string token);
	}
}

