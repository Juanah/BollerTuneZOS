using System;
using System.Runtime.Serialization;

namespace BTZ.Common
{
	[DataContract]
	public class LoginRequest
	{
		[DataMember]
		public LoginData loginData{ get; set; }
	}
}

