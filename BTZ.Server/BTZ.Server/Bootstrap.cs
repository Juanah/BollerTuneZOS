using System;
using TinyIoC;
using MEF.Core;
using BTZ.Infrastructure;
using BTZ.DataAccess;
using BTZ.Core;


namespace BTZ.Server
{
	public class Bootstrap
	{
		public void Register()
		{
			TinyIoCContainer.Current.Register<IUserRepository,UserRepository> ();
			TinyIoCContainer.Current.Register<ILoginManager,LoginManager> ();
			TinyIoCContainer.Current.Register<ILogInMessageProcessor,LogInMessageProcessor> ();
			TinyIoCContainer.Current.Register<IBTZHosts,BTZHosts> ();
		}
	}
}

