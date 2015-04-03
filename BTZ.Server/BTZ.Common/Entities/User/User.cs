using System;
using MEF.Infrastructure;

namespace BTZ.Common
{
	/// <summary>
	/// Stellt einen BTOS Benutzer dar
	/// Jonas Ahlf 30.03.2015 21:22:50
	/// </summary>
	public class User : BaseEntity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BTZ.DataAccess.User"/> class.
		/// </summary>
		public User ()
		{
		}

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>The username.</value>
		public string Username{ get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public string Password{ get; set; }

		/// <summary>
		/// Benutzerprofilbild
		/// </summary>
		/// <value>The avatar.</value>
		public byte[] Avatar{ get; set; }

		public string PremissionStr{ get; set; }

		/// <summary>
		/// Berechtigung
		/// </summary>
		/// <value>The premission.</value>
		[Ignore()]
		public Premission Premission{ get{ return Premission; } set{
				Premission = value;
				PremissionStr = Premission.ToString ();
			}} 
	}
}

