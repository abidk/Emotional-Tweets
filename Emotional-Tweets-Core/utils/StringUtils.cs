using System;
using System.Net;
using System.Text;
using System.IO;

namespace EmotionalTweetsCore
{
	public class StringUtils
	{
		public static string GetResponseString(WebResponse response)
		{
			using (Stream stream = response.GetResponseStream())
			{
				return new StreamReader(stream, Encoding.UTF8).ReadToEnd();
			}
		}
	}
}

