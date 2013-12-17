using System;
using System.Net;
using Spring.Social.Twitter.Api.Impl;
using Spring.Social.Twitter.Api;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace service.EmotionalTweetsCore
{
	public class DefaultTwitterSearchAPI : TwitterSearchAPI
	{
		public IList<Tweet> search(string searchText)
		{
			string consumerKey = "..."; // The application's consumer key
			string consumerSecret = "..."; // The application's consumer secret
			string accessToken = ".."; // The access token granted after OAuth authorization
			string accessTokenSecret = "..."; // The access token secret granted after OAuth authorization
			ITwitter twitter = new TwitterTemplate(consumerKey, consumerSecret, accessToken, accessTokenSecret);

			Task<SearchResults> searchResults = twitter.SearchOperations.SearchAsync(searchText);
			SearchResults results = searchResults.Result;
			return results.Tweets;
		}
	}
}

