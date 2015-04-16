using System;
using BTZ.Communication;
using BTZ.Common;
using System.IO;
using BTZ.Infrastructure;
using Newtonsoft.Json;

namespace BTZ.Core
{
	public class AppService : IAppService
	{
		ILogInMessageProcessor _loginMessageProcessor;


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
			StreamReader streamReader = new StreamReader(input);
			string rawString = streamReader.ReadToEnd();
			streamReader.Dispose();

			if (String.IsNullOrEmpty (rawString)) {
				return new LoginResponse (){ Success= false, Token = ""};
			}

			return _loginMessageProcessor.LoginUser (rawString);
		}

		public LoginResponse RegisterUser (Stream input, string token)
		{
			StreamReader streamReader = new StreamReader(input);
			string rawString = streamReader.ReadToEnd();
			streamReader.Dispose();

			if (String.IsNullOrEmpty (rawString)) {
				return new LoginResponse (){ Success= false, Token = ""};
			}

			return _loginMessageProcessor.RegisterUser (rawString);
		}

		#endregion



	}
}

