using System;
using BTZ.Communication;
using BTZ.Common;
using System.IO;
namespace BTZ.Core
{
	public class AppService : IAppService
	{
		public AppService ()
		{
		}

		#region IAppService implementation

		public EntityMessage GetEntity (string requestobject)
		{
			throw new NotImplementedException ();
		}

		public LoginResponse Login (Stream input, string token)
		{
			throw new NotImplementedException ();
		}

		public LoginResponse RegisterUser (Stream input, string token)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

