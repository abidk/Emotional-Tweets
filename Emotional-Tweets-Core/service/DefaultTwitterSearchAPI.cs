using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using EmotionalTweetsCore;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace service.EmotionalTweetsCore
{
	public class DefaultTwitterSearchAPI : TwitterSearchAPI
	{
		const string TWITTER_OAUTH_URL = "https://api.twitter.com/oauth2/token";
		const string TWITTER_SEARCH_URL = "https://api.twitter.com/1.1/search/tweets.json?q={0}";
		const string TWITTER_OAUTH_CONSUMER_KEY = "Ykg56zZYXlxQLjyK4DQ";
		const string TWITTER_OAUTH_CONSUMER_SECRET = "r9NIHabDzuZTYHrlYxpAjqVIzRrrStsEiY7Pry6Ec";

		private AccessToken accessToken;

		public IList<Tweet> search(string text)
		{
			if (accessToken == null) {
				accessToken = retrieveAccessToken();
			}


			String url =  String.Format (TWITTER_SEARCH_URL, WebUtility.UrlEncode(text));
			var request = WebRequest.Create(url);
			request.Headers.Add("Authorization", string.Format("{0} {1}", accessToken.token_type, accessToken.access_token));
			request.Method = "Get";

			var tweets = new List<Tweet>();
			var response = JObject.Parse(StringUtils.GetResponseString(request.GetResponse()));
			var statuses = response["statuses"];

			foreach(var item in statuses) {
				Tweet tweet = new Tweet() {
					Id = item["id"].ToString(),
					ScreenName = item["user"] ["screen_name"].ToString(),
					Text = item["text"].ToString (),
					CreatedDate = parseDateTimeStr(item["created_at"].ToString())
				};
				tweets.Add(tweet);
			}

			return tweets;
		}

		private DateTime parseDateTimeStr(string dateTime)
		{
			const string format = "ddd MMM dd HH:mm:ss zzzz yyyy";
			return DateTime.ParseExact(dateTime, format, CultureInfo.InvariantCulture);
		}

		private AccessToken retrieveAccessToken()
		{
			var authHeader = string.Format("Basic {0}", 
				Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(TWITTER_OAUTH_CONSUMER_KEY) + 
					":" + Uri.EscapeDataString((TWITTER_OAUTH_CONSUMER_SECRET)))));

			var request = WebRequest.Create(TWITTER_OAUTH_URL);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
			request.Headers.Add("Authorization", authHeader);

			using (Stream stream = request.GetRequestStream())
			{
				var content = ASCIIEncoding.ASCII.GetBytes("grant_type=client_credentials");
				stream.Write(content, 0, content.Length);
			}

			var response = StringUtils.GetResponseString(request.GetResponse());
			return JsonConvert.DeserializeObject<AccessToken>(response);
		}

	}
}

