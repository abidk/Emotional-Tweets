using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace EmotionalTweetsCore
{
	public class DefaultSentimentAnalysisAPI : SentimentAnalysisAPI
	{
		const string SENTIMENT_URL = "https://sentimentalsentimentanalysis.p.mashape.com/sentiment/current/classify_text/";

		public SentimentResult analyse(string text) 
		{
			var request = WebRequest.Create(SENTIMENT_URL);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
			request.Headers.Add("X-Mashape-Authorization", "...");

			using (Stream stream = request.GetRequestStream())
			{
				var content = ASCIIEncoding.ASCII.GetBytes(String.Format("lang=en&text={0}", text));
				stream.Write(content, 0, content.Length);
			}

			var response = StringUtils.GetResponseString(request.GetResponse());
			return JsonConvert.DeserializeObject<SentimentResult> (response);
		}
	}
}

