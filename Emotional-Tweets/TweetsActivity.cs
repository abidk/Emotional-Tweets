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
using Android.Util;

namespace EmotionalTweets
{
	[Activity (Label = "Tweets")]
	public class TweetsActivity : Activity
	{
		public const string SEARCH_TEXT_KEY = "search_text_key";
		public const string TAG = "TweetsActivity";

		private TwitterSearchAPI searchApi = new DefaultTwitterSearchAPI();
		private SentimentAnalysisAPI sentimentApi = new DefaultSentimentAnalysisAPI();
		private TweetAdapter _adapter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Tweets);

			_adapter = new TweetAdapter(this, new List<TweetItem>());

			var tweetsList = FindViewById<ListView> (Resource.Id.list_tweets);
			tweetsList.Adapter = _adapter;
		}

		protected override void OnStart()
		{
			base.OnStart();

			Task task = new Task(() => { retrieveSearchResults(); });
			task.Start();
		}

		private void retrieveSearchResults()
		{
			Log.Info (TAG, "Retreiving tweets");

			string searchText = Intent.GetStringExtra (SEARCH_TEXT_KEY) ?? null;
			IList<Tweet> tweets = searchApi.search(searchText);

			// could optimise this further by using futures rather than sequential loop..
			foreach (var tweet in tweets) {
				var sentimentResult = sentimentApi.analyse(tweet.Text);

				var item = new TweetItem ();
				item.Tweet = tweet;
				item.Sentiment = sentimentResult;
				_adapter.Add(item);

				RunOnUiThread(() =>
				{
					_adapter.NotifyDataSetChanged();
				});
			}
		}
	}
}


