using System;
using MEF.Infrastructure;

namespace BTZ.Common
{
	public class CWallPost : BaseEntity
	{
		public CWallPost ()
		{
		}

		[ForeignKey(typeof(User))]
		public User Owner{ get; set; }

		/// <summary>
		/// Titel des Posts
		/// </summary>
		/// <value>The title.</value>
		public string Title{ get; set; }

		/// <summary>
		/// Schrifftlicher inhalt des Posts
		/// </summary>
		/// <value>The content.</value>
		public string Content{ get; set; }

		/// <summary>
		/// PostBild
		/// </summary>
		/// <value>The image.</value>
		public string Image{ get; set; }

	}
}

