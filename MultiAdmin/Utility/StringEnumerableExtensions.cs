using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiAdmin.Utility
{
	public static class StringEnumerableExtensions
	{
		public static string JoinArgs(this IEnumerable<string> args)
		{
			StringBuilder argsStringBuilder = new StringBuilder();
			foreach (string arg in args)
			{
				if (arg.IsNullOrEmpty())
					continue;

				// Escape escape characters (if not on Windows) and quotation marks
				string escapedArg = Utils.IsWindows ? arg.Replace("\"", "\\\"") : arg.Replace("\\", "\\\\").Replace("\"", "\\\"");

				// Separate with spaces
				if (!argsStringBuilder.IsEmpty())
					argsStringBuilder.Append(' ');

				// Handle spaces by surrounding with quotes
				if (escapedArg.Contains(' '))
				{
					argsStringBuilder.Append('"');
					argsStringBuilder.Append(escapedArg);
					argsStringBuilder.Append('"');
				}
				else
				{
					argsStringBuilder.Append(escapedArg);
				}
			}

			return argsStringBuilder.ToString();
		}
	}
}
