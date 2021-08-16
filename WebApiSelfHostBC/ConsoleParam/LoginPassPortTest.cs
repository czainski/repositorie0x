using System;
using System.Text;

namespace WebApiSelfHostBC.ConsoleRead
{
	public static class LoginPassPortTest
	{
		public static string ReadLoginOrPassOrPort(bool pass = false, bool port = false)
		{
			if (port) pass = false;
			var result = new StringBuilder();
			while (true)
			{
				ConsoleKeyInfo key = Console.ReadKey(true);
				if (port && key.Key != ConsoleKey.Enter)
					if (!Char.IsDigit(key.KeyChar))
					{
						Console.WriteLine("\n\n\t  Port: \"{0}{1}\" is not good.  Port must been a holy numeric!", result.ToString(), key.KeyChar);
						return "null";
					}
				switch (key.Key)
				{
					case ConsoleKey.Enter:
				
						return result.ToString().Trim();
					case ConsoleKey.Backspace:
						if (result.Length == 0)
							continue;
						result.Length--;
						Console.Write("\b \b");
						continue;
					default:
						result.Append(key.KeyChar);
						if (pass)
							Console.Write("*");
						else
							Console.Write(key.KeyChar);
						continue;
				}
			}
		}
	}
}
