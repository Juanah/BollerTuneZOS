using System;
using System.Runtime.Serialization;

namespace BTZ.Common
{
	[DataContract]
	public class RegisterUser
	{
		[DataMember]
		public User User{ get; set; }
	}
}

