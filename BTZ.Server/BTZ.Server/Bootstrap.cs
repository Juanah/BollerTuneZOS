using System;
using TinyIoC;
using BTZ.Infrastructure;
using BTZ.DataAccess;
using BTZ.Core;


namespace BTZ.Server
{
	public class Bootstrap
	{
		public void Register()
		{

			TinyIoCContainer.Current.Register<DatabaseHandler> ().AsSingleton ();
			TinyIoCContainer.Current.Register<IUserRepository,UserRepository> ().AsSingleton ();
			TinyIoCContainer.Current.Register<ILoginManager,LoginManager> ().AsSingleton ();
			TinyIoCContainer.Current.Register<ILogInMessageProcessor,LogInMessageProcessor> ().AsSingleton ();
			TinyIoCContainer.Current.Register<IBTZHosts,BTZHosts> ();

			var userRepo = TinyIoCContainer.Current.Resolve<IUserRepository> ();

			userRepo.AddUser (new BTZ.Data.User (){ Username = "XMAN"});

		}
	}
}

