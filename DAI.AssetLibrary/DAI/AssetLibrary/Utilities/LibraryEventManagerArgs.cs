using System;

namespace DAI.AssetLibrary.Utilities
{
	public class LibraryEventManagerArgs : EventArgs
	{
		public string Message { get; set; }

		public object Parameter { get; set; }

		public LibraryEventManagerArgs(string message, object parameter = null)
		{
			Message = message;
			Parameter = parameter;
		}
	}
}
