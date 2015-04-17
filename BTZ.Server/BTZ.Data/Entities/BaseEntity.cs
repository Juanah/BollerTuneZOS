using System;
using MEF.Infrastructure;

namespace BTZ.Data
{
	/// <summary>
	/// Basisklasse aller Datenbankklassen
	/// Jonas Ahlf 30.03.2015 21:28:42
	/// </summary>
	public class BaseEntity : IEntity
	{
		/// <summary/>
		public BaseEntity ()
		{
		}

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[IDKey(true)]
		public int Id{ get; set; }

		#region IEntity implementation

		/// <summary>
		/// Deeps the copy.
		/// </summary>
		/// <returns>The copy.</returns>
		public object DeepCopy ()
		{
			return MemberwiseClone ();
		}
		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <returns>The identifier.</returns>
		public int GetId ()
		{
			return Id;
		}

		#endregion
	}
}

