using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using service.EmotionalTweetsCore;
using System.Collections.Generic;
using EmotionalTweetsCore;

namespace EmotionalTweets
{
	[Activity (Label = "Tweets")]
	public class TweetsActivity : Activity
	{
		public const string SEARCH_TEXT_KEY = "search_text_key";

		private TwitterSearchAPI searchApi = new DefaultTwitterSearchAPI();

		private ListView tweetsList;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Tweets);

			string searchText = Intent.GetStringExtra (SEARCH_TEXT_KEY) ?? null;
			IList<Tweet> tweets = searchApi.search(searchText);

			IList<TweetItem> listItems = new List<TweetItem>();
			foreach(var tweet in tweets) {
				var item = new TweetItem();
				item.tweet = tweet;

				listItems.Add (item);
			}

			tweetsList = FindViewById<ListView> (Resource.Id.list_tweets);
			tweetsList.Adapter = new TweetAdapter(this, listItems);


		}


	}
}


