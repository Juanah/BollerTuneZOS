using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using BTZ.Common;
using System.IO;

namespace BTZ.Communication
{
	/// <summary>
	/// AppService Vertrag 
	/// Jonas Ahlf 03.04.2015 22:57:04
	/// </summary>
	[ServiceContract]
	public interface IAppService
	{
		
		[OperationContract]
		[WebInvoke(
			Method = "GET",
			ResponseFormat = WebMessageFormat.Json,
			UriTemplate = "get/{requestobject}")]
		EntityMessage GetEntity(string requestobject);

		[OperationContract]
		[WebInvoke(
			Method = "POST",
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare,
			UriTemplate = "/set/{token}")]
		LoginResponse Login(Stream input,string token);

		[OperationContract]
		[WebInvoke(
			Method = "POST",
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare,
			UriTemplate = "/set/{token}")]
		LoginResponse RegisterUser(Stream input,string token);


	}
}

